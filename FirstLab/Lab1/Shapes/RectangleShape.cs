namespace Lab1.Shapes;

public class RectangleShape : Shape
{
    private int _x, _y, _width, _height;
    static int _randomTopBorder = 1000;

    public RectangleShape()
    {
        var rand = new Random();
        _x = rand.Next(0, _randomTopBorder);
        _y = rand.Next(0, _randomTopBorder);
        _width = rand.Next(0, _randomTopBorder);
        _height = rand.Next(0, _randomTopBorder);
        //MessageBox.Show($"{_x.ToString()}, {_y.ToString()}, {_width.ToString()}, {_height.ToString()}");
    }

    public override void Draw(Graphics shape, Pen pen, Brush brush)
    {
        shape.DrawRectangle(pen, _x, _y, _width, _height);
        shape.FillRectangle(brush, _x, _y, _width, _height);

    }
}