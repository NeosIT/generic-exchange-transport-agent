using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public interface ITaggedParent
    {
        ToolTip SharedToolTip { get; }
        ColorTag TagInfo { get; }
        int AvailableSpace { get; }
        Control AsControl { get; }

        void ChildSelected(ITaggedChild child);
        int IndexOf(Control child);
        void InsertAt(Control insert, int index);
        void RemoveChild(Control child);
        void ReplaceChildAt(int index, ITaggedChild insert);
    }
}