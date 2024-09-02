using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace WebApplication1.Models

{
    [Table("bank_account")]
    public class BankAccount
    {


        [Key]
        [Column("Id")]
        public long BankAccountId { get; set; }

        [Required]
        [Column("balance", TypeName = "double")]
        public double Balance { get; set; }

        [Required]
        [Column("user_id", TypeName = "bigint")]
        public long UserId { get; set; }

        public ICollection<History>? Histories { get; set; }


    }

}