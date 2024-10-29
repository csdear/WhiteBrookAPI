using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    /// <summary>
    /// Represents a service for managing Superheroes.
    /// </summary>
    public interface ISuperHeroService
    {
        /// <summary>
        /// Retrieves all Superheroes.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes.</returns>
        Task<List<SuperHero>> GetAllHeroes();

        /// <summary>
        /// Retrieves a single Superhero by their ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero.</param>
        /// <returns>A task that represents the asynchronous operation and contains the Superhero with the specified ID, or null if not found.</returns>
        Task<SuperHero?> GetSingleHero(int id);

        /// <summary>
        /// Adds a new Superhero.
        /// </summary>
        /// <param name="hero">The Superhero object to add.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes after the addition.</returns>
        Task<List<SuperHero>> AddHero(SuperHero hero);

        /// <summary>
        /// Updates a Superhero with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero to update.</param>
        /// <param name="request">The updated Superhero object.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes after the update, or null if the Superhero was not found.</returns>
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero request);

        /// <summary>
        /// Deletes a Superhero with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero to delete.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes after the deletion, or null if the Superhero was not found.</returns>
        Task<List<SuperHero>?> DeleteHero(int id);

    }
}
