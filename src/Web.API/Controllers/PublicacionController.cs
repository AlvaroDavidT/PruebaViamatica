using Application.Publicaciones.Command;
using Application.Publicaciones.Query;
using Domain.Comentarios;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PublicacionController : ApiController
    {

        private readonly ISender _mediator;

        public PublicacionController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearPublicacion([FromBody] CrearPublicacion command)
        {
            var crearPublicacionResul = await _mediator.Send(command);
            return crearPublicacionResul.Match(customer => Ok(),
                                             errors => Problem(errors));
        }

        [HttpGet("Todas")]
        public async Task<IActionResult> TodasPublicaciones()
        {
            var publicacionesResult = await _mediator.Send(new TodasPublicaciones());

            return publicacionesResult.Match(
                Publicacion => Ok(Publicacion),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var publicacionResult = await _mediator.Send(new ConsultaPublicacionId(id));

            return publicacionResult.Match(
                publicacion => Ok(publicacion),
                errors => Problem(errors)
            );
        }


        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizacionPublicacion actualizacion)
        {
            var updateResult = await _mediator.Send(actualizacion);

            return updateResult.Match(
                publicacionId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var eliminarResult = await _mediator.Send(new EliminarPublicacion(id));

            return eliminarResult.Match(
                publicacionId => NoContent(), 
                errors => Problem(errors)
            );
        }


        [HttpGet("Comentarios/{id}")]
        public async Task<IActionResult> ConsultaComentarioPubId(Guid id)
        {
            var listaComentariosResult = await _mediator.Send(new ConsultaComentarioPubId(id));

            return listaComentariosResult.Match(
                comentario => Ok(comentario),
                errors => Problem(errors)
            );
        }


    }
}