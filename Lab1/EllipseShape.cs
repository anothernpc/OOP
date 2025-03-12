namespace Lab1;

public class EllipseShape : Shape
{
    private int _x, _y, _width, _height;
    static int _randomTopBorder = 1000;
    
    public EllipseShape()
    {
        var rand = new Random();
        _x = rand.Next(0, _randomTopBorder);
        _y = rand.Next(0, _randomTopBorder);
        _width = rand.Next(0, _randomTopBorder);
        _height = rand.Next(0, _randomTopBorder);
    }

    public override void Draw(Graphics shape, Pen pen)
    {
        shape.DrawEllipse(pen, _x, _y, _width, _height);
    }
    
}
