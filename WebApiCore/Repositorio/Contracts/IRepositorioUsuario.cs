using WebApiCore.Models;

namespace WebApiCore.Repositorio.Contracts
{
    public interface IRepositorioUsuario
    {
        Task DeleteAsync(long Id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(long Id);
        Task InsertAsync(Usuario user);
        Task UpdateAsync(Usuario user);
    }
}
