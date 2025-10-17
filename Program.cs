using System.Diagnostics;
using System.Runtime.InteropServices;

namespace scythe;

public static class Program {

    public static void Main() {
        
        string? target = null;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) target = $"{AppContext.BaseDirectory}bin/scythe/linux-x64/scythe-core.x86_64";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) target = $"{AppContext.BaseDirectory}bin/scythe/win-x64/scythe-core.exe";

        Console.WriteLine(target);

        if (target is null) Environment.Exit(1);

        try {

            var ini = new IniFile(Path.Join(AppContext.BaseDirectory, "runner.ini"));

            var modName = ini.Read("Mod", "name");

            var startInfo = new ProcessStartInfo {

                FileName = target,
                Arguments = $"-mod \"./{modName}\"",
                WorkingDirectory = AppContext.BaseDirectory,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo);
        }

        catch (Exception ex) { Console.WriteLine($"Error launching target: {ex.Message}"); }
    }
}