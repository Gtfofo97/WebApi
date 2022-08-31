using WebApiCore.Models;
using WebApiCore.Models.ViewModels;

namespace WebApiCore.Repositorio.Contracts
{
    public interface IRepositorioRolUsuario
    {
        Task DeleteAsync(long Id);
        Task<IEnumerable<vmRolUsuario>> GetAllAsync();
        Task InsertAsync(RolUsuario roluser);
        Task UpdateAsync(RolUsuario roluser);
    }
}
