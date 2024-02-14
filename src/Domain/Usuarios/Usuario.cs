using Domain.Comentarios;
using Domain.Primitives;
using Domain.Publicaciones;

namespace Domain.Usuarios
{
    public sealed class Usuario : AggregateRoot
    {
        public Usuario(Guid id, string nombre, string email,DateTime fechaCreacion,bool estado)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            FechaCreacion = fechaCreacion;
            Estado = estado;
        }
                
        public Usuario()
        {
             Publicaciones = new List<Publicacion>();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }     
        public byte[] PasswordHash { get ; set; } 
        public byte[] PasswordSalt {get ; set; }
        public IList<Publicacion> Publicaciones { get; set; }
    }
}