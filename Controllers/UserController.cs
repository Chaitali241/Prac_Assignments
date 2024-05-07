using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prac_assignments.Model.Dto;
using Prac_assignments.Repository;

namespace Prac_assignments.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private ResponseDto _response;
        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                _logger.LogInformation("API to fetch users called.");
                _response.Result = await _userRepository.GetAllUsers();
                _response.IsSuccess = true;
                _response.DisplayMessage = "common.server_msg.user.listing";
                _logger.LogInformation("Users fetched Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Fetched :" + ex.Message);
                _response.DisplayMessage = "common.server_msg.error.something_went_wrong";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(500, _response);
                throw;
            }
            return _response;
        }

        [HttpGet("GetUserById")]
        public async Task<object> GetById([FromQuery] int id)
        {
            try
            {
                _logger.LogInformation("Getting User with Id:" + id + " Started.");
                _response.Result = await _userRepository.GetUserById(id);
                _response.IsSuccess = true;
                _response.DisplayMessage = "common.server_msg.user.show";
                _logger.LogInformation("User fetched Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error faced: " + ex.Message);
                _response.DisplayMessage = "common.server_msg.error.something_went_wrong";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(500, _response);
            }
            return _response;
        }
        [HttpPost("Create")]
        public async Task<object> Create(UserDto userDto)
        {
            try
            {
                _logger.LogInformation("API for user creation called.");
                _response.Result = await _userRepository.CreateUser(userDto);
                _response.IsSuccess = true;
                _response.DisplayMessage = "common.server_msg.user.create";
                _logger.LogInformation("User created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error faced: " + ex.Message);
                _response.DisplayMessage = "common.server_msg.error.something_went_wrong";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(500, _response);
                throw;
            }
            return _response;
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] UserDto userDto)
        {
            try
            {
                _logger.LogInformation("Update API for User called.");
                _response.Result = await _userRepository.UpdateUser(userDto);
                _response.IsSuccess = true;
                _response.DisplayMessage = "common.server_msg.user.update";
                _logger.LogInformation("User Updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error faced: " + ex.Message);
                _response.DisplayMessage = "common.server_msg.error.something_went_wrong";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(500, _response);
            }
            return _response;
        }
        [HttpDelete("Delete")]
        public async Task<object> Delete([FromQuery] int id)
        {
            try
            {
                _logger.LogInformation("API for Delete user called.");
                _response.Result = await _userRepository.DeleteUser(id);
                _response.IsSuccess = true;
                _response.DisplayMessage = "common.server_msg.user.delete";
                _logger.LogInformation("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Faced: " + ex.Message);
                _response.DisplayMessage = "common.server_msg.error.something_went_wrong";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(500, _response);

            }
            return _response;
        }
    }
}
