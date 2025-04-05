using Lab1.Shapes;
using System.Collections.Frozen;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ShapeList _shapeList = new ShapeList();
        ShapeList _shapeListHistory = new ShapeList();
        Pen currentPen = new Pen(Color.Black);
        Brush currentBrush; 

        private Shape DetectShape()
        {
            switch (cbSelectShape.SelectedIndex)
            {
                case 0:
                    {
                        return new SegmentShape();
                    }
                case 1:
                    {
                        return new RectangleShape();
                    }
                case 2:
                    {
                        return new EllipseShape();
                    }
                case 3:
                    {
                        return new PolygonShape();
                    }
                case 4:
                    {
                        return new BrokenLineShape();
                    }
                default:
                    MessageBox.Show("No figure selected", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }

        private void paintList()
        {
            Graphics figure = pctbMain.CreateGraphics();
            for (int i = 0; i < _shapeList.Count; i++)
            {
                _shapeList[i].Draw(figure, _shapeList[i].pen, _shapeList[i].brush);
            }
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Graphics figure = pctbMain.CreateGraphics();
            Shape shape = DetectShape();
            if (shape != null)
            {
                shape.pen = new Pen(currentPen.Color, currentPen.Width);
                shape.brush = currentBrush;
                _shapeList.Add(shape);
                _shapeListHistory.Add(shape);
                pctbMain.Refresh();
                paintList();
            }
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_shapeList.Count > 0)
            {
                _shapeList.RemoveAt(_shapeList.Count - 1);
                pctbMain.Refresh();
                paintList();
            }
        }

        private void pctbMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trbrThickness_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trbrThickness.Value;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            
            if (_shapeListHistory.Count > _shapeList.Count)
            {
                _shapeList.Add(_shapeListHistory[_shapeList.Count]);
                pctbMain.Refresh();
                paintList();
            }
        }

        private void pbFillColor_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentBrush = new SolidBrush(colorDialog1.Color);
                pbFillColor.BackColor = colorDialog1.Color;
            }
        }

        private void pbStroke_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentPen.Color = colorDialog1.Color;
                pbStrokeColor.BackColor = colorDialog1.Color;
            }
        }

        private void lblColorFill_Click(object sender, EventArgs e)
        {

        }
    }
}
