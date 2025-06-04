using BaseShape;
using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class UndoRedoManager
    {

        public bool redoAction(List<Shape> _shapeListHistory, List<Shape> _shapeList)
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

        public bool undoAction(List<Shape> _shapeListHistory, List<Shape> _shapeList)
        {
            if (_shapeList.Count > 0)
            {
                _shapeList.RemoveAt(_shapeList.Count - 1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
