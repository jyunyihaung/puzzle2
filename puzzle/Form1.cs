using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int itemX, itemY;
        private int mousX, mousY;
        private bool isMoving = false;
        private int boundX, boundY;

        private void Form1_Load(object sender, EventArgs e)
        {
            boundX = this.Width;
            boundY = this.Height;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("pressed", "title");
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            isMoving = false;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if(isMoving)
            {
                int tX = Cursor.Position.X;
                int tY = Cursor.Position.Y;
                ((PictureBox)sender).Left = itemX + (tX - mousX);
                ((PictureBox)sender).Top  = itemY + (tY - mousY);

                if ((((PictureBox) sender).Left + ((PictureBox)sender).Width ) > (boundX-35) ) // right limit
                {
                    isMoving = false;
                    ((PictureBox)sender).Left = boundX - 35 - ((PictureBox)sender).Width;
                }
                if(((PictureBox)sender).Left < 0 + 20) // left limit
                {
                    isMoving = false;
                    ((PictureBox)sender).Left = (0 + 20);
                }

                if(((PictureBox)sender).Top < (0 + 30)) // up limit
                {
                    isMoving = false;
                    ((PictureBox)sender).Top = (0 + 30);

                }
                if ( (((PictureBox)sender).Top + ((PictureBox)sender).Height) > (boundY - 60)) // down limit
                {
                    isMoving = false;
                    ((PictureBox)sender).Top = (boundY - 60 - ((PictureBox)sender).Height);

                }

            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            itemX = ((PictureBox)sender).Left;
            itemY = ((PictureBox)sender).Top;
            mousX = Cursor.Position.X;
            mousY = Cursor.Position.Y;
            isMoving = true;
        }
    }
}
