using Cake.Core;
using Cake.Core.IO;

namespace Cake.Ember.Build
{
    /// <summary>
    /// The Argument Builder for the Build method of the Ember CLI.
    /// </summary>
    internal sealed class EmberBuildArgumentBuilder : EmberArgumentBuilder<EmberBuildSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmberBuildArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public EmberBuildArgumentBuilder(ICakeEnvironment environment, EmberBuildSettings settings)
            : base(environment, settings)
        {
            _environment = environment;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected override void AddArguments(ProcessArgumentBuilder builder, EmberBuildSettings settings)
        {
            builder.Append("build");

            if (settings.Watch)
            {
                builder.Append("--watch");
            }

            if (settings.SuppressSizes)
            {
                builder.Append("--suppress-sizes");
            }
        }
    }
}