using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static int threshold;

        public Form1()
        {
            InitializeComponent();
        }

        private void openfile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopenFileDialog = new OpenFileDialog();
            if (myopenFileDialog.ShowDialog()== DialogResult.OK) {
               //  pictureBox1.Load(myopenFileDialog.FileName);
                String picture_position = myopenFileDialog.FileName;
                //   Image image = pictureBox1.Image;
                Image<Bgr, Byte> image = new Image<Bgr, byte>(picture_position);
                Image<Bgr, Byte> image2   = image.CopyBlank();
                
                pictureBox1.Image = image.ToBitmap();
                //  MessageBox.Show(pictureBox1.Image.GetType().ToString()); 
                image2 = image.ThresholdBinary(new Bgr(threshold, threshold, threshold), new Bgr(255, 255, 255));

                pictureBox2.Image = image2.ToBitmap();
            }
        }

        private async void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "threshold= " +trackBar1.Value.ToString();
                     
            
        }

        
    }
} 
