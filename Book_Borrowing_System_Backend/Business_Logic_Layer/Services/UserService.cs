using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.RepoInterfaces;
using Shared.DTOs;

namespace Business_Logic_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IBookRepo _bookRepo;
        public UserService(IUserRepo userRepo, IBookRepo bookRepo)
        {
            _userRepo = userRepo;
            _bookRepo = bookRepo;   

        }
        public async Task<string> BorrowBook(int userId, int bookId )
        {   
            var userresult = await _userRepo.BorrowBook(userId);
            var bookresult = await _bookRepo.BorrowBook(bookId, userId);

            return userresult+bookresult;
        }
        public async Task<UserLentBorrowedDTO> GetUser(int id)
        {
            return await _userRepo.GetUserByID(id);
        }
        public async Task<UserDTO> GetUsernameandTokenById(int id)
        {
            return await _userRepo.GetUsernameandTokenByID(id);
        }

        public async Task<string> ReturnBook(int userId, int bookId)
        {
            var user = await _userRepo.GetUserByID(userId);
            var bookborrowerid = await _bookRepo.GetBorrowerId(bookId);
            if(bookborrowerid == null) 
            {
                throw new Exception("Book is not borrowed and is available to borrow");
            }
            if(user == null)
            {
                throw new Exception("user not found");
            }
            if(userId != bookborrowerid)
            {
                throw new Exception("You can return only books borrowed by you");
            }
            _bookRepo.SetBorrowerId(bookId);
            return "Book returned successfully";
        }
    }
}
