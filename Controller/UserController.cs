using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication1.Controller;

[Authorize]
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration; // To access JWT settings from appsettings.json

    public UsersController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var bankAccountList = await _context.BankAccount
        .Where(b => b.UserId == id)
        .Select(b => new BankAccountDto
        {
            Id = b.BankAccountId,
            Balance = b.Balance,
        })
        .ToListAsync();

        var userDto = new UserDto
        {
            Id = user.UserId,
            Name = user.UserName,
            BankAccounts = bankAccountList
        };
        return Ok(userDto);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register(UserLoginDto userRegisterDto)
    {
        if (await _context.User.AnyAsync(u => u.UserName == userRegisterDto.username))
        {
            return BadRequest("Username is already taken.");
        }


        var user = new User
        {
            UserName = userRegisterDto.username,
            Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.password)
        };

        _context.User.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Registration successful.");
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login(UserLoginDto userLoginDto)
    {
        var user = await _context.User.SingleOrDefaultAsync(u => u.UserName == userLoginDto.username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.password, user.Password))
        {
            return Unauthorized("Invalid username or password.");
        }
        var token = GenerateJwtToken(user);

        return Ok(new { Id = user.UserId, username = user.UserName, Token = token });
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}