using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prac_assignments.Model;
using Prac_assignments.Model.Dto;
using Prac_assignments.TenantDbContext;

namespace Prac_assignments.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly TenantDBContext _dbContext;
        public UserRepository(IMapper mapper, TenantDBContext dBContext)
        {
            _mapper = mapper;
            _dbContext = dBContext;
        }
        public async Task<UserDto> CreateUser(UserDto UserDto)
        {
            var user = _mapper.Map<UserProfile>(UserDto);
            _dbContext.UserProfile.Add(user);
            await _dbContext.SaveChangesAsync();
            var newUser = _mapper.Map<UserDto>(user);
            return newUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("User Id is null or not assign value");
            }
            try
            {
                var existingUser = _dbContext.UserProfile.FirstOrDefault(x => x.Id == id);
                _dbContext.UserProfile.Remove(existingUser);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _dbContext.UserProfile.ToListAsync();
            var userDtos =  _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var currentUser = await _dbContext.UserProfile.Where(u => u.Id == id)
                 .FirstOrDefaultAsync();
            var userDto = _mapper.Map<UserDto>(currentUser);
            return userDto;
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(UserDto));
            var existingUser = await _dbContext.UserProfile.FindAsync(userDto.Id);
            var updatedUser = _mapper.Map<UserProfile>(userDto);
            _dbContext.UserProfile.Update(updatedUser);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
