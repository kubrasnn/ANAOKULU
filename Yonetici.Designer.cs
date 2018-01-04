namespace ANAOKULU
{
    partial class Yonetici
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_OgrenciKayitEkle = new System.Windows.Forms.Button();
            this.btn_OgretmenKayitEkle = new System.Windows.Forms.Button();
            this.btn_OgrenciListe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_OgrenciKayitEkle
            // 
            this.btn_OgrenciKayitEkle.Location = new System.Drawing.Point(103, 28);
            this.btn_OgrenciKayitEkle.Name = "btn_OgrenciKayitEkle";
            this.btn_OgrenciKayitEkle.Size = new System.Drawing.Size(231, 36);
            this.btn_OgrenciKayitEkle.TabIndex = 0;
            this.btn_OgrenciKayitEkle.Text = "Öğrenci Kayıt Ekleme/Güncelleme/Silme";
            this.btn_OgrenciKayitEkle.UseVisualStyleBackColor = true;
            this.btn_OgrenciKayitEkle.Click += new System.EventHandler(this.btn_OgrenciKayitEkle_Click);
            // 
            // btn_OgretmenKayitEkle
            // 
            this.btn_OgretmenKayitEkle.Location = new System.Drawing.Point(103, 70);
            this.btn_OgretmenKayitEkle.Name = "btn_OgretmenKayitEkle";
            this.btn_OgretmenKayitEkle.Size = new System.Drawing.Size(231, 38);
            this.btn_OgretmenKayitEkle.TabIndex = 1;
            this.btn_OgretmenKayitEkle.Text = "Öğretmen Kayıt Ekleme/Güncelleme/Silme";
            this.btn_OgretmenKayitEkle.UseVisualStyleBackColor = true;
            this.btn_OgretmenKayitEkle.Click += new System.EventHandler(this.btn_OgretmenKayitEkle_Click);
            // 
            // btn_OgrenciListe
            // 
            this.btn_OgrenciListe.Location = new System.Drawing.Point(103, 114);
            this.btn_OgrenciListe.Name = "btn_OgrenciListe";
            this.btn_OgrenciListe.Size = new System.Drawing.Size(231, 37);
            this.btn_OgrenciListe.TabIndex = 2;
            this.btn_OgrenciListe.Text = "Öğrenci Listesi";
            this.btn_OgrenciListe.UseVisualStyleBackColor = true;
            this.btn_OgrenciListe.Click += new System.EventHandler(this.btn_OgrenciListe_Click);
            // 
            // Yonetici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(420, 188);
            this.Controls.Add(this.btn_OgrenciListe);
            this.Controls.Add(this.btn_OgretmenKayitEkle);
            this.Controls.Add(this.btn_OgrenciKayitEkle);
            this.Name = "Yonetici";
            this.Text = "Yönetici";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OgrenciKayitEkle;
        private System.Windows.Forms.Button btn_OgretmenKayitEkle;
        private System.Windows.Forms.Button btn_OgrenciListe;
    }
}