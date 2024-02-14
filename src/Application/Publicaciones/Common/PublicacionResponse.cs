using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Publicaciones.Common
{
    public record PublicacionResponse(Guid Id,
                                      string Titulo,
                                      string Contenido,
                                      DateTime FechaPublicacion,
                                      Guid UsuarioId);

}

