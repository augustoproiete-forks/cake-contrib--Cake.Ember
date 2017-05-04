using Cake.Core.IO;
using Cake.Ember.Build;

namespace Cake.Ember.Tests.Fixtures
{
    internal sealed class EmberBuildRunnerFixture : EmberFixture<EmberBuildSettings>
    {
        public EmberBuildRunnerFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new EmberBuildRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Build(Settings);
        }
    }
}