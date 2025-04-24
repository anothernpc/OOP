using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ShapeList
    {
        List<Shape> _shapeList = new List<Shape>();
        List<Shape> _shapeListHistory = new List<Shape>();

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

        public bool undoAction()
        {
            if (_shapeList.Count > 0)
            {
                _shapeList.RemoveAt(_shapeList.Count - 1);
                return true;
            } else
            {
                return false;
            }
        }



        public bool redoAction() 
        {
            if (_shapeListHistory.Count > _shapeList.Count)
            {
                _shapeList.Add(_shapeListHistory[_shapeList.Count]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void openAction()
        {
            string filePath = "shapes.json";

            Program.SaveListToJsonFile(_shapeList, filePath);
        }


        public void saveAction()
        {
        }
    }
}
