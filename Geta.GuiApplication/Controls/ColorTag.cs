using System;
using System.Drawing;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls
{
    public class ColorTag : IEquatable<ColorTag>
    {
        public string Label { get; }
        public Color Color { get; }

        public ColorTag(string label, int rgb)
        {
            Label = label;
            Color = Color.FromArgb((rgb >> 16) & 255, (rgb >> 8) & 255, rgb & 255);
        }

        public ColorTag(string label, byte r, byte g, byte b)
        {
            Label = label;
            Color = Color.FromArgb(r, g, b);
        }

        public ColorTag(string label, Color color)
        {
            Label = label;
            Color = Color.FromArgb(255, color);
        }


        public bool Equals(ColorTag other)
        {
            return other != null && Color == other.Color && Label == other.Label;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ColorTag);
        }

        public override int GetHashCode()
        {
            return Color.ToArgb() ^ Label.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{Label}:#{Color.R.ToString("X2")}{Color.G.ToString("X2")}{Color.B.ToString("X2")}]";
        }


        public static bool operator ==(ColorTag a, ColorTag b)
        {
            return (object)a == (object)b || 
                ((object)a != null && (object)b != null &&
                a.Color == b.Color && a.Label == b.Label);
        }

        public static bool operator !=(ColorTag a, ColorTag b)
        {
            return !(a == b);
        }
    }
}