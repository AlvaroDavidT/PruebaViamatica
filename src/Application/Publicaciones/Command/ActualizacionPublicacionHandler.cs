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
    internal sealed class ActualizacionPublicacionHandler : IRequestHandler<ActualizacionPublicacion, ErrorOr<Unit>>
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ActualizacionPublicacionHandler(IPublicacionRepository publicacionRepository, IUnitOfWork unitOfWork)
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(ActualizacionPublicacion command, CancellationToken cancellationToken)
        {
            if (!await _publicacionRepository.ExistsAsync(command.Id))
            {
                return Error.NotFound("Publicacion.NoExiste", "La publicacion No existe");
            }

            Publicacion publicacion = Publicacion.ActualizarPublicacion(
                command.Id, 
                command.Titulo,
                command.Contenido,
                DateTime.Now,
                command.IdUsuario
                );

            _publicacionRepository.Update(publicacion);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
