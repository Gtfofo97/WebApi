using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;
using System.Data.SqlClient;
using Dapper;
using WebApiCore.Models.ViewModels;

namespace WebApiCore.Repositorio
{
    public class RepositorioRolUsuario : IRepositorioRolUsuario
    {
        private readonly SqlConnection db;

        public RepositorioRolUsuario(SqlConnection conn)
        {
            db = conn;
        }

        public async Task<IEnumerable<vmRolUsuario>> GetAllAsync()
        {
            var query = @"select usuario.Nombre, usuario.Email, rol.NombreRol as Rol from RolUsuario roluser 
                            inner join Usuario usuario on roluser.IdUsuario = usuario.Id 
                            inner join Rol rol on roluser.IdRol = rol.Id";
            var result = await db.QueryAsync<vmRolUsuario>(query);
            return result;
        }

        public async Task InsertAsync(RolUsuario roluser)
        {
            var query = "Insert into RolUsuario (IdUsuario, IdRol) values (@IdUsuario, @IdRol)";
            await db.ExecuteAsync(query, roluser);
        }

        public async Task DeleteAsync(long Id)
        {
            var query = "Delete from RolUsuario where Id = @Id";
            await db.ExecuteAsync(query, new { Id });
        }

        public async Task UpdateAsync(RolUsuario roluser)
        {
            var query = "Update RolUsuario set IdUsuario = @IdUsuario, IdRol = @IdRol where Id = @Id";
            await db.ExecuteAsync(query, roluser);
        }
    }
}
