using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Comentarios;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ComentarioRepository :IComentarioRepository
    {
        
        private readonly ApplicationDbContext _context;
        public ComentarioRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(Comentario comentario) => await _context.Comentarios.AddAsync(comentario);
        
        public async Task<List<Comentario>> GetAll() => await _context.Comentarios.ToListAsync();

        public async Task<Comentario?> GetByIdAsync(Guid id) => await _context.Comentarios.SingleOrDefaultAsync(u=>u.Id==id);
    }
}