﻿using System;
using Cake.Core;
using Cake.Testing;
using Cake.Ember.Tests.Fixtures;
using Xunit;

namespace Cake.Ember.Tests
{
    public sealed class EmberBuildRunnerTests
    {
        public sealed class TheBuildMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new EmberBuildRunnerFixture();
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
                var fixture = new EmberBuildRunnerFixture();
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
                var fixture = new EmberBuildRunnerFixture();
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
                var fixture = new EmberBuildRunnerFixture();
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
                var fixture = new EmberBuildRunnerFixture();
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
                var fixture = new EmberBuildRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/ember.cmd", result.Path.FullPath);
            }

            [Fact]
            public void Should_Add_Watch_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberBuildRunnerFixture();
                fixture.Settings.Watch = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --watch", result.Args);
            }

            [Fact]
            public void Should_Add_SuppressSizes_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberBuildRunnerFixture();
                fixture.Settings.SuppressSizes = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --suppress-sizes", result.Args);
            }

            [Fact]
            public void Should_Add_Environment_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberBuildRunnerFixture();
                fixture.Settings.Environment = "qa";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --environment qa", result.Args);
            }

            [Fact]
            public void Should_Add_OutputPath_File_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberBuildRunnerFixture();
                fixture.Settings.OutputPath = "output";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --output-path \"/Working/output\"", result.Args);
            }

            [Fact]
            public void Should_Add_Watcher_To_Arguments_If_Set()
            {
                // Given
                var fixture = new EmberBuildRunnerFixture();
                fixture.Settings.Watcher = "events";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --watcher events", result.Args);
            }
        }
    }
}