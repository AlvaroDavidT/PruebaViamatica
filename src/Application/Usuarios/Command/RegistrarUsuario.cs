using ErrorOr;
using MediatR;

namespace Application.Usuarios.Command
{
    public record RegistrarUsuario(
        string Correo,
        string Password,
        string Nombre

        ) : IRequest<ErrorOr<Unit>>;
}