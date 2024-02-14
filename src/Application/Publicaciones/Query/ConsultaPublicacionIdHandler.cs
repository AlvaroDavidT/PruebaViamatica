using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Publicaciones.Common;
using Domain.Publicaciones;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Query
{
    internal sealed class ConsultaPublicacionIdHandler : IRequestHandler<ConsultaPublicacionId,ErrorOr<PublicacionResponse>>
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public ConsultaPublicacionIdHandler(IPublicacionRepository publicacionRepository)
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
        }

        public async Task<ErrorOr<PublicacionResponse>> Handle(ConsultaPublicacionId query, CancellationToken cancellationToken)
        {
            if (await _publicacionRepository.GetByIdAsync(query.Id) is not Publicacion publicacion)
            {
                return Error.NotFound("Publicacion.NoExiste", "La publicacion con el Id no existe.");
            }

            return new PublicacionResponse(publicacion.Id,
                                            publicacion.Titulo,
                                            publicacion.Contenido,
                                            publicacion.FechaPublicacion,
                                            publicacion.UsuarioId);
        }
    }
}


