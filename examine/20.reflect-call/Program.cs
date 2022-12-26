using System.Reflection;

try
{
    var asm = Assembly.LoadFrom("/usr/share/dotnet/sdk/7.0.101/Microsoft.Build.dll");
    var type = asm.GetType("Microsoft.Build.Evaluation.IntrinsicFunctions");
    var bind = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
    var getIdent = type.GetMethod("GetTargetFrameworkIdentifier", bind, new[] { typeof(string), });
    var getVer = type.GetMethod("GetTargetFrameworkVersion", bind, new[] { typeof(string), typeof(int), });
    Console.WriteLine($"reflect-call:Identifier={getIdent.Invoke(null, new object[] { "net7.0" })}");
    Console.WriteLine($"reflect-call:Version={getVer.Invoke(null, new object[] { "net7.0", 2 })}");
}
catch (Exception ex)
{
    Console.WriteLine($"reflect-call:{ex}");
}