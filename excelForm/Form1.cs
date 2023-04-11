using Sculptor.KfLibDNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kliknuo");

            string[] arguments = { "C:\\Sculptor\\bin\\kfserver.exe" };

            // set dates in the export class
            RacunRepository racunRepository = new RacunRepository();

            
            Racun r1 = (Racun)racunRepository.NextRecord();
            Racun r2 = (Racun)racunRepository.NextRecord();
            Racun r3 = (Racun)racunRepository.PreviousRecord();

            Debug.WriteLine(r1.krajnji_kupac);
            Debug.WriteLine(r2.krajnji_kupac);
            Debug.WriteLine(r3.krajnji_kupac);

            return;


            Export.Export.start(arguments);

            Debug.WriteLine("Gotov");
        }

    }
}
