using Microsoft.Maui.Graphics;

namespace MAUI_Test.Models
{
    public class OrderItem
    {
        public string Invoice { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // Process, Open, On Hold
        public Color StatusColor { get; set; } = Colors.White;
        public Color StatusBg { get; set; } = Colors.Black;
    }
}
