using AutoMapper;
using EventManagementAPICRUD.DTO_s;
using EventManagementAPICRUD.Models;
using EventManagementAPICRUD.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPICRUD.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                User user = _mapper.Map<User>(userDTO);
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
                var createdUser = await _repository.Register(user);
                return Ok("User register Successfully");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await _repository.Login(login.Username, login.PasswordHash);
            if (user == null)
                return NotFound();

            // Generate JWT token if necessary
            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {

            return Ok("Logged out successfully.");
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //{
        //    var users = await _repository.GetUsers();
        //    return Ok(users);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById(int id)
        //{
        //    var user = await _repository.GetUserById(id);
        //    if (user == null)
        //        return NotFound();

        //    return Ok(user);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var existingUser = await _repository.GetUserById(id);
        //        if (existingUser == null)
        //            return NotFound();

        //        existingUser.Username = userDTO.Username;
        //        existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.PasswordHash);
        //        existingUser.Role = userDTO.Role;
        //        existingUser.UpdatedBy = id;
        //        existingUser.UpdatedDate = DateTime.Now;

        //        await _repository.UpdateUser(existingUser);
        //        return Ok("Data Update SuccessFully");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _repository.GetUserById(id);
        //    if (user == null)
        //        return NotFound();

        //    await _repository.DeleteUser(id);
        //    return Ok("Delete SuccessFully");
        //}
    
    }
}
