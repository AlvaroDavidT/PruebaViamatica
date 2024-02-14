using Domain.Comentarios;
using Domain.Primitives;

namespace Domain.Publicaciones
{
    public sealed class Publicacion : AggregateRoot
    {
        public Publicacion(Guid id, string titulo, string contenido, DateTime fechaPublicacion, Guid usuarioId)
        {
            Id = id;
            Titulo = titulo;
            Contenido = contenido;
            FechaPublicacion = fechaPublicacion;
            UsuarioId = usuarioId;

        }
        public Publicacion()
        {
            Comentarios = new List<Comentario>();
        }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid UsuarioId { get; set; }
        public IList<Comentario> Comentarios { get; set; }

        public static Publicacion ActualizarPublicacion(Guid Id, string titulo, string contenido, DateTime fechaPublicacion, Guid usuarioId)
        {
            return new Publicacion(Id,titulo, contenido, fechaPublicacion, usuarioId);
        }
    }
}
