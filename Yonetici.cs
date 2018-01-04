using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ANAOKULU
{
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
           
        }

        private void btn_OgrenciKayitEkle_Click(object sender, EventArgs e)
        {
            KayitEkleme goster = new KayitEkleme();
            goster.Show();
            this.Hide();
        }

        private void btn_OgretmenKayitEkle_Click(object sender, EventArgs e)
        {
            OgretmenKayıtEkleme goster = new OgretmenKayıtEkleme();
            goster.Show();
            this.Hide();
        }

        private void btn_OgrenciListe_Click(object sender, EventArgs e)
        {
            Ogretmen goster = new Ogretmen();
            goster.Show();
            this.Hide();
        }

       

      

        

        

       
    }
}
