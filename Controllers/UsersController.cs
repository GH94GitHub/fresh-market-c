using Microsoft.AspNetCore.Mvc;
using FreshMarket.Dtos;
using FreshMarket.Exceptions;
using FreshMarket.Exceptions.Postgres;
using FreshMarket.Models;
using FreshMarket.Services;

namespace FreshMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                return UserDto.valueOf(await _userService.GetUser(id));
            }
            catch (UserIdNotExistsException ex)
            {
                Console.WriteLine(ex);
                return NotFound(ex.Message);
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(User user)
        {
            try
            {
                return Ok(UserDto.valueOf(await _userService.CreateUser(user)));
            }
            catch (ModelCannotHaveIdException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
            catch (UniqueViolationException uniqueViolation)
            {
                return BadRequest(uniqueViolation.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> PutUser(int id, UserDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest();

            try
            {
                return UserDto.valueOf(await _userService.UpdateUser(userDto));
            }
            catch (UserNotExistsException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (UserIdNotExistsException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

    }
}
