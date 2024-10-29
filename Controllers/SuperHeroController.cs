using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;
using System.ComponentModel.DataAnnotations;

// using SuperHeroAPI.Models;  This been added and made global within program.cs thus no longer  needed here.

namespace SuperHeroAPI.Controllers
{   /// <summary>
    /// Represents a RESTful API controller for managing Superheroes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private ISuperHeroService _superHeroService;
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperHeroController"/> class.
        /// </summary>
        /// <param name="superHeroService">The service responsible for Superhero operations.</param>
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        /// <summary>
        /// Get All Super Heroes.
        /// </summary>
        /// <returns> Return Customer Details</returns>
        /// <response code="200">Return SuperHeroes list successfully.</response>
        /// <response code="500">There was a problem getting super heroes list due to an internal error with an API.</response>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            //var result = _superHeroService.GetAllHeroes();
            //return Ok(result);
            return await _superHeroService.GetAllHeroes();
        }

        /// <summary>
        /// Retrieves a single Superhero by their ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero.</param>
        /// <returns>The Superhero with the specified ID.</returns>
        /// <response code="200">Returns the Superhero with the specified ID.</response>
        /// <response code="404">If the Superhero with the specified ID is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }

        /// <summary>
        /// Create Superhero given Id, name,firstname, lastname and place.
        /// </summary>
        /// <param name="hero">hero object - id, name, firstname, lastname and place required.</param>
        /// <returns></returns>
        /// <response code="200">Create SuperHero sucessfully.</response>
        /// <response code="500">There was a problem creating superhero due to an internal error with an API.</response>
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            return Ok(result);
        }

        /// <summary>
        /// Updates a Superhero with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero to update.</param>
        /// <param name="request">The updated Superhero object.</param>
        /// <returns>The updated Superhero object.</returns>
        /// <response code="200">Returns the updated Superhero object.</response>
        /// <response code="404">If the Superhero with the specified ID is not found.</response>
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }

        /// <summary>
        /// Deletes a Superhero with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero to delete.</param>
        /// <returns>The deleted Superhero object.</returns>
        /// <response code="200">Returns the deleted Superhero object.</response>
        /// <response code="404">If the Superhero with the specified ID is not found.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }


    }
}
