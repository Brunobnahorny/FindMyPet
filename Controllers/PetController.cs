
using System.Threading.Tasks;
using FindMyPet.Data;
using FindMyPet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        public IDataRepository _data { get; }
        public PetController(IDataRepository data)
        {
            _data = data;
        }
        //GetAllStore
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _data.GetAllPetsAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        //GetPetByIdAsync
        [HttpGet("{PetId}")]
        public async Task<IActionResult> GetPetByIdAsync(int PetId)
        {
            try
            {
                var result = await _data.GetPetByIdAsync(PetId);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pet model)
        {
            try
            {
                _data.Add(model);
                if (await _data.SaveChangesAsync())
                {
                    return Created($"/{model.PetId}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpPut("{PetId}")]
        public async Task<IActionResult> Put(int PetId, Pet model)
        {
            try
            {
                var Pet = await _data.GetPetByIdAsync(PetId);
                if (Pet == null) return NotFound();

                _data.Update(model);

                if (await _data.SaveChangesAsync())
                {
                    return Created($"/PetDetails/{model.PetId}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{PetId}")]
        public async Task<IActionResult> Delete(int PetId)
        {
            try
            {
                var Pet = await _data.GetPetByIdAsync(PetId);
                if (Pet == null) return NotFound();

                _data.Delete(Pet);
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