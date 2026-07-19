namespace MAUI_Test.Drawables
{
    public class LineChartDrawable : IDrawable
    {
        public List<float> BlueData { get; set; } = new List<float> { 2, 13, 7, 14, 12, 27, 4 };
        public List<float> OrangeData { get; set; } = new List<float> { 1, 6, 5, 9, 8, 18, 3 };

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float leftMargin = 30f;
            float rightMargin = 20f;
            float topMargin = 20f;
            float bottomMargin = 30f;

            float plotWidth = dirtyRect.Width - leftMargin - rightMargin;
            float plotHeight = dirtyRect.Height - topMargin - bottomMargin;

            if (plotWidth <= 0 || plotHeight <= 0) return;

            float maxValue = 35f;

            canvas.StrokeColor = Color.FromArgb("#E2E8F0");
            canvas.StrokeSize = 1f;
            canvas.FontColor = Color.FromArgb("#94A3B8");
            canvas.FontSize = 10f;

            int gridSteps = 7;
            for (int i = 0; i <= gridSteps; i++)
            {
                float gridVal = i * 5f;
                float y = topMargin + plotHeight - (gridVal / maxValue) * plotHeight;
                
                canvas.DrawLine(leftMargin, y, leftMargin + plotWidth, y);

                canvas.DrawString(gridVal.ToString(), 5f, y + 4f, HorizontalAlignment.Left);
            }

            int xCount = BlueData.Count;
            float xStep = plotWidth / (xCount - 1);
            for (int i = 0; i < xCount; i++)
            {
                float x = leftMargin + i * xStep;
                canvas.DrawString((i + 1).ToString(), x, topMargin + plotHeight + 18f, HorizontalAlignment.Center);
            }

            DrawSeries(canvas, BlueData, leftMargin, topMargin, plotWidth, plotHeight, maxValue, xStep, Color.FromArgb("#3B82F6"), Color.FromArgb("#103B82F6"), Color.FromArgb("#003B82F6"));

            DrawSeries(canvas, OrangeData, leftMargin, topMargin, plotWidth, plotHeight, maxValue, xStep, Color.FromArgb("#F97316"), Color.FromArgb("#10F97316"), Color.FromArgb("#00F97316"));
        }

        private void DrawSeries(ICanvas canvas, List<float> data, float left, float top, float width, float height, float maxVal, float xStep, Color strokeColor, Color fillStartColor, Color fillEndColor)
        {
            int count = data.Count;
            if (count < 2) return;

            PathF path = new PathF();
            PathF fillPath = new PathF();

            float firstX = left;
            float firstY = top + height - (data[0] / maxVal) * height;
            path.MoveTo(firstX, firstY);
            
            fillPath.MoveTo(left, top + height);
            fillPath.LineTo(firstX, firstY);


            for (int i = 1; i < count; i++)
            {
                float x = left + i * xStep;
                float y = top + height - (data[i] / maxVal) * height;
                path.LineTo(x, y);
                fillPath.LineTo(x, y);
            }

            fillPath.LineTo(left + (count - 1) * xStep, top + height); // bottom-right corner
            fillPath.Close();

            var gradient = new LinearGradientPaint
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1),
                GradientStops = new[]
                {
                    new PaintGradientStop(0f, fillStartColor),
                    new PaintGradientStop(1f, fillEndColor)
                }
            };
            canvas.SetFillPaint(gradient, new RectF(left, top, width, height));
            canvas.FillPath(fillPath);

            canvas.StrokeColor = strokeColor;
            canvas.StrokeSize = 2.5f;
            canvas.StrokeLineJoin = LineJoin.Round;
            canvas.StrokeLineCap = LineCap.Round;
            canvas.DrawPath(path);

            for (int i = 0; i < count; i++)
            {
                float x = left + i * xStep;
                float y = top + height - (data[i] / maxVal) * height;

                canvas.FillColor = Colors.White;
                canvas.FillCircle(x, y, 4.5f);

                canvas.StrokeColor = strokeColor;
                canvas.StrokeSize = 2f;
                canvas.DrawCircle(x, y, 4.5f);
            }
        }
    }
}
