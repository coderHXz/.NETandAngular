
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserModel
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Tokens_Available { get; set; }

        public ICollection<BookModel>? Books_Borrowed { get; set; }

        public ICollection<BookModel>? Books_Lent { get; set; }
    }
}
