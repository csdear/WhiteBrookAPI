using System.Diagnostics.Contracts;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    /// <summary>
    /// Provides operations for managing Superheroes.
    /// </summary>
   #pragma warning disable CS1998
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero> {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Ironman",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu"
            },
        };
        /// <summary>
        /// Adds a new Superhero.
        /// </summary>
        /// <param name="hero">The Superhero object to add.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes after the addition.</returns>
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            // Add the Superhero to the list.
            superHeroes.Add(hero);
            return superHeroes;
        }

        /// <summary>
        /// Deletes a Superhero with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero to delete.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes after the deletion, or null if the Superhero was not found.</returns>
        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            // Find the Superhero with the specified ID.
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            // Remove the Superhero from the list.
            superHeroes.Remove(hero);

            return superHeroes;
        }

        /// <summary>
        /// Retrieves all Superheroes.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes.</returns>
        public async Task<List<SuperHero>> GetAllHeroes()
        {
            // Return all Superheroes.
            return superHeroes;
        }

        /// <summary>
        /// Retrieves a single Superhero by their ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero.</param>
        /// <returns>A task that represents the asynchronous operation and contains the Superhero with the specified ID, or null if not found.</returns>
        public async Task<SuperHero?> GetSingleHero(int id)
        {
            // Find the Superhero with the specified ID.
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;
            return hero;
        }

        /// <summary>
        /// Updates a Superhero with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Superhero to update.</param>
        /// <param name="request">The updated Superhero object.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Superheroes after the update, or null if the Superhero was not found.</returns>
        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            // Find the Superhero to be updated by ID.
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            // Update the Superhero with new data from the request.
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            // Return all Superheroes.
            return superHeroes;
        }

    }
}