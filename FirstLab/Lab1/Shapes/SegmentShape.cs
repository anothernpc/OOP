namespace Lab1.Shapes;

public class SegmentShape : Shape
{
    private int _x1, _y1, _x2, _y2;
    static int _randomTopBorder = 1000;

    public SegmentShape() 
    {
        var rand = new Random();
        _x1 = rand.Next(0, _randomTopBorder);
        _y1 = rand.Next(0, _randomTopBorder);
        _x2 = rand.Next(0, _randomTopBorder);
        _y2 = rand.Next(0, _randomTopBorder);
    }
    
    public override void Draw(Graphics shape, Pen pen)
    {
        shape.DrawLine(pen, _x1, _y1, _x2, _y2);
    }
}