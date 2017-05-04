using System;
using Cake.Core;
using Cake.Testing;
using Cake.Ember.Tests.Fixtures;
using Xunit;

namespace Cake.Ember.Tests
{
    public sealed class EmberServeRunnerTests
    {
        public sealed class TheServeMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("settings", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Throw_If_Ember_Executable_Was_Not_Found()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Ember: Could not locate executable.", result.Message);
            }

            [Theory]
            [InlineData("/bin/tools/Ember/ember.cmd", "/bin/tools/Ember/ember.cmd")]
            [InlineData("./tools/Ember/ember.cmd", "/Working/tools/Ember/ember.cmd")]
            public void Should_Use_Ember_Executable_From_Tool_Path_If_Provided(string toolPath, string expected)
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.ToolPath = toolPath;
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Ember: Process was not started.", result.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Ember: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_Find_Ember_Executable_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/ember.cmd", result.Path.FullPath);
            }

            [Fact]
            public void Should_Add_Port_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.Port = 13;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --port 13", result.Args);
            }

            [Fact]
            public void Should_Add_Host_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.Host = "default";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --host default", result.Args);
            }

            [Fact]
            public void Should_Add_Proxy_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.Proxy = "proxyA";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --proxy proxyA", result.Args);
            }

            [Fact]
            public void Should_Add_SecureProxy_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.SecureProxy = false;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --secure-proxy=false", result.Args);
            }

            [Fact]
            public void Should_Add_TransparentProxy_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.TransparentProxy = false;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --transparent-proxy=false", result.Args);
            }

            [Fact]
            public void Should_Add_LiveReload_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.LiveReload = false;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --live-reload=false", result.Args);
            }

            [Fact]
            public void Should_Add_LiveReloadHost_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.LiveReloadHost = "host";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --live-reload-host host", result.Args);
            }

            [Fact]
            public void Should_Add_LiveReloadBaseUrl_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.LiveReloadBaseUrl = "baseUrl";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --live-reload-base-url baseUrl", result.Args);
            }

            [Fact]
            public void Should_Add_LiveReloadPort_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.LiveReloadPort = 13;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --live-reload-port 13", result.Args);
            }

            [Fact]
            public void Should_Add_Ssl_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.Ssl = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --ssl", result.Args);
            }

            [Fact]
            public void Should_Add_SslKey_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.SslKey = "ssl/server.key";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --ssl-key ssl/server.key", result.Args);
            }

            [Fact]
            public void Should_Add_SslCert_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.SslCert = "ssl/server.cert";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --ssl-cert ssl/server.cert", result.Args);
            }

            [Fact]
            public void Should_Add_Environment_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.Environment = "qa";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --environment qa", result.Args);
            }

            [Fact]
            public void Should_Add_OutputPath_File_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.OutputPath = "output";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --output-path \"/Working/output\"", result.Args);
            }

            [Fact]
            public void Should_Add_Watcher_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberServeRunnerFixture();
                fixture.Settings.Watcher = "events";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve --watcher events", result.Args);
            }
        }
    }
}