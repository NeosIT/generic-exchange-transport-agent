
namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Common;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
    using Forms;

    [Export(typeof(IHandler))]
    [DataContract(Name = "ExecutableHandler", Namespace = "")]
    public class ExecutableHandler : FilterableHandlerBase, IExecutableHandler
    {
        [DataMember]
        public int Timeout { get; internal set; }

        [DataMember]
        public bool Export { get; internal set; }

        [DataMember]
        public string EmlFileName { get; internal set; }

        [DataMember]
        public string Cmd { get; internal set; }

        [DataMember]
        public string Args { get; internal set; }

        public int ExitCode { get; internal set; }

        public ExecutableHandler()
        {
            Timeout = 5000;
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ShowConfigDialog()
        {
            var configForm = new ConfigForm(this);
            configForm.ShowDialog();
        }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            ExitCode = (int) ExitCodeEnum.CommandNotRun;

            if (!AppliesTo(emailItem, lastExitCode)) return;

            if (Export)
            {
                if (string.IsNullOrEmpty(EmlFileName))
                {
                    EmlFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        $"{Guid.NewGuid()}.eml");
                }

                if (null != emailItem && !emailItem.IsExported)
                {
                    Logger.Debug(@"[GenericTransportAgent] Exporting EML file to ""{1}""...", EmlFileName);
                    emailItem.Save(EmlFileName);
                }
            }

            if (!string.IsNullOrEmpty(Cmd))
            {
                var process = new Process { StartInfo = { FileName = Cmd, }, };

                if (!string.IsNullOrEmpty(Args))
                {
                    if (Args.Contains("$emlfile$", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Args = Args.Replace("$emlfile$", EmlFileName);
                    }

                    process.StartInfo.Arguments = Args;
                }

                Logger.Debug(@"[GenericTransportAgent] Running command ""{1}"" (args: ""{2}"")...", Cmd, Args);
                process.Start();
                process.WaitForExit(Timeout);

                if (!process.HasExited)
                {
                    Logger.Debug(@"[GenericTransportAgent] - Command did not exit successfully...");
                    process.Kill();
                    ExitCode = (int) ExitCodeEnum.CommandTimedOut;
                }
                else
                {
                    ExitCode = process.ExitCode;
                    Logger.Debug(@"[GenericTransportAgent] - Command did exit successfully, exit code {1}...", ExitCode);
                }
            }

            if (null == Handlers || Handlers.Count <= 0) return;

            foreach (var handler in Handlers)
            {
                handler.Execute(emailItem, ExitCode);
            }
        }

        public override string Name => "ExecutableHandler";

        public override string ToString()
        {
            return Name;
        }
    }
}
