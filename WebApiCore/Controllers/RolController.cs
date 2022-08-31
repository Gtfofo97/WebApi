using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;
using WebApiCore.Repositorio.Contracts;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork unitofwork;
        public RolController (IUnitOfWork irol)
        {
            unitofwork = irol;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            try
            {
                return Ok(await unitofwork.RepositorioRol.GetAllAsync());
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
                await unitofwork.RepositorioRol.InsertAsync(model);
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
                await unitofwork.RepositorioRol.DeleteAsync(Id);
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
                await unitofwork.RepositorioRol.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
