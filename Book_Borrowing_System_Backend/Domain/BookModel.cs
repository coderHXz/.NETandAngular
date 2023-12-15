using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class BookModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool Is_Book_Available { get; set; }

        [ForeignKey("Lender")]
        public int Lent_By_User_Id { get; set; }

        [ForeignKey("Borrower")]
        public int? Borrowed_By_User_Id { get; set; }
    }
}