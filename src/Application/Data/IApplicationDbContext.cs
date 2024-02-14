using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Usuario> Usuarios {get;set;}

        Task<int> SaveChangesAsync(CancellationToken cancellationToken= default);
    }
}