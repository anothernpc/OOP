namespace Lab1.Shapes;

public class PolygonShape : Shape
{
    private Point[] _points = [];

    public PolygonShape()
    {
    }
    
    public override void Draw(Graphics shape, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
    {
        Array.Resize(ref _points, points.Length + 1);
        points.CopyTo(_points, 0);
        _points[_points.Length - 1] = (Point)currentPoint;
        if (pen != null)
        {
            shape.DrawPolygon(pen, _points);
        }
        if (brush != null)
        {
            shape.FillPolygon(brush, _points);
        }
 
    }
}