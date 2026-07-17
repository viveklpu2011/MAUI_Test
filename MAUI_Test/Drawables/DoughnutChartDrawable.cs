using Microsoft.Maui.Graphics;

namespace MAUI_Test.Drawables
{
    public class DoughnutChartDrawable : IDrawable
    {
        public float YoutubePercent { get; set; } = 55f;
        public float FacebookPercent { get; set; } = 34f;
        public float DirectPercent { get; set; } = 11f;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float size = System.Math.Min(dirtyRect.Width, dirtyRect.Height);
            if (size <= 0) return;

            float thickness = 28f;
            float margin = 20f;
            float diameter = size - (margin * 2f);
            
            float x = (dirtyRect.Width - diameter) / 2f;
            float y = (dirtyRect.Height - diameter) / 2f;

            RectF arcRect = new RectF(x + thickness / 2f, y + thickness / 2f, diameter - thickness, diameter - thickness);

            canvas.StrokeSize = thickness;
            canvas.StrokeLineCap = LineCap.Butt; // clean edges between segments

            // Total is 100%. Convert percents to angles.
            // 0 degrees is at the right (3 o'clock). Let's start drawing from the top (12 o'clock / 270 degrees or -90 degrees).
            float startAngle = -90f; 

            // 1. YouTube Segment (Red/Orange) - 55%
            float youtubeAngle = (YoutubePercent / 100f) * 360f;
            canvas.StrokeColor = Color.FromArgb("#F97316"); // orange-red
            canvas.DrawArc(arcRect.X, arcRect.Y, arcRect.Width, arcRect.Height, startAngle, startAngle + youtubeAngle, true, false);
            startAngle += youtubeAngle;

            // 2. Facebook Segment (Blue) - 34%
            float facebookAngle = (FacebookPercent / 100f) * 360f;
            canvas.StrokeColor = Color.FromArgb("#3B82F6"); // blue
            canvas.DrawArc(arcRect.X, arcRect.Y, arcRect.Width, arcRect.Height, startAngle, startAngle + facebookAngle, true, false);
            startAngle += facebookAngle;

            // 3. Direct Search Segment (Yellow) - 11%
            float directAngle = (DirectPercent / 100f) * 360f;
            canvas.StrokeColor = Color.FromArgb("#EAB308"); // gold yellow
            canvas.DrawArc(arcRect.X, arcRect.Y, arcRect.Width, arcRect.Height, startAngle, startAngle + directAngle, true, false);
        }
    }
}
