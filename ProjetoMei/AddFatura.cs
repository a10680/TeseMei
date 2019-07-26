using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.CvEnum;



namespace Projeto
{
    public partial class AddFatura : Form
    {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddFatura_Load(object sender, EventArgs e)
        {
            //janela do tamanho do ecra
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;



            flowLayoutPanel1.Controls.Add(pictureBox1);
            panel1.Show();
            flowLayoutPanel1.Show();
            panel7.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            flowLayoutPanel1.Hide();
            panel7.Show();
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



        
        /// <summary>
        /// botão abrir ficheiros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
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

        private Rectangle GetRectangle()
        {
            rtg = new Rectangle();
            rtg.X = Math.Min(startLoc.X, endLoc.X);
            rtg.Y = Math.Min(startLoc.Y, endLoc.Y);
            rtg.Width = Math.Abs(startLoc.X - endLoc.X);
            rtg.Height = Math.Abs(startLoc.Y - endLoc.Y);

            return rtg;
        }

        private void button2_Click(object sender, EventArgs e)
        {

           // FornecedorBL f = new FornecedorBL();
            
            int x, y, w, h;

            
            if (comboBox1.Text == "Data")
            {
                textBoxData.Text = textBoxResultado.Text;
                x = GetRectangle().X;
                y = GetRectangle().Y;
                w = GetRectangle().Width;
                h = GetRectangle().Height;
                Console.WriteLine("x:" + x + " y:" + y + " width:" + w + " h: " + h);
                textBoxResultado.Text = "";
            }
            else if (comboBox1.Text == "Número")
            {
                textBoxNumero.Text = textBoxResultado.Text;
                x = GetRectangle().X;
                y = GetRectangle().Y;
                w = GetRectangle().Width;
                h = GetRectangle().Height;
                Console.WriteLine("x:" + x + " y:" + y + " width:" + w + " h: " + h);
                textBoxResultado.Text = "";
            }
            else if (comboBox1.Text == "NIF fornecedor")
            {
                textBoxNIF.Text = textBoxResultado.Text;
                x = GetRectangle().X;
                y = GetRectangle().Y;
                w = GetRectangle().Width;
                h = GetRectangle().Height;
                Console.WriteLine("x:" + x + " y:" + y + " width:" + w + " h: " + h);
                bool aux = false;
                //aux = f.addFornecedor(textBoxNIF.Text);

                if (aux) MessageBox.Show("adicionado");
                textBoxResultado.Text = "";
            }
            else if (comboBox1.Text == "Total")
            {
                textBoxTotal.Text = textBoxResultado.Text;
                x = GetRectangle().X;
                y = GetRectangle().Y;
                w = GetRectangle().Width;
                h = GetRectangle().Height;
                Console.WriteLine("x:" + x + " y:" + y + " width:" + w + " h: " + h);
                textBoxResultado.Text = "";
            }

            comboBox1.Text = "";

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // AddFatura
        //    // 
        //    this.ClientSize = new System.Drawing.Size(884, 636);
        //    this.Name = "AddFatura";
        //    this.Load += new System.EventHandler(this.AddFatura_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void AddFatura_Load_1(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AddFatura
            // 
            this.ClientSize = new System.Drawing.Size(921, 765);
            this.Name = "AddFatura";
            this.ResumeLayout(false);

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


            temp.Save("C:/Users/Daniel/Documents/Projeto/Projeto/bin/Debug/test.bmp");
            var ocr = new TesseractEngine(@"./tessdata", "por", EngineMode.Default);
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
            return strArrayOne[0];
        }
    }
}
