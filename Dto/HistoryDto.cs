
namespace WebApplication1.Dto;
public class HistoryDto
{
    public long Id { get; set; }
    public required string Action { get; set; }

    public required DateTime Date { get; set; }

    public required double Amount { get; set; }

    public long? BankAccountTargetId { get; set; }

    public required long BankAccountOwnerId { get; set; }


}