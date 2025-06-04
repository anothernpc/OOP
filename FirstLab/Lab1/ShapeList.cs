using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseShape;

namespace Lab1
{
    class ShapeList
    {
        public List<Shape> _shapeList = new List<Shape>();
        public List<Shape> _shapeListHistory = new List<Shape>();
        SerializationManager serializerManager = new SerializationManager();
        ShapeLoadingManager shapeLoadingManager = new ShapeLoadingManager();
        Point? startPoint = null;
        Point? currentPoint = null;
        Point[] pointsArray = [];

        public Shape DetectShape(List<Shape> shapes, string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("No figure selected", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Shape foundShape = shapes.FirstOrDefault(shape => (shape.GetType().Name == className+"Shape") || (shape.GetType().Name == className) );

            if (foundShape != null)
            {
                return (Shape)Activator.CreateInstance(foundShape.GetType()); 
            }

            MessageBox.Show($"Figure {className} not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }


        public void paintShapeList(Graphics figure)
        {
            for (int i = 0; i < _shapeList.Count; i++)
            {
                _shapeList[i].Draw(figure, _shapeList[i].pen, _shapeList[i].brush, _shapeList[i].startPoint, _shapeList[i].currentPoint, _shapeList[i].points);
            }
        }

        public void drawNewShape(Shape shape, Pen currentPen, Brush currentBrush, Point startPoint, Point currentPoint, Point[] points)
        {
            _shapeListHistory.Clear();
            _shapeListHistory.AddRange(_shapeList);
            makeShape(shape, currentPen, currentBrush, startPoint, currentPoint, points);
            _shapeList.Add(shape);
            _shapeListHistory.Add(shape);
        }

        public void makeShape(Shape shape, Pen currentPen, Brush currentBrush, Point startPoint, Point currentPoint, Point[] points)
        {
            shape.pen = new Pen(currentPen.Color, currentPen.Width);
            shape.brush = currentBrush;
            shape.startPoint = startPoint;
            shape.currentPoint = currentPoint;
            Array.Resize(ref shape.points, points.Length);
            points.CopyTo(shape.points, 0);
        }

        public bool createShape(Graphics figure, Shape shape, Pen currentPen, Brush currentBrush)
        {


            if (shape != null && startPoint != null && currentPoint != null)
            {
                drawNewShape(shape, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
                return true;
            }
            return false;
        }

        //public void createPreview(Graphics figure, Shape shape, Pen currentPen, Brush currentBrush)
        //{
        //    if (shape != null && startPoint != null && currentPoint != null)
        //    {
        //        makeShape(shape, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
        //        pctbMain.Refresh();
        //        paintShapeList(figure);
        //        shape.Draw(figure, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
        //    }
        //}

        public void onPaintEvent(Shape shape, Graphics shapeToPaint, Pen currentPen, Brush currentBrush)
        {
            if (startPoint.HasValue && currentPoint.HasValue && (pointsArray.Length > 0))
            {
                paintShapeList(shapeToPaint);
                shape.Draw(shapeToPaint, currentPen, currentBrush, (Point)startPoint, (Point)currentPoint, pointsArray);
            }
        }

        public void startPreview(Point location)
        {
            startPoint = location;
            Array.Resize(ref pointsArray, pointsArray.Length + 1);
            pointsArray[pointsArray.Length - 1] = (Point)startPoint;
        }

        public bool savePreview(Graphics figure, Shape shape, Pen currentPen, Brush currentBrush)
        {
            Array.Resize(ref pointsArray, pointsArray.Length + 1);
            pointsArray[pointsArray.Length - 1] = (Point)currentPoint;
            bool result = createShape(figure, shape, currentPen, currentBrush);

            startPoint = null;
            currentPoint = null;
            Array.Clear(pointsArray, 0, pointsArray.Length);
            Array.Resize(ref pointsArray, 0);
            return result;
        }

        public bool mouseMoveEvent(object? selectedItem, Point location)
        {
            if (universalCheck(false, true, selectedItem))
            {
                currentPoint = location;
                return true;

            }
            return false;
        }
        public bool universalCheck(bool shouldCheckShape, bool shouldCheckStartPoint, object? selectedItem)
        {
            bool isOkay = true;
            if (shouldCheckShape && (selectedItem == null))
            {
                isOkay = false;
            }
            if (shouldCheckStartPoint && !startPoint.HasValue)
            {
                isOkay = false;
            }

            return isOkay;
        }

        public void openAction(OpenFileDialog openFileDialog, ShapeList shapeList, List<Shape> shapes)
        {
            _shapeList.Clear();
            _shapeListHistory.Clear();
            try
            {
                _shapeList.AddRange(serializerManager.openAction(openFileDialog, shapeList, shapes));
                _shapeListHistory.AddRange(_shapeList);
            }
            catch (Exception ex) { 
            
            }
            
        }

        public void saveAction(SaveFileDialog saveFileDialog)
        {
            serializerManager.saveAction(_shapeList, saveFileDialog);
        }
    }
}
