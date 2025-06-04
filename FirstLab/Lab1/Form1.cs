using Lab1.Shapes;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using BaseShape;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        string shapeFolderPath = @"..\..\..\Shapes";
        string dllPath = @"StarShapeLibrary.dll";
        UndoRedoManager undoRedoManager = new UndoRedoManager();
        ShapeList shapeListsManager = new ShapeList();
        public List<Shape> shapes = new List<Shape>();
        ShapeLoadingManager shapeLoadingManager = new ShapeLoadingManager();
        List<string> shapeNames = new List<string>();
        Pen currentPen = new Pen(Color.Black);
        Brush currentBrush;
        Shape currentShape;


        public Form1()
        {
            InitializeComponent();
            shapeNames.Clear();
            var shapeFiles = Directory.GetFiles(shapeFolderPath, "*.cs")
                                  .Select(file => Path.GetFileNameWithoutExtension(file))
                                  .Where(name => name.EndsWith("Shape") && (name != "Shape"))
                                  .Select(name => name.Replace("Shape", ""))
                                  .ToList();
            foreach (var shapeFile in shapeFiles)
            {
                //проверки на валидный класс не будет мне оч впадлу
                shapeNames.Add(shapeFile);
            }

            shapeNames.AddRange(shapeLoadingManager.GetShapesFromDLL(dllPath));
            shapes.AddRange(shapeLoadingManager.LoadShapesFromDLL(dllPath));
            shapes.AddRange(shapeLoadingManager.LoadShapesFromFiles(shapeFolderPath));
            cbSelectShape.Items.Clear();
            cbSelectShape.Items.AddRange(shapeNames.ToArray());
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoRedoManager.undoAction(shapeListsManager._shapeListHistory, shapeListsManager._shapeList))
            {
                pctbMain.Refresh();
                Graphics figure = pctbMain.CreateGraphics();
                shapeListsManager.paintShapeList(figure);
            }

        }

        private void pctbMain_Paint(object sender, PaintEventArgs e)
        {
            if (currentShape != null)
            {
                shapeListsManager.onPaintEvent(currentShape, e.Graphics, currentPen, currentBrush);
            } else
            {
                Graphics figure = pctbMain.CreateGraphics();
                shapeListsManager.paintShapeList(e.Graphics);
            }
        }

        private void trbrThickness_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trbrThickness.Value;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (undoRedoManager.redoAction(shapeListsManager._shapeListHistory, shapeListsManager._shapeList))
            {
                pctbMain.Refresh();
                Graphics figure = pctbMain.CreateGraphics();
                shapeListsManager.paintShapeList(figure);
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
            shapeListsManager.openAction(openFileDialog, shapeListsManager, shapes);
            pctbMain.Invalidate();
            //Graphics figure = pctbMain.CreateGraphics();
            //shapeListsManager.paintShapeList(figure);
            //currentShape = shapeListsManager._shapeList[shapeListsManager._shapeList.Count - 1];
            //currentBrush = currentShape.brush;
            //currentPen = currentShape.pen;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeListsManager.saveAction(saveFileDialog);
        }

        private void pctbMain_Click(object sender, EventArgs e)
        {

        }

        private void pctbMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                shapeListsManager.startPreview(e.Location);
            }
        }

        private void pctbMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (shapeListsManager.mouseMoveEvent(cbSelectShape.SelectedItem, e.Location))
            {
                pctbMain.Invalidate();
            }
        }

        private void pctbMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && shapeListsManager.universalCheck(false, true, cbSelectShape.SelectedItem))
            {
                Graphics figure = pctbMain.CreateGraphics();
                Shape shape = shapeListsManager.DetectShape(shapes, cbSelectShape.SelectedItem.ToString());
                if (shapeListsManager.savePreview(figure, shape, currentPen, currentBrush))
                {
                    pctbMain.Refresh();
                    figure = pctbMain.CreateGraphics();
                    shapeListsManager.paintShapeList(figure);
                }
            }
        }

        private void cbSelectShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentShape = shapeListsManager.DetectShape(shapes, cbSelectShape.SelectedItem.ToString());
        }

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeNames.AddRange(shapeLoadingManager.openAction(openFileDialog, shapes));
            cbSelectShape.Items.Clear();
            cbSelectShape.Items.AddRange(shapeNames.ToArray());
            //currentShape = shapes[shapeListsManager._shapeList.Count - 1];
            //currentBrush = currentShape.brush;
            //currentPen = currentShape.pen;

        }
    }
}
