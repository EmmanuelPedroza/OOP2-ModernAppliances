using System;
using System.IO;
using ModernAppliances.Classes.BaseClass;

namespace ModernAppliances.Helpers
{
    /// <summary>
    /// Provides helper methods for file operations related to appliances.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Gets the full file path for a given file name.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The full file path.</returns>
        public static string GetFilePath(string fileName)
        {
            // dir for the txt file relative to the exe or dll file
            string currentDirectory = Directory.GetCurrentDirectory();
            // dir for the txt file relative to the c# file
            string projDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
            
            return Path.Combine(projDirectory, fileName);
        }

        /// <summary>
        /// Saves a list of appliances to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to save to.</param>
        /// <param name="appliances">The list of appliances to save.</param>
        public static void SaveToFile(string fileName, List<Appliance> appliances)
        {
            string filePath = GetFilePath(fileName);
            string[] lines = appliances.Select(appliance => appliance.FormatForFile()).ToArray();
            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Reads all lines from a file.
        /// </summary>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <returns>An array of strings, each representing a line from the file.</returns>
        public static string[] ReadFromFile(string fileName)
        {
            string filePath = GetFilePath(fileName);
            return File.ReadAllLines(filePath);
        }
    }
}