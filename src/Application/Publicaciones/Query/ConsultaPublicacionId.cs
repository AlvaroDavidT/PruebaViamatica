using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Publicaciones.Common;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Query
{
    public record ConsultaPublicacionId(Guid Id) : IRequest<ErrorOr<PublicacionResponse>>;
    
}