using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Ember.Serve
{
    /// <summary>
    /// The Ember Serve Runner used to serve Ember Application locally.
    /// </summary>
    public sealed class EmberServeRunner : EmberTool<EmberServeSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmberServeRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public EmberServeRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Serves a local Ember Application using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Serve(EmberServeSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunEmber(settings, new EmberServeArgumentBuilder(_environment, settings));
        }
    }
}