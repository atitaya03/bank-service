using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace WebApplication1.Models
{
    [Table("history")]
    public class History
    {
        [Key]
        [Column("Id")]
        public long HistoryId { get; set; }

        [Required]
        [Column("action", TypeName = "varchar(50)")]
        public required string Action { get; set; }

        [Required]
        [Column("date", TypeName = "timestamp")]
        public DateTime Date { get; set; }

        [Required]
        [Column("amount", TypeName = "double")]
        public double Amount { get; set; }

        [Required]
        [Column("bank_account_owner", TypeName = "bigint")]
        public long BankAccountId { get; set; }

        [Column("bank_account_target", TypeName = "bigint")]
        public long? BankAccountTargetId { get; set; }







    }
}