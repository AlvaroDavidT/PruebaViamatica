using Application.Data;
using Domain.Comentarios;
using Domain.Primitives;
using Domain.Publicaciones;
using Domain.Usuarios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;// capture event of domain

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher=publisher ?? throw new ArgumentNullException(nameof(publisher)); 
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Comentario> Comentarios  { get; set; }
        
        public DbSet<Publicacion> Publicaciones  { get; set; }
      

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken =  new CancellationToken())
        {
            var domainEvents= ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e =>e.GetDomainEvents().Any())
                .SelectMany(e =>e.GetDomainEvents());
            var result = await base.SaveChangesAsync(cancellationToken);
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent,cancellationToken);
            }
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}