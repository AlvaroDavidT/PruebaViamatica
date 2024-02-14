using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Comentarios.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.API.Controllers
{
    [Route("[controller]")]
    public class ComentarioController : ApiController
    {
        private readonly ISender _mediator;

        public ComentarioController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CrearComentario([FromBody] CrearComentario command)
        {
            var crearComentarioResul = await _mediator.Send(command);
            return crearComentarioResul.Match(customer => Ok(),
                                             errors => Problem(errors));
        }
    }
}