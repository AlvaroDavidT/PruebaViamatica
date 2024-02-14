using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Comentarios
{
    public interface IComentarioRepository
    {
        Task Add(Comentario comentario);
        Task<Comentario?> GetByIdAsync(Guid id);
        Task<List<Comentario>> GetAll();
    }
}