using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet("{id}")]
       // [Authorize(Roles = "User")]
        public async Task<ActionResult<UserLentBorrowedDTO>> GetUserBookDetail(int id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpGet("username/{id}")]
        public async Task<ActionResult<UserDTO>> GetUsername(int id)
        {
            var userdata = await _userService.GetUsernameandTokenById(id);
            return Ok(userdata);
        }

        [HttpPost]
        public async Task<ActionResult<string>> BookBorrow(int userId, int bookId)
        {
            var result = await _userService.BorrowBook(userId, bookId);
            return Ok(new { message = result });
        }

        [HttpPut("{userId}/{bookId}")]
        public async Task<ActionResult<string>> ReturnBook(int userId, int bookId)
        {
            var result = await _userService.ReturnBook(userId, bookId);
            return Ok(new { message = result });
        }
    }
}
