using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;
using System.Data.SqlClient;
using Dapper;
namespace WebApiCore.Repositorio
{
    public class RepositorioRol : IRepositorioRol
    {
        private readonly string connection;

        public RepositorioRol(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DBContext");
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Select * from Rol";
                var result = await db.QueryAsync<Rol>(query);
                return result;
            }
        }

        public async Task InsertAsync(Rol rol)
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Insert into Rol (NombreRol) values (@NombreRol)";
                await db.ExecuteAsync(query, rol);
            }
        }

        public async Task DeleteAsync(long Id)
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Delete from Rol where Id = @Id";
                await db.ExecuteAsync(query, new { Id });
            }
        }

        public async Task UpdateAsync(Rol rol)
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Update Rol set NombreRol = @NombreRol where Id = @Id";
                await db.ExecuteAsync(query, rol);
            }
        }
    }
}
