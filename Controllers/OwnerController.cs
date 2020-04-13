using System.Threading.Tasks;
using findmypet.Data;
using findmypet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace findmypet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        public IDataRepository _data { get; }
        public OwnerController(IDataRepository data)
        {
            _data = data;
        }
        //GetAllStore
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _data.GetAllOwnersAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        //GetOwnerByIdAsync
        [HttpGet("{OwnerId}")]
        public async Task<IActionResult> GetOwnerByIdAsync(int OwnerId)
        {
            try
            {
                var result = await _data.GetOwnerByIdAsync(OwnerId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Owner model)
        {
            try
            {
                _data.Add(model);
                if (await _data.SaveChangesAsync())
                {
                    return Created($"/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpPut("{OwnerId}")]
        public async Task<IActionResult> Put(int OwnerId, Owner model)
        {
            try
            {
                var Owner = await _data.GetOwnerByIdAsync(OwnerId, false);
                if (Owner == null) return NotFound();

                _data.Update(model);

                if (await _data.SaveChangesAsync())
                {
                    return Created($"/OwnerDetails/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{OwnerId}")]
        public async Task<IActionResult> Delete(int OwnerId)
        {
            try
            {
                var Owner = await _data.GetOwnerByIdAsync(OwnerId, false);
                if (Owner == null) return NotFound();

                _data.Delete(Owner);
                if (await _data.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }
    }
}