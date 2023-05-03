using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExcelForm
{
    internal class Helpers
    {
        public static bool validDate(string dateString, string format)
        {
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static DateTime convertToDateTime(string dateString, string format = "dd.MM.yyyy")
        {
            if (validDate(dateString, format))
                return DateTime.ParseExact(dateString, format, null);
            throw new Exception("Invalid date format");
        }

        static int FindLineNumber(string tableName, string searchStr)
        {
            try
            {
                using (StreamReader reader = new StreamReader($"{AppSettings.Instance.ProjectPath}\\{tableName}.d"))
                {
                    string line;
                    int lineNumber = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (line.Contains(searchStr))
                        {
                            return lineNumber + 2;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }

            return -1; // If search string not found, return -1
        }

        static void ReplaceLine(string filePath, int lineNumber, string replacementString)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Debug.WriteLine(lines);
                if (lineNumber > 0 && lineNumber <= lines.Length)
                {
                    lines[lineNumber - 1] = replacementString;
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine($"Line {lineNumber} was successfully replaced with '{replacementString}'.");
                }
                else
                {
                    Console.WriteLine($"Error: Line number {lineNumber} is out of range.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading/writing file: {e.Message}");
            }
        }

        public static void editLine(string tableName, string searchStr)
        {
            int lineNumber = FindLineNumber(tableName, searchStr);
            ReplaceLine($"{AppSettings.Instance.ProjectPath}\\{tableName}.d", lineNumber, "dd.MM.yyyy");
        }
    }
}
