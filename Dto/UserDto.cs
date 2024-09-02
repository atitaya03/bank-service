namespace WebApplication1.Dto;

public class UserDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required List<BankAccountDto> BankAccounts { get; set; }
}