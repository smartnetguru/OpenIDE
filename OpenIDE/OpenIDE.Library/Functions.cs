using System.Drawing;

namespace OpenIDE.Library
{
    public class Functions
    {
        public static Color Argb(int red, int green, int blue, int alpha)
        {
            return Color.FromArgb(alpha, red, green, blue);
        }

        public static Color Hsla(double hue, double saturation, double luminosity, int alpha)
        {
            var c = (Color)new HSLColor(hue, saturation, luminosity);
            
            return Color.FromArgb(alpha, c);
        }

        public static Color Hexadecimal(string src)
        {
            return ColorTranslator.FromHtml(src);
        }
    }
}