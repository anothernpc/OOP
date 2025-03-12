namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ShapeList _shapeList = new ShapeList();
        static int _randomPenWidth = 10;

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
                _shapeList[i].Draw(figure, _shapeList[i].pen);
            }
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Graphics figure = pctbMain.CreateGraphics();
            Shape shape = DetectShape();
            if (shape != null)
            {
                _shapeList.Add(shape);
                pctbMain.Refresh();
                paintList();
            }
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_shapeList.Count > 0)
            {
                _shapeList.RemoveAt(_shapeList.Count - 1);
            }
            pctbMain.Refresh();
            paintList();
        }

        private void pctbMain_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
