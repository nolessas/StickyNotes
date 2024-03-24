//ColorManager.cs
using System.Collections.Generic;
using System.Drawing;

namespace StickyNote9
{
    public class ColorManager
    {
        private readonly List<Color> pastelColors;
        private int currentIndex = 0;

        public ColorManager()
        {
            // Define colors using RGB values to avoid any potential naming conflicts
            pastelColors = new List<Color>
            {
                Color.FromArgb(255, 182, 193),  // Pastel Pink
                Color.FromArgb(255, 255, 192),  // Pastel Yellow
                Color.FromArgb(173, 216, 230),  // Pastel Blue
                Color.FromArgb(144, 238, 144),  // Pastel Green
                Color.FromArgb(240, 128, 128)   // Pastel Coral
            };
        }

        public Color GetNextColor()
        {
            currentIndex = (currentIndex + 1) % pastelColors.Count;
            return pastelColors[currentIndex];
        }

        public Color GetCurrentColor()
        {
            return pastelColors[currentIndex];
        }
    }
}
