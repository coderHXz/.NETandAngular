using Domain;
using Shared.DTOs;

namespace Data_Access_Layer.RepoInterfaces
{
    public interface IBookRepo
    {
        Task<IEnumerable<BookModelDTO>> GetBooks();
        Task<ViewBookDTO?> GetBookById(int id);
        Task<string> BorrowBook(int bookId, int userId);
        Task<string> AddBook(AddBookDTO book);

        Task<int?> GetBorrowerId(int bookId);
        void SetBorrowerId(int bookId);
    }
}
