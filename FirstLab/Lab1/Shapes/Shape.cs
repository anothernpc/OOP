namespace Lab1.Shapes;

public class Shape
{
    static int _randomPenWidth = 10;
    public Shape()
    {
    }
    public virtual void Draw(Graphics shape, Pen pen)
    {
    }
    private static Pen getRandomPen()
    {
        Random random = new Random();
        int red = random.Next(0, 256);
        int green = random.Next(0, 256);
        int blue = random.Next(0, 256);
        int penWidth = random.Next(0, _randomPenWidth);
        Color randomColor = Color.FromArgb(red, green, blue);
        Pen pen = new Pen(randomColor, penWidth);
        return pen;
    }
    public Pen pen = getRandomPen();
}