using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace IMGChnager
{
    public partial class Main : MaterialForm
    {
        bool haspic = false;
        public Main()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey800, Primary.Grey800, Accent.Teal700, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string path;
            var path1 = "\\FortniteGame\\Saved\\PersistentDownloadDir\\CMS\\Files\\C28FF1DE0C661DAF01E118A30B3F21B897A7A6E2";
            var path2 = Environment.GetEnvironmentVariable("LocalAppData") + path1;
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DateLinks.xml");
            path = Environment.ExpandEnvironmentVariables(path2);
            string[] files = Directory.GetFiles(@path2);
            foreach (var file in files)
            {
                var combobox = materialComboBox1;
                combobox.Items.Add(file);
            }
        }
        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            widepic.ImageLocation = "";
            tallpic.ImageLocation = "";
            haspic = false;
            var combobox = materialComboBox1;
            System.Drawing.Image img = System.Drawing.Image.FromFile(combobox.Text);
            var imgsize = new System.Drawing.Size(img.Width, img.Height);
            MessageBox.Show("Width: " + img.Width + ", Height: " + img.Height);
            if(img.Width < 600)
            {
                tallpic.ImageLocation = combobox.Text;
                haspic = true;
            }

            if (img.Width > 1000)
            {
                widepic.ImageLocation = combobox.Text;
                haspic = true;
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var path1 = "\\FortniteGame\\Saved\\PersistentDownloadDir\\CMS\\Files\\C28FF1DE0C661DAF01E118A30B3F21B897A7A6E2";
            var path2 = Environment.GetEnvironmentVariable("LocalAppData") + path1;
            var newpic = "";
            if(haspic == false)
            {
                MessageBox.Show("Please Select A Image you would like to change!");
            }
            if(haspic == true)
            {
                if (widepic.ImageLocation == "")
                {
                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = new Bitmap(open.FileName);
                        newpic = open.FileName;             
                    }
                    var filename = System.IO.Path.GetFileName(tallpic.ImageLocation);
                    MessageBox.Show(filename);
                    File.Delete(@materialComboBox1.Text);
                    pictureBox1.Image.Save(@path2 + "\\" + filename);
                }
                if (tallpic.ImageLocation == "")
                {
                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = new Bitmap(open.FileName);
                        newpic = open.FileName;
                    }
                    var filename = System.IO.Path.GetFileName(widepic.ImageLocation);
                    MessageBox.Show(filename);
                    File.Delete(@materialComboBox1.Text);
                    pictureBox1.Image.Save(@path2 + "\\"+filename);
                }
            }
        }
    }
}
