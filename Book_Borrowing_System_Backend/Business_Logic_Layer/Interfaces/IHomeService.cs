using Domain;
using Shared.DTOs;

namespace Business_Logic_Layer.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<BookModelDTO>> GetBooks();
        Task<ViewBookDTO> GetBookById(int id);

        Task<string> AddBook(AddBookDTO book);
    }
}
