using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Autenticaciones;
using Domain.Primitives;
using Domain.Usuarios;
using ErrorOr;
using MediatR;

namespace Application.Usuarios.Command
{
    internal sealed class UsuarioLoginHandler : IRequestHandler<UsuarioLogin, ErrorOr<UsuarioLogueadoResponse>>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToken _token;

        public UsuarioLoginHandler(IUsuarioRepository userRepository, IUnitOfWork unitOfWork, IToken token)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _token = token ?? throw new ArgumentNullException(nameof(token));

        }

        public async Task<ErrorOr<UsuarioLogueadoResponse>> Handle(UsuarioLogin request, CancellationToken cancellationToken)
        {
            if (await _userRepository.Login(request.Correo, request.Password) is not Usuario usuario)
            {
                return Error.NotFound("Error", "Error credenciales.");
            }

            var token = _token.CrearToken(usuario);
            return new UsuarioLogueadoResponse(token,
                                            usuario.Id,
                                            usuario.Nombre,
                                            usuario.Email
                                            );

        }
    }
}