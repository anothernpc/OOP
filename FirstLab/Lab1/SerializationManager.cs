using BaseShape;
using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab1
{
    class SerializationManager
    {

        public List<Shape>? openAction(OpenFileDialog openFileDialog, ShapeList shapeList, List<Shape> shapes)
        {

            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Open Shape List";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string json = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions { IncludeFields = true };
                    List<Shape>? deserializedList = JsonSerializer.Deserialize<List<Shape>>(json, options);
                    List<Shape> newList = new List<Shape>();
                    if (deserializedList != null)
                    {
                        foreach (Shape shape in deserializedList)
                        {
                            shape?.RestoreGraphics();
                            Shape detectedShape = shapeList.DetectShape(shapes, shape.shapeType);
                          
                            if (detectedShape != null)
                            {
                                Shape newShape = Activator.CreateInstance(detectedShape.GetType()) as Shape;
                                
                                if (newShape != null)
                                {
                                    newShape.pen = shape.pen;
                                    newShape.brush = shape.brush;
                                    newShape.startPoint = shape.startPoint;
                                    newShape.currentPoint = shape.currentPoint;
                                    newShape.points = shape.points;

                                    newShape.brushColor = shape.brushColor;
                                    newShape.penColor = shape.penColor;
                                    newShape.shapeType = shape.shapeType;
                                    newShape.strokeThickness = shape.strokeThickness;
                                }
                                newList.Add(newShape);

                            }

                            
                        }
                    }
                    return newList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading JSON: {ex.Message}");
                }
            }

            return null ;
        }


        public void saveAction(List<Shape> _shapeList, SaveFileDialog saveFileDialog)
        {
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Save Shape List";
            saveFileDialog.DefaultExt = "json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                
                var options = new JsonSerializerOptions { WriteIndented = true, IgnoreReadOnlyProperties = true, IncludeFields = true }; 
                foreach (Shape shape in _shapeList)
                {
                    shape.penColor  = ColorTranslator.ToHtml(shape.pen.Color);
                    shape.brushColor = ColorTranslator.ToHtml((shape.brush as SolidBrush).Color);
                    shape.strokeThickness = shape.pen.Width;
                }
                string json = JsonSerializer.Serialize(_shapeList, options);

                File.WriteAllText(filePath, json);
            }
        }
    }
}
