using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeMan.RabbitMq.Entities
{
    [Table("account")]
    public class Account
    {
        [Column("user_id")]
        [Key]
        public int UserId { get; set; }
        [Column("username")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}