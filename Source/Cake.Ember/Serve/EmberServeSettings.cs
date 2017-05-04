namespace Cake.Ember.Serve
{
    /// <summary>
    /// Contains settings used by <see cref="EmberServeRunner"/>.
    /// </summary>
    public sealed class EmberServeSettings : EmberSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmberServeSettings"/> class.
        /// </summary>
        public EmberServeSettings()
        {
            SecureProxy = true;
            TransparentProxy = true;
            LiveReload = true;
            Ssl = false;
        }

        /// <summary>
        /// Gets or sets a value to use for the port to host website on.
        /// </summary>
        /// <remarks>Default is 4200.  Pass 0 to automatically pick an available port.</remarks>
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets the host on which to listen to.
        /// </summary>
        /// <remarks>Listens on all interfaces by default</remarks>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the proxy that should be used.
        /// </summary>
        public string Proxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a secure proxy is being used.
        /// </summary>
        /// <remarks>Default is true.  Set to false to proxy self-signed SSL certificates.</remarks>
        public bool SecureProxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a transparent proxy is being used.
        /// </summary>
        /// <remarks>Default is true.  Set to false to omit x-forwarded-* headers when proxying</remarks>
        public bool TransparentProxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the Live Reload Server.
        /// </summary>
        /// <remarks>Default is true.</remarks>
        public bool LiveReload { get; set; }

        /// <summary>
        /// Gets or sets the host to be used for Live Reload Server.
        /// </summary>
        /// <remarks>Defaults to Host value.</remarks>
        public string LiveReloadHost { get; set; }

        /// <summary>
        /// Gets or sets the Base Url to use for Live Reload Server.
        /// </summary>
        public string LiveReloadBaseUrl { get; set; }

        /// <summary>
        /// Gets or sets a value to use for the port for Live Reload Server.
        /// </summary>
        /// <remarks>Defaults to port number within [49152...65535].</remarks>
        public int? LiveReloadPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SSL is being used.
        /// </summary>
        /// <remarks>Default is false.</remarks>
        public bool Ssl { get; set; }

        /// <summary>
        /// Gets or sets the Key for the SSL Certificate.
        /// </summary>
        /// <remarks>Default is ssl/server.key.</remarks>
        public string SslKey { get; set; }

        /// <summary>
        /// Gets or sets the SSL Certificate.
        /// </summary>
        /// <remarks>Defaults to ssl/server.cert</remarks>
        public string SslCert { get; set; }
    }
}