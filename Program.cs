using System.Diagnostics;
using System.Runtime.InteropServices;

namespace scythe;

public static class Program {

    public static void Main() {
        
        string? target = null;
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) target = Path.Join(AppContext.BaseDirectory, "bin/scythe/scythe-core.x86_64");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) target = Path.Join(AppContext.BaseDirectory, "bin/scythe/scythe-core.exe");

        Console.WriteLine(target);

        if (target is null) Environment.Exit(1);

        try {

            var ini = new IniFile(Path.Join(AppContext.BaseDirectory, "runner.ini"));

            var modName = ini.Read("Mod", "name");

            var startInfo = new ProcessStartInfo {

                FileName = target,
                Arguments = $"-mod \"bin/{modName}\"",
                WorkingDirectory = AppContext.BaseDirectory,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo);
        }

        catch (Exception ex) { Console.WriteLine($"Error launching target: {ex.Message}"); }
    }
}