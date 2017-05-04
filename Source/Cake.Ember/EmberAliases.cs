using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Ember.Build;
using Cake.Ember.Serve;

namespace Cake.Ember
{
    /// <summary>
    /// <para>Contains functionality related to the <see href="https://ember-cli.com/">Ember CLI</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, the Ember CLI utility will need to be installed and available, or you will need to provide a ToolPath to where it can be located, and also you will need to include the following in your build.cake file to download and
    /// reference the addin from NuGet.org:
    /// <code>
    /// #addin Cake.Ember
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("Ember")]
    [CakeNamespaceImport("Cake.Ember.Build")]
    [CakeNamespaceImport("Cake.Ember.Serve")]
    public static class EmberAliases
    {
        /// <summary>
        /// Runs the Ember Build command.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// EmberBuild();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void EmberBuild(this ICakeContext context)
        {
            EmberBuild(context, new EmberBuildSettings());
        }

        /// <summary>
        /// Runs the Ember Build command with the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// EmberBuild(new EmberBuildSettings()
        /// {
        ///     Environment = "qa"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void EmberBuild(this ICakeContext context, EmberBuildSettings settings)
        {
            var runner = new EmberBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Build(settings);
        }

        /// <summary>
        /// Runs the Ember Serve command.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// EmberServe();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void EmberServe(this ICakeContext context)
        {
            EmberServe(context, new EmberServeSettings());
        }

        /// <summary>
        /// Runs the Ember Serve command with the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// EmberServe(new EmberServeSettings()
        /// {
        ///     Environment = "qa"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void EmberServe(this ICakeContext context, EmberServeSettings settings)
        {
            var runner = new EmberServeRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Serve(settings);
        }
    }
}