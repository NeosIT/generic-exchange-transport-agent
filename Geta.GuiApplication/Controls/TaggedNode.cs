using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public class TaggedNode : Panel, ITaggedParent, ITaggedChild
    {
        private static int count = 0;
        private int _count;

        private ITaggedParent _parent;
        private Panel _marking;
        private FlowLayoutPanel _content;
        private Panel _highlight;

        public ToolTip SharedToolTip => Parent.SharedToolTip;
        public ColorTag TagInfo { get; }
        public int AvailableSpace => _content.ClientSize.Width - _content.Padding.Horizontal;
        public Control AsControl => this;
        public ITaggedParent Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                UpdateWidth(value.AvailableSpace);
            }
        }

        public TaggedNode(ITaggedParent parent, ColorTag tag)
        {
            _count = count++;
            TagInfo = tag ?? throw new ArgumentNullException(nameof(tag));

            SuspendLayout();
            AutoScroll = false;
            Margin = new Padding(0);
            Padding = new Padding(2, 2, 0, 2);
            Size = new Size(200, 50);
            MinimumSize = new Size(100, 25);
            Anchor = AnchorStyles.Left | AnchorStyles.Right;
            AutoSize = true;
            BackColor = Color.White;

            _marking = new Panel();
            _marking.SuspendLayout();
            _content = new FlowLayoutPanel();
            _content.SuspendLayout();
            _highlight = new Panel();
            _highlight.SuspendLayout();

            _marking.Name = "Tag";
            _marking.TabIndex = 1;
            _marking.Dock = DockStyle.Left;
            //_marking.Location = new Point(0, 0);
            _marking.Margin = new Padding(0);
            _marking.Padding = new Padding(0);
            _marking.Size = new Size(8, 25);
            _marking.MinimumSize = new Size(8, 25);
            _marking.MaximumSize = new Size(8, 0);
            _marking.BackColor = tag.Color;
            parent.SharedToolTip.SetToolTip(_marking, tag.Label);
            _marking.Click += OnClick;

            _content.Name = "Content";
            _content.TabIndex = 0;
            _content.Dock = DockStyle.Fill;
            //_content.Location = new Point(8, 0);
            _content.Margin = new Padding(0);
            _content.Padding = new Padding(0, 2, 0, 2);
            _content.Size = new Size(100 - 8, 25);
            _content.MinimumSize = new Size(75, 25);
            _content.MaximumSize = new Size(0, 0);
            _content.AutoSize = true;
            _content.BackColor = Color.White;
            _content.FlowDirection = FlowDirection.TopDown;
            _content.WrapContents = false;

            _highlight.Name = "Highlight";
            _highlight.TabIndex = 2;
            _highlight.Dock = DockStyle.Right;
            //_highlight.Location = new Point(0, 0);
            _highlight.Margin = new Padding(0);
            _highlight.Padding = new Padding(0);
            _highlight.Size = new Size(2, 25);
            _highlight.MinimumSize = new Size(2, 25);
            _highlight.MaximumSize = new Size(2, 0);
            _highlight.BackColor = tag.Color;
            _highlight.Visible = false;

            Controls.Add(_highlight);
            Controls.Add(_content);
            Controls.Add(_marking);

            _marking.ResumeLayout();
            _content.ResumeLayout();
            _highlight.ResumeLayout();
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            ResumeLayout();
        }


        public void SetTagWidth(int pixels)
        {
            _marking.MinimumSize = new Size(pixels, 25);
            _marking.MaximumSize = new Size(pixels, 0);
            _marking.Size = new Size(pixels, _marking.Size.Height);
            _content.Size = new Size(Size.Width - pixels, _content.Size.Height);
        }

        public void Highlight(bool selected)
        {
            if (selected)
            {
                Parent.ChildSelected(this);
                _content.BackColor = TagInfo.Color;
                _highlight.Visible = true;
            }
            else
            {
                _content.BackColor = Color.White;
                _highlight.Visible = false;
            }
        }

        public void AddNeighbour(TaggedLeaf neighbour, ColorTag tag)
        {
            if (neighbour == null) throw new ArgumentNullException(nameof(neighbour));
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            if (tag == TagInfo)
            {
                neighbour.Parent = this;
                _content.Controls.Add(neighbour);
            }
            else if (Parent.TagInfo == tag)
            {
                neighbour.Parent = Parent;
                int index = Parent.IndexOf(this);
                Parent.InsertAt(neighbour, index + 1);
                //Highlight(false);
                neighbour.Highlight(true);
            }
            else
            {
                var node = new TaggedNode(Parent, tag);
                //node.SuspendLayout();
                int index = Parent.IndexOf(this);
                Parent.ReplaceChildAt(index, node);
                //Highlight(false);
                Parent = node;
                neighbour.Parent = node;
                node._content.Controls.Add(this);
                node._content.Controls.Add(neighbour);
                node.Highlight(true);
                //node.ResumeLayout(true);
            }
        }

        public void UpdateWidth(int width)
        {
            if (Width == width) return;
            //SuspendLayout();
            MinimumSize = new Size(width, 25);
            MaximumSize = new Size(width, 0);
            Width = width;
            width -= Padding.Horizontal;
            width -= _marking.Width;
            _content.MinimumSize = new Size(width, 25);
            //_content.MaximumSize = _content.MinimumSize;
            _content.Width = width;
            width -= _content.Padding.Horizontal;
            foreach (var child in _content.Controls)
            {
                (child as ITaggedChild)?.UpdateWidth(width);
            }
            //ResumeLayout();
        }

        public void AppendTo(ITaggedParent newParent, int at)
        {
            if (newParent.TagInfo != TagInfo)
            {
                Parent = newParent;
                newParent.InsertAt(this, at);
                Highlight(true);
            }
            else
            {
                //Same tag as new parent, append all children instead.
                newParent.AsControl.SuspendLayout();
                var content = _content.Controls;
                //We need to copy the list before removing elements.
                var children = new ITaggedChild[content.Count];
                for (int i = 0; i < children.Length; i++)
                {
                    children[i] = content[i] as ITaggedChild;
                }
                ITaggedChild last = null;
                foreach (var child in children)
                {
                    if (child == null) continue;
                    child.AppendTo(newParent, at++);
                    last = child;
                }
                if (newParent is ITaggedChild node)
                {
                    node.Highlight(true);
                }
                else
                {
                    last.Highlight(true);
                }
                newParent.AsControl.ResumeLayout(true);
            }
        }

        public void ChildSelected(ITaggedChild child)
        {
            Parent.ChildSelected(child);
        }

        public int IndexOf(Control child)
        {
            return _content.Controls.IndexOf(child);
        }

        public void InsertAt(Control insert, int index)
        {
            //SuspendLayout();
            var content = _content.Controls;
            content.Add(insert);
            content.SetChildIndex(insert, index);
            //ResumeLayout(true);
        }

        public void RemoveChild(Control child)
        {
            SuspendLayout();
            var content = _content.Controls;
            content.Remove(child);
            if (content.Count > 1)
            {
                Highlight(true);
                ResumeLayout(true);
                return;
            }

            Parent.AsControl.SuspendLayout();
            //Only 1 child left, dissolve this node.
            var remainder = (ITaggedChild)content[0];
            int index = Parent.IndexOf(this);
            Parent.ReplaceChildAt(index, remainder);
            Parent.AsControl.ResumeLayout(true);
        }

        public void ReplaceChildAt(int at, ITaggedChild replacement)
        {
            //SuspendLayout();
            var content = _content.Controls;
            content.RemoveAt(at);
            replacement.AppendTo(this, at);
            //ResumeLayout(true);
        }


        private void OnClick(object sender, EventArgs e)
        {
            Highlight(true);
        }

        public override string ToString()
        {
            return $"Node#{_count.ToString("X2")} > {Parent.ToString()}";
        }
    }
}