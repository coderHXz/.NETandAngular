using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class UserLentBorrowedDTO
    {
        public ICollection<BookDTO>? Books_Borrowed { get; set; }

        public ICollection<BookDTO>? Books_Lent { get; set; }
    }
}
