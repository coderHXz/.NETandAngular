using Domain;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IUserService
    {
        Task<UserLentBorrowedDTO> GetUser(int id);
        Task<UserDTO> GetUsernameandTokenById(int id);

        Task<string> BorrowBook(int userId, int bookId);

        Task<string> ReturnBook(int userId, int bookId);
    }
}
