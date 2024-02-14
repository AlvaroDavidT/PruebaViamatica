using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Usuarios;

namespace Domain.Autenticaciones
{
    public interface IToken
    {
        string CrearToken(Usuario usuario);
    }
}