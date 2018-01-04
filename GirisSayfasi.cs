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
    public partial class GirisSayfasi : Form
    {
        public GirisSayfasi()
        {
            InitializeComponent();
        }
        
        private void GirişSayfası_Load(object sender, EventArgs e)
        {       
            txt_Sifre.PasswordChar = '*';

            
        }

        private void LogiKontrol()
        {
            int count = 0;
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            sql = " select KullaniciAdi, Sifre, 1 as AdminMi from Yonetici " +
                   "UNION " +
                   "select Ogretmen.KullaniciAdi,Ogretmen.Sifre ,0 as AdminMi from Ogretmen ";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string KullaniciAdi = dataReader["KullaniciAdi"].ToString();
                    string Sifre = dataReader["Sifre"].ToString();
                    int admin = Convert.ToInt32(dataReader["AdminMi"]);
                   
                    if(KullaniciAdi==txt_Kullanici.Text.Trim())
                    {
                        count++;
                        if (Sifre == txt_Sifre.Text.Trim())
                        {
                            if(admin==1) // ADMİN GİRİŞİ
                            { 
                                Yonetici goster = new Yonetici();
                                goster.Show();
                                this.Hide();
                            }
                             else
                            {
                                Ogretmen goster = new Ogretmen();
                                goster.Show();
                                this.Hide();
                            }
                        }
                        else
                            MessageBox.Show("Hatalı şifre, tekrar deneyiniz ! ");    
                    }

                }
                dataReader.Close();
                command.Dispose();
                connection.Close();

                if (count == 0)
                    MessageBox.Show("Kullanıcı bilgilerinizi kontrol edip tekrar deneyiniz ! ");
            }
            catch (Exception )
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogiKontrol();
        }

     

        

        
    }
}
