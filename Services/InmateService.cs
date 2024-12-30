using System.Diagnostics.Contracts;
using WhiteBrookAPI.Models;

namespace WhiteBrookAPI.Services.InmateService
{
    /// <summary>
    /// Provides operations for managing Inmates.
    /// </summary>
   #pragma warning disable CS1998
    public class InmateService : IInmateService
    {
        private static List<Inmate> Inmates = new List<Inmate> {
            new Inmate
            {
                Id = 1,
                Name = "Scarface",
                FirstName = "Al",
                LastName = "Capone",
                Place = "New York City"
            },
            new Inmate
            {
                Id = 2,
                Name = "Machine Gun",
                FirstName = "George",
                LastName = "Kelly",
                Place = "Chicago"
            },
        };
        /// <summary>
        /// Adds a new Inmate.
        /// </summary>
        /// <param name="inmate">The Inmate object to add.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates after the addition.</returns>
        public async Task<List<Inmate>> AddInmate(Inmate inmate)
        {
            // Add the Inmate to the list.
            Inmates.Add(inmate);
            return Inmates;
        }

        /// <summary>
        /// Deletes a Inmate with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate to delete.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates after the deletion, or null if the Inmate was not found.</returns>
        public async Task<List<Inmate>?> DeleteInmate(int id)
        {
            // Find the Inmate with the specified ID.
            var inmate = Inmates.Find(x => x.Id == id);
            if (inmate is null)
                return null;

            // Remove the Inmate from the list.
            Inmates.Remove(inmate);

            return Inmates;
        }

        /// <summary>
        /// Retrieves all Inmates.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates.</returns>
        public async Task<List<Inmate>> GetAllInmates()
        {
            // Return all Inmates.
            return Inmates;
        }

        /// <summary>
        /// Retrieves a single Inmate by their ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate.</param>
        /// <returns>A task that represents the asynchronous operation and contains the Inmate with the specified ID, or null if not found.</returns>
        public async Task<Inmate?> GetSingleInmate(int id)
        {
            // Find the Inmate with the specified ID.
            var inmate = Inmates.Find(x => x.Id == id);
            if (inmate is null)
                return null;
            return inmate;
        }

        /// <summary>
        /// Updates a Inmate with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate to update.</param>
        /// <param name="request">The updated Inmate object.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates after the update, or null if the Inmate was not found.</returns>
        public async Task<List<Inmate>?> UpdateInmate(int id, Inmate request)
        {
            // Find the Inmate to be updated by ID.
            var inmate = Inmates.Find(x => x.Id == id);
            if (inmate is null)
                return null;

            // Update the Inmate with new data from the request.
            inmate.FirstName = request.FirstName;
            inmate.LastName = request.LastName;
            inmate.Name = request.Name;
            inmate.Place = request.Place;

            // Return all Inmates.
            return Inmates;
        }

    }
}