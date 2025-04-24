using Lab1.Shapes;
using System.Text.Json;

namespace Lab1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static void SaveListToJsonFile(List<Shape> list, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // Makes JSON more readable
            string json = JsonSerializer.Serialize(list, options);
            File.WriteAllText(filePath, json);
        }



        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}