using System.ComponentModel.DataAnnotations.Schema;

namespace UPlayAPI.Models
{
    public class UserBudget
    {
        public int Id { get; set; }

        public int Budget { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
