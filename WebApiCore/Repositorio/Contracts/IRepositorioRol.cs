using WebApiCore.Models;

namespace WebApiCore.Repositorio.Contracts
{
    public interface IRepositorioRol
    {
        Task DeleteAsync(long Id);
        Task<IEnumerable<Rol>> GetAllAsync();
        Task InsertAsync(Rol rol);
        Task UpdateAsync(Rol rol);
    }
}
