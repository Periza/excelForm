﻿using Sculptor.KfLibDNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        private static string[] napravi_racun_files = { "napravi_racun.r", "napravi_racun10.r", "napravi_racun11.r" };

        public Form1()
        {
            InitializeComponent();

            // Onemogući buttone koji će biti kasnije omgućeni kada se odabere datoteka
            button1.Enabled = false;
            button2.Enabled = false;

        }
        // generiranje excel datoteke
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"KfServerPath: {AppSettings.Instance.KfServerPath}");
            string[] arguments = { $"{AppSettings.Instance.SculptorPath}\\bin\\kfserver.exe" };

            if(sender == button1)
            {
                button1.Enabled = false;
            }
            
            Export.Export.start(arguments, label1, Path.GetFileNameWithoutExtension(databasePath));

            Debug.WriteLine("Gotov");

            button1.Enabled = true;
        }

        // generiranje pdf datoteka
        private void button2_Click(object sender, EventArgs e)
        {
            string srepwcPath = $"{AppSettings.Instance.SculptorPath}\\bin\\srepw.exe";
            string programPath = $"{AppSettings.Instance.ProjectPath}\\generatePdf.q";

            // start
            pdfProcess = Process.Start($"{srepwcPath}", $"{programPath}");
            pdfProcess.WaitForExit();

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
                        compile();



                    }
                   
                    button1.Enabled = true;
                    button2.Enabled = true;
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


        private void compile()
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

    }
}
