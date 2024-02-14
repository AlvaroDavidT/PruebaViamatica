using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Comentarios;
using Domain.Usuarios;

namespace Domain.Publicaciones
{
    public interface IPublicacionRepository
    {
        Task Add(Publicacion publicacion);
        Task<Publicacion?> GetByIdAsync(Guid id);
        Task<List<Publicacion>> GetAll();
        Task<bool> ExistsAsync(Guid id);
        void Delete(Publicacion publicacion);
        void Update(Publicacion publicacion);
        Task<List<Comentario>> GetByIdComentarioAsync(Guid PublicacionId);
        Task<Usuario?> GetByPublicadorIdAsync(Guid id);
    }
}