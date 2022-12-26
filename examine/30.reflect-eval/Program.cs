using System.Reflection;

try
{
    var asm = Assembly.LoadFrom("/usr/share/dotnet/sdk/7.0.101/Microsoft.Build.dll");
    var type = asm.GetType("Microsoft.Build.Evaluation.Project");
    var inst = Activator.CreateInstance(type);

    var setProp = type.GetMethod("SetProperty", new[] { typeof(string), typeof(string), });
    var propIdentifier = setProp.Invoke(inst, new object[] { "TestIdentifier", "$([MSBuild]::GetTargetFrameworkIdentifier(net7.0))", });
    var propVersion = setProp.Invoke(inst, new object[] { "TestVersion", "$([MSBuild]::GetTargetFrameworkVersion(net7.0, 2))", });

    var getIdentifier = propIdentifier.GetType().GetProperty("EvaluatedValue");
    var getVersion = propIdentifier.GetType().GetProperty("EvaluatedValue");
    Console.WriteLine($"reflect-eval:Identifier={getIdentifier.GetValue(propIdentifier)}");
    Console.WriteLine($"reflect-eval:Version={getVersion.GetValue(propVersion)}");
}
catch (Exception ex)
{
    Console.WriteLine($"reflect-eval:{ex}");
}