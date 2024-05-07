using Prac_assignments.Model.Dto;

namespace Prac_assignments.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> CreateUser(UserDto UserDto);
        Task<UserDto> UpdateUser(UserDto UserDto);
        Task<bool> DeleteUser(int id);
    }
}
