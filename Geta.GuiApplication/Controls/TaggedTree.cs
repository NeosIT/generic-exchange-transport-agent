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
            AutoScroll = true;

            SharedToolTip = new ToolTip
            {
                AutomaticDelay = 200,
                ShowAlways = true,
            };
        }


        public void AddAtSelection(string entry, ColorTag tag)
        {
            SuspendLayout();
            if (_selected == null || Controls.Count == 0)
            {
                var leaf = new TaggedLeaf(this, entry);
                Controls.Add(leaf);
                leaf.Highlight(true);
            }
            else
            {
                var leaf = new TaggedLeaf(this, entry);
                _selected.AddNeighbour(leaf, tag);
            }
            ResumeLayout();
        }

        public void ChildSelected(ITaggedChild child)
        {
            if (child == null || child == _selected) return;
            _selected?.Highlight(false);
            _selected = child;
            //child.Highlight(true);
        }

        public int IndexOf(Control child)
        {
            return Controls.IndexOf(child);
        }

        public void InsertAt(Control insert, int index)
        {
            SuspendLayout();
            var content = Controls;
            content.Add(insert);
            content.SetChildIndex(insert, index);
            ResumeLayout(true);
        }

        public void RemoveChild(Control child)
        {
            Controls.Remove(child);
        }

        public void ReplaceChildAt(int at, ITaggedChild replacement)
        {
            //SuspendLayout();
            var content = Controls;
            content.RemoveAt(at);
            replacement.AppendTo(this, at);
            replacement.Highlight(true);
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
