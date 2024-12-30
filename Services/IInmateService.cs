using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhiteBrookAPI.Models;

namespace WhiteBrookAPI.Services.InmateService
{
    /// <summary>
    /// Represents a service for managing Inmates.
    /// </summary>
    public interface IInmateService
    {
        /// <summary>
        /// Retrieves all Inmates.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates.</returns>
        Task<List<Inmate>> GetAllInmates();

        /// <summary>
        /// Retrieves a single Inmate by their ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate.</param>
        /// <returns>A task that represents the asynchronous operation and contains the Inmate with the specified ID, or null if not found.</returns>
        Task<Inmate?> GetSingleInmate(int id);

        /// <summary>
        /// Adds a new Inmate.
        /// </summary>
        /// <param name="Inmate">The Inmate object to add.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates after the addition.</returns>
        Task<List<Inmate>> AddInmate(Inmate inmate);

        /// <summary>
        /// Updates a Inmate with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate to update.</param>
        /// <param name="request">The updated Inmate object.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates after the update, or null if the Inmate was not found.</returns>
        Task<List<Inmate>?> UpdateInmate(int id, Inmate request);

        /// <summary>
        /// Deletes a Inmate with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Inmate to delete.</param>
        /// <returns>A task that represents the asynchronous operation and contains a list of Inmates after the deletion, or null if the Inmate was not found.</returns>
        Task<List<Inmate>?> DeleteInmate(int id);

    }
}
