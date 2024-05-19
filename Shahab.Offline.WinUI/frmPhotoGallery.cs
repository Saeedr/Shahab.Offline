using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Shahab.Offline.WinUI
{
    public partial class frmPhotoGallery : Form
    {
        Random rnd = new Random();
        int picCount = 0;
        int picCount2 = 1;

        private void PicClick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            PictureBox pic = sender as PictureBox;
            picCount2 = int.Parse(pic.Tag.ToString());
            int d = rnd.Next(1, 14);
            if (d == 1)
                animator1.AnimationType = AnimatorNS.AnimationType.HorizBlind;
            if (d == 2)
                animator1.AnimationType = AnimatorNS.AnimationType.HorizSlide;
            if (d == 3)
                animator1.AnimationType = AnimatorNS.AnimationType.HorizSlideAndRotate;
            if (d == 4)
                animator1.AnimationType = AnimatorNS.AnimationType.Leaf;
            if (d == 5)
                animator1.AnimationType = AnimatorNS.AnimationType.Mosaic;
            if (d == 6)
                animator1.AnimationType = AnimatorNS.AnimationType.Particles;
            if (d == 7)
                animator1.AnimationType = AnimatorNS.AnimationType.Rotate;
            if (d == 8)
                animator1.AnimationType = AnimatorNS.AnimationType.Scale;
            if (d == 9)
                animator1.AnimationType = AnimatorNS.AnimationType.ScaleAndHorizSlide;
            if (d == 10)
                animator1.AnimationType = AnimatorNS.AnimationType.ScaleAndRotate;
            if (d == 11)
                animator1.AnimationType = AnimatorNS.AnimationType.Transparent;
            if (d == 12)
                animator1.AnimationType = AnimatorNS.AnimationType.VertBlind;
            if (d == 13)
                animator1.AnimationType = AnimatorNS.AnimationType.VertSlide;
            foreach (Control ctn in panel1.Controls)
            {
                if (ctn is PictureBox)
                {
                    PictureBox pi = ctn as PictureBox;
                    pi.Visible = false;
                    if (pi.Tag.ToString() == pic.Tag.ToString())
                    {
                        animator1.Show(pi);
                    }
                }
            }
            timer1.Interval = 5000;
            timer1.Enabled = true;
        }

        public frmPhotoGallery()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dl = new FolderBrowserDialog();
            if (dl.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists("Dir.txt"))
                    System.IO.File.Delete("Dir.txt");
                System.IO.File.WriteAllText("Dir.txt", dl.SelectedPath);
                int i = 0;
                DirectoryInfo DF = new DirectoryInfo(dl.SelectedPath);
                foreach (FileInfo fi in DF.GetFiles())
                {
                    i++;
                    try
                    {
                        PictureBox pi = new PictureBox();
                        pi.Size = new Size(80, 80);
                        pi.Image = Image.FromFile(fi.FullName);
                        pi.SizeMode = PictureBoxSizeMode.StretchImage;
                        pi.Tag = i.ToString();
                        pi.Cursor = Cursors.Hand;
                        pi.Click += PicClick;
                        flowLayoutPanel1.Controls.Add(pi);
                        PictureBox pi2 = new PictureBox();
                        pi2.Size = new Size(80, 80);
                        pi2.Image = Image.FromFile(fi.FullName);
                        pi2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pi2.Tag = i.ToString();
                        pi2.Size = panel1.Size;
                        if (i != 1)
                            pi2.Visible = false;
                        panel1.Controls.Add(pi2);
                    }
                    catch { i--; }
                }
                timer1.Enabled = true;
                picCount = i;
            }
        }

        private void frmPhotoGallery_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("Dir.txt"))
            {
                DirectoryInfo DF = new DirectoryInfo(System.IO.File.ReadAllText("Dir.txt"));
                int i = 0;
                foreach (FileInfo fi in DF.GetFiles())
                {
                    i++;
                    try
                    {
                        PictureBox pi = new PictureBox();
                        pi.Size = new Size(80, 80);
                        pi.Image = Image.FromFile(fi.FullName);
                        pi.SizeMode = PictureBoxSizeMode.StretchImage;
                        pi.Tag = i.ToString();
                        pi.Cursor = Cursors.Hand;
                        pi.Click += PicClick;
                        flowLayoutPanel1.Controls.Add(pi);
                        PictureBox pi2 = new PictureBox();
                        pi2.Size = new Size(80, 80);
                        pi2.Image = Image.FromFile(fi.FullName);
                        pi2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pi2.Tag = i.ToString();
                        pi2.Size = panel1.Size;
                        if (i != 1)
                            pi2.Visible = false;
                        panel1.Controls.Add(pi2);
                    }
                    catch { i--; }
                }
                timer1.Enabled = true;
                picCount = i;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picCount2 < picCount)
                picCount2++;
            else
                picCount2 = 1;
            int d = rnd.Next(1, 14);
            if (d == 1)
                animator1.AnimationType = AnimatorNS.AnimationType.HorizBlind;
            if (d == 2)
                animator1.AnimationType = AnimatorNS.AnimationType.HorizSlide;
            if (d == 3)
                animator1.AnimationType = AnimatorNS.AnimationType.HorizSlideAndRotate;
            if (d == 4)
                animator1.AnimationType = AnimatorNS.AnimationType.Leaf;
            if (d == 5)
                animator1.AnimationType = AnimatorNS.AnimationType.Mosaic;
            if (d == 6)
                animator1.AnimationType = AnimatorNS.AnimationType.Particles;
            if (d == 7)
                animator1.AnimationType = AnimatorNS.AnimationType.Rotate;
            if (d == 8)
                animator1.AnimationType = AnimatorNS.AnimationType.Scale;
            if (d == 9)
                animator1.AnimationType = AnimatorNS.AnimationType.ScaleAndHorizSlide;
            if (d == 10)
                animator1.AnimationType = AnimatorNS.AnimationType.ScaleAndRotate;
            if (d == 11)
                animator1.AnimationType = AnimatorNS.AnimationType.Transparent;
            if (d == 12)
                animator1.AnimationType = AnimatorNS.AnimationType.VertBlind;
            if (d == 13)
                animator1.AnimationType = AnimatorNS.AnimationType.VertSlide;
            foreach (Control ctn in panel1.Controls)
            {
                PictureBox pi = ctn as PictureBox;
                pi.Visible = false;
                if (pi.Tag.ToString() == picCount2.ToString())
                {
                    animator1.Show(pi);
                }
            }
        }
    }
}
