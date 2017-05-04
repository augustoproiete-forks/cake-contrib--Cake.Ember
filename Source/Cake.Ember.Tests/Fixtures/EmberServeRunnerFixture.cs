using Cake.Core.IO;
using Cake.Ember.Serve;

namespace Cake.Ember.Tests.Fixtures
{
    internal sealed class EmberServeRunnerFixture : EmberFixture<EmberServeSettings>
    {
        public EmberServeRunnerFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new EmberServeRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Serve(Settings);
        }
    }
}