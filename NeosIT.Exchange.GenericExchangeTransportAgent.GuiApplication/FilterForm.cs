using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class FilterForm : Form
    {
        public FilterForm(IFilterable filterable, IEnumerable<Type> knownTypes)
        {
            Filterable = filterable;
            
            using (var ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(IFilterable), knownTypes);
                serializer.WriteObject(ms, Filterable);
                ms.Position = 0;
                _filters = ((IFilterable)serializer.ReadObject(ms)).Filters;
            }
            
            InitializeComponent();
        }

        public IFilterable Filterable { get; private set; }
        private IList<IFilterable> _filters; 

        private void FilterFormLoad(object sender, EventArgs e)
        {
            OnDropDownList.DataSource = Enum.GetValues(typeof(FilterKeyEnum));
            OperatorDropDownList.DataSource = Enum.GetValues(typeof(FilterOperatorEnum));
            OnDropDownList.Enabled = false;
            OperatorDropDownList.Enabled = false;
            ValueTextBox.Enabled = false;
            RemoveButton.Enabled = false;
            ApplyButton.Enabled = false;
            FiltersTreeView.Nodes.Clear();
            FiltersTreeView.Nodes.AddRange(TreeNodeMapper.MapFilters(_filters));
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveDialogButtonClick(object sender, EventArgs e)
        {
            Filterable.Filters = _filters;
            Close();
        }

        private void FiltersTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != FiltersTreeView.SelectedNode)
            {
                if (null != FiltersTreeView.SelectedNode.Tag)
                {
                    OnDropDownList.Enabled = true;
                    OperatorDropDownList.Enabled = true;
                    ValueTextBox.Enabled = true;
                    RemoveButton.Enabled = true;
                    ApplyButton.Enabled = true;

                    Filter filter = (Filter) FiltersTreeView.SelectedNode.Tag;
                    OnDropDownList.SelectedItem = filter.On;
                    OperatorDropDownList.SelectedItem = filter.Operator;
                    ValueTextBox.Text = filter.Value;
                }
            }
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            if (null != FiltersTreeView.SelectedNode)
            {
                if (null != FiltersTreeView.SelectedNode.Tag)
                {
                    TreeNode node = FiltersTreeView.SelectedNode;

                    Filter filter = (Filter) node.Tag;
                    filter.On = (FilterKeyEnum) OnDropDownList.SelectedItem;
                    filter.Operator = (FilterOperatorEnum) OperatorDropDownList.SelectedItem;
                    filter.Value = ValueTextBox.Text;

                    string filterText = string.Format("{0} {1} {2}", filter.On, filter.Operator, filter.Value);
                    node.Name = filterText;
                    node.Text = filterText;
                }
            }
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            if (null != FiltersTreeView.SelectedNode)
            {
                if (null != FiltersTreeView.SelectedNode.Tag)
                {
                    IFilterable filter = (IFilterable)FiltersTreeView.SelectedNode.Tag;

                    if (null != FiltersTreeView.SelectedNode.Parent)
                    {
                        if (null != FiltersTreeView.SelectedNode.Parent.Tag)
                        {
                            IFilterable parent = (IFilterable) FiltersTreeView.SelectedNode.Parent.Tag;
                            parent.Filters.Remove(filter);
                        }
                    }
                    else
                    {
                        if (_filters.IsReadOnly)
                        {
                            _filters = new List<IFilterable>(_filters);
                        }

                        _filters.Remove(filter);
                    }

                    FiltersTreeView.SelectedNode.Remove();

                    if (null == FiltersTreeView.SelectedNode)
                    {
                        OnDropDownList.Enabled = false;
                        OperatorDropDownList.Enabled = false;
                        ValueTextBox.Enabled = false;
                        RemoveButton.Enabled = false;
                        ApplyButton.Enabled = false;
                    }
                }
            }
        }

        private void AndButtonClick(object sender, EventArgs e)
        {
            if (null != FiltersTreeView.SelectedNode)
            {
                if (null != FiltersTreeView.SelectedNode.Tag)
                {
                    TreeNode node = FiltersTreeView.SelectedNode;
                    IFilterable parent = (IFilterable) node.Tag;
                    Filter filter = new Filter();

                    if (parent.Filters.IsReadOnly)
                    {
                        parent.Filters = new List<IFilterable>(parent.Filters);
                    }

                    parent.Filters.Add(filter);
                    
                    node.Nodes.Add(TreeNodeMapper.MapFilter(filter));
                }
            }
            else
            {
                if (_filters.IsReadOnly)
                {
                    _filters = new List<IFilterable>(_filters);
                }

                Filter filter = new Filter();
                _filters.Add(filter);
                FiltersTreeView.Nodes.Add(TreeNodeMapper.MapFilter(filter));
            }
        }

        private void OrButtonClick(object sender, EventArgs e)
        {
            if (null != FiltersTreeView.SelectedNode)
            {
                if (null != FiltersTreeView.SelectedNode.Tag)
                {
                    Filter filter = new Filter();

                    if (null != FiltersTreeView.SelectedNode.Parent)
                    {
                        if (null != FiltersTreeView.SelectedNode.Parent.Tag)
                        {
                            TreeNode node = FiltersTreeView.SelectedNode.Parent;
                            IFilterable parent = (IFilterable) node.Tag;

                            if (parent.Filters.IsReadOnly)
                            {
                                parent.Filters = new List<IFilterable>(parent.Filters);
                            }

                            parent.Filters.Add(filter);
                            node.Nodes.Add(TreeNodeMapper.MapFilter(filter));
                        }
                    }
                    else
                    {
                        if (_filters.IsReadOnly)
                        {
                            _filters = new List<IFilterable>(_filters);
                        }

                        _filters.Add(filter);
                        FiltersTreeView.Nodes.Add(TreeNodeMapper.MapFilter(filter));
                    }
                }
            }
            else
            {
                Filter filter = new Filter();
                _filters.Add(filter);
                FiltersTreeView.Nodes.Add(TreeNodeMapper.MapFilter(filter));
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
