using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.Ember.Tests
{
    internal abstract class EmberFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected EmberFixture()
            : base("ember.cmd")
        {
        }
    }
}