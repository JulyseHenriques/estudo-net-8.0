using CadastroPets.Application.DTOs;
using MediatR;
using CadastroPets.Application.Interfaces;

namespace CadastroPets.Application.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetUserById(request.Id);
        }
    }
}
