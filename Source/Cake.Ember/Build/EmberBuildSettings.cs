namespace Cake.Ember.Build
{
    /// <summary>
    /// Contains settings used by <see cref="EmberBuildRunner"/>.
    /// </summary>
    public sealed class EmberBuildSettings : EmberSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmberBuildSettings"/> class.
        /// </summary>
        public EmberBuildSettings()
        {
            Watch = false;
            SuppressSizes = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to watch the input files.
        /// </summary>
        /// <remarks>Default is false</remarks>
        public bool Watch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to suppress sizes.
        /// </summary>
        /// <remarks>Default is false</remarks>
        public bool SuppressSizes { get; set; }
    }
}