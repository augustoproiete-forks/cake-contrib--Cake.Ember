using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Ember.Build
{
    /// <summary>
    /// The Ember Build Runner used to build Ember Applications.
    /// </summary>
    public sealed class EmberBuildRunner : EmberTool<EmberBuildSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmberBuildRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public EmberBuildRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Builds an Ember Application using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Build(EmberBuildSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunGem(settings, new EmberBuildArgumentBuilder(_environment, settings));
        }
    }
}