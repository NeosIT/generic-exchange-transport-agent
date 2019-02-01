using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public class TaggedTree : FlowLayoutPanel, ITaggedParent
    {
        private static int count = 0;
        private int _count;
        private ITaggedChild _selected;
        private int _oldWidth;
        private int _scoll;

        public ToolTip SharedToolTip { get; }
        public ColorTag TagInfo => null;
        public int AvailableSpace => ClientSize.Width - Padding.Horizontal;
        public Control AsControl => this;


        public TaggedTree()
        {
            _count = count++;
            Name = "";
            Margin = new Padding(0);
            Padding = new Padding(0, 0, 2, 0);
            Size = new Size(100, 25);
            _oldWidth = ClientSize.Width;
            BackColor = Color.White;
            FlowDirection = FlowDirection.TopDown;
            WrapContents = false;
            ClientSizeChanged += UpdateWidth;

            AutoScroll = false;
            HorizontalScroll.Maximum = 0;
            HorizontalScroll.Visible = false;
            HorizontalScroll.Enabled = false;
            VerticalScroll.Visible = false;
            HScroll = false;
            AutoScroll = true;

            SharedToolTip = new ToolTip
            {
                AutomaticDelay = 200,
                ShowAlways = true,
            };
        }


        public void AddAtSelection(IPayload entry, ColorTag tag)
        {
            SuspendLayout();
            var leaf = new TaggedLeaf(this, entry);
            if (_selected == null || Controls.Count == 0)
            {
                Controls.Add(leaf);
            }
            else
            {
                _selected.AddNeighbour(leaf, tag);
            }
            ResumeLayout();
            leaf.Highlight(true);
        }

        public void ChildSelected(ITaggedChild child)
        {
            if (child == null || child == _selected) return;
            _selected?.Highlight(false);
            _selected = child;
            if (child.ScrollOnFocus)
                ScrollControlIntoView(child.AsControl);
            //child.Highlight(true);
        }

        public void Freeze()
        {
            _scoll = VerticalScroll.Value;
            SuspendLayout();
        }

        public void Unfreeze()
        {
            if (VerticalScroll.Maximum < _scoll)
                VerticalScroll.Value = VerticalScroll.Maximum;
            else
                VerticalScroll.Value = _scoll;
            ResumeLayout(true);
        }

        public int IndexOf(ITaggedChild child)
        {
            return Controls.IndexOf(child.AsControl);
        }

        public void InsertAt(ITaggedChild insert, int index)
        {
            SuspendLayout();
            var content = Controls;
            content.Add(insert.AsControl);
            content.SetChildIndex(insert.AsControl, index);
            ResumeLayout(true);
        }

        public void RemoveChild(ITaggedChild child)
        {
            Controls.Remove(child.AsControl);
        }

        public void ReplaceChildAt(int at, ITaggedChild replacement)
        {
            //SuspendLayout();
            var scroll = VerticalScroll.Value;
            var content = Controls;
            content.RemoveAt(at);
            replacement.AppendTo(this, at);
            replacement.Highlight(true);
            VerticalScroll.Value = scroll;
            //ResumeLayout(true);
        }


        private void UpdateWidth(object sender, EventArgs e)
        {
            int width = ClientSize.Width;
            if (width == _oldWidth) return;
            _oldWidth = width;
            width -= Padding.Horizontal;
            SuspendLayout();
            foreach (var child in Controls)
            {
                (child as ITaggedChild)?.UpdateWidth(width);
            }
            ResumeLayout(true);
        }

        public override string ToString()
        {
            return $"Tree#{_count.ToString("X2")}";
        }
    }
}
