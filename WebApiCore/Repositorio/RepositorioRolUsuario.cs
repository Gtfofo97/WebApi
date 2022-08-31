using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;
using System.Data.SqlClient;
using Dapper;
using WebApiCore.Models.ViewModels;

namespace WebApiCore.Repositorio
{
    public class RepositorioRolUsuario : IRepositorioRolUsuario
    {
        private readonly string connection;

        public RepositorioRolUsuario(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DBContext");
        }

        public async Task<IEnumerable<vmRolUsuario>> GetAllAsync()
        {
            using (var db = new SqlConnection(connection))
            {
                var query = @"select usuario.Nombre, usuario.Email, rol.NombreRol as Rol from RolUsuario roluser 
                            inner join Usuario usuario on roluser.IdUsuario = usuario.Id 
                            inner join Rol rol on roluser.IdRol = rol.Id";
                var result = await db.QueryAsync<vmRolUsuario>(query);
                return result;
            }
        }

        public async Task InsertAsync(RolUsuario roluser)
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Insert into RolUsuario (IdUsuario, IdRol) values (@IdUsuario, @IdRol)";
                await db.ExecuteAsync(query, roluser);
            }
        }

        public async Task DeleteAsync(long Id)
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Delete from RolUsuario where Id = @Id";
                await db.ExecuteAsync(query, new { Id });
            }
        }

        public async Task UpdateAsync(RolUsuario roluser)
        {
            using (var db = new SqlConnection(connection))
            {
                var query = "Update RolUsuario set IdUsuario = @IdUsuario, IdRol = @IdRol where Id = @Id";
                await db.ExecuteAsync(query, roluser);
            }
        }
    }
}
