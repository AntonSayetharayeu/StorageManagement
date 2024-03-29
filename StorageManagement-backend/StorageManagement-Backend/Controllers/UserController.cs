﻿using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace StorageManagement.Controllers
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

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpGet("users/{roleID:int}")]
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(int roleID)
        {
            return await _userService.GetUsersByRoleAsync(roleID);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email, [FromBody] string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required");
            }

            var user = await _userService.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new { id = user.ID, email = user.Email });
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.AddNewUserAsync(user);
            return CreatedAtRoute("GetUser", new {id = user.ID}, user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
        {
            if (id != user.ID)
            {
                return BadRequest("User ID in request body doesn't match route ID");
            }

            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserByIdAsync(int id)
        {
            await _userService.DeleteUserByIdAsync(id);
            return NoContent();
        }
    }
}
