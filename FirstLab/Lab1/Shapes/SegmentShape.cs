using BaseShape;
namespace Lab1.Shapes;

public class SegmentShape : Shape
{
    public int _x1, _y1, _x2, _y2;

    public SegmentShape() 
    {
        shapeType = "Segment";
    }
    
    public override void Draw(Graphics shape, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
    {
        _x1 = startPoint.X;
        _y1 = startPoint.Y;
        _x2 = currentPoint.X;
        _y2 = currentPoint.Y;
        if (pen != null)
        {
            shape.DrawLine(pen, _x1, _y1, _x2, _y2);
        }
    }
}