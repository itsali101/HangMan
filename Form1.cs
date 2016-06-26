using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Hangman
{
    public partial class Form1 : Form
    {
        SoundPlayer sound1 = new SoundPlayer();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sound1.SoundLocation = Directory.GetCurrentDirectory() +"\\Music\\128_3.wav";
            sound1.Play();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        public void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
