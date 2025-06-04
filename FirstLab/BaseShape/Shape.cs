using System.Text.Json.Serialization;
using System.Drawing;

namespace BaseShape;

public class Shape
{
    public Shape()
    {
    }
    public virtual void Draw(Graphics shape, Pen pen, Brush brush, Point startPoint, Point currentPoint, Point[] points)
    {
    }
    public void RestoreGraphics()
    {
        Color pensActualColor = ColorTranslator.FromHtml(penColor);
        pen = new Pen(pensActualColor, strokeThickness);
        Color brushesActualColor = ColorTranslator.FromHtml(brushColor);
        brush = new SolidBrush(brushesActualColor);
    }


    [JsonIgnore]
    public Pen pen;
    [JsonIgnore]
    public Brush brush;
    public Point startPoint;
    public Point currentPoint;
    public Point[] points = [];
    public string penColor;
    public string brushColor;
    public float strokeThickness;
    public string shapeType;
}