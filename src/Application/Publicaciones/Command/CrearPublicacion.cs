using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Command
{
    public record CrearPublicacion(string Titulo,
                              string Contenido,
                              Guid IdUsuario
                              ) : IRequest<ErrorOr<Unit>>;
}