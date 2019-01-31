using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public class TaggedLeaf : Panel, ITaggedChild
    {
        private static int count = 0;
        private int _count;

        private ITaggedParent _parent;
        private Label _text;
        private Panel _overlay;

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

        public TaggedLeaf(ITaggedParent parent, string text)
        {
            _count = count++;

            SuspendLayout();
            AutoScroll = false;
            Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Margin = new Padding(0);
            Padding = new Padding(2, 1, 2, 1);
            Size = new Size(92, 25);
            MinimumSize = new Size(50, 25);
            BackColor = Color.White;

            _text = new Label();
            _text.SuspendLayout();
            _overlay = new Panel();
            _overlay.SuspendLayout();

            _text.Name = "Condition";
            _text.Text = text ?? throw new ArgumentNullException(nameof(text));
            _text.TextAlign = ContentAlignment.MiddleLeft;
            _text.BorderStyle = BorderStyle.None;
            _text.Cursor = Cursors.Default;
            _text.AutoSize = false;
            //_text.Enabled = false;
            _text.TabIndex = 0;
            _text.Dock = DockStyle.Fill;
            _text.Margin = new Padding(0);
            _text.Padding = new Padding(0);
            _text.Size = new Size(92, 21);
            _text.MinimumSize = new Size(25, 21);
            _text.MaximumSize = new Size(0, 0);
            _text.BackColor = Color.White;
            _text.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            //SharedToolTip.SetToolTip(_text, tag.Label);
            _text.Click += OnClick;

            _overlay.Name = "Overlay";
            _overlay.TabIndex = 1;
            _overlay.Dock = DockStyle.Fill;
            _overlay.Margin = new Padding(0);
            _overlay.Padding = new Padding(0);
            _overlay.Size = new Size(92, 21);
            _overlay.MinimumSize = new Size(0, 21);
            _overlay.MaximumSize = new Size(0, 25);

            Controls.Add(_text);
            //Controls.Add(_overlay);

            _text.ResumeLayout(true);
            //_overlay.ResumeLayout(true);
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            ResumeLayout(true);
        }


        public void Highlight(bool selected)
        {
            if (selected)
            {
                Parent.ChildSelected(this);
                _text.BackColor = Color.FromArgb(unchecked((int)0xffbababa));
                //_text.ForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            }
            else
            {
                _text.BackColor = Color.White;
                //_text.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
        }

        public void AddNeighbour(TaggedLeaf neighbour, ColorTag tag)
        {
            if (neighbour == null) throw new ArgumentNullException(nameof(neighbour));
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            if (tag == Parent.TagInfo)
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
                node.AddNeighbour(this, tag);
                neighbour.Parent = node;
                node.AddNeighbour(neighbour, tag);
                node.Highlight(true);
                //node.ResumeLayout(true);
            }
        }

        public void UpdateWidth(int width)
        {
            SuspendLayout();
            MinimumSize = new Size(width, 25);
            Width = width;
            ResumeLayout();
        }

        public void AppendTo(ITaggedParent newParent, int at)
        {
            Parent = newParent;
            newParent.InsertAt(this, at);
        }


        private void OnClick(object sender, EventArgs e)
        {
            Parent.RemoveChild(this);
            //Highlight(true);
        }

        public override string ToString()
        {
            return $"Leaf#{_count.ToString("X2")} > {Parent.ToString()}";
        }
    }
}