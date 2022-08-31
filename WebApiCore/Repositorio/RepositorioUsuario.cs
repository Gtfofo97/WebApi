using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;
using System.Data.SqlClient;
using Dapper;

namespace WebApiCore.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly SqlConnection db;
        public RepositorioUsuario(SqlConnection conn)
        {
            db = conn;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var query = "Select * from Usuario";
            var result = await db.QueryAsync<Usuario>(query);
            return result;
        }

        public async Task InsertAsync(Usuario user)
        {
            var query = "insert into Usuario (Nombre, Apellido, Email, Password) values (@Nombre, @Apellido, @Email, @Password)";
            await db.ExecuteAsync(query, user);
        }

        public async Task DeleteAsync(long Id)
        {
            var query = "Delete from Usuario where Id = @Id";
            await db.ExecuteAsync(query, new { Id });
        }

        public async Task<Usuario> GetByIdAsync(long Id)
        {
            var query = "Select * from Usuario where Id = @Id";
            var result = await db.QueryFirstOrDefaultAsync<Usuario>(query, new { Id });
            return result;
        }

        public async Task UpdateAsync(Usuario user)
        {
            var query = "Update Usuario set Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Password = @Password where Id = @Id";
            await db.ExecuteAsync(query, user);
        }
    }
}
