using BaseShape;
using Lab1.Shapes;
using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab1
{
    internal class ShapeLoadingManager
    {


        public List<Shape> LoadShapesFromFiles(string shapeFolderPath)
        {
            List<Shape> shapes = new List<Shape>();

            var shapeFiles = Directory.GetFiles(shapeFolderPath, "*.cs")
                                      .Select(file => Path.GetFileNameWithoutExtension(file))
                                      .Where(name => name.EndsWith("Shape") && name != "Shape")
                                      .Select(name => name.Replace("Shape", ""))
                                      .ToList();

            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (var shapeName in shapeFiles)
            {
                Type shapeType = assembly.GetType($"Lab1.Shapes.{shapeName}Shape");
                if (shapeType != null && typeof(Shape).IsAssignableFrom(shapeType))
                {
                    Shape shapeInstance = Activator.CreateInstance(shapeType) as Shape;
                    if (shapeInstance != null)
                    {
                        shapes.Add(shapeInstance);
                    }
                }
            }

            return shapes;
        }

        public List<Shape> LoadShapesFromDLL(string dllPath)
        {
            List<Shape> shapes = new List<Shape>();
            Assembly assembly = Assembly.LoadFrom(dllPath);

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(Shape).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    Shape shapeInstance = Activator.CreateInstance(type) as Shape;
                    if (shapeInstance != null)
                    {
                        shapes.Add(shapeInstance);
                    }
                }
            }

            return shapes;
        }

        public List<string> GetShapesFromDLL(string dllPath)
        {
            List<string> shapeNames = new List<string>();
            Assembly assembly = Assembly.LoadFrom(dllPath);

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(Shape).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    shapeNames.Add(type.Name);
                }
            }

            return shapeNames;
        }



        public List<string> openAction(OpenFileDialog openFileDialog, List<Shape> shapes)
        {
            openFileDialog.Filter = ".dll files (*.dll)|*.dll";
            openFileDialog.Title = "Open Shape List";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    shapes.AddRange(LoadShapesFromDLL(filePath));
                    return GetShapesFromDLL(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading plugins: {ex.Message}");
                }
            }
            return null;
          
        }
    }

}
