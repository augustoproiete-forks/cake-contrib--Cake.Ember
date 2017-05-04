using Cake.Core;
using Cake.Core.IO;

namespace Cake.Ember.Serve
{
    /// <summary>
    /// The Argument Builder for the Build method of the Gem CLI.
    /// </summary>
    internal sealed class EmberServeArgumentBuilder : EmberArgumentBuilder<EmberServeSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmberServeArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public EmberServeArgumentBuilder(ICakeEnvironment environment, EmberServeSettings settings)
            : base(environment, settings)
        {
            _environment = environment;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected override void AddArguments(ProcessArgumentBuilder builder, EmberServeSettings settings)
        {
            builder.Append("serve");

            if (settings.Port.HasValue)
            {
                builder.Append("--port");
                builder.Append(settings.Port.Value.ToString());
            }

            if (!string.IsNullOrWhiteSpace(settings.Host))
            {
                builder.Append("--host");
                builder.Append(settings.Host);
            }

            if (!string.IsNullOrWhiteSpace(settings.Proxy))
            {
                builder.Append("--proxy");
                builder.Append(settings.Proxy);
            }

            if (settings.SecureProxy)
            {
                builder.Append("--secure-proxy");
            }

            if (settings.TransparentProxy)
            {
                builder.Append("--transparent-proxy");
            }

            if (settings.LiveReload)
            {
                builder.Append("--live-reload");
            }

            if (!string.IsNullOrWhiteSpace(settings.LiveReloadHost))
            {
                builder.Append("--live-reload-host");
                builder.Append(settings.LiveReloadHost);
            }

            if (!string.IsNullOrWhiteSpace(settings.LiveReloadBaseUrl))
            {
                builder.Append("--live-reload-base-url");
                builder.Append(settings.LiveReloadBaseUrl);
            }

            if (settings.LiveReloadPort.HasValue)
            {
                builder.Append("--live-reload-port");
                builder.Append(settings.LiveReloadPort.Value.ToString());
            }

            if (settings.Ssl)
            {
                builder.Append("--ssl");
            }

            if (!string.IsNullOrWhiteSpace(settings.SslKey))
            {
                builder.Append("--ssl-key");
                builder.Append(settings.SslKey);
            }

            if (!string.IsNullOrWhiteSpace(settings.SslCert))
            {
                builder.Append("--ssl-cert");
                builder.Append(settings.SslCert);
            }
        }
    }
}