using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModelDTO>>> GetBooks()
        {
            var books = await _homeService.GetBooks();
            return Ok(books);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<ViewBookDTO>> GetBook(int id)
        {
            try
            {
                var book = await _homeService.GetBookById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddBook([FromBody] AddBookDTO book )
        {
            try
            {
                var result = await _homeService.AddBook(book);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
