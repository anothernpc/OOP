namespace Lab1.Shapes;

public class BrokenLineShape : Shape
{
    private Point[] _points;
    static int _randomTopBorder = 1000;
    static int _randomPointsAmountBorder = 20;

    public BrokenLineShape()
    {
        var rand = new Random();
        _points = new Point[rand.Next(1, _randomPointsAmountBorder)];
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = new Point(rand.Next(0, _randomTopBorder), rand.Next(0, _randomTopBorder));
        }
    }

    public override void Draw(Graphics shape, Pen pen, Brush brush)
    {
        shape.DrawLines(pen, _points);
    }
}