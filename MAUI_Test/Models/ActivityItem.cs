using Microsoft.Maui.Graphics;

namespace MAUI_Test.Models
{
    public class ActivityItem
    {
        public string Time { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconData { get; set; } = string.Empty;
        public Color IconBgColor { get; set; } = Colors.LightGray;
        public Color IconColor { get; set; } = Colors.Gray;
        public bool ShowLine { get; set; } = true;
    }
}
