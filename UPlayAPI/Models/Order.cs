using System.ComponentModel.DataAnnotations.Schema;

namespace UPlayAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        // Foreign key property
        public int UserId { get; set; }

        // Navigation property to represent the one-to-many relationship
        public User? User { get; set; }

        public List<OrderDetails>? OrderDetails { get; set; }
    }
}
