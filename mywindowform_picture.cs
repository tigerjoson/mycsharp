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
                Image<Bgr, Byte> image2 = image.CopyBlank();
                pictureBox1.Image = image.ToBitmap();
                //  MessageBox.Show(pictureBox1.Image.GetType().ToString()); 
                int threshold = 70;
                
                int Height = pictureBox1.Image.Height;
                int Width = pictureBox1.Image.Width;
            
                image2 = image.ThresholdBinary(new Bgr(threshold, threshold, threshold), new Bgr(255, 255, 255)) ;
                /*for (int h=0;h<Height ; h++) {
                    for (int w = 0; w < Width; w++) {
                    }
                }*/
                pictureBox2.Image = image2.ToBitmap();
            }
        }

    }
}
