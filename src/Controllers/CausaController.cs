using Microsoft.AspNetCore.Mvc;
using WorkingWithDapper.Entities;
using WorkingWithDapper.Services;

namespace WorkingWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausaController : ControllerBase
    {
        private readonly ICausaService _causaService;

        public CausaController(ICausaService causaService)
        {
            _causaService = causaService;
        }

        /// <summary>
        /// Returns a list of causes
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<CausaEntity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _causaService.GetCausasAsyc());
        }

        /// <summary>
        /// Returns a list of causes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CausaEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _causaService.GetCausaByIdAsync(id));
        }

        ///// <summary>
        ///// Returns a list of cause options
        ///// </summary>
        ///// <returns></returns>
        //[ProducesResponseType(typeof(IEnumerable<GetCausaOpcionViewModel>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Produces("application/json")]
        //[HttpGet("GetCauseOptions")]
        //public async Task<IActionResult> GetCauseOptions()
        //{
        //    return Ok(await _causaService.GetOpcionesCausaAsync());
        //}

        ///// <summary>
        ///// Create a cause
        ///// </summary>
        ///// <param name="model">Post request model</param>
        ///// <returns>Nothing</returns>
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Produces("application/json")]
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] PostCausaRequestModel model)
        //{
        //    await _causaService.PostCausaAsync(model);
        //    return StatusCode(StatusCodes.Status201Created);
        //}

        ///// <summary>
        ///// Edit a cause
        ///// </summary>
        ///// <param name="id">Id of the cause</param>
        ///// <param name="model">Post request model</param>
        ///// <returns>Nothing</returns>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Put(int id, [FromBody] PutCausaRequestModel model)
        //{
        //    await _causaService.PutCausaAsync(id, model);
        //    return Ok();
        //}

        /// <summary>
        /// Delete a cause
        /// </summary>
        /// <param name="id">Id of the cause</param>
        /// <returns>Nothing</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _causaService.DeleteCausaAsync(id);
            return Ok();
        }
    }
}
