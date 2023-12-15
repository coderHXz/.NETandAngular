using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class AddBookDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum 10 & Maximum 250 character allowed")]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Lent_By_User_Id { get; set; }
    }
}
