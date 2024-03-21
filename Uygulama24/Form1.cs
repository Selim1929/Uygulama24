using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama24
{
    public partial class Form1 : Form
    {
        List<Ogrenciler> liste = new List<Ogrenciler>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenciler ogrenciler = new Ogrenciler();
            ogrenciler.AdSoyad=txtAdSoyad.Text;
            ogrenciler.Numara=int.Parse(txtNumara.Text);
            ogrenciler.DersNotu=int.Parse(txtDersNotu.Text);
            liste.Add(ogrenciler);
            Bagla();
        }
        private void Bagla()
        {
            gridListe.DataSource = null;
            gridListe.DataSource = liste;
        }

        private void gridListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                txtNumara.Text = gridListe.CurrentRow.Cells[0].Value.ToString();
                txtAdSoyad.Text = gridListe.CurrentRow.Cells[1].Value.ToString();
                txtDersNotu.Text = gridListe.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            {
                // DataGridView'de seçili bir satırın olup olmadığını kontrol et
                if (gridListe.SelectedRows.Count > 0)
                {
                    // Seçili satırın indeksini al
                    int selectedIndex = gridListe.SelectedRows[0].Index;

                    // DataGridView'deki veri kaynağını al
                    var dataSource = gridListe.DataSource;

                    // Veri kaynağı bir BindingSource ise
                    if (dataSource is BindingSource bindingSource)
                    {
                        // Veri kaynağının List özelliğini kontrol et
                        if (bindingSource.List is IList list)
                        {
                            // Seçili satırı veri kaynağından kaldır
                            list.RemoveAt(selectedIndex);

                            // DataGridView'i güncelle
                            gridListe.DataSource = null;
                            gridListe.DataSource = bindingSource;
                        }
                    }
                    else if (dataSource is IList list)
                    {
                        // Seçili satırı veri kaynağından kaldır
                        list.RemoveAt(selectedIndex);

                        // DataGridView'i güncelle
                        gridListe.DataSource = null;
                       gridListe.DataSource = list;
                    }
                    else
                    {
                        MessageBox.Show("Veri kaynağı doğru formatta değil!");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin!");
                }
            }
        }   
    }
    class Ogrenciler
    {
        public int Numara { get; set; }
        public string AdSoyad { get; set; }
        public int DersNotu { get; set; }
    }
}
