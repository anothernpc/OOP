using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab1
{
    class SerializationManager
    {
        public List<Shape> openAction(OpenFileDialog openFileDialog)
        {

            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Open Shape List";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<Shape>>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading JSON: {ex.Message}");
                }
            }

            return null;
        }


        public void saveAction(List<Shape> _shapeList, SaveFileDialog saveFileDialog)
        {
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Save Shape List";
            saveFileDialog.DefaultExt = "json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                
                var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true }; 
                string json = JsonSerializer.Serialize(_shapeList, options);

                File.WriteAllText(filePath, json);
            }
        }
    }
}
