# NeosIT Generic Exchange Transport Agent

## How to build

- [.NET SDK >= 4.7.2](https://dotnet.microsoft.com/download/thank-you/net472-developer-pack) must be installed on build system
- Create a directory c:\exchange-libs
- For each Exchange version to compile against, create a directory `c:\exchange-libs\${EXCHANGE_VERSION}`, e.g. `c:\exchange-libs\2013`
- Copy all DLLs from the `\Bin` directory of your Exchange installation to the created directory
- Run (in powershell)

```ps1
.\build.ps1 -BuildTarget ${EXCHANGE_VERSION} -ExchangeLibrariesPath c:\exchange-libs
```