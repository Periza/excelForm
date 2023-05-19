using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace ExcelForm
{
    public partial class ChangeAppSettings : Form
    {
        string path;
        public ChangeAppSettings(string filePath)
        {
            InitializeComponent();
            path = filePath;
            initData();
        }

        private void ChangeAppSettings_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveData();
            this.Close();
        }

        /// <summary>
        /// metoda za spremanje podataka iz textBoxova u appsettings.json
        /// </summary>
        private void saveData()
        {
            string kfServer = "", sculptor = "", project = "", tehnon = "";
            if (!string.IsNullOrEmpty(kfServerPathTb.Text))
            {
                kfServer = kfServerPathTb.Text;
            }
            if (!string.IsNullOrEmpty(sculptorPathTb.Text))
            {
                sculptor = sculptorPathTb.Text;
            }
            if (!string.IsNullOrEmpty(projectPathTb.Text))
            {
                project = projectPathTb.Text;
            }
            if (!string.IsNullOrEmpty(tehnonPathTb.Text))
            {
                tehnon = tehnonPathTb.Text;
            }

            AppSettings.SaveSettings(kfServer, sculptor, project, tehnon);
        }

        /// <summary>
        /// metoda za učitavanje podataka u textBoxove ako postoje
        /// </summary>
        private void initData()
        {
            if (File.Exists(path))
            {
                AppSettings temp = LoadJson();
                kfServerPathTb.Text = temp.KfServerPath;
                sculptorPathTb.Text = temp.SculptorPath;
                projectPathTb.Text = temp.ProjectPath;
                tehnonPathTb.Text = temp.TehnonPath;
            }
        }

        /// <summary>
        /// metoda za učitavanje appsettings iz .json fila
        /// </summary>
        private AppSettings LoadJson()
        {
            AppSettings item;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                item = JsonConvert.DeserializeObject<AppSettings>(json);
            }

            return item;
        }


    }
}
