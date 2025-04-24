using Lab1.Shapes;
using System.Collections.Frozen;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        string shapeFolderPath = @"..\..\..\Shapes";
        public Form1()
        {
            InitializeComponent();
            var shapeFiles = Directory.GetFiles(shapeFolderPath, "*.cs")
                                  .Select(file => Path.GetFileNameWithoutExtension(file))
                                  .Where(name => name.EndsWith("Shape") && (name != "Shape"))
                                  .Select(name => name.Replace("Shape", ""))
                                  .ToList();
            foreach (var shapeFile in shapeFiles)
            {
                //проверки на валидный класс не будет мне оч впадлу
                cbSelectShape.Items.Add(shapeFile);
            }
        }

        ShapeList shapeListsManager = new ShapeList();
        Pen currentPen = new Pen(Color.Black);
        Brush currentBrush;
        Point? startPoint = null;
        Point? currentPoint = null;
        Point[] pointsArray = [];

        private Shape DetectShape(string className)
        {
            if (className != null)
            {
                Type type = Type.GetType($"Lab1.Shapes.{className}Shape");
                if (type != null)
                {
                    object instance = Activator.CreateInstance(type);
                    return instance as Shape;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                MessageBox.Show("No figure selected", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        public void paintList()
        {
            Graphics figure = pctbMain.CreateGraphics();
            shapeListsManager.paintShapeList(figure);
        }

        public void createShape()
        {
            Graphics figure = pctbMain.CreateGraphics();
            Shape shape = DetectShape(cbSelectShape.SelectedItem.ToString());
            if (shape != null && startPoint != null && currentPoint != null)
            {
                shapeListsManager.drawNewShape(shape, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
                pctbMain.Refresh();
                paintList();
            }
        }

        public void createPreview()
        {
            Graphics figure = pctbMain.CreateGraphics();
            Shape shape = DetectShape(cbSelectShape.SelectedItem.ToString());
            if (shape != null && startPoint != null && currentPoint != null)
            {
                //pctbMain.Refresh();
                //paintList();
                shapeListsManager.makeShape(shape, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
                pctbMain.Refresh();
                paintList();
                shape.Draw(figure, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
            }
        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            createShape();
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (shapeListsManager.undoAction())
            {
                pctbMain.Refresh();
                paintList();
            }

        }

        private void pctbMain_Paint(object sender, PaintEventArgs e)
        {
            if (startPoint.HasValue && currentPoint.HasValue && (pointsArray.Length > 0))
            {
                Shape shape = DetectShape(cbSelectShape.SelectedItem.ToString());
                shapeListsManager.paintShapeList(e.Graphics);
                shape.Draw(e.Graphics, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
            }
        }

        private void trbrThickness_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trbrThickness.Value;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (shapeListsManager.redoAction())
            {
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



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeListsManager.openAction();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeListsManager.saveAction();
        }

        private void pctbMain_Click(object sender, EventArgs e)
        {

        }

        private void pctbMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                Array.Resize(ref pointsArray, pointsArray.Length + 1);
                pointsArray[pointsArray.Length - 1] = (Point)startPoint;
            }
        }

        private void pctbMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (universalCheck(false, true))
            {
                currentPoint = e.Location;
                pctbMain.Invalidate();
            }
        }

        private void pctbMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && universalCheck(false, true))
            {
                Array.Resize(ref pointsArray, pointsArray.Length + 1);
                pointsArray[pointsArray.Length - 1] = (Point)currentPoint;
                createShape();

                startPoint = null;
                currentPoint = null;
                Array.Clear(pointsArray, 0, pointsArray.Length);
                Array.Resize(ref pointsArray, 0);
            }
        }

        private void pctbMain_Paint_1(object sender, PaintEventArgs e)
        {
            if (universalCheck(true, true))
            {
                Shape shape = DetectShape(cbSelectShape.SelectedItem.ToString());
                shapeListsManager.paintShapeList(e.Graphics);
                shape.Draw(e.Graphics, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
            }
        }

        private bool universalCheck(bool shouldCheckShape, bool shouldCheckStartPoint)
        {
            bool isOkay = true;
            if (shouldCheckShape && (cbSelectShape.SelectedItem == null))
            {
                isOkay = false;
            }
            if (shouldCheckStartPoint && !startPoint.HasValue)
            {
                isOkay = false;
            }

            return isOkay;
        }
    }
}
