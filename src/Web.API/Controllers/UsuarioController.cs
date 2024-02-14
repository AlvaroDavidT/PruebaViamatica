using Application.Usuarios.Command;
using Domain.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
   
    [Route("[controller]")]
    public class UserController : ApiController
    {

        private readonly ISender _mediator;

        public UserController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] RegistrarUsuario command)
        {
            var createUserResul = await _mediator.Send(command);
            return createUserResul.Match(customer => Ok(),
                                             errors => Problem(errors));
        }


        [HttpPost("Loguear")]
        public async Task<IActionResult> LoginUsuario([FromBody] UsuarioLogin command)
        {
            var LoginUserResul = await _mediator.Send(command);
            return LoginUserResul.Match(login => Ok(login),
                                             errors => Problem(errors));
        }
    }
}

