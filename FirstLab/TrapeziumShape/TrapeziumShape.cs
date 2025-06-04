using System.Drawing;
using BaseShape;

namespace TrapeziumShape
{

    public class TrapeziumShape : Shape
    {
        public override void Draw(Graphics graphics, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
        {
            PointF[] trapeziumPoints = CalculateTrapeziumPoints(startPoint, currentPoint);

            graphics.FillPolygon(brush, trapeziumPoints);
            graphics.DrawPolygon(pen, trapeziumPoints);
        }
        public TrapeziumShape()
        {
            shapeType = "Trapezium";
        }

        private PointF[] CalculateTrapeziumPoints(Point start, Point end)
        {
            float topWidth = Math.Abs(end.X - start.X) * 0.6f;
            float bottomWidth = Math.Abs(end.X - start.X);
            float height = Math.Abs(end.Y - start.Y);

            float centerX = (start.X + end.X) / 2;
            float topLeftX = centerX - (topWidth / 2);
            float topRightX = centerX + (topWidth / 2);
            float bottomLeftX = start.X;
            float bottomRightX = end.X;

            PointF[] points =
            {
                new PointF(topLeftX, start.Y),      
                new PointF(topRightX, start.Y),     
                new PointF(bottomRightX, end.Y),    
                new PointF(bottomLeftX, end.Y)     
            };

            return points;

        }


    }
    }
