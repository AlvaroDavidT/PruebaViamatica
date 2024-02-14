using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Usuarios
{
    
    public record UsuarioLogueadoResponse(string Token,Guid Id,string Nombre, string Email);
        
    
}