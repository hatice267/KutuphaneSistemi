namespace KutuphaneUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnListele = new Button();
        dataGridView1 = new DataGridView();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        btnEkle = new Button();
        txtKitapAdi = new TextBox();
        txtYazarID = new TextBox();
        txtKategoriID = new TextBox();
        txtYayineviID = new TextBox();
        txtStokAdedi = new TextBox();
        label6 = new Label();
        label7 = new Label();
        txtGuncelleStokAdedi = new TextBox();
        txtGuncelleYayineviID = new TextBox();
        txtGuncelleKategoriID = new TextBox();
        txtGuncelleYazarID = new TextBox();
        txtGuncelleKitapAdi = new TextBox();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        label11 = new Label();
        label12 = new Label();
        label13 = new Label();
        txtGuncelleSilID = new TextBox();
        btnGuncelle = new Button();
        btnSil = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // btnListele
        // 
        btnListele.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnListele.Location = new Point(160, 12);
        btnListele.Name = "btnListele";
        btnListele.Size = new Size(560, 29);
        btnListele.TabIndex = 0;
        btnListele.Text = "Kitapları Listele";
        btnListele.UseVisualStyleBackColor = true;
        btnListele.Click += btnListele_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(27, 47);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(803, 228);
        dataGridView1.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(26, 320);
        label1.Name = "label1";
        label1.Size = new Size(78, 20);
        label1.TabIndex = 7;
        label1.Text = "Kitap Adı :";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(26, 363);
        label2.Name = "label2";
        label2.Size = new Size(70, 20);
        label2.TabIndex = 8;
        label2.Text = "Yazar ID :";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(27, 406);
        label3.Name = "label3";
        label3.Size = new Size(92, 20);
        label3.TabIndex = 9;
        label3.Text = "Kategori ID :";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(26, 451);
        label4.Name = "label4";
        label4.Size = new Size(88, 20);
        label4.TabIndex = 10;
        label4.Text = "Yayınevi ID :";
        label4.Click += label4_Click;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(26, 494);
        label5.Name = "label5";
        label5.Size = new Size(89, 20);
        label5.TabIndex = 11;
        label5.Text = "Stok Adedi :";
        // 
        // btnEkle
        // 
        btnEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnEkle.Location = new Point(26, 529);
        btnEkle.Name = "btnEkle";
        btnEkle.Size = new Size(346, 29);
        btnEkle.TabIndex = 12;
        btnEkle.Text = "Kitap Ekle";
        btnEkle.UseVisualStyleBackColor = true;
        btnEkle.Click += btnEkle_Click;
        // 
        // txtKitapAdi
        // 
        txtKitapAdi.Location = new Point(140, 313);
        txtKitapAdi.Name = "txtKitapAdi";
        txtKitapAdi.Size = new Size(223, 27);
        txtKitapAdi.TabIndex = 13;
        // 
        // txtYazarID
        // 
        txtYazarID.Location = new Point(140, 356);
        txtYazarID.Name = "txtYazarID";
        txtYazarID.Size = new Size(223, 27);
        txtYazarID.TabIndex = 14;
        // 
        // txtKategoriID
        // 
        txtKategoriID.Location = new Point(140, 399);
        txtKategoriID.Name = "txtKategoriID";
        txtKategoriID.Size = new Size(223, 27);
        txtKategoriID.TabIndex = 15;
        // 
        // txtYayineviID
        // 
        txtYayineviID.Location = new Point(140, 444);
        txtYayineviID.Name = "txtYayineviID";
        txtYayineviID.Size = new Size(223, 27);
        txtYayineviID.TabIndex = 16;
        // 
        // txtStokAdedi
        // 
        txtStokAdedi.Location = new Point(140, 487);
        txtStokAdedi.Name = "txtStokAdedi";
        txtStokAdedi.Size = new Size(223, 27);
        txtStokAdedi.TabIndex = 17;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
        label6.Location = new Point(104, 285);
        label6.Name = "label6";
        label6.Size = new Size(157, 25);
        label6.TabIndex = 18;
        label6.Text = "YENİ KİTAP EKLE";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
        label7.Location = new Point(573, 285);
        label7.Name = "label7";
        label7.Size = new Size(202, 25);
        label7.TabIndex = 19;
        label7.Text = "KİTAP GÜNCELLE / SİL";
        // 
        // txtGuncelleStokAdedi
        // 
        txtGuncelleStokAdedi.Location = new Point(620, 531);
        txtGuncelleStokAdedi.Name = "txtGuncelleStokAdedi";
        txtGuncelleStokAdedi.Size = new Size(223, 27);
        txtGuncelleStokAdedi.TabIndex = 29;
        // 
        // txtGuncelleYayineviID
        // 
        txtGuncelleYayineviID.Location = new Point(620, 491);
        txtGuncelleYayineviID.Name = "txtGuncelleYayineviID";
        txtGuncelleYayineviID.Size = new Size(223, 27);
        txtGuncelleYayineviID.TabIndex = 28;
        // 
        // txtGuncelleKategoriID
        // 
        txtGuncelleKategoriID.Location = new Point(620, 444);
        txtGuncelleKategoriID.Name = "txtGuncelleKategoriID";
        txtGuncelleKategoriID.Size = new Size(223, 27);
        txtGuncelleKategoriID.TabIndex = 27;
        // 
        // txtGuncelleYazarID
        // 
        txtGuncelleYazarID.Location = new Point(620, 399);
        txtGuncelleYazarID.Name = "txtGuncelleYazarID";
        txtGuncelleYazarID.Size = new Size(223, 27);
        txtGuncelleYazarID.TabIndex = 26;
        // 
        // txtGuncelleKitapAdi
        // 
        txtGuncelleKitapAdi.Location = new Point(620, 356);
        txtGuncelleKitapAdi.Name = "txtGuncelleKitapAdi";
        txtGuncelleKitapAdi.Size = new Size(223, 27);
        txtGuncelleKitapAdi.TabIndex = 25;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(507, 538);
        label8.Name = "label8";
        label8.Size = new Size(89, 20);
        label8.TabIndex = 24;
        label8.Text = "Stok Adedi :";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(506, 498);
        label9.Name = "label9";
        label9.Size = new Size(88, 20);
        label9.TabIndex = 23;
        label9.Text = "Yayınevi ID :";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(507, 451);
        label10.Name = "label10";
        label10.Size = new Size(92, 20);
        label10.TabIndex = 22;
        label10.Text = "Kategori ID :";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(507, 406);
        label11.Name = "label11";
        label11.Size = new Size(70, 20);
        label11.TabIndex = 21;
        label11.Text = "Yazar ID :";
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new Point(506, 363);
        label12.Name = "label12";
        label12.Size = new Size(78, 20);
        label12.TabIndex = 20;
        label12.Text = "Kitap Adı :";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new Point(506, 320);
        label13.Name = "label13";
        label13.Size = new Size(70, 20);
        label13.TabIndex = 30;
        label13.Text = "Kitap ID :";
        // 
        // txtGuncelleSilID
        // 
        txtGuncelleSilID.Location = new Point(620, 313);
        txtGuncelleSilID.Name = "txtGuncelleSilID";
        txtGuncelleSilID.Size = new Size(223, 27);
        txtGuncelleSilID.TabIndex = 31;
        // 
        // btnGuncelle
        // 
        btnGuncelle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnGuncelle.Location = new Point(506, 581);
        btnGuncelle.Name = "btnGuncelle";
        btnGuncelle.Size = new Size(168, 29);
        btnGuncelle.TabIndex = 32;
        btnGuncelle.Text = "Güncelle";
        btnGuncelle.UseVisualStyleBackColor = true;
        btnGuncelle.Click += btnGuncelle_Click;
        // 
        // btnSil
        // 
        btnSil.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnSil.Location = new Point(693, 581);
        btnSil.Name = "btnSil";
        btnSil.Size = new Size(150, 29);
        btnSil.TabIndex = 33;
        btnSil.Text = "Sil";
        btnSil.UseVisualStyleBackColor = true;
        btnSil.Click += btnSil_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(875, 634);
        Controls.Add(btnSil);
        Controls.Add(btnGuncelle);
        Controls.Add(txtGuncelleSilID);
        Controls.Add(label13);
        Controls.Add(txtGuncelleStokAdedi);
        Controls.Add(txtGuncelleYayineviID);
        Controls.Add(txtGuncelleKategoriID);
        Controls.Add(txtGuncelleYazarID);
        Controls.Add(txtGuncelleKitapAdi);
        Controls.Add(label8);
        Controls.Add(label9);
        Controls.Add(label10);
        Controls.Add(label11);
        Controls.Add(label12);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(txtStokAdedi);
        Controls.Add(txtYayineviID);
        Controls.Add(txtKategoriID);
        Controls.Add(txtYazarID);
        Controls.Add(txtKitapAdi);
        Controls.Add(btnEkle);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(dataGridView1);
        Controls.Add(btnListele);
        MaximizeBox = false;
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnListele;
    private DataGridView dataGridView1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Button btnEkle;
    private TextBox txtKitapAdi;
    private TextBox txtYazarID;
    private TextBox txtKategoriID;
    private TextBox txtYayineviID;
    private TextBox txtStokAdedi;
    private Label label6;
    private Label label7;
    private TextBox txtGuncelleStokAdedi;
    private TextBox txtGuncelleYayineviID;
    private TextBox txtGuncelleKategoriID;
    private TextBox txtGuncelleYazarID;
    private TextBox txtGuncelleKitapAdi;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private TextBox txtGuncelleSilID;
    private Button btnGuncelle;
    private Button btnSil;
}
