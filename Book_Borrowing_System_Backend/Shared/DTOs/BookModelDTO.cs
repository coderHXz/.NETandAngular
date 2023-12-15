using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class BookModelDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
