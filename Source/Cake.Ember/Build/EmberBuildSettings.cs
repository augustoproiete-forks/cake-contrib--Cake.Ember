namespace Cake.Ember.Build
{
    /// <summary>
    /// Contains settings used by <see cref="EmberBuildRunner"/>.
    /// </summary>
    public sealed class EmberBuildSettings : EmberSettings
    {
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