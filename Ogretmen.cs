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
    public partial class Ogretmen : Form
    {
        public Ogretmen()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True");
        private void btn_listele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT OgrenciID as ÖgrenciNo, Adi + ' '+ Soyadi as AdiSoyadi from Ogrenci  ";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.SelectCommand = komut;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_liste.DataSource = dt;
            baglanti.Close();
        }

        private void dgv_liste_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv_liste.CurrentRow != null)
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Select * from Ogrenci where OgrenciID=" + dgv_liste.CurrentRow.Cells[0].Value.ToString(), baglanti);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    lbl_tckimlik2.Text = dr["TCKimlikNo"].ToString();
                    lbl_ogradsoyad.Text = dr["Adi"].ToString();
                    lbl_ogradsoyad.Text += " " + dr["Soyadi"].ToString();
                    string Cinsiyet = "";
                    if (dr["Cinsiyet"].ToString() == "K")
                        Cinsiyet = "Kız";
                    else if (dr["Cinsiyet"].ToString() == "E")
                        Cinsiyet = "Erkek";
                    lbl_ogrcins2.Text = Cinsiyet;
                    lbl_ogrdogtar2.Text = dr["DogumTarihi"].ToString();
                    lbl_ogrdogyer2.Text = dr["DogumYeri"].ToString();

                }
                baglanti.Close();
                baglanti.Open();
                kmt = new SqlCommand("Select * from Veli where OgrenciID=" + dgv_liste.CurrentRow.Cells[0].Value.ToString(), baglanti);
                dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    lbl_veadsoyad.Text = dr["VeliAdi"].ToString();
                    lbl_veadsoyad.Text += " " + dr["VeliSoyadi"].ToString();
                    lbl_veyakder2.Text = dr["YakinlikDerecesi"].ToString();
                    lbl_veevtel2.Text = dr["EvTelNo"].ToString();
                    lbl_veadres2.Text = dr["Adres"].ToString();
                    lbl_veceptel2.Text = dr["CepTelNo"].ToString();
                }
            }
        }

        private void btn_raporla_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            int StartCol = 1;

            int StartRow = 1;

            for (int j = 0; j < dgv_liste.Columns.Count; j++)
            {

                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];

                myRange.Value2 = dgv_liste.Columns[j].HeaderText;

            }

            StartRow++;

            for (int i = 0; i < dgv_liste.Rows.Count; i++)
            {

                for (int j = 0; j < dgv_liste.Columns.Count; j++)
                {

                    try
                    {

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];

                        myRange.Value2 = dgv_liste[j, i].Value == null ? "" : dgv_liste[j, i].Value;

                    }

                    catch
                    {
                        ;
                    }

                }

            }


        }

        private void btn_ogradsoyadara_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            baglanti.Open();
            SqlCommand arakomut = new SqlCommand();
            arakomut.Connection = baglanti;
            arakomut.CommandText = "SELECT *  FROM Ogrenci WHERE Adi + ' '+ Soyadi LIKE '%" + txt_adsoyadara.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(arakomut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_liste.DataSource = dt;
            baglanti.Close();
        }

        private void btn_ogrıdara_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            baglanti.Open();
            SqlCommand arakomut = new SqlCommand();
            arakomut.Connection = baglanti;
            arakomut.CommandText = "SELECT *  FROM Ogrenci WHERE OgrenciID LIKE '%" + txt_ogrıdara.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(arakomut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_liste.DataSource = dt;
            baglanti.Close();
        }

        private void btn_tckimlikara_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=ANAOKULU;Integrated Security=True";
            baglanti.Open();
            SqlCommand arakomut = new SqlCommand();
            arakomut.Connection = baglanti;
            arakomut.CommandText = "SELECT *  FROM Ogrenci WHERE TCKimlikNo LIKE '%" + txt_tckimlikara.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(arakomut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_liste.DataSource = dt;
            baglanti.Close();
        }
    }
}
    


