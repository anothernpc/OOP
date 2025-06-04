using System.Drawing;
using BaseShape;

namespace StarShapeLibrary
{
    public class StarShape : Shape
    {
        public override void Draw(Graphics graphics, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
        {
            PointF[] starPoints = CalculateStarPoints(startPoint, currentPoint);

            graphics.FillPolygon(brush, starPoints);
            graphics.DrawPolygon(pen, starPoints);
        }

        private PointF[] CalculateStarPoints(Point start, Point end)
        {
            float centerX = (start.X + end.X) / 2;
            float centerY = (start.Y + end.Y) / 2;
            float radius = Math.Abs(start.X - end.X) / 2;

            PointF[] points = new PointF[10];

            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI / 5 * i;
                float factor = (i % 2 == 0) ? 1.0f : 0.4f; 
                points[i] = new PointF(
                    centerX + radius * factor * (float)Math.Cos(angle),
                    centerY - radius * factor * (float)Math.Sin(angle)
                );
            }

            return points;
        }
    }
}
