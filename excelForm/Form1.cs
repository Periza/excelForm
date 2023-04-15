using Sculptor.KfLibDNet;
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
            string[] arguments = { "C:\\Sculptor\\bin\\kfserver.exe" };

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
            string srepwcPath = @"C:\Sculptor\bin\srepw.exe";
            string programPath = @"D:\Tehnon2023\tehnon23\generatePdf.q";

            // start
            pdfProcess = Process.Start($"{srepwcPath}", $"{programPath}");
            pdfProcess.WaitForExit();

        }

        // odabir baze podataka
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the file extension filter
                openFileDialog.Filter = "D files|*.d";

                // Display the file picker dialog
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK) // The user selected a file
                {
                    
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
            string filePath = @"D:\Tehnon2023\tehnon23\generatePdf.r";
            string[] fileLines = File.ReadAllLines(filePath);
            int lineIndex = 15;

            string imeTablice = Path.GetFileNameWithoutExtension(databasePath);

            // sadržaj nove linije treba biti "!file FILE_RACUN "imeTablice""
            string newLineContent = $"!file FILE_RACUN \"{imeTablice}\"";

            if(lineIndex < fileLines.Length)
            {
                fileLines[lineIndex] = newLineContent;
                File.WriteAllLines(filePath, fileLines);
            }

            // treba izmjeniti i napravi_racun datoteke
            string path = @"D:\Tehnon2023\tehnon23\";
            

            // za svaki element u nizu napravi_racun datoteka
            foreach(string napravi_racun_file in napravi_racun_files)
            {
                // svima je FILE_RACUN na 13. liniji
                newLineContent = $"file FILE_RACUN \"{imeTablice}\"";

                if (lineIndex < fileLines.Length)
                {
                    fileLines[lineIndex] = newLineContent;
                    File.WriteAllLines($"{path}{napravi_racun_file}", fileLines);
                }
            }

        }

        private void compile()
        {
            // kompajliraj generate_pdf.r
            string path = @"D:\Tehnon2023\tehnon23\";
            string sccPath = @"C:\Sculptor\bin\scc.exe";

            Process compileProcess = Process.Start(sccPath, $"{path}generatePdf.r");

            compileProcess.WaitForExit();

            // kompaliraj sve napravi_racun datoteke
            foreach (string napravi_racun_file in napravi_racun_files)
            {
                compileProcess = Process.Start(sccPath, $"{path}{napravi_racun_file}");
            }
            
        }
    }
}
