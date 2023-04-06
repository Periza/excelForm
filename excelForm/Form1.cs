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



            Export.Export.start(arguments);
            List<string> dates = Export.Export.getByDate("25.02.2023");
            foreach (string date in dates)
            {
                Debug.WriteLine(date);
            }

            Debug.WriteLine("Gotov");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
