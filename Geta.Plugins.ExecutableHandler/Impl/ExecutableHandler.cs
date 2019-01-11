using System.Linq;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl
{
    [Export(typeof(IHandler))]
    [DataContract(Name = "ExecutableHandler", Namespace = "")]
    public class ExecutableHandler : FilterableHandlerBase, IExecutableHandler
    {
        [DataMember]
        public int Timeout { get; internal set; }

        [DataMember]
        public bool Export { get; internal set; }

        [DataMember]
        public string ExportPath { get; set; }

        [DataMember]
        public string EmlFileName { get; internal set; }

        [DataMember]
        public string Cmd { get; set; }

        [DataMember]
        public string Args { get; set; }

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

            string exportFileName = string.Empty;

            if (Export)
            {
                if (string.IsNullOrEmpty(ExportPath))
                {
                    ExportPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                var invalidPathChars = Path.GetInvalidPathChars();
                ExportPath = new string(ExportPath.Where(x => !invalidPathChars.Contains(x)).ToArray());

                if (string.IsNullOrEmpty(EmlFileName))
                {
                    var messageId = emailItem.Message.MessageId;
                    EmlFileName = !string.IsNullOrEmpty(messageId) ? string.Format("{0}.eml", messageId) : string.Format("{0}.eml", Guid.NewGuid());
                }

                EmlFileName = new string(EmlFileName.Where(x => !invalidPathChars.Contains(x)).ToArray());
                exportFileName = Path.Combine(ExportPath, EmlFileName);

                if (null != emailItem && !emailItem.IsExported)
                {
                    Logger.Debug(@"[GenericTransportAgent] Exporting EML file to ""{1}""...", EmlFileName);
                    emailItem.Save(exportFileName);
                }
            }

            if (!string.IsNullOrEmpty(Cmd))
            {
                var process = new Process { StartInfo = { FileName = Cmd, }, };

                if (!string.IsNullOrEmpty(Args))
                {
                    if (Args.Contains("$emlfile$", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Args = Args.Replace("$emlfile$", exportFileName);
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
