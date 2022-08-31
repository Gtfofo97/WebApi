using System.Data.SqlClient;

namespace WebApiCore.Repositorio.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioRol RepositorioRol { get; }
        IRepositorioRolUsuario RepositorioRolUsuario { get; }
    }
}
