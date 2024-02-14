namespace Domain.Usuarios
{

    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(Guid id);
        Task Add(Usuario usuario);
        Task<List<Usuario>> GetAll();
         
        Task<Usuario> Registrar(Usuario usuario, string password);
        Task<Usuario> Login (string email, string password);
        Task<bool> ExisteUsuario (string email);

        
    }
}