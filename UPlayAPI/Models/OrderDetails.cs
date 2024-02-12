using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UPlayAPI.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        // Foreign key property
        public int OrderId { get; set; }

        // Navigation property to represent the many-to-one relationship
        public Order? Order { get; set; }


        [Required, MinLength(3), MaxLength(100)]
        public string Service { get; set; } = string.Empty;

        [Required, MinLength(3), MaxLength(100)]
        public string Participants { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(5)")] // Adjust the size based on your needs
        public string Time { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
