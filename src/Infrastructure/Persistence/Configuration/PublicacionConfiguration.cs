using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Publicaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class PublicacionConfiguration
    {
        public void Configure(EntityTypeBuilder<Publicacion> builder)
        {
            builder.ToTable("Publicacion");

            builder.HasKey(p => p.Id);
            // Is not primitive
        

            builder.Property(p => p.Titulo).HasMaxLength(50);
            builder.Property(p => p.Contenido).HasMaxLength(200);

     
        }
    }
}