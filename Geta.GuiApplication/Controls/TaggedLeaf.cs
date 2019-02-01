using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public class TaggedLeaf : Panel, ITaggedChild
    {
        private static readonly Color HighlightColor = Color.FromArgb(unchecked((int)0xffdadada));
        private static int count = 0;
        private int _count;

        private ITaggedParent _parent;
        private Label _text;
        private Button _deleteButton;

        public IPayload Payload { get; }
        public Control AsControl => this;
        public bool ScrollOnFocus => true;
        public ITaggedParent Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                UpdateWidth(value.AvailableSpace);
            }
        }

        public TaggedLeaf(ITaggedParent parent, IPayload payload)
        {
            _count = count++;
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));

            SuspendLayout();
            AutoScroll = false;
            AutoScrollOffset = new Point(0, -25);
            Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Margin = new Padding(0);
            Padding = new Padding(2, 1, 2, 1);
            Size = new Size(92, 25);
            MinimumSize = new Size(50, 25);
            BackColor = Color.White;

            _text = new Label();
            _text.SuspendLayout();
            _deleteButton = new Button();
            _deleteButton.SuspendLayout();

            _text.Name = "Condition";
            _text.Text = payload.DisplayText;
            _text.TextAlign = ContentAlignment.MiddleLeft;
            _text.AutoEllipsis = true;
            _text.BorderStyle = BorderStyle.None;
            _text.Cursor = Cursors.Default;
            _text.AutoSize = false;
            //_text.Enabled = false;
            _text.TabIndex = 0;
            _text.Dock = DockStyle.Fill;
            _text.Margin = new Padding(0);
            _text.Padding = new Padding(0);
            _text.Size = new Size(92, 21);
            _text.MinimumSize = new Size(50, 21);
            _text.MaximumSize = new Size(0, 0);
            _text.BackColor = Color.White;
            _text.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            //SharedToolTip.SetToolTip(_text, tag.Label);
            _text.Click += OnClick;

            _deleteButton.Name = "Delete";
            _deleteButton.Text = "❌";
            _deleteButton.TextAlign = ContentAlignment.TopCenter;
            _deleteButton.Font = new Font("Arial", 7.2f, FontStyle.Bold);
            _deleteButton.TabIndex = 1;
            _deleteButton.Anchor = AnchorStyles.Right;
            _deleteButton.Location = new Point(70 ,1);
            _deleteButton.Margin = new Padding(0);
            _deleteButton.Padding = new Padding(1, 0, 0, 0);
            _deleteButton.MinimumSize = new Size(21, 21);
            _deleteButton.MaximumSize = new Size(21, 21);
            _deleteButton.BackColor = Color.FromArgb(0, 0, 0, 0);
            _deleteButton.FlatStyle = FlatStyle.Flat;
            _deleteButton.FlatAppearance.BorderColor = Color.Black;
            _deleteButton.FlatAppearance.BorderSize = 0;
            _deleteButton.ForeColor = Color.Red;
            _deleteButton.UseVisualStyleBackColor = false;
            _deleteButton.Click += OnDelete;
            _deleteButton.MouseEnter += HoverButton;
            _deleteButton.MouseLeave += UnhoverButton;

            _text.Controls.Add(_deleteButton);
            Controls.Add(_text);

            _deleteButton.ResumeLayout(true);
            _text.ResumeLayout(true);
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            ResumeLayout(true);
        }


        public void Highlight(bool selected)
        {
            if (selected)
            {
                Parent.ChildSelected(this);
                _text.BackColor = HighlightColor;
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
            }
            else
            {
                var node = new TaggedNode(Parent, tag);
                //node.SuspendLayout();
                int index = Parent.IndexOf(this);
                Parent.ReplaceChildAt(index, node);
                Parent = node;
                node.AddNeighbour(this, tag);
                neighbour.Parent = node;
                node.AddNeighbour(neighbour, tag);
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
            //Parent.RemoveChild(this);
            Highlight(true);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            Parent.Freeze();
            Parent.RemoveChild(this);
            Parent.Unfreeze();
        }

        private void HoverButton(object sender, EventArgs e)
        {
            _deleteButton.BackColor = _text.BackColor;
            var location = _deleteButton.Location;
            location.Y = 1;
            _deleteButton.Location = location;
            _deleteButton.FlatAppearance.BorderSize = 1;
        }

        private void UnhoverButton(object sender, EventArgs e)
        {
            _deleteButton.BackColor = Color.FromArgb(0, 0, 0, 0);
            var location = _deleteButton.Location;
            location.Y = 2;
            _deleteButton.Location = location;
            _deleteButton.FlatAppearance.BorderSize = 0;
        }

        public override string ToString()
        {
            return $"Leaf#{_count.ToString("X2")} > {Parent.ToString()}";
        }
    }
}
