using CadastroPets.Application.DTOs;

namespace CadastroPets.Application.Interfaces
{
    public interface IUserService
    {
        UserDto GetUserById(int id);
        Task<int> CreateUserAsync(UserDto userDto);
    }
}
