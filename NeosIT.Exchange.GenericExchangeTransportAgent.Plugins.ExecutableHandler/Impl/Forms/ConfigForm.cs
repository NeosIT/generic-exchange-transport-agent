using System;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl.Forms
{
    public partial class ConfigForm : Form
    {
        private readonly ExecutableHandler _handler;

        public ConfigForm(ExecutableHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            CommandTextBox.Text = _handler.Cmd;
            ArgumentsTextBox.Text = _handler.Args;
            TimeoutNumericUpDown.Value = _handler.Timeout;
            ExportEmlFileCheckBox.Checked = _handler.Export;
            ExportEmlFilePathTextBox.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFilePathBrowseButton.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFileFilenameLabel.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFileFilenameTextBox.Enabled = ExportEmlFileCheckBox.Checked;
            ExportEmlFilePathTextBox.Text = _handler.ExportPath;
            ExportEmlFileFilenameTextBox.Text = _handler.EmlFileName;
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            _handler.Cmd = CommandTextBox.Text;
            _handler.Args = ArgumentsTextBox.Text;
            _handler.Timeout = Convert.ToInt32(TimeoutNumericUpDown.Value);
            _handler.Export = ExportEmlFileCheckBox.Checked;
            _handler.EmlFileName = ExportEmlFileFilenameTextBox.Text;
            _handler.ExportPath = ExportEmlFilePathTextBox.Text; 

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
