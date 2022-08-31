using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IUnitOfWork unitofwork;

        public RolUsuarioController(IUnitOfWork iroluser)
        {
            unitofwork = iroluser;
        }

        [HttpGet]
        public async Task<ActionResult<List<RolUsuario>>> Get()
        {
            try
            {
                return Ok(await unitofwork.RepositorioRolUsuario.GetAllAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolUsuario model)
        {
            try
            {
                await unitofwork.RepositorioRolUsuario.InsertAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            try
            {
                await unitofwork.RepositorioRolUsuario.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RolUsuario model)
        {
            try
            {
                await unitofwork.RepositorioRolUsuario.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
