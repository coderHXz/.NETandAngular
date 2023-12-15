using Data_Access_Layer.Data;
using Data_Access_Layer.RepoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace Data_Access_Layer.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDBContext _context;

        public UserRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task<string> BorrowBook(int id)
        {
            var userborrow = await _context.Users.FindAsync(id);

            if (userborrow != null)
            {
                if (userborrow.Tokens_Available> 0)
                {
                    userborrow.Tokens_Available--;
                    await _context.SaveChangesAsync();
                    return "User borrowed successfully.";
                }
                else
                {
                    return "No tokens available for borrowing this book.";
                }
            }
            else
            {
                return "User not found.";
            }
        }

        public async Task<UserLentBorrowedDTO> GetUserByID(int id)
        {
            return await _context.Users.Where(u => u.UserId == id).Select(u => new UserLentBorrowedDTO
            {
                Books_Borrowed = u.Books_Borrowed.Select(b => new BookDTO
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToList(),
                Books_Lent = u.Books_Lent.Select(b => new BookDTO
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToList()
            }).FirstOrDefaultAsync();
        }

        public Task<UserModel> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            return Task.FromResult(user);
        }

        public async Task<UserDTO> GetUsernameandTokenByID(int id)
        {
            return await _context.Users.Where(u => u.UserId == id).Select(u => new UserDTO
            {
                Name = u.Name,
                Tokens = u.Tokens_Available
            }).FirstOrDefaultAsync();
        }


    }
}
