using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Yapısı_Proje_1
{
    public partial class Form1 : Form
    {
        public class dugum
        {
            public int no;
            public string ad;
            public int fiyat;
            public dugum sonraki = null;
            public dugum onceki=null;
            public dugum(int no, string ad, int fiyat)
            {
                this.no = no;
                this.ad = ad;
                this.fiyat = fiyat;
                
            }
        }
        public void Yazdir1(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dugum gecici = bas;
            while (gecici!= null)           
            {
                dgv.Rows.Add(gecici.no, gecici.ad,gecici.fiyat);
                gecici= gecici.sonraki;
            }
        }
        

        public void Sildir(int no)
        {
            if (bas == null)
            {
                return;
            }
            else if (bas.no == no)
            {
                bas = bas.sonraki;
                if (bas != null)
                {
                    bas.onceki = null;
                }
                return;
            }
            else if (son.no == no)
            {
                son = son.onceki;
                if (son != null)
                {
                    son.sonraki = null;

                }
                return;
            }

            dugum gecici = bas;
            while (gecici != null)
            {
                
                if (gecici.no == no)
                {                    
                    gecici.onceki.sonraki = gecici.sonraki;
                    gecici.sonraki.onceki = gecici.onceki;
                    return;
                }
                
                gecici = gecici.sonraki;



            }
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        public dugum bas = null;
        

        public dugum son = null;

        public dugum yeni = null;

        public int sayac = 0;
        

      

        private void button1_Click(object sender, EventArgs e)
        {
            if (bas == null && sayac == 0)
            {

                bas = new dugum(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
                sayac++;

                bas.sonraki = son;

                sayac = 1;
            }
            else if (sayac == 1)
            {
                son = new dugum(Convert.ToInt32(textBox1.Text), (textBox2.Text), Convert.ToInt32(textBox3.Text));

                son.onceki = bas;
                bas.sonraki = son;

               
                sayac++;
            }
            else if (sayac != 1)
            {
                yeni = new dugum(Convert.ToInt32(textBox1.Text), (textBox2.Text), Convert.ToInt32(textBox3.Text));

                dugum gecici = son;


                while (gecici.sonraki != null)
                {
                    gecici = gecici.sonraki;
                }
                gecici.sonraki = yeni;
                yeni.onceki = gecici;
                son = yeni;



            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }


        private void button4_Click(object sender, EventArgs e)
        {

            Yazdir1(dataGridView1);      

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox4.Text);
            Sildir(no);
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            
        }
        private void button5_Click(object sender, EventArgs e)
        {          

            int no = Convert.ToInt32(textBox4.Text);
            dugum gecici = bas;

            while (gecici != null)
            {
                if (gecici.no == no)
                {
                    textBox5.Text = gecici.ad;
                    textBox6.Text = gecici.fiyat.ToString();
                    return;
                }
                gecici = gecici.sonraki;
            }

            textBox5.Clear();
            textBox6.Clear();   

        }
        private void button3_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox7.Text);
            int fiyat2 = Convert.ToInt32(textBox9.Text);

            dugum gecici = bas;

            while (gecici != null)
            {
                if (gecici.no == no)
                {
                    gecici.fiyat = fiyat2;
                    return;
                }
                gecici = gecici.sonraki;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            int no = Convert.ToInt32(textBox7.Text);
            dugum gecici = bas;

            while (gecici != null)
            {
                if (gecici.no == no)
                {
                    textBox8.Text = gecici.ad;
                    textBox9.Text = gecici.fiyat.ToString();
                    return;
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı.");
                }
                gecici = gecici.sonraki;
                
            }

            textBox5.Clear();
            textBox6.Clear();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
