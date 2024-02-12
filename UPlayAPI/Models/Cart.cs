using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPlayAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Service { get; set; } = string.Empty;

        [Required, MinLength(3), MaxLength(100)]
        public string Participants { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Time { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        // Foreign key property
        public int UserId { get; set; }

        // Navigation property to represent the one-to-many relationship
        public User? User { get; set; }
    }
}
