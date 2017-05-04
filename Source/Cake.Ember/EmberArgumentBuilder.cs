using Cake.Core;
using Cake.Core.IO;

namespace Cake.Ember
{
    /// <summary>
    /// The top level argument builder for the Ember CLI Tool
    /// </summary>
    /// <typeparam name="T">The Settings type to build arguments from</typeparam>
    public abstract class EmberArgumentBuilder<T>
        where T : EmberSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly ProcessArgumentBuilder _builder;
        private readonly T _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmberArgumentBuilder{T}"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="setting">The settings</param>
        protected EmberArgumentBuilder(ICakeEnvironment environment, T setting)
        {
            _environment = environment;
            _settings = setting;
            _builder = new ProcessArgumentBuilder();
        }

        /// <summary>
        /// Gets the Cake Environment
        /// </summary>
        protected ICakeEnvironment Environment => _environment;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>A populated argument builder.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            AddArguments(_builder, _settings);
            AddCommonArguments();
            return _builder;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected abstract void AddArguments(ProcessArgumentBuilder builder, T settings);

        private void AddCommonArguments()
        {
            if (!string.IsNullOrEmpty(_settings.Environment))
            {
                _builder.Append("--environment");
                _builder.Append(_settings.Environment);
            }

            if (_settings.OutputPath != null)
            {
                _builder.Append("--output-path");
                _builder.AppendQuoted(_settings.OutputPath.MakeAbsolute(_environment).FullPath);
            }

            if (!string.IsNullOrEmpty(_settings.Watcher))
            {
                _builder.Append("--watcher");
                _builder.Append(_settings.Watcher);
            }
        }
    }
}