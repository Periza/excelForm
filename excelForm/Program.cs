using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch(Win32Exception ex)
            {
                Debug.WriteLine("debug exception");
                string message = ex.Message;
                int index = message.IndexOf('\"');
                if (index >= 0)
                {
                    int index2 = message.IndexOf('\"', index + 1);
                    if (index2 >= 0)
                    {
                        string filePath = message.Substring(index + 1, index2 - index - 1);
                        Console.WriteLine("The file path is: " + filePath);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine("fnf exception");
                Console.WriteLine("File not found: " + ex.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
