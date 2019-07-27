using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tesseract;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.CvEnum;
using BL;





namespace ProjetoMei
{
    public partial class AddFatura : Form
    {

        CampoBL campos = new CampoBL();

        Image<Bgr, byte> image, resizedImage;
        Image File;
        Rectangle rtg;
        Point startLoc;
        Point endLoc;
        bool IsMouseDown = false;
        List<string> referencias = new List<string>();
        PictureBox pb;
       
        string nif;

        public AddFatura()
        {
            InitializeComponent();

        }

        private void AddFatura_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            flowLayoutPanel1.Controls.Add(pictureBox1);

            panel1.Show();
            flowLayoutPanel1.Show();
            panel2.Hide();
        }




        private Rectangle GetRectangle()
        {
            rtg = new Rectangle();
            rtg.X = Math.Min(startLoc.X, endLoc.X);
            rtg.Y = Math.Min(startLoc.Y, endLoc.Y);
            rtg.Width = Math.Abs(startLoc.X - endLoc.X);
            rtg.Height = Math.Abs(startLoc.Y - endLoc.Y);

            return rtg;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            //f.Filter = "PNG(*.PNG)| *.png";
            //f.Filter ="JPG(*.JPG)|*.jpg";

            if (f.ShowDialog() == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(f.FileName);
                resizedImage = image.Resize(pictureBox1.Width, pictureBox1.Height, Inter.Linear);

                //image = image.ThresholdBinary(new Gray(185),new Gray(255));
                //image = image.Dilate(1).Erode(1);

                //pb = new PictureBox();
                //pb.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = resizedImage.ToBitmap();
                //flowLayoutPanel1.AutoScroll = true;
                //flowLayoutPanel1.Controls.Add(pb);
                //var img = new Bitmap(f.FileName);


                // var ocr = new TesseractEngine(@"./tessdata", "por", EngineMode.Default);
                // var page = ocr.Process(img);
                //var output = page.GetText();
                //richTextBox1.Text = output;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            startLoc = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                endLoc = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rtg != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRectangle());


            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
            pictureBox1.Invalidate();
            ocr(GetRectangle());
        }

        private void l(object sender, EventArgs e)
        {

            panel1.Show();
            flowLayoutPanel1.Show();
            panel2.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            flowLayoutPanel1.Hide();
            panel2.Show();
        }

        private string ocr(Rectangle rtg)
        {


            resizedImage.ROI = rtg;
            Image<Bgr, byte> temp = resizedImage.CopyBlank();
            resizedImage.CopyTo(temp);
            //temp.Resize(pictureBox2.Width, pictureBox2.Height, Inter.Linear);
            resizedImage.ROI = Rectangle.Empty;
            //pictureBox2.Image = temp.Bitmap;
            //pictureBox2.Width = temp.Width;
            //pictureBox2.Height = temp.Height;


            //temp.Save("C:/Users/Daniel/Documents/Projeto/Projeto/bin/Debug/test.bmp");
            temp.Save("C:/Users/Admin/source/repos/a10680/TeseMei/ProjetoMei/bin/Debug/test.bmp");

            //var ocr = new TesseractEngine(@"./tessdata", "por", EngineMode.Default);
            var ocr = new TesseractEngine(@"C:/Users/Admin/Downloads", "por", EngineMode.Default);
            //ocr.SetVariable("output-preserve-enabled", 1);
            ocr.SetVariable("tessedit_pageseg_mode", 6);

            //ocr.SetVariable("tessedit_char_whitelist", 0123456789);
            var page = ocr.Process(temp.Bitmap);
            string output = page.GetText();
            textBoxResultado.Text = output;
            string[] strArrayOne = new string[] { "" };

            strArrayOne = output.Split('\n');

            //for (int i = 0; i < strArrayOne.Length; i++)
            //{
            //    this.dataGridView.Rows.Add(strArrayOne[i]);
            //}
            //textBox1.Text = output;
            //textData.Text = output;

           
            if (campos.verificaData(strArrayOne[0]))
            {
                textBoxData.Text = strArrayOne[0];
            }
            else if (campos.verificaNIF(strArrayOne[0]))
            {
                textBoxNif.Text = strArrayOne[0];
            }
            else if (campos.verificaValorTotal(strArrayOne[0]))
            {
                textBoxTotal.Text = strArrayOne[0];
            }
            else
            {
                textBoxNumero.Text = strArrayOne[0];    
            }
            return strArrayOne[0];
        }
    }
}
