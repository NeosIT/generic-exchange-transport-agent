using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Deployment.WindowsInstaller;
using NeosIT.Exchange.GenericExchangeTransportAgent.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication;
using WixSharp;
using File = WixSharp.File;

namespace Geta.Setup
{
    internal static class Program
    {
        private const string StartMenuPath = @"%ProgramMenu%\" + CompanyName + "\\" + AppName;
        private const string AppName = "Generic Exchange Transport Agent";
        private const string AppFileName = "Geta.GuiApplication.exe";
        private const string AppGuid = "C90F9189-39BF-4DC4-9BF4-B4DE090B40A6";
        private const string AppUpgradeCode = "1480F3A0-DC3A-4D10-BF7B-90F7410FA88B";
        private const string CompanyName = "Neos IT GmbH";
        private const string AboutUrl = "https://github.com/NeosIT/generic-exchange-transport-agent";
        private const InstallScope InstallScope = WixSharp.InstallScope.perMachine;
        private const string IconPath = @"..\Geta.GuiApplication\Resources\Icon.ico";
        private const string ContactEmail = "info@neos-it.de";
        private const string AppDescription = "Lorem Ipsum"; // TODO
        private const string LicenseFile = "license.rtf";
        private const string BackgroundImagePath = @"Images\MSI BG.png";
        private const string BannerImagePath = null;

        /// <summary>
        /// Gets the name of the parent directory. i.e. bin/2010/App.exe => 2010
        /// </summary>
        public static string Configuration => new FileInfo(typeof(Program).Assembly.Location).Directory?.Name;

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
                    new LaunchCondition("PLATFORM=x64", Setup.ErrorPlatform64Required),
                    new LaunchCondition("VersionNT>600", Setup.ErrorVersionTooLow)
                },
                Dirs = new[]
                {
                    new Dir(new Id("INSTALL_DIR"), AppName)
                    {
                        IsInstallDir = true,
                        Files = GetApplicationFiles()
                    },
                    new Dir(StartMenuPath)
                    {
                        Shortcuts = new[]
                        {
                            new ExeFileShortcut(AppName, $@"[INSTALL_DIR]\{AppFileName}", "")
                            {
                                IconFile = IconPath
                            },
                            new ExeFileShortcut($"Uninstall {AppName}", "[System64Folder]msiexec.exe",
                                "/x [ProductCode]")
                        }
                    }
                },
                BannerImage = BannerImagePath,
                BackgroundImage = BackgroundImagePath,
                ValidateBackgroundImage = false,
                LicenceFile = LicenseFile,
                Description = AppDescription
            };

            project.Load += ProjectOnBeforeInstall;

            Compiler.BuildMsi(project, Path.Combine("bin", Configuration, $"{AppName}.msi"));
        }

        private static File[] GetApplicationFiles()
        {
            return new DirectoryInfo($@"..\Geta.GuiApplication\bin\{Configuration}").GetFiles()
                .Select(x =>
                {
                    var file = new File(x.FullName);
                    if (x.Name == AppFileName)
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
            var exchangeDir =
                Environment.GetEnvironmentVariable("ExchangeInstallPath", EnvironmentVariableTarget.Machine);
            if (!exchangeDir.IsNullOrWhiteSpace())
            {
#if NET35
                e.Session["INSTALL_DIR"] =
 string.Join(Path.PathSeparator.ToString(), new []{exchangeDir, "TransportRoles", "agents", AppName});
#else
                e.Session["INSTALL_DIR"] = Path.Combine(exchangeDir, "TransportRoles", "agents", AppName);
#endif
            }
            else
            {
                e.Result = ActionResult.Failure;
            }
        }
    }
}