using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Pomodoro
{
    public partial class Özel_Ayarlar : System.Windows.Forms.Form
    {
        public Özel_Ayarlar()
        {
            InitializeComponent();
        }

        private void Özel_Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (colorDialog1.Color==Color.Black)
            {
                colorDialog1.Color = Color.White;
                pictureBox1.BackColor = colorDialog1.Color;
            }
            else
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
           
        }
        
        public void button1_Click(object sender, EventArgs e)
        {


            string path = Application.StartupPath + @"\save\.save";
            string clean = "";
            System.IO.File.WriteAllText(path, clean);

            string[] dizi = { numericUpDown1.Value.ToString(), colorDialog1.Color.ToArgb().ToString(), numericUpDown2.Value.ToString(), numericUpDown3.Value.ToString() };
            System.IO.File.WriteAllLines(path, dizi);

            Anasayfa sf = new Anasayfa();
            sf.label5.Text = Convert.ToString(numericUpDown1.Value);
            sf.timer1.Interval = Convert.ToInt32(numericUpDown2.Value);
            sf.timer3.Interval = Convert.ToInt32(numericUpDown3.Value);
            sf.timer4.Interval = Convert.ToInt32(numericUpDown3.Value);
            sf.BackColor = colorDialog1.Color;
            sf.kayıt = true;
            this.Hide();
            sf.ShowDialog();


        }

        private void Özel_Ayarlar_Load(object sender, EventArgs e)
        {
             
        }

        private void Özel_Ayarlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ayarlarınız Kayıt Edilsinmi ?", "Pomodoro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                button1.PerformClick();
            }
            else
            {
                this.Hide();
                Anasayfa sf = new Anasayfa();
                sf.ShowDialog();
            }
        }
    }
}
