using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace WebApplication1.Models
{

    [Table("user")]
    public class User
    {
        [Key]
        [Column("Id")]
        public long UserId { get; set; }

        [Required]
        [Column("user_name", TypeName = "varchar(50)")]
        public required string UserName { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(50)")]
        public required string Password { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } = [];


    }
}