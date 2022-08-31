using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork unitofwork;
        public UsuarioController (IUnitOfWork iuser)
        {
            unitofwork = iuser;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                return Ok(await unitofwork.RepositorioUsuario.GetAllAsync());

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario model)
        {
            try
            {
                await unitofwork.RepositorioUsuario.InsertAsync(model);
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
                await unitofwork.RepositorioUsuario.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(long Id)
        {
            try
            {
                var usuario = await unitofwork.RepositorioUsuario.GetByIdAsync(Id);
                if (usuario == null)
                    return NotFound();
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Usuario model)
        {
            try
            {
                var existUsuario = await unitofwork.RepositorioUsuario.GetByIdAsync(model.Id);
                if (existUsuario == null)
                    return NotFound();
                await unitofwork.RepositorioUsuario.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
