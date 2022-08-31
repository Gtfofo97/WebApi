using System.Data.SqlClient;
using WebApiCore.Repositorio;
using WebApiCore.Repositorio.Contracts;

namespace WebApiCore.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private SqlConnection sqlConnection;

        public UnitOfWork(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("DBContext"));
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }

        public IRepositorioUsuario repositorioUsuario;
        public IRepositorioUsuario RepositorioUsuario => repositorioUsuario ??= new RepositorioUsuario(sqlConnection);
        public IRepositorioRol repositorioRol;
        public IRepositorioRol RepositorioRol => repositorioRol ??= new RepositorioRol(sqlConnection);

        public IRepositorioRolUsuario repositorioRolUsuario;
        public IRepositorioRolUsuario RepositorioRolUsuario => repositorioRolUsuario ??= new RepositorioRolUsuario(sqlConnection);
    }
}
