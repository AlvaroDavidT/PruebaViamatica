using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(Usuario usuario) => await _context.Usuarios.AddAsync(usuario);

        public async Task<bool> ExisteUsuario(string email) => await _context.Usuarios.AnyAsync(u => u.Email == email);


        public async Task<List<Usuario>> GetAll() => await _context.Usuarios.ToListAsync();

        public async Task<Usuario?> GetByIdAsync(Guid id) => await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);

        public async Task<Usuario> Login(string email, string password)
        {
            var usuario = await _context.Usuarios.FirstAsync(u => u.Email == email);
            if (usuario == null)
            {
                return null;
            }
            if (!VerificaPassHash(password, usuario.PasswordHash, usuario.PasswordSalt))
                return null;

            return usuario;
        }

        private bool VerificaPassHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (var i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != computeHash[i]) return false;
            }
            return true;
        }

        public async Task<Usuario> Registrar(Usuario usuario, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            createPasswordHast(password, out passwordHash, out passwordSalt);
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;
            await _context.Usuarios.AddAsync(usuario);
            return usuario;
        }

        private void createPasswordHast(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
    }
}
