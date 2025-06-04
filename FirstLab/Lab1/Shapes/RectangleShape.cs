using BaseShape;
namespace Lab1.Shapes;

public class RectangleShape : Shape
{

    public RectangleShape()
    {
        shapeType = "Rectangle";
    }

    public override void Draw(Graphics shape, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
    {

        int x1 = Math.Min(startPoint.X, currentPoint.X);
        int y1 = Math.Min(startPoint.Y, currentPoint.Y);
        int x2 = Math.Max(startPoint.X, currentPoint.X);
        int y2 = Math.Max(startPoint.Y, currentPoint.Y);

        int width = x2 - x1;
        int height = y2 - y1;

        if (pen != null)
        {
            shape.DrawRectangle(pen, x1, y1, width, height);
        }
        if (brush != null)
        {
            shape.FillRectangle(brush, x1, y1, width, height);
        }
    }
}