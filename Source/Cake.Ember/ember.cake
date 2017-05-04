#r "Cake.Ember.dll"

try
{
    // EmberBuild(new EmberBuildSettings { Environment = "", WorkingDirectory = ""});

	EmberServe(new EmberServeSettings { Environment = "", WorkingDirectory = ""});
}
catch(Exception ex)
{
    Error("{0}", ex);
}