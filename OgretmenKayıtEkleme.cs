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
    public partial class OgretmenKayıtEkleme : Form
    {
        public OgretmenKayıtEkleme()
        {
            InitializeComponent();
        }

        private void btn_kaydet2_Click(object sender, EventArgs e)
        {
             SqlConnection sqlConInsert = new SqlConnection();

             sqlConInsert.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = sqlConInsert;


            DateTime dogumgunu = new DateTime();
            dogumgunu = dtp_ogrtdogtar.Value;

            cmnd.CommandText = "INSERT INTO Ogretmen (KullaniciAdi,Sifre,Ad, Soyad,TCKimlikNo,Cinsiyet,DogumTarihi,DogumYeri,TelNo,Adres,Sinif) " +
                               "VALUES (@Kullanici,@Sifre,@AD, @SOYAD,@TCKimlik,@Cinsiyet,@DogumTarihi,@DogumYeri,@CepTel,@Adres,@Sinif) ";

            cmnd.Parameters.AddWithValue("@Kullanici", txt_KullaniciAdi.Text);
            cmnd.Parameters.AddWithValue("@Sifre", txt_Sifre.Text);
            cmnd.Parameters.AddWithValue("@AD", txt_ogrtad.Text);
            cmnd.Parameters.AddWithValue("@SOYAD",txt_ogrtsoyad.Text );
            cmnd.Parameters.AddWithValue("@TCKimlik", txt_ogrttckimlik.Text);
            cmnd.Parameters.AddWithValue("@Sinif", txt_sinif2.Text);
            if(rd_erkek2.Checked)
              cmnd.Parameters.AddWithValue("@Cinsiyet", 'E');
            else
              cmnd.Parameters.AddWithValue("@Cinsiyet", 'K');
            cmnd.Parameters.AddWithValue("@DogumTarihi", dogumgunu);
            cmnd.Parameters.AddWithValue("@DogumYeri", txt_ogrtdogyer.Text);
            cmnd.Parameters.AddWithValue("@CepTel", txt_ogrtceptel.Text);
            cmnd.Parameters.AddWithValue("@Adres", txt_ogrtadres.Text);

            //try
            //{
                sqlConInsert.Open();
                cmnd.ExecuteNonQuery();
                sqlConInsert.Close();

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("hata");

            //}

            //finally
            //{
            //    if (cmnd != null)
            //        cmnd.Dispose();
            //    if (sqlConInsert != null)
            //        sqlConInsert.Close();
            //}
        }

        private void btn_guncelle2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConUpdate = new SqlConnection();

            sqlConUpdate.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = sqlConUpdate;


            DateTime dogumgunu = new DateTime();
            dogumgunu = dtp_ogrtdogtar.Value;

            cmnd.CommandText = "UPDATE Ogretmen SET KullaniciAdi=@Kullanici,Sifre=@Sifre,Ad=@AD,Soyad=@SOYAD,TCKimlikNo=@TCKimlik,Cinsiyet=@Cinsiyet,DogumTarihi=@DogumTarihi,DogumYeri=@DogumYeri,TelNo=@CepTel,Adres=@Adres WHERE TCKimlikNo=@TCKimlik";

            cmnd.Parameters.AddWithValue("@Kullanici", txt_KullaniciAdi.Text);
            cmnd.Parameters.AddWithValue("@Sifre", txt_Sifre.Text);
            cmnd.Parameters.AddWithValue("@AD", txt_ogrtad.Text);
            cmnd.Parameters.AddWithValue("@SOYAD", txt_ogrtsoyad.Text);
            cmnd.Parameters.AddWithValue("@TCKimlik", txt_ogrttckimlik.Text);
            if (rd_erkek2.Checked)
                cmnd.Parameters.AddWithValue("@Cinsiyet", 'E');
            else
                cmnd.Parameters.AddWithValue("@Cinsiyet", 'K');
            cmnd.Parameters.AddWithValue("@DogumTarihi", dogumgunu);
            cmnd.Parameters.AddWithValue("@DogumYeri", txt_ogrtdogyer.Text);
            cmnd.Parameters.AddWithValue("@CepTel", txt_ogrtceptel.Text);
            cmnd.Parameters.AddWithValue("@Adres", txt_ogrtadres.Text);

     //       try
     //       {
                //if (sqlConUpdate.State == ConnectionState.Open)
                    sqlConUpdate.Open();
                    cmnd.ExecuteNonQuery();
                    sqlConUpdate.Close();
    
            //}
            //catch (Exception )
            //{

            //}
            //finally
            //{
            //    if (cmnd != null)
            //        cmnd.Dispose();
            //    if (sqlConUpdate != null)
            //        sqlConUpdate.Close();
            //}
        }

        private void btn_sil2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConDelete = new SqlConnection();


            sqlConDelete.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = sqlConDelete;

            DateTime dogumgunu = new DateTime();
            dogumgunu = dtp_ogrtdogtar.Value;

            cmnd.CommandText = "DELETE FROM Ogretmen WHERE TCKimlikNo=@TCKimlik";
  
            cmnd.Parameters.AddWithValue("@TCKimlik", txt_ogrttckimlik.Text);
        
            try
            {
                sqlConDelete.Open();
                cmnd.ExecuteNonQuery();
                sqlConDelete.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                if (cmnd != null)
                    cmnd.Dispose();
                if (sqlConDelete != null)
                    sqlConDelete.Close();
            }
        
        }

        }

     
    }

