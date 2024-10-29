namespace SuperHeroAPI.Models
{
    /// <summary>
    /// Represents a Superhero.
    /// </summary>
    public class SuperHero
    {
        /// <summary>
        /// Gets or sets the ID of the Superhero.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the Superhero.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the Superhero.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the Superhero.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the place associated with the Superhero.
        /// </summary>
        public string Place { get; set; } = string.Empty;
    }
}
