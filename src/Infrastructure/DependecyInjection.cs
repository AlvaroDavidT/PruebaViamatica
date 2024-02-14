using Application.Data;
using Domain.Autenticaciones;
using Domain.Comentarios;
using Domain.Primitives;
using Domain.Publicaciones;
using Domain.Usuarios;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Dbb
            services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("DataBase")));
          
            //Application.Data
            services.AddScoped<IApplicationDbContext>(sp => 
                sp.GetRequiredService<ApplicationDbContext>());

            //Domain. Primitives
            services.AddScoped<IUnitOfWork>(sp => 
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddScoped<IPublicacionRepository, PublicacionRepository>();


            services.AddScoped<IComentarioRepository, ComentarioRepository>();


            services.AddScoped<IToken, TokenRepository>();


            return services;
        }
    }
}