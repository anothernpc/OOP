namespace Lab1.Shapes;

public class Shape
{
    public Shape()
    {
    }
    public virtual void Draw(Graphics shape, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
    {
    }
    
    public Pen pen;
    public Brush brush;
    public Point startPoint;
    public Point currentPoint;
    public Point[] points = [];
}