using Domain.Comentarios;
using Domain.Publicaciones;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PublicacionRepository : IPublicacionRepository
    {
        private readonly ApplicationDbContext _context;
        public PublicacionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(Publicacion publicacion) => await _context.Publicaciones.AddAsync(publicacion);  

        public async Task<List<Publicacion>> GetAll() => await _context.Publicaciones.ToListAsync();

        public async Task<Publicacion?> GetByIdAsync(Guid id) => await _context.Publicaciones.SingleOrDefaultAsync(p=>p.Id==id);

        public void Delete(Publicacion publicacion) => _context.Publicaciones.Remove(publicacion);
        public void Update(Publicacion publicacion) => _context.Publicaciones.Update(publicacion);
            
        public Task<bool> ExistsAsync(Guid id) => _context.Publicaciones.AnyAsync(publicacion=>publicacion.Id==id);

        public async Task<List<Comentario>> GetByIdComentarioAsync(Guid PublicacionId){
            var respuesta = await _context.Comentarios.Where(c => c.PublicacionId == PublicacionId).ToListAsync();
            return respuesta;
        }

        public async Task<Usuario?> GetByPublicadorIdAsync(Guid id)=> await _context.Usuarios.SingleOrDefaultAsync(p=>p.Id==id);
        
    } 
}