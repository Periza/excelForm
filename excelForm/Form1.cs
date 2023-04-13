using Sculptor.KfLibDNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arguments = { "C:\\Sculptor\\bin\\kfserver.exe" };

            if(sender == button1)
            {
                button1.Enabled = false;
            }
            
            Export.Export.start(arguments, label1);

            Debug.WriteLine("Gotov");

            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
