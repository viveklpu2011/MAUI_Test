using Microsoft.Maui.Graphics;

namespace MAUI_Test.Models
{
    public class KpiItem
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string IconData { get; set; } = string.Empty;
        public Color IconColor { get; set; } = Colors.White;
        public Color IconBgColor { get; set; } = Colors.LightGray;
    }
}
