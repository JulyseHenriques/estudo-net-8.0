using CadastroPets.Application.DTOs;
using MediatR;

namespace CadastroPets.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
