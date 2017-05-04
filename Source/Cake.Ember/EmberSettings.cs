using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Ember
{
    /// <summary>
    /// Contains the common settings used by all commands in Ember.
    /// </summary>
    public abstract class EmberSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the name of the environment to generate the output for.
        /// </summary>
        /// <remarks>Default is development.</remarks>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the location where all generated files will be output to.
        /// </summary>
        /// <remarks>Default is /dist.</remarks>
        public DirectoryPath OutputPath { get; set; }

        /// <summary>
        /// Gets or sets a value for the Watcher.
        /// </summary>
        /// <remarks>Default is events.</remarks>
        public string Watcher { get; set; }
    }
}