using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRepositorioRol repositorioRol;
        public RolController (IRepositorioRol irol)
        {
            repositorioRol = irol;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            try
            {
                return Ok(await repositorioRol.GetAllAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rol model)
        {
            try
            {
                await repositorioRol.InsertAsync(model);
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
                await repositorioRol.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Rol model)
        {
            try
            {
                await repositorioRol.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
