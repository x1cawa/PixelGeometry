using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ConsoleGeometry.Geometry.Printable
{
    public static class ColorExtension
    {
        public static ConsoleColor ToConsoleColor(this Color color)
        {
            int index = (color.R > 128 | color.G > 128 | color.B > 128) ? 8 : 0; //bright bit
            index |= (color.R > 64) ? 4 : 0; //Red bit
            index |= (color.G > 64) ? 2 : 0; //Green bit
            index |= (color.B > 64) ? 1 : 0; //Blue bit
            return (ConsoleColor)index;
        }

        public static Color ToColor(this ConsoleColor color)
        {
            int index = (int)color;
            int brightness = ((index & 8) > 0) ? 2 : 1;
            int r = ((index & 4) > 0) ? 64 * brightness : 0;
            int g = ((index & 2) > 0) ? 64 * brightness : 0;
            int b = ((index & 1) > 0) ? 64 * brightness : 0;
            return Color.FromArgb(r, g, b);
        }
    }
}
