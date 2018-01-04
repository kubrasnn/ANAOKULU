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
    public partial class KayitEkleme : Form
    {
        public KayitEkleme()
        {
            InitializeComponent();
        }

        private void KayıtEkleme_Load(object sender, EventArgs e)
        {

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConInsert = new SqlConnection();


            sqlConInsert.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = sqlConInsert;

            DateTime dogumgunu = new DateTime();
            dogumgunu = dtp_ogrdogtar.Value;


            cmnd.CommandText = "INSERT INTO Ogrenci (TCKimlikNo, Adi, Soyadi,DogumTarihi,DogumYeri,Cinsiyet,Sinif) " +
                               "VALUES (@TCKimlik,@AD, @SOYAD,@DogumTarihi,@DogumYeri,@Cinsiyet,@Sinif) ";

                       

            cmnd.Parameters.AddWithValue("@TCKimlik", txt_tckimlik.Text);
            cmnd.Parameters.AddWithValue("@AD", txt_ograd.Text);
            cmnd.Parameters.AddWithValue("@SOYAD", txt_ogrsoyad.Text);
            cmnd.Parameters.AddWithValue("@DogumTarihi", dogumgunu);
            cmnd.Parameters.AddWithValue("@DogumYeri", txt_dogyer.Text);
            cmnd.Parameters.AddWithValue("@Sinif",txt_sinif.Text);
            if (rd_erkek.Checked)
                cmnd.Parameters.AddWithValue("@Cinsiyet", 'E');
            else
                cmnd.Parameters.AddWithValue("@Cinsiyet", 'K');
            

            cmnd.Parameters.AddWithValue("@VeliAD", txt_vead.Text);
            cmnd.Parameters.AddWithValue("@VeliSOYAD", txt_vesoyad.Text);
            cmnd.Parameters.AddWithValue("@YakinlikDer", txt_veyakder.Text);
            cmnd.Parameters.AddWithValue("@EvTel", txt_veevtel.Text);
            cmnd.Parameters.AddWithValue("@CepTel", txt_veceptel.Text);
            cmnd.Parameters.AddWithValue("@Adres", txt_veadres.Text);

            if (ch_evet.Checked)
              cmnd.Parameters.AddWithValue("@Servis", 1);
            else
              cmnd.Parameters.AddWithValue("@Servis", 0);
            cmnd.Parameters.AddWithValue("@OUcret", txt_aucret.Text);
            cmnd.Parameters.AddWithValue("@SUcret", txt_sucret.Text);
            cmnd.Parameters.AddWithValue("@OSekli",cb_odsekli.Text );
            cmnd.Parameters.AddWithValue("@Taksit",cb_setaksit.Text );

           //try
           // {
                sqlConInsert.Open();
                cmnd.ExecuteNonQuery();
                

                cmnd.CommandText = "select Top 1 (OgrenciID) from Ogrenci order by OgrenciID DESC";
                //cmnd.ExecuteNonQuery();
                int id=-6;
                SqlDataReader sqlRead;
                sqlRead = cmnd.ExecuteReader();
                while (sqlRead.Read())
                {
                    id = sqlRead.GetInt32(0); 
                }
                sqlRead.Close();
                cmnd.Parameters.AddWithValue("@OgrenciID", id);
                cmnd.CommandText = "INSERT INTO Veli (VeliAdi,VeliSoyadi,YakinlikDerecesi,EvTelNo,CepTelNo,Adres,OgrenciID) " +
                                   "VALUES (@VeliAD, @VeliSOYAD,@YakinlikDer,@EvTel,@CepTel,@Adres,@OgrenciID) ";

                cmnd.ExecuteNonQuery();


                cmnd.CommandText = "INSERT INTO UcretBilgileri (ServisVarMı,OkulUcreti,ServisUcreti,OdemeSekli,Taksit,OgrenciID) " +
                                   "VALUES (@Servis,@OUcret, @SUcret,@OSekli,@Taksit,@OgrenciID) ";
                cmnd.ExecuteNonQuery();
                sqlConInsert.Close();
              
            //}
            //catch (Exception )
            //{

            //}
            //finally
            //{
            //    if (cmnd != null)
            //        cmnd.Dispose();
            //    if (sqlConInsert != null)
            //        sqlConInsert.Close();
            //}
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConUpdate = new SqlConnection();


            sqlConUpdate.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = sqlConUpdate;

            DateTime dogumgunu = new DateTime();
            dogumgunu = dtp_ogrdogtar.Value;


            cmnd.CommandText = "UPDATE Ogrenci SET TCKimlikNo=@TCKimlik,Adi=@AD,Soyadi=@SOYAD,DogumTarihi=@DogumTarihi,DogumYeri=@DogumYeri,Cinsiyet=@Cinsiyet,Sinif=@Sinif WHERE TCKimlikNo=@TCKimlik";
                              

            cmnd.Parameters.AddWithValue("@TCKimlik", txt_tckimlik.Text);
            cmnd.Parameters.AddWithValue("@AD", txt_ograd.Text);
            cmnd.Parameters.AddWithValue("@SOYAD", txt_ogrsoyad.Text);
            cmnd.Parameters.AddWithValue("@DogumTarihi", dogumgunu);
            cmnd.Parameters.AddWithValue("@DogumYeri", txt_dogyer.Text);
            cmnd.Parameters.AddWithValue("@Sinif",txt_sinif.Text);
            if (rd_erkek.Checked)
                cmnd.Parameters.AddWithValue("@Cinsiyet", 'E');
            else
                cmnd.Parameters.AddWithValue("@Cinsiyet", 'K');


            cmnd.Parameters.AddWithValue("@VeliAD", txt_vead.Text);
            cmnd.Parameters.AddWithValue("@VeliSOYAD", txt_vesoyad.Text);
            cmnd.Parameters.AddWithValue("@YakinlikDer", txt_veyakder.Text);
            cmnd.Parameters.AddWithValue("@EvTel", txt_veevtel.Text);
            cmnd.Parameters.AddWithValue("@CepTel", txt_veceptel.Text);
            cmnd.Parameters.AddWithValue("@Adres", txt_veadres.Text);

            if (ch_evet.Checked)
                cmnd.Parameters.AddWithValue("@Servis", 1);
            else
                cmnd.Parameters.AddWithValue("@Servis", 0);
            cmnd.Parameters.AddWithValue("@OUcret",txt_aucret.Text);
            cmnd.Parameters.AddWithValue("@SUcret", txt_sucret.Text);
            cmnd.Parameters.AddWithValue("@OSekli", cb_odsekli.Text);
            cmnd.Parameters.AddWithValue("@Taksit", cb_setaksit.Text);

            //try
            //{
            //    if (sqlConUpdate.State == ConnectionState.Open)  
                sqlConUpdate.Open();
                cmnd.ExecuteNonQuery();
               


                cmnd.CommandText = "select OgrenciID from Ogrenci WHERE Ogrenci.TCKimlikNo=@TCKimlik";
                //cmnd.ExecuteNonQuery();
                SqlDataReader sqlRead;
                sqlRead = cmnd.ExecuteReader();
                int id = 0;
                while (sqlRead.Read())
                {
                    id = sqlRead.GetInt32(0);
                }
                sqlRead.Close();
                cmnd.Parameters.Clear();
                cmnd.Parameters.AddWithValue("@TCKimlik", txt_tckimlik.Text);
                
               cmnd.CommandText= "UPDATE Veli SET VeliAdi=@VeliAD,VeliSoyadi=@VeliSOYAD,YakinlikDerecesi=@YakinlikDer,EvTelNo=@EvTel,CepTelNo=@CepTel,Adres=@Adres WHERE CepTelNo=@CepTel ";
               cmnd.Parameters.AddWithValue("@VeliAD", txt_vead.Text);
               cmnd.Parameters.AddWithValue("@VeliSOYAD", txt_vesoyad.Text);
               cmnd.Parameters.AddWithValue("@YakinlikDer", txt_veyakder.Text);
               cmnd.Parameters.AddWithValue("@EvTel", txt_veevtel.Text);
               cmnd.Parameters.AddWithValue("@CepTel", txt_veceptel.Text);
               cmnd.Parameters.AddWithValue("@Adres", txt_veadres.Text);
               cmnd.Parameters.AddWithValue("@OgrenciID", id);
               cmnd.ExecuteNonQuery();

               cmnd.CommandText = "select VeliID from Veli WHERE Veli.CepTelNo=@CepTel ";
               //cmnd.ExecuteNonQuery();
               SqlDataReader sqlRead2;
               sqlRead2 = cmnd.ExecuteReader();
               while (sqlRead2.Read())
               {
                   txt_veceptel.Text = sqlRead2.GetInt32(0).ToString();
               }
               cmnd.Parameters.Clear();
               sqlRead2.Close();
               cmnd.Parameters.AddWithValue("@CepTel", txt_veceptel.Text);
                cmnd.CommandText="UPDATE UcretBilgileri SET ServisVarMı=@Servis,OkulUcreti=@OUcret,ServisUcreti=@SUcret,OdemeSekli=@OSekli,Taksit=@Taksit ";

                if (ch_evet.Checked)
                    cmnd.Parameters.AddWithValue("@Servis", 1);
                else
                    cmnd.Parameters.AddWithValue("@Servis", 0);
                cmnd.Parameters.AddWithValue("@OUcret", txt_aucret.Text);
                cmnd.Parameters.AddWithValue("@SUcret", txt_sucret.Text);
                cmnd.Parameters.AddWithValue("@OSekli", cb_odsekli.Text);
                cmnd.Parameters.AddWithValue("@Taksit", cb_setaksit.Text);
               cmnd.ExecuteNonQuery();
                sqlConUpdate.Close();

            //}
            //catch (Exception)
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

        private void btn_sil_Click(object sender, EventArgs e)
        {
             SqlConnection sqlConDelete = new SqlConnection();


            sqlConDelete.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = sqlConDelete;

            DateTime dogumgunu = new DateTime();
            dogumgunu = dtp_ogrdogtar.Value;


            cmnd.CommandText = "DELETE FROM Ogrenci WHERE TCKimlikNo=@TCKimlik";

            cmnd.Parameters.AddWithValue("@TCKimlik", txt_tckimlik.Text);
       
           
           //try
           // {
                sqlConDelete.Open();
                cmnd.ExecuteNonQuery();
                sqlConDelete.Close();

              
            //}
            //catch (Exception )
            //{

            //}
            //finally
            //{
            //    if (cmnd != null)
            //        cmnd.Dispose();
            //    if (sqlConDelete != null)
            //        sqlConDelete.Close();
            //}
        
        }

       
    }
}
