using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var exeDir = Path.GetDirectoryName(Environment.ProcessPath);
    Console.WriteLine(exeDir);
    var process = new Process
    {
        StartInfo = new()
        {
            FileName = "/bin/python",
            Arguments = $"{exeDir}/pi.py",
            CreateNoWindow = true,
        }
    };

    process.Start();
});

app.Run();
