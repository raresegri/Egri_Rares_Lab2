using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egri_Rares_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Titlul cartii este obligatoriu.")]
        [Display(Name = "Book Title")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Titlul cartii trebuie sa aiba intre 3 si 150 caractere.")]
        public String title { get; set; }
        public int? AuthorsID { get; set; }
        public Authors? Authors { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; } 
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<Borrowing>? Borrowings { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
