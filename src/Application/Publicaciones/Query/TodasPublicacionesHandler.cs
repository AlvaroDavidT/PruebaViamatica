using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Application.Publicaciones.Common;
using Domain.Publicaciones;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Query
{
    public class TodasPublicacionesHandler: IRequestHandler<TodasPublicaciones,ErrorOr<IReadOnlyList<PublicacionResponse>>>
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public TodasPublicacionesHandler(IPublicacionRepository publicacionRepository)
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PublicacionResponse>>> Handle(TodasPublicaciones request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Domain.Publicaciones.Publicacion> publicaciones = await _publicacionRepository.GetAll();

            return publicaciones.Select(publicacion => new PublicacionResponse(publicacion.Id,
                                                                                publicacion.Titulo,
                                                                                publicacion.Contenido,
                                                                                publicacion.FechaPublicacion,
                                                                                publicacion.UsuarioId
                                                                                    )).ToList();
        }
    }
}