using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace Application.Comentarios.Command
{
   public record CrearComentario(string Contenido,
                             Guid IdPublicacion
                             ) : IRequest<ErrorOr<Unit>>;
}