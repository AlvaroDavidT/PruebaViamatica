using Domain.Autenticaciones;
using Domain.Primitives;
using Domain.Usuarios;
using ErrorOr;
using MediatR;

namespace Application.Usuarios.Command
{
    internal sealed class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuario, ErrorOr<Unit>>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToken _token;
  
        public RegistrarUsuarioHandler(IUsuarioRepository userRepository, IUnitOfWork unitOfWork,IToken token)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _token = token ?? throw new ArgumentNullException(nameof(token));

        }

        public async Task<ErrorOr<Unit>> Handle(RegistrarUsuario request, CancellationToken cancellationToken)
        {
            if (await _userRepository.ExisteUsuario(request.Correo))
            {
                return Error.NotFound("Ya Existe", "Usuario ya existe.");
            }
            

            var user = new Usuario(
                Guid.NewGuid(),
                request.Nombre,
                request.Correo,
                DateTime.Now,
                true);
            await _userRepository.Registrar(user,request.Password);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

     
