using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Command
{
    public record EliminarPublicacion(Guid Id) : IRequest<ErrorOr<Unit>>;
}