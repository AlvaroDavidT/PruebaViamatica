using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Comentarios;
using Domain.Publicaciones;
using Domain.Usuarios;

namespace Application.Publicaciones.Common
{

    public class ComentarioResponse     
    {
        public Usuario usuario { get; set; }       
    }
}