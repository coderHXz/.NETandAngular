using Data_Access_Layer.Data;
using Data_Access_Layer.RepoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace Data_Access_Layer.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDBContext _context;

        public BookRepo(AppDBContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<BookModelDTO>> GetBooks()
        {
            return await _context.Books.Select(book => new BookModelDTO
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Genre = book.Genre,
            }).ToListAsync();
        }


        public async Task<int?> GetBorrowerId(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            return book.Borrowed_By_User_Id;
        }

        public async Task<ViewBookDTO?> GetBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            var lentByUserName = await _context.Users
                .Where(u => u.UserId == book.Lent_By_User_Id)
                .Select(u => u.Name)
                .FirstOrDefaultAsync();

            var borrowedByUserName = await _context.Users
                .Where(u => u.UserId == book.Borrowed_By_User_Id)
                .Select(u => u.Name)
                .FirstOrDefaultAsync();

            var bookDTO = new ViewBookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Genre = book.Genre,
                Description = book.Description,
                Rating = book.Rating,
                Is_Book_Available = book.Is_Book_Available,
                Lender = lentByUserName,
            };

            return bookDTO;
        }

        public async Task<string> AddBook(AddBookDTO book)
        {

            var newBook = new BookModel
            {
                        Name = book.Name,
                        Rating = book.Rating,
                        Author = book.Author,
                        Genre = book.Genre,
                        Description = book.Description,
                        Is_Book_Available = true,
                        Lent_By_User_Id = book.Lent_By_User_Id,
                        Borrowed_By_User_Id = null
            };
            _context.Books.Add(newBook);

            try
            {
                await _context.SaveChangesAsync();
                return "Book added successfully!";
            }
            catch (Exception ex)
            {
                return $"Error adding the book: {ex.Message}";
            }
        }

        public async Task<string> BorrowBook(int bookid, int userId)
        {
            var book = await _context.Books.FindAsync(bookid);
            
            if (book != null)
            {
                book.Borrowed_By_User_Id = userId;
                book.Is_Book_Available = false;

                int lentuserId = book.Lent_By_User_Id;
                var user = await _context.Users.FindAsync(lentuserId);
                if (user != null)
                {
                    user.Tokens_Available++;
                }
                else
                {
                    return "Lent User Not Found";
                }
                await _context.SaveChangesAsync();
                return "Book Table updated succesfully Borrowed Book";
            }
            else
            {
                return "Book not found.";
            }
        }

        public async void SetBorrowerId(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            book.Borrowed_By_User_Id = null;
            book.Is_Book_Available = true;
            _context.SaveChanges();
        }
    }
}
