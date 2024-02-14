using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Comentarios;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Comentarios.Command
{
    public class CrearComentarioHandler : IRequestHandler<CrearComentario, ErrorOr<Unit>> 
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearComentarioHandler(IComentarioRepository comentarioRepository, IUnitOfWork unitOfWork)
        {
            _comentarioRepository = comentarioRepository ?? throw new ArgumentNullException(nameof(comentarioRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        }

        public async Task<ErrorOr<Unit>> Handle(CrearComentario request, CancellationToken cancellationToken)
        {
            var comentario = new Comentario(
                Guid.NewGuid(),
                request.Contenido,
                DateTime.Now,
                request.IdPublicacion
                );
            await _comentarioRepository.Add(comentario);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}