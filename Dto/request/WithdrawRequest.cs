
namespace WebApplication1.Dto.request;
public class ActionRequest
{

    public double Amount { get; set; }
    public long BankAccountOwnerId { get; set; }

    public long? BankAccountTargetId { get; set; }
    public long UserId { get; set; }
}