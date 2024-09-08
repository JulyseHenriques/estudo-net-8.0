using MediatR;

namespace CadastroPets.Application.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
