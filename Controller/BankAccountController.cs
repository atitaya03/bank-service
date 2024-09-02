

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Dto.request;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace WebApplication1.Controller;

[Authorize]
[Route("api/bank-account")]
[ApiController]

public class BankAccountController : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public BankAccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{bankId}")]
    public async Task<ActionResult<BankAccount>> GetBankAccount(long bankId)
    {
        var bankAccount = await _context.BankAccount
        .Where(b => b.BankAccountId == bankId)
        .Select(b => new BankAccountDto
        {
            Balance = b.Balance,
            Id = b.BankAccountId

        }).ToArrayAsync();

        return Ok(bankAccount);

    }

    [HttpGet("{bankId}/histories")]
    public async Task<ActionResult<History>> GetHistory(long bankId)
    {

        var histories = await _context.History
        .Where(h => h.BankAccountId == bankId)
        .Select(h => new HistoryDto
        {
            Id = h.HistoryId,
            Action = h.Action,
            Amount = h.Amount,
            Date = h.Date,
            BankAccountOwnerId = h.BankAccountId,
            BankAccountTargetId = h.BankAccountTargetId,
        })
        .ToListAsync();


        return Ok(histories);
    }

    [HttpPost("withdraw")]
    public async Task<ActionResult> Withdraw([FromBody] ActionRequest request)
    {
        if (request.Amount <= 0)
        {
            return BadRequest("amount must greater than 0");
        }

        var bankAccount = await _context.BankAccount
        .FirstOrDefaultAsync(b => b.BankAccountId == request.BankAccountOwnerId && b.UserId == request.UserId);

        if (bankAccount == null)
        {
            return NotFound("Bank account not found for the specified user.");
        }

        if (bankAccount.Balance < request.Amount)
        {
            return BadRequest("Insufficient balance.");
        }

        bankAccount.Balance -= request.Amount;

        var history = new History
        {
            BankAccountId = bankAccount.BankAccountId,
            Amount = request.Amount,
            Action = "withdraw",
            Date = DateTime.Now,
            BankAccountTargetId = null
        };

        _context.History.Add(history);


        await _context.SaveChangesAsync();

        return Ok(new { Message = "Withdrawal successful." });


    }

    [HttpPost("deposit")]
    public async Task<ActionResult> Deposit([FromBody] ActionRequest request)
    {
        if (request.Amount <= 0)
        {
            return BadRequest("amount must greater than 0");
        }

        var bankAccount = await _context.BankAccount
        .FirstOrDefaultAsync(b => b.BankAccountId == request.BankAccountOwnerId && b.UserId == request.UserId);

        if (bankAccount == null)
        {
            return NotFound("Bank account not found for the specified user.");
        }


        bankAccount.Balance += request.Amount;

        var history = new History
        {
            BankAccountId = bankAccount.BankAccountId,
            Amount = request.Amount,
            Action = "deposit",
            Date = DateTime.Now,
            BankAccountTargetId = null
        };

        _context.History.Add(history);


        await _context.SaveChangesAsync();

        return Ok(new { Message = "Deposit successful." });


    }

    [HttpPost("transfer")]
    public async Task<ActionResult> Transfer([FromBody] ActionRequest request)
    {
        if (request.Amount <= 0)
        {
            return BadRequest("amount must greater than 0");
        }

        if (request.BankAccountTargetId == null)
        {
            return BadRequest("must enter target bank account");
        }

        var bankAccountOwner = await _context.BankAccount
        .FirstOrDefaultAsync(b => b.BankAccountId == request.BankAccountOwnerId && b.UserId == request.UserId);

        var bankAccountTarget = await _context.BankAccount
        .FirstOrDefaultAsync(b => b.BankAccountId == request.BankAccountTargetId);

        if (bankAccountOwner == null)
        {
            return NotFound("Bank account not found for the specified user.");
        }

        if (bankAccountTarget == null)
        {
            return NotFound("Bank account target not found");
        }

        if (bankAccountOwner.Balance < request.Amount)
        {
            return BadRequest("Insufficient balance.");
        }

        bankAccountOwner.Balance -= request.Amount;

        bankAccountTarget.Balance += request.Amount;

        var history = new History
        {
            BankAccountId = bankAccountOwner.BankAccountId,
            Amount = request.Amount,
            Action = "transfer",
            Date = DateTime.Now,
            BankAccountTargetId = bankAccountTarget.BankAccountId
        };

        _context.History.Add(history);


        await _context.SaveChangesAsync();

        return Ok(new { Message = "Transfer successful." });


    }

}