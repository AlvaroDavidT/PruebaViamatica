using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Primitives;
using Domain.Publicaciones;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Command
{
    public class CrearPublicacionHandler : IRequestHandler<CrearPublicacion, ErrorOr<Unit>>
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPublicacionHandler(IPublicacionRepository publicacionRepository, IUnitOfWork unitOfWork)
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        }

        public async Task<ErrorOr<Unit>> Handle(CrearPublicacion request, CancellationToken cancellationToken)
        {
            var publicacion = new Publicacion(
                Guid.NewGuid(),
                request.Titulo,
                request.Contenido,
                DateTime.Now,
                request.IdUsuario          
                );
            await _publicacionRepository.Add(publicacion);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}