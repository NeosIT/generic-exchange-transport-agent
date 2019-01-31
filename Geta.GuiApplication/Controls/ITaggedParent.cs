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
        int IndexOf(ITaggedChild child);
        void InsertAt(ITaggedChild insert, int index);
        void RemoveChild(ITaggedChild child);
        void ReplaceChildAt(int index, ITaggedChild insert);
    }
}
