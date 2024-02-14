using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Primitives;

namespace Domain.Comentarios
{
    public sealed class Comentario: AggregateRoot
    {
        public Comentario(Guid id, string contenido, DateTime fechaComentario,Guid publicacionId)
        {
            Id = id;
            Contenido = contenido;
            FechaComentario = fechaComentario;
            PublicacionId = publicacionId;
        }

        public Guid Id { get; set; }
        public string Contenido { get; set; }  
        public DateTime FechaComentario { get; set; }
        public Guid PublicacionId { get; set; }
        
    }
}

        