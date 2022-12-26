using Microsoft.Build.Evaluation;

try
{
    var wrapper = new NuGetFrameworkWrapper();
    Console.WriteLine($"wrapper-class:Identifier={wrapper.GetTargetFrameworkIdentifier("net7.0")}");
    Console.WriteLine($"wrapper-class:Version={wrapper.GetTargetFrameworkVersion("net7.0", 2)}");
}
catch (Exception ex)
{
    Console.WriteLine($"wrapper-class:{ex}");
}