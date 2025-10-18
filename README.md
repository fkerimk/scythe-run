# SCYTHE <img width="24" height="24" alt="icon" src="https://fkerimk.com/scythe/icon.png" /> run

A launcher designed to start a mod using Scythe.

## 🛠 License

scythe-run is licensed under the [LGPL-2.1 license](./LICENSE).

## Building

Make sure you have the .NET 10 SDK packages installed.

> [!NOTE] 
> Place scythe-lib at `lib/bin/scythe-lib.dll`, or assign a custom location in `scythe-run.csproj`.

```bash
git clone https://github.com/fkerimk/scythe-run.git
cd scythe-run
dotnet publish -v q -c Release -r linux-x64 # for linux
dotnet publish -v q -c Release -r win-x64 # for windows
cd ..
```

For Linux, the build will be at the `scythe-run/bin/Release/net10.0/linux-x64/publish/scythe-run`.<br/>
For Windows, the build will be at the `scythe-run/bin/Release/net10.0/win-x64/publish/scythe-run.exe`.


You can take an automatic build using the [scythe-build](https://github.com/fkerimk/scythe-build) module.

