using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public interface ITaggedChild
    {
        Control AsControl { get; }
        ITaggedParent Parent { get; set; }

        void Highlight(bool selected);
        void AddNeighbour(TaggedLeaf neighbour, ColorTag tag);
        void UpdateWidth(int width);
        void AppendTo(ITaggedParent newParent, int at);
    }
}