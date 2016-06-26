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
    public partial class Form2 : Form
    {
        string store = "";
        string pStore = "";
        int incr = 0;
        public Form2()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Words();
            FUNC();
            
        }
        private void FUNC()
        {
            textBox1.Text = "";
            int check=0;
            for (int i = 0; i < store.Length; i++)
            {
                if (store[i] != '-')
                {
                    textBox1.Text += "____\t";
                }
                else
                {
                    textBox1.Text += "   "+pStore[i]+"\t";
                }
            }
            for (int i = 0; i < pStore.Length; i++)
            {
                if (store[i] != '-')
                {
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                MessageBox.Show("Congratulations Won!!!!","Yayyyyyy!!! :)",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                DialogResult rslt = MessageBox.Show("Play New Game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                checkSure(rslt);
            }
        }
        
         private void Words()
         {
             Random r = new Random();
             int i = r.Next(0, 52);
             string[] Word ={"DESTINATION","PARALLEL","CIRCLE","LOVEABLE","PUNISH","VOLUME","PRESENTATION","LEADERSHIP",
                             "INSTRUCTION","LOAD","DESIGN","DISABLE"," DEVELOPMENT","ORGANIZATION","CERTIFICATE","STANDARDS",
                             "KNOWLEDGE","ALI","INSPIRE","DISTANCE","WINDOW","SHAHIDAFRIDI","COMPUTER"," COUNTRY"," CUPBOARD","CHANGES",
                             "ANALYZE","NEWYORK","PAKISTAN","GONAWAZGO","ARGUMENT","APPROPRIATE","ACCURACY","EXPLAINED","DEPTH","NOTES",
                             "SOURCES","WRITING","FINED","TISSUE","AUTOMOBILE","PLEASURE","SKIP","DAMAGE","PASSION","INVITE","DRIVING",
                             "CREATE","TOGETHER","WELCOME","SHARE"};
            store = Word[i];
            pStore = Word[i];
         }
        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Form1.ActiveForm.Dispose();
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult rslt=MessageBox.Show("Are you sure?\n All the progress will be lost!", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rslt == DialogResult.Yes)
            {
                hangPic.Image = null;
                store = "";
                pStore = "";
                incr = 0;
                Wguess.Text = "";
                Words();
                FUNC();
                
            }

            
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rslt=MessageBox.Show("Are You sure?", " Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rslt == DialogResult.Yes)
            {
                Form1.ActiveForm.Close();
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void wordClick(object sender, EventArgs e)
        {
            int l=0;
            Button btn = (Button)sender;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (btn.Text == textBox1.Text[i].ToString())
                {
                    l = 1;
                }
                if (i < Wguess.Text.Length && btn.Text == Wguess.Text[i].ToString())
                {
                    l = 1;
                }
            }
            if (l != 1)
            {
                string temporary = "";
                l = 0;
                for (int i = 0; i < store.Length; i++)
                {
                    if (btn.Text == store[i].ToString())
                    {
                        temporary += '-';
                    }
                    else
                    {
                        temporary += store[i];
                    }
                }
                if (store == temporary)
                {
                    Wguess.Text += btn.Text + "  ";
                    
                    incr++;
                    hangPic.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Ali Bhai " + incr + ".png");
                    if (incr == 4)
                    {

                        DialogResult rslt = MessageBox.Show("BOOO!! :( \n You LOST!\nCorrect Word is:    "+pStore+"\nPlay New Game?", "LOST!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        checkSure(rslt);
                        l = 1;
                       
                    }

                }
                if (l != 1)
                {
                    store = temporary;
                }
                FUNC(); 
            }
        }

        private void checkSure(System.Windows.Forms.DialogResult rslt)
        {
            if (rslt == DialogResult.Yes)
            {
                hangPic.Image = null;
                incr = 0;
                store = "";
                pStore = "";
                Wguess.Text = "";
                Words();
               
            }
            else
            {
                Form1.ActiveForm.Close();
                Application.Exit();
            }
            FUNC();
        }
       
        private Form helpForm = new Form();
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            helpForm.Size = new Size(530, 550);
            helpForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            helpForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            helpForm.MaximizeBox = false;
            helpForm.MinimizeBox = false;
            helpForm.ShowInTaskbar = false;
            RichTextBox helpRich = new RichTextBox();
            helpRich.LoadFile(Directory.GetCurrentDirectory() + "\\Help\\Help.rtf");
            helpRich.Location = new Point(10, 10);
            helpRich.Size = new Size(500, 400);
            helpForm.Controls.Add(helpRich);
            Button btn = new Button();
            btn.Location = new Point(200, 430);
            btn.Text = "OK";
            btn.Size = new Size(100, 40);
            helpForm.Controls.Add(btn);
            btn.Click += btn_Click;
            helpForm.ShowDialog();

        }

        void btn_Click(object sender, EventArgs e)
        {
            helpForm.Close();
        }

  
    }
}
