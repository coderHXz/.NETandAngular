using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.RepoInterfaces;
using Domain;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class HomeService : IHomeService
    {
        private readonly IBookRepo _bookRepo;
        public HomeService(IBookRepo bookRepo) 
        {
            _bookRepo = bookRepo;
        }

        public async Task<string> AddBook(AddBookDTO book)
        {
            return await _bookRepo.AddBook(book);
        }

        public async Task<ViewBookDTO> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookById(id);

            if (book == null)
            {
                throw new InvalidOperationException("Enter Valid Id");
            }
            return book;
        }

        public async Task<IEnumerable<BookModelDTO>> GetBooks()
        {
            return await _bookRepo.GetBooks();
        }


    }
}
