using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace Application.Usuarios.Command
{
    public record UsuarioLogin(
        string Correo,
        string Password
    ) : IRequest<ErrorOr<UsuarioLogueadoResponse>>;
}