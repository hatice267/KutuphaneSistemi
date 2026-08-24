using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Data;
namespace KutuphaneUI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void btnListele_Click(object sender, EventArgs e)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "http://localhost:5048/api/kitaplar";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonVeri = await response.Content.ReadAsStringAsync();
                var kitaplar = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(jsonVeri);

                DataTable tablo = new DataTable();

                if (kitaplar != null && kitaplar.Count > 0)
                {
                    // Sütunları oluştur (ilk kitaptaki anahtarlardan)
                    foreach (var sutunAdi in kitaplar[0].Keys)
                    {
                        tablo.Columns.Add(sutunAdi);
                    }

                    // Satırları doldur
                    foreach (var kitap in kitaplar)
                    {
                        DataRow satir = tablo.NewRow();
                        foreach (var anahtar in kitap.Keys)
                        {
                            satir[anahtar] = kitap[anahtar].ToString();
                        }
                        tablo.Rows.Add(satir);
                    }
                }

                dataGridView1.DataSource = tablo;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Hata: " + response.StatusCode);
            }
        }
    }

    private async void btnEkle_Click(object sender, EventArgs e)
    {
        // Önce kontrol edelim
        if (string.IsNullOrWhiteSpace(txtKitapAdi.Text) ||
            string.IsNullOrWhiteSpace(txtYazarID.Text) ||
            string.IsNullOrWhiteSpace(txtYayineviID.Text) ||
            string.IsNullOrWhiteSpace(txtKategoriID.Text) ||
            string.IsNullOrWhiteSpace(txtStokAdedi.Text))
        {
            MessageBox.Show("Lütfen tüm alanları doldurun.");
            return;
        }

        if (!int.TryParse(txtYazarID.Text, out int yazarID) ||
            !int.TryParse(txtYayineviID.Text, out int yayineviID) ||
            !int.TryParse(txtKategoriID.Text, out int kategoriID) ||
            !int.TryParse(txtStokAdedi.Text, out int stokAdedi))
        {
            MessageBox.Show("ID ve Stok Adedi alanları sayı olmalıdır.");
            return;
        }

        using (HttpClient client = new HttpClient())
        {
            string url = "http://localhost:5048/api/kitaplar";

            var yeniKitap = new
            {
                kitapAdi = txtKitapAdi.Text,
                yazarID = yazarID,
                yayineviID = yayineviID,
                kategoriID = kategoriID,
                stokAdedi = stokAdedi
            };

            string jsonVeri = JsonSerializer.Serialize(yeniKitap);
            StringContent icerik = new StringContent(jsonVeri, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, icerik);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Kitap başarıyla eklendi!");
                txtKitapAdi.Clear();
                txtYazarID.Clear();
                txtYayineviID.Clear();
                txtKategoriID.Clear();
                txtStokAdedi.Clear();
            }
            else
            {
                MessageBox.Show("Hata: " + response.StatusCode);
            }
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private async void btnGuncelle_Click(object sender, EventArgs e)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                int id = int.Parse(txtGuncelleSilID.Text);
                string url = $"http://localhost:5048/api/kitaplar/{id}";

                var guncelKitap = new
                {
                    kitapAdi = txtGuncelleKitapAdi.Text,
                    yazarID = int.Parse(txtGuncelleYazarID.Text),
                    yayineviID = int.Parse(txtGuncelleYayineviID.Text),
                    kategoriID = int.Parse(txtGuncelleKategoriID.Text),
                    stokAdedi = int.Parse(txtGuncelleStokAdedi.Text)
                };

                string jsonVeri = JsonSerializer.Serialize(guncelKitap);
                StringContent icerik = new StringContent(jsonVeri, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, icerik);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Kitap başarıyla güncellendi!");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Kitap başarıyla güncellendi!");
                        txtGuncelleSilID.Clear();
                        txtGuncelleKitapAdi.Clear();
                        txtGuncelleYazarID.Clear();
                        txtGuncelleYayineviID.Clear();
                        txtGuncelleKategoriID.Clear();
                        txtGuncelleStokAdedi.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Hata: " + response.StatusCode);
                }
            }
        }
        catch (FormatException)
        {
            MessageBox.Show("Lütfen tüm alanlara geçerli değerler girin.");
        }
    }
    private async void btnSil_Click(object sender, EventArgs e)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                int id = int.Parse(txtGuncelleSilID.Text);
                string url = $"http://localhost:5048/api/kitaplar/{id}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Kitap başarıyla silindi!");
                    txtGuncelleSilID.Clear();
                }
                else
                {
                    MessageBox.Show("Hata: " + response.StatusCode);
                }
            }
        }
        catch (FormatException)
        {
            MessageBox.Show("Lütfen geçerli bir Kitap ID girin.");
        }
    }
}
