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

namespace day26_05
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        int number;
        string readMessage;


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Stream myStream;
            saveFileDialog1.DefaultExt = "dat";
            saveFileDialog1.Filter = "데이터(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((myStream = openFileDialog1.OpenFile()) != null)
                {
                    using(BinaryReader br = new BinaryReader(myStream))
                    {
                        number = br.ReadInt32();
                        readMessage = br.ReadString();
                        Invalidate();
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 13;
            string sendMessage = "Hello World";
            Stream myStream;
            saveFileDialog1.DefaultExt = "dat";
            saveFileDialog1.Filter = "데이터(*.dat)|*.dat";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using(BinaryWriter bw = new BinaryWriter(myStream))
                    {
                        bw.Write(num);
                        bw.Write(sendMessage);
                    }
                }
            }
        }

         Brush color = Brushes.Black;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            if(number != 0) e.Graphics.DrawString(number.ToString(), Font, color, 10, 30);
            e.Graphics.DrawString(readMessage, Font, color, 50, 30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = new SolidBrush(colorDialog1.Color);              
            }
            Invalidate();
        }
    }
}
