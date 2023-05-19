using Microsoft.CSharp;
using Newtonsoft.Json;
using Sculptor.KfLibDNet;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelForm
{
    public partial class Form1 : Form
    {

        private static Process pdfProcess;

        private static string databasePath;

        private static string[] napravi_racun_files = { "napravi_racun.r" };

        public Form1()
        {
            InitializeComponent();

            // Onemogući buttone koji će biti kasnije omgućeni kada se odabere datoteka
            button_GenerirajExcelDat.Enabled = false;
            button_GenerirajPDF.Enabled = false;

        }
       
        // generiranje excel datoteke
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current =  Cursors.WaitCursor;
            Debug.WriteLine($"KfServerPath: {AppSettings.Instance.KfServerPath}");
            string[] arguments = { $"{AppSettings.Instance.SculptorPath}\\bin\\kfserver.exe" };

            if(sender == button_GenerirajExcelDat)
            {
                button_GenerirajExcelDat.Enabled = false;
            }
            
            Export.Export.start(arguments, label1, Path.GetFileNameWithoutExtension(databasePath));

            Debug.WriteLine("Gotov");

            button_GenerirajExcelDat.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        // generiranje pdf datoteka
        private void generatePdf_Click(object sender, EventArgs e)
        {
            /* If the folder does dot exist when Sculptor generates pdf-s
             * the program will "hang" untill someone manualy creates it
             * so will do it in a function
             */
            Cursor.Current = Cursors.WaitCursor;

            string srepwcPath = $"{AppSettings.Instance.SculptorPath}\\bin\\srepw.exe";
            string programPath = $"{AppSettings.Instance.ProjectPath}\\generatePdf.q";

            // start
            pdfProcess = Process.Start($"{srepwcPath}", $"{programPath}");
            pdfProcess.WaitForExit();
            Cursor.Current = Cursors.Default;
        }

        // odabir baze podataka
        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("button 3 click");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                Debug.WriteLine("open file dialog");
                // Set the file extension filter
                openFileDialog.Filter = "D files|*.d";

                // Display the file picker dialog
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK) // The user selected a file
                {
                    Debug.WriteLine("dialog OK");
                    // ako je novi database path drugačiji od promijeni ga
                    if (openFileDialog.FileName != databasePath)
                    {
                        databasePath = openFileDialog.FileName;
                        label2.Text = databasePath;

                        // uredi datoteku
                        izmjeniDatoteke();
                        // kompajliraj uređeni file koristeći scc
                        Compile();



                    }
                   
                    button_GenerirajExcelDat.Enabled = true;
                    button_GenerirajPDF.Enabled = true;
                }
            }
        }

        // izmjeni .r datoteku tako da na umjesto !file FILE_RACUN "X"
        // imamo !file FILE_RACUN "tablica"
        private void izmjeniDatoteke()
        {
            Debug.WriteLine("izmjeni datoteke");
            string path = $"{AppSettings.Instance.ProjectPath}";
            string[] fileLines = {"" };
            Debug.WriteLine(path);
            try
            {
                fileLines = File.ReadAllLines($"{path}\\generatePdf.r", Encoding.GetEncoding(1250));
            } catch(Exception ex)
            {
                Debug.WriteLine("exception reading all lines");
                Debug.WriteLine($"{path}\\generatePdf.r");
            }
            int lineIndex = 15;

            string imeTablice = Path.GetFileNameWithoutExtension(databasePath);

            Debug.WriteLine("izmjeni tablice 2");

            // sadržaj nove linije treba biti "!file FILE_RACUN "imeTablice""
            string newLineContent = $"!file FILE_RACUN \"{imeTablice}\"";

            if (lineIndex < fileLines.Length)
            {
                fileLines[lineIndex] = newLineContent;
                File.WriteAllLines($"{path}\\generatePdf.r", fileLines, Encoding.GetEncoding(1250));
            }

            // treba izmjeniti i napravi_racun datoteke

            lineIndex = 12;

            // za svaki element u nizu napravi_racun datoteka
            foreach (string napravi_racun_file in napravi_racun_files)
            {
                fileLines = File.ReadAllLines($"{path}\\{napravi_racun_file}", Encoding.GetEncoding(1250));
                // svima je FILE_RACUN na 13. liniji
                newLineContent = $"!file FILE_RACUN \"{imeTablice}\"";

                if (lineIndex < fileLines.Length)
                {
                    fileLines[lineIndex] = newLineContent;
                    File.WriteAllLines($"{path}\\{napravi_racun_file}", fileLines, Encoding.GetEncoding(1250));
                }
            }
        }


        private void Compile()
        {
            Debug.WriteLine("compile");
            // kompajliraj generate_pdf.r
            string path = $"{AppSettings.Instance.ProjectPath}";
            string sccPath = $"{AppSettings.Instance.SculptorPath}\\bin\\scc.exe";
            var psi = new ProcessStartInfo(sccPath, $"{path}\\generatePdf.r")
            {
                WorkingDirectory = path
            };

            Process compileProcess = Process.Start(psi);

            

            compileProcess.WaitForExit();

            if(compileProcess.ExitCode != 0)
            {
                throw new Exception("Error with compilation generatePdf.r");
            }

            Debug.WriteLine($"generatePdf.r compile: {compileProcess.ExitCode}");

            // kompaliraj sve napravi_racun datoteke
            foreach (string napravi_racun_file in napravi_racun_files)
            {
                var asi = new ProcessStartInfo(sccPath, $"{path}\\{napravi_racun_file}")
                {
                    WorkingDirectory = path
                };
                


                var process = Process.Start(asi);

                process.WaitForExit();

                if(process.ExitCode != 0)
                {
                    throw new Exception("Error with compilation");
                }

                Debug.WriteLine($"Exit code: {process.ExitCode}");
                Debug.WriteLine("Compilation done");
            }
            
        }

        /// <summary>
        /// kreiranje novog forma za promjenu appsettings.json
        /// </summary>
        private void settingsButton_Click_1(object sender, EventArgs e)
        {
            string fileName = "appsettings.json";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            if (!File.Exists(path))
            {
                Debug.WriteLine($"Path {path} does not exist");
                return;
            }

            Form form = new ChangeAppSettings(path);
            form.ShowDialog();

            Compile();

            MessageBox.Show("Compiled");
        }
    }
}
