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
using System.Media;
using System.IO;

namespace Pomodoro
{
    public partial class Anasayfa : System.Windows.Forms.Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void yuvarlakButon1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SoundPlayer soundPlayer = new SoundPlayer();
        int hedef2 = 12;
        int tur = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            


            turAtlaToolStripMenuItem.Enabled = false;
            sıfırlaToolStripMenuItem.Enabled = false;
            //string[] dizi = new string[3];
            



            timer3.Enabled = false;
            progressBar1.Value = 0;
            label7.Text = dakika.ToString();
            label8.Text = saniye.ToString();
            timer1.Enabled = false;
            label2.Text = tur.ToString();
            label4.Text = tur.ToString();
    
            string[] satırlar = File.ReadAllLines(Application.StartupPath + @"\save\.save");
            int[] ekle = new int[4];
            int i = 0;
            foreach (var item in satırlar)
            {
                ekle[i] = Convert.ToInt32(satırlar[i]);
                i++;
            }
            label5.Text = ekle[0].ToString();
            this.BackColor = Color.FromArgb(ekle[1]);
            timer1.Interval = ekle[2];
            timer3.Interval = ekle[3];
            timer4.Interval = ekle[3];

            
        }

        private void yuvarlakButon1_Click_1(object sender, EventArgs e)
        {
            if (label5.Text == "-" || label5.Text == "0")
            {
                label5.Text = hedef2.ToString();
            }
            yuvarlakButon1.Enabled = false;
            label2.Text = tur.ToString();
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer1.Start();
            timer2.Start();
            turAtlaToolStripMenuItem.Enabled = true;
        }
        int dakika = 25;
        int dakika2 = 0;
        int saniye = 60;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = 24;
            saniye--;
            if (dakika == 0 && saniye == 0)
            {
                
                timer1.Enabled = false;
                timer3.Enabled = true;
                dakika = 25;
                dakika2 = 0;
                saniye = 60;           
                progressBar1.Value = 0;
                moladakika = 5;
                label10.Text = "Mola :";

                SoundPlayer soundPlayer = new SoundPlayer();
                string path = "ses1.wav";
                soundPlayer.SoundLocation = path;
                soundPlayer.Play();

            }
            //else if (saniye==59)
            //{
            //    dakika--;
            //}
            else if (saniye==0)
            {
                dakika--;
                saniye = 60;
                dakika2++;
            }
            
            label7.Text = dakika.ToString();
            label8.Text = saniye.ToString();
            
        }
        int moladakika2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (label10.Text== "Dakika :")
            {
                progressBar1.Maximum = 24;
                if (progressBar1.Value != progressBar1.Maximum)
                {
                    progressBar1.Value = dakika2;
                }
                //hedeflerin progress barı
                //if (progressBar2.Value != progressBar2.Maximum)
                //{
                //    progressBar2.Value = tur;
                //}
                molaToolStripMenuItem.Enabled = false;
                dakikaToolStripMenuItem.Enabled = true;
            }
            if(label10.Text=="Mola :")
            {
                progressBar1.Maximum = 5;
                
                if (progressBar1.Value != progressBar1.Maximum)
                {
                    progressBar1.Value = moladakika2;
                }
                //hedeflerin progress barı
                //if (progressBar2.Value != progressBar2.Maximum)
                //{
                //    progressBar2.Value = tur;
                //}
                dakikaToolStripMenuItem.Enabled = false;
                molaToolStripMenuItem.Enabled = true;
            }
            if (Convert.ToInt32(label5.Text) > 4)
            {
                if (Convert.ToInt32(label4.Text) != 0 && Convert.ToInt32(label4.Text) % 4 == 0)
                {
                    if (label10.Text=="Mola :")
                    {
                        label10.Text = "Uzun Mola :";
                        timer3.Enabled = false;
                        timer4.Enabled = true;

                    }
                   


                }
            }
            if (label10.Text=="Uzun Mola :")
            {
                progressBar1.Maximum = 24;
                if (progressBar1.Value!=progressBar1.Maximum)
                {
                    progressBar1.Value = uzunmola2;
                }
            }
            if (tur==Convert.ToInt32(label5.Text))
            {
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer1.Enabled = false;
                

                MessageBox.Show("Tebrikler Pomodoroyu Bitirdiniz.\n \n-Ya başlamamalı, ya da bitirmeli. -Ovidius","Pomodoro",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DialogResult dialogResult = MessageBox.Show("Pomodoroyu Sıfırlamak İstermisiniz ?","Pomodoro",MessageBoxButtons.YesNo,MessageBoxIcon.Hand);
                if (dialogResult==DialogResult.Yes)
                {
                    
                    sıfırlaToolStripMenuItem.PerformClick();
                    yuvarlakButon1.Enabled = true;
                    label7.Text = dakika.ToString();
                    label8.Text = saniye.ToString();
                    timer2.Enabled = true;
                    tur = 0;
                    label2.Text = tur.ToString();
                    label4.Text=tur.ToString();
                }
                else if(dialogResult == DialogResult.No)
                {
                    Environment.Exit(1);
                }
                
                

            }
            label2.Text = tur.ToString();
            label4.Text = tur.ToString();
        }

        private void yuvarlakButon21_Click(object sender, EventArgs e)
        {
            if (label10.Text == "Dakika :" && yuvarlakButon1.Enabled == false)
            {
                if (timer1.Enabled == true)
                {
                    yuvarlakButon21.Text = "Devam";
                    timer1.Stop();
                    sıfırlaToolStripMenuItem.Enabled = true;
                    turToolStripMenuItem.Enabled = true;
                }
                else
                {
                    yuvarlakButon21.Text = "Dur";
                    
                    timer1.Start();
                    sıfırlaToolStripMenuItem.Enabled = false;
                    turToolStripMenuItem.Enabled = false;
                }

            }
            else if (label10.Text == "Mola :" && yuvarlakButon1.Enabled != true)
            {
                if (timer3.Enabled == true)
                {
                    yuvarlakButon21.Text = "Devam";
                    timer3.Stop();
                    sıfırlaToolStripMenuItem.Enabled = true;
                    turToolStripMenuItem.Enabled = true;
                }
                else
                {
                    yuvarlakButon21.Text = "Dur";
                    timer3.Start();
                    sıfırlaToolStripMenuItem.Enabled = false;
                    turToolStripMenuItem.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Pomodoroyu Başlatmadınız !","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void yuvarlakButon22_Click(object sender, EventArgs e)
        {    
                timer1.Start();
                timer2.Start();   
                timer3.Start();
    
        }
        public bool kayıt = false;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (kayıt==true)
                {
                    DialogResult dialogResult = MessageBox.Show("Ayarlarınız Kaydedilsinmi ?", "ShadowMask", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {

                        Environment.Exit(1);




                    }
                    else if (dialogResult == DialogResult.No)
                    {

                        string clean = "";
                        File.WriteAllText(Application.StartupPath + @"\save\.save", clean);
                        Environment.Exit(1);
                    }





                }
                else if(kayıt==false)
                {
                    Application.Exit();
                }
                    
                
                
                
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik Bir Hata Oluştu Lütfen Tekrar Deneyin");
            }
            
           
            
        }
        int moladakika = 5;
        private void timer3_Tick(object sender, EventArgs e)
        {
            saniye--;
            if (saniye==59)
            {
                moladakika2++;
                moladakika--;
            }
            if (saniye == 0 && moladakika == 0)
            {
                timer1.Enabled = true;
                timer3.Enabled = false;
                dakika = 25;
                dakika2 = 0;
                saniye = 60;
                label10.Text = "Dakika :";
                moladakika2 = 0;
                tur++;

                SoundPlayer soundPlayer = new SoundPlayer();
                string path = "ses1.wav";
                soundPlayer.SoundLocation = path;
                soundPlayer.Play();
            }
            if (saniye==0)
            {
                saniye = 60;
                
            }
            
            
            label7.Text = moladakika.ToString();
            label8.Text = saniye.ToString();
            

            
        }

        private void yuvarlakButon22_Click_1(object sender, EventArgs e)
        {
            if (label10.Text == "Dakika :" && yuvarlakButon1.Enabled == false)
            {
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                }
                else
                {
                    timer1.Start();
                }

            }
            else if (label10.Text == "Mola :" && yuvarlakButon1.Enabled != true)
            {
                if (timer3.Enabled == true && yuvarlakButon1.Enabled == false)
                {
                    timer3.Stop();
                }
                else
                {
                    timer1.Start();
                }

            }
            else
            {
                MessageBox.Show("Pomodoroyu Başlatmadınız !");
            }
        }

        private void özelAyarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
            timer3.Stop();

            

            Özel_Ayarlar aç = new Özel_Ayarlar();
            aç.Show();
        }

        private void dakikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dakika = 0;
            saniye = 1;
            dakika2 = 24;

        }

        private void molaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moladakika = 0;
            moladakika2 = 4;
            saniye = 1;
        }
        int Moves;
        int Mouse_X;
        int Mouse_Y;
        private void Anasayfa_MouseUp(object sender, MouseEventArgs e)
        {
            //Move = 0;
        }

        private void Anasayfa_MouseMove(object sender, MouseEventArgs e)
        {
            //if (Move==1)
            //{
            //    this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            //}
        }

        private void Anasayfa_MouseDown(object sender, MouseEventArgs e)
        {
            //Move = 1;
            //Mouse_X = e.X;
            //Mouse_Y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Moves = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Moves = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moves == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label5.Text == "-")
            {
                label5.Text = hedef2.ToString();
            }
            yuvarlakButon1.Enabled = false;
            label2.Text = tur.ToString();
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer1.Start();
            timer2.Start();

        }

        public void sıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yuvarlakButon1.Enabled = true;
            yuvarlakButon21.Text = "Dur";
                tur = 0;
                timer1.Enabled = false;
                timer3.Enabled = false;
                timer2.Enabled = true;
                dakika2 = 0;
                dakika = 25;
                saniye = 60;
                progressBar1.Value = 0;
                label7.Text = dakika.ToString();
                label8.Text = saniye.ToString();
                
                label2.Text = tur.ToString();
                label4.Text = tur.ToString();
            
            
        }

        private void turToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tur++;
            dakika = 25;
            saniye = 60;
            dakika2 = 0;
            label7.Text = dakika.ToString();
            label8.Text = saniye.ToString();
        }
        int uzunmola=25;
        int uzunmola2=0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            saniye--;
            if (uzunmola == 0 && saniye == 0)
            {
                
                tur++;
                timer4.Enabled = false;
                timer1.Enabled = true;
                uzunmola = 25;
                uzunmola2 = 0;
                saniye = 60;
                progressBar1.Value = 0;
                moladakika = 5;
                label10.Text = "Dakika :";

            }
            
            else if (saniye == 0)
            {
                uzunmola2++;
                uzunmola--;
                saniye = 60;
                
            }
            label7.Text = uzunmola.ToString();
            label8.Text = saniye.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
