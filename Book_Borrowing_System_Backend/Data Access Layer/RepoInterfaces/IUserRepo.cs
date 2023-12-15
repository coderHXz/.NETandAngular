using Domain;
using Shared.DTOs;

namespace Data_Access_Layer.RepoInterfaces
{
    public interface IUserRepo
    {
        Task<UserModel> GetUserByUsernameAndPassword(string username, string password);
        Task<UserLentBorrowedDTO> GetUserByID(int id);
        Task<UserDTO> GetUsernameandTokenByID(int id);

        Task<string> BorrowBook(int id);
    }
}
