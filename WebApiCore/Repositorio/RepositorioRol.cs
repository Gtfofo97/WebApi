using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;
using System.Data.SqlClient;
using Dapper;

namespace WebApiCore.Repositorio
{
    public class RepositorioRol : IRepositorioRol
    {
        private readonly SqlConnection db;

        public RepositorioRol(SqlConnection conn)
        {
            db = conn;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            var query = "Select * from Rol";
            var result = await db.QueryAsync<Rol>(query);
            return result;
        }

        public async Task InsertAsync(Rol rol)
        {
            var query = "Insert into Rol (NombreRol) values (@NombreRol)";
            await db.ExecuteAsync(query, rol);
        }

        public async Task DeleteAsync(long Id)
        {
            var query = "Delete from Rol where Id = @Id";
            await db.ExecuteAsync(query, new { Id });
        }

        public async Task UpdateAsync(Rol rol)
        {
            var query = "Update Rol set NombreRol = @NombreRol where Id = @Id";
            await db.ExecuteAsync(query, rol);
        }
    }
}
