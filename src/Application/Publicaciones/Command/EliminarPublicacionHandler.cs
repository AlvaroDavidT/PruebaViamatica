using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Publicaciones.Query;
using Domain.Primitives;
using Domain.Publicaciones;
using ErrorOr;
using MediatR;

namespace Application.Publicaciones.Command
{
    internal sealed class EliminarPublicacionHandler : IRequestHandler<EliminarPublicacion, ErrorOr<Unit>>
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EliminarPublicacionHandler(IPublicacionRepository publicacionRepository, IUnitOfWork unitOfWork)
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(EliminarPublicacion command, CancellationToken cancellationToken)
        {
            if (await _publicacionRepository.GetByIdAsync(command.Id) is not Publicacion publicacion)
            {
                return Error.NotFound("Publicacion.No Encontrada", "La publicacion con ese Id no existe");
            }

            _publicacionRepository.Delete(publicacion);


            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
