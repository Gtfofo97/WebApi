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
        private readonly IRepositorioUsuario repositorioUsuario;
        public UsuarioController (IRepositorioUsuario iuser)
        {
            repositorioUsuario = iuser;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                return Ok(await repositorioUsuario.GetAllAsync());

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
                await repositorioUsuario.InsertAsync(model);
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
                await repositorioUsuario.DeleteAsync(Id);
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
                var usuario = await repositorioUsuario.GetByIdAsync(Id);
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
                var existUsuario = await repositorioUsuario.GetByIdAsync(model.Id);
                if (existUsuario == null)
                    return NotFound();
                await repositorioUsuario.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
