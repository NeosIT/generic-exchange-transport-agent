using System;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class ExecutableConfigForm : Form, IGenericConfigForm<ExecutableHandler>
    {
        public ExecutableHandler Handler { get; private set; }

        public void Init(ExecutableHandler handler)
        {
            Handler = handler;
        }

        public ExecutableConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            CommandTextBox.Text = Handler.Cmd;
            ArgumentsTextBox.Text = Handler.Args;
            TimeoutNumericUpDown.Value = Handler.Timeout;
            ExportEmlFileCheckBox.Checked = Handler.Export;
            ExportEmlFilePathTextBox.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFilePathBrowseButton.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFileFilenameLabel.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFileFilenameTextBox.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFilePathTextBox.Text = Handler.ExportPath;
            ExportEmlFileFilenameTextBox.Text = Handler.EmlFileName;
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            Handler.Cmd = CommandTextBox.Text;
            Handler.Args = ArgumentsTextBox.Text;
            Handler.Timeout = Convert.ToInt32(TimeoutNumericUpDown.Value);
            Handler.Export = ExportEmlFileCheckBox.Checked;
            Handler.EmlFileName = ExportEmlFileFilenameTextBox.Text;
            Handler.ExportPath = ExportEmlFilePathTextBox.Text;

            Close();
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CommandBrowseButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == CommandFileDialog.ShowDialog())
            {
                CommandTextBox.Text = CommandFileDialog.FileName;
            }
        }

        private void ExportEmlFileCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            ExportEmlFilePathTextBox.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFilePathBrowseButton.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFileFilenameLabel.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFileFilenameTextBox.Enabled = ExportEmlFileCheckBox.Checked;
        }

        private void ExportEmlFilePathBrowseButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == ExportFolderBrowserDialog.ShowDialog())
            {
                ExportEmlFilePathTextBox.Text = ExportFolderBrowserDialog.SelectedPath;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}