using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Deployment.WindowsInstaller;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication;
using WixSharp;
using File = WixSharp.File;

namespace Geta.Setup
{
    internal static class Program
    {
        private static readonly string StartMenuPath = $@"%ProgramMenu%\{CompanyName}\{AppName}";
        private const string AppName = "Generic Exchange Transport Agent";
        private const string AppFileName = "Geta.GuiApplication.exe";
        private const string AppGuid = "C90F9189-39BF-4DC4-9BF4-B4DE090B40A6";
        private const string AppUpgradeCode = "1480F3A0-DC3A-4D10-BF7B-90F7410FA88B";
        private const string CompanyName = "Neos IT GmbH";
        private const string AboutUrl = "https://github.com/NeosIT/generic-exchange-transport-agent";
        private const InstallScope InstallScope = WixSharp.InstallScope.perMachine;
        private const string IconPath = @"..\Geta.GuiApplication\Icon.ico";
        private const string ContactEmail = "info@neos-it.de";

        public static void Main()
        {
            Compiler.WixLocation = Path.GetFullPath(@"..\packages\WixSharp.wix.bin.3.11.0\tools\bin");
            
            var project = new ManagedProject
            {
                Name = AppName,
                GUID = new Guid(AppGuid),
                UpgradeCode = new Guid(AppUpgradeCode),
                InstallScope = InstallScope,
                Platform = Platform.x64,
                Version = typeof(MainForm).Assembly.GetName().Version,
                
                ControlPanelInfo = new ProductInfo
                {
                    ProductIcon = IconPath,
                    UrlInfoAbout = AboutUrl,
                    NoModify = true,
                    NoRepair = true,
                    InstallLocation = "[INSTALL_DIR]",
                    Manufacturer = CompanyName,
                    Contact = ContactEmail
                },
                LaunchConditions = new List<LaunchCondition>
                {
                    new LaunchCondition("PLATFORM=x64", "A 64 bit operation system is required."),
                    new LaunchCondition("VersionNT>600", "Windows 7 or Server 2008 R2 or higher is required.")
                },
                Dirs = new[]
                {
                    new Dir(new Id("INSTALL_DIR"), AppName)
                    {
                        IsInstallDir = true,
                        Files = GetApplicationFiles()
                    },
                    new Dir(StartMenuPath){
                        Shortcuts = new []
                        {
                            new ExeFileShortcut(AppName, $@"[INSTALL_DIR]\{AppFileName}", "")
                            {
                                IconFile = IconPath
                            },
                            new ExeFileShortcut($"Uninstall {AppName}", "[System64Folder]msiexec.exe", "/x [ProductCode]")
                        }
                    }
                },
                UI = WUI.WixUI_Minimal
            };

            project.Load += ProjectOnBeforeInstall;

            Compiler.BuildMsi(project, $"{AppName}.msi");
        }

        private static File[] GetApplicationFiles()
        {
            return new DirectoryInfo("..\\Geta.GuiApplication\\bin\\Release").GetFiles()
                .Select(x =>
                {
                    
                    var file = new File(x.FullName);
                    if (x.Name == "Geta.GuiApplication.exe")
                    {
                        file.Shortcuts = new[]
                        {
                            new FileShortcut(AppName)
                            {
                                Id = "StartMenuLink",
                                IconFile = IconPath
                            }
                        };
                    }

                    return file;
                }).ToArray();
        }

        private static void ProjectOnBeforeInstall(SetupEventArgs e)
        {
            var exchangeDir = Environment.GetEnvironmentVariable("ExchangeInstallPath", EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrWhiteSpace(exchangeDir))
            {
                e.Session["INSTALL_DIR"] = Path.Combine(exchangeDir, "TransportRoles", "agents", AppName);
            }
            else
            {
                e.Result = ActionResult.Failure;
            }
        }
    }
}