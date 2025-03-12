namespace Lab1.Shapes;

public class PolygonShape : Shape
{
    private Point[] _points;
    static int _randomTopBorder = 1000;
    static int _randomPointsAmountTopBorder = 20;
    static int _randomPointsAmountBottomBorder = 3;

    public PolygonShape()
    {
        var rand = new Random();
        _points = new Point[rand.Next(_randomPointsAmountBottomBorder, _randomPointsAmountTopBorder)];
        Point center = new Point(rand.Next(0, _randomTopBorder), rand.Next(0, _randomTopBorder));
        int radius = rand.Next(0, _randomTopBorder);
        // for (int i = 0; i < _points.Length; i++)
        // {
        //     _points[i] = new Point(rand.Next(0, _randomTopBorder), rand.Next(0, _randomTopBorder));
        // }
        
        for (int i = 0; i < _points.Length; i++)
        {
            double angle = 2 * Math.PI * i / _points.Length; 
            _points[i] = new Point(
                center.X + (int)(radius * Math.Cos(angle)),
                center.Y + (int)(radius * Math.Sin(angle))
            );
        }
    }
    
    public override void Draw(Graphics shape, Pen pen)
    {
        shape.DrawPolygon(pen, _points);
    }
}