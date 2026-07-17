using Microsoft.Maui.Graphics;
using System;

namespace MAUI_Test.Drawables
{
    public enum MiniChartType
    {
        BlueBars,
        YellowArea,
        RedLine,
        PurpleBars
    }

    public class MiniChartDrawable : IDrawable
    {
        public MiniChartType ChartType { get; set; } = MiniChartType.BlueBars;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float w = dirtyRect.Width;
            float h = dirtyRect.Height;

            if (w <= 0 || h <= 0) return;

            canvas.Antialias = true;

            switch (ChartType)
            {
                case MiniChartType.BlueBars:
                    DrawBars(canvas, w, h, Color.FromArgb("#3B82F6"));
                    break;
                case MiniChartType.PurpleBars:
                    DrawBars(canvas, w, h, Color.FromArgb("#8B5CF6"));
                    break;
                case MiniChartType.YellowArea:
                    DrawArea(canvas, w, h, Color.FromArgb("#EAB308"), Color.FromArgb("#40EAB308"));
                    break;
                case MiniChartType.RedLine:
                    DrawLine(canvas, w, h, Color.FromArgb("#EF4444"));
                    break;
            }
        }

        private void DrawBars(ICanvas canvas, float w, float h, Color color)
        {
            float[] barHeights = new float[] { 0.4f, 0.7f, 0.5f, 0.8f, 0.3f, 0.9f, 0.6f };
            int count = barHeights.Length;
            float spacing = 4f;
            float totalSpacing = spacing * (count - 1);
            float barWidth = (w - totalSpacing) / count;

            canvas.FillColor = color;

            for (int i = 0; i < count; i++)
            {
                float barH = barHeights[i] * h;
                float x = i * (barWidth + spacing);
                float y = h - barH;
                
                // Draw rounded rectangle for the bar
                canvas.FillRoundedRectangle(x, y, barWidth, barH, 2f);
            }
        }

        private void DrawArea(ICanvas canvas, float w, float h, Color strokeColor, Color fillColor)
        {
            float[] points = new float[] { 0.2f, 0.5f, 0.3f, 0.7f, 0.4f, 0.8f, 0.6f, 0.5f };
            int count = points.Length;
            float step = w / (count - 1);

            PathF path = new PathF();
            PathF fillPath = new PathF();

            float startY = h - points[0] * h;
            path.MoveTo(0, startY);
            fillPath.MoveTo(0, h);
            fillPath.LineTo(0, startY);

            for (int i = 1; i < count; i++)
            {
                float x = i * step;
                float y = h - points[i] * h;
                path.LineTo(x, y);
                fillPath.LineTo(x, y);
            }

            fillPath.LineTo(w, h);
            fillPath.Close();

            // Fill area
            canvas.FillColor = fillColor;
            canvas.FillPath(fillPath);

            // Draw line stroke
            canvas.StrokeColor = strokeColor;
            canvas.StrokeSize = 2f;
            canvas.StrokeLineJoin = LineJoin.Round;
            canvas.DrawPath(path);
        }

        private void DrawLine(ICanvas canvas, float w, float h, Color strokeColor)
        {
            float[] points = new float[] { 0.3f, 0.2f, 0.6f, 0.4f, 0.3f, 0.8f, 0.5f, 0.4f, 0.7f };
            int count = points.Length;
            float step = w / (count - 1);

            PathF path = new PathF();
            float startY = h - points[0] * h;
            path.MoveTo(0, startY);

            for (int i = 1; i < count; i++)
            {
                float x = i * step;
                float y = h - points[i] * h;
                path.LineTo(x, y);
            }

            canvas.StrokeColor = strokeColor;
            canvas.StrokeSize = 2f;
            canvas.StrokeLineJoin = LineJoin.Round;
            canvas.DrawPath(path);
        }
    }
}
