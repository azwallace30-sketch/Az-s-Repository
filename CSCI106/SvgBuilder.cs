using System;

namespace CSCI106
{
    public class SvgBuilder
    {
        private const string SVG_HEADER_TEMPLATE = "<svg width=\"{0}\" height=\"{1}\" xmlns=\"http://www.w3.org/2000/svg\">";
        private const string SVG_FOOTER = "</svg>";

        private string Buffer = "";

        private uint Width;
        private uint Height;

        public static SvgBuilder New((uint, uint) dimensions)
        {
            var (width, height) = dimensions;

            return new SvgBuilder
            {
                Buffer = string.Empty,
                Width = width,
                Height = height,
            };
        }

        public string Build() =>
            string.Format(SVG_HEADER_TEMPLATE, Width, Height)
                + Buffer
                + SVG_FOOTER;

        private bool IsValidRectangle(int x, int y, int width, int height)
        {
            if (width <= 0 || height <= 0)
                return false;

            // Completely off screen (left/top)
            if (x + width <= 0 || y + height <= 0)
                return false;

            // Starts outside (right/bottom)
            if (x >= Width || y >= Height)
                return false;

            // Goes outside bounds
            if (x + width > Width || y + height > Height)
                return false;

            return true;
        }

        public void AddRectangle(int x, int y, int width, int height, string fill, string stroke)
        {
            if (!IsValidRectangle(x, y, width, height))
            {
                throw new ArgumentException("Invalid rectangle: must have positive dimensions and be inside the SVG.");
            }

            Buffer += $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" fill=\"{fill}\""
                   + (string.IsNullOrWhiteSpace(stroke) ? "" : $" stroke=\"{stroke}\"")
                   + " />";
        }

        // 🔗 Allows parser to plug into builder
        public void AddRectangle(Rectangle rect)
        {
            AddRectangle(rect.X, rect.Y, rect.Width, rect.Height, rect.Fill, rect.Stroke);
        }
    }
}