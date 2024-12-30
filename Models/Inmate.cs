namespace WhiteBrookAPI.Models
{
    /// <summary>
    /// Represents a Inmate.
    /// </summary>
    public class Inmate
    {
        /// <summary>
        /// Gets or sets the ID of the Inmate.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the Inmate.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the Inmate.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the Inmate.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the place associated with the Inmate.
        /// </summary>
        public string Place { get; set; } = string.Empty;
    }
}
