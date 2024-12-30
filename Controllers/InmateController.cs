using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteBrookAPI.Models;
using WhiteBrookAPI.Services.InmateService;
using System.ComponentModel.DataAnnotations;

// using WhiteBrookAPI.Models;  This been added and made global within program.cs thus no longer  needed here.

namespace WhiteBrookAPI.Controllers
{   /// <summary>
    /// Represents a RESTful API controller for managing Inmates.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InmateController : ControllerBase
    {
        private IInmateService _InmateService;
        /// <summary>
        /// Initializes a new instance of the <see cref="InmateController"/> class.
        /// </summary>
        /// <param name="InmateService">The service responsible for Inmate operations.</param>
        public InmateController(IInmateService InmateService)
        {
            _InmateService = InmateService;
        }

        /// <summary>
        /// Get All Inmates.
        /// </summary>
        /// <returns> Return Customer Details</returns>
        /// <response code="200">Return Inmates list successfully.</response>
        /// <response code="500">There was a problem getting inmates list due to an internal error with an API.</response>
        [HttpGet]
        [Route("GetAllInmates")]
        public async Task<ActionResult<List<Inmate>>> GetAllInmates()
        {
            //var result = _InmateService.GetAllInmates();
            //return Ok(result);
            return await _InmateService.GetAllInmates();
        }

        /// <summary>
        /// Retrieves a single Inmate by their ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate.</param>
        /// <returns>The Inmate with the specified ID.</returns>
        /// <response code="200">Returns the Inmate with the specified ID.</response>
        /// <response code="404">If the Inmate with the specified ID is not found.</response>
        [HttpGet("GetSingleInmate/{id}")]
        public async Task<ActionResult<Inmate>> GetSingleInmate(int id)
        {
            var result = await _InmateService.GetSingleInmate(id);
            if (result is null)
                return NotFound("Inmate not found");
            return Ok(result);
        }

        /// <summary>
        /// Create Inmate given Id, name,firstname, lastname and place.
        /// </summary>
        /// <param name="inmate">inmate object - id, name, firstname, lastname and place required.</param>
        /// <returns></returns>
        /// <response code="200">Create Inmate sucessfully.</response>
        /// <response code="500">There was a problem creating Inmate due to an internal error with an API.</response>
        [HttpPost("AddInmate")]
        public async Task<ActionResult<List<Inmate>>> AddInmate([FromBody]Inmate inmate)
        {
            var result = await _InmateService.AddInmate(inmate);
            return Ok(result);
        }

        /// <summary>
        /// Updates a Inmate with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate to update.</param>
        /// <param name="request">The updated Inmate object.</param>
        /// <returns>The updated Inmate object.</returns>
        /// <response code="200">Returns the updated Inmate object.</response>
        /// <response code="404">If the Inmate with the specified ID is not found.</response>
        [HttpPut("UpdateInmate/{id}")]
        public async Task<ActionResult<Inmate>> UpdateInmate(int id, Inmate request)
        {
            var result = await _InmateService.UpdateInmate(id, request);
            if (result is null)
                return NotFound("Inmate not found");
            return Ok(result);
        }

        /// <summary>
        /// Deletes a Inmate with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate to delete.</param>
        /// <returns>The deleted Inmate object.</returns>
        /// <response code="200">Returns the deleted Inmate object.</response>
        /// <response code="404">If the Inmate with the specified ID is not found.</response>
        [HttpDelete("DeleteInmate/{id}")]
        public async Task<ActionResult<Inmate>> DeleteInmate(int id)
        {
            var result = await _InmateService.DeleteInmate(id);
            if (result is null)
                return NotFound("Inmate not found");
            return Ok(result);
        }


    }
}
