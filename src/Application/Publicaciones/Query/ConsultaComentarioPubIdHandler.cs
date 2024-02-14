using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Publicaciones.Common;
using Domain.Comentarios;
using Domain.Publicaciones;
using Domain.Usuarios;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Query
{
    public class ConsultaComPubIdHandler : IRequestHandler<ConsultaComentarioPubId, ErrorOr<ComentarioResponse>>
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public ConsultaComPubIdHandler(IPublicacionRepository publicacionRepository)
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
        }

        public async Task<ErrorOr<ComentarioResponse>> Handle(ConsultaComentarioPubId query, CancellationToken cancellationToken)
        {

            ///await _publicacionRepository.GetByIdAsync(query.Id) is not Publicacion publicacion)
            var publicacion = await _publicacionRepository.GetByIdAsync(query.Id);
            var usuario = await _publicacionRepository.GetByPublicadorIdAsync(publicacion.UsuarioId);
            List<Comentario> comentarios = await _publicacionRepository.GetByIdComentarioAsync(query.Id);


            return new ComentarioResponse
            {
                usuario = usuario
            };

        }
    }
}