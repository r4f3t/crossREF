﻿using CrossReference.CrossGeneral;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace CrossReference
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        #region UrunArama



        private void gezginGetir()
        {
            string itemCode = TXTCode.Text;
            //  //GridGezgin.Visible = true;
            CrossGeneralManager crossGeneralManager = new CrossGeneralManager();
            GridItems.DataSource = crossGeneralManager.SearchCrossB2B(itemCode);
            this.Text = "Kayıt Sayısı:" + GridItems.Rows.Count;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            gezginGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TXTCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                gezginGetir();
            }
            else if (e.KeyChar == 27)
            {
                TXTCode.Text = "";
            }
            else if (e.KeyChar.Equals(Keys.Down))
            {

            }
        }



        private void TXTCode_TextChanged(object sender, EventArgs e)
        {
            //      gezginGetir();
        }

        private void TXTCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                //GridGezgin.Focus();
            }
        }

        private void TXTCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
            }
        }

        private void GridGezgin_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridGezgin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //GridGezginEnter();
            }


        }

        private void GridGezgin_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
        #region Excel

        public class Urun
        {
            public string Kod1 { get; set; }
            public string Kod2 { get; set; }
            public string MARKA { get; set; }
            public string ARAC_TURU { get; set; }
        }
        public Func<string, string, bool> compareSpaceless = (a, b) => a.Trim(' ') == b.Trim(' ');
        private void veriAktar(string veriyolu, string extension)
        {
            if (String.IsNullOrEmpty(veriyolu))
            {
                MessageBox.Show("Dosya Seçmediniz !!!");
                return;
            }
            List<CrossGeneralModel> uruns = new List<CrossGeneralModel>();
            FileStream streamTemp = File.Open(veriyolu, FileMode.Open, FileAccess.Read);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(streamTemp))
            {
                var currentSheet = package.Workbook.Worksheets;
                var workSheet = currentSheet[0];//florists
                var noOfCol = workSheet.Dimension.End.Column;
                var noOfRow = workSheet.Dimension.End.Row;
                for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
                {
                    var urun = new CrossGeneralModel();
                    urun.AracTipi = workSheet.Cells[rowIterator, 1].Value != null ? workSheet.Cells[rowIterator, 1].Value.ToString() : string.Empty;
                    urun.Marka = workSheet.Cells[rowIterator, 2].Value != null ? workSheet.Cells[rowIterator, 2].Value.ToString() : string.Empty;
                    urun.Oem = workSheet.Cells[rowIterator, 3].Value != null ? workSheet.Cells[rowIterator, 3].Value.ToString() : string.Empty;
                    urun.UrunKodu = workSheet.Cells[rowIterator, 4].Value != null ? workSheet.Cells[rowIterator, 4].Value.ToString() : string.Empty;
                    urun.UrunMarka = workSheet.Cells[rowIterator, 5].Value != null ? workSheet.Cells[rowIterator, 5].Value.ToString() : string.Empty;
                    if (!(String.IsNullOrEmpty(urun.AracTipi)))
                    {
                        uruns.Add(urun);
                    }

                    progressBar1.Value = (progressBar1.Value >= 100) ? 0 : progressBar1.Value;
                    progressBar1.Value++;
                }
                GRPLoader.Text = "Veriler Okundu";
                int i = 0;
                foreach (var item in uruns)
                {
                    if (i == 0)
                    {
                        CrossGeneralManager crossGeneralManager = new CrossGeneralManager();
                        crossGeneralManager.AddData(uruns);
                    }
                    progressBar1.Value = (progressBar1.Value >= 100) ? 0 : progressBar1.Value;
                    progressBar1.Value++;
                    GRPLoader.Text = "Veriler Dbye Yazılıyor.";
                    i++;
                }


                GRPLoader.Text = "Veriler Dbye Yazıldı";
                GRPLoader.Visible = false;
                MessageBox.Show("Aktarım Tamamlandı");
            }
        }
        private async void BTNAktar_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Excel Dosyası |*.xlsx";
                file.FilterIndex = 2;
                file.RestoreDirectory = true;
                file.CheckFileExists = false;
                file.Title = "Excel Dosyası Seçiniz..";
                file.ShowDialog();

                string DosyaYolu = file.FileName;
                string DosyaAdi = file.SafeFileName;
                GRPLoader.Visible = true;
                GRPLoader.Text = "Veriler Belleğe Okunuyor";
                Task task = Task.Factory.StartNew(() => veriAktar(DosyaYolu, Path.GetExtension(DosyaYolu)));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void GridGezginEnter()
        {
            //  TXTCode.Text = GridGezgin.CurrentRow.Cells[1].Value.ToString();
            //GridGezgin.Visible = false;
            //VeriGetir(//GridGezgin.CurrentRow.Cells[2].Value.ToString());
        }
        private void GridGezgin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //GridGezginEnter();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GDMLType = "I";
            //FrmNewCross frmNewCross = new FrmNewCross();
            //frmNewCross.Show();
            GridItems.Rows.Add("");
        }
        public static string GOEM, GOEMMarka, GUrunKodu, GUrunMarka, GAracTipi, GId, GDMLType;
        Font newFont = new Font("Tahoma", 12f, FontStyle.Regular);
        private void GridItems_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            e.CellElement.Font = newFont;
            e.Row.Height = 50;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            GridItems.Width = this.Width - 50;
            GridItems.Height = this.Height - 50;
            for (int i = 1; i < GridItems.Columns.Count; i++)
            {
                GridItems.MasterTemplate.Columns[i].Width = GridItems.Width / GridItems.Columns.Count;
            }
        }

        private void GridItems_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
          
        }

        private void GridItems_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
          
        }

        private void GridItems_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                var id = GridItems.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (!String.IsNullOrEmpty(id))
                {

                    var se = sender;
                    var er = e;
                    var newValue = GridItems.Rows[e.RowIndex].Cells["UrunKodu"].Value.ToString();
                    var urunMarka = GridItems.Rows[e.RowIndex].Cells["CatalogName"].Value.ToString();
                    CrossGeneralManager crossGeneralManager = new CrossGeneralManager();
                    crossGeneralManager.UpdateCode(newValue, urunMarka, id);
                   // MessageBox.Show("Kayıt Güncellendi.");

                }
                else
                {
                    //kontrol et

                    var oem = GridItems.Rows[e.RowIndex].Cells["OEM"].Value;
                    var oemMarka = GridItems.Rows[e.RowIndex].Cells["Marka"].Value;
                    var urunKodu = GridItems.Rows[e.RowIndex].Cells["UrunKodu"].Value;
                    var urunMarka = GridItems.Rows[e.RowIndex].Cells["CatalogName"].Value;

                    if (oem == null)
                    {

                        return;
                    }
                    if (oemMarka == null)
                    {
                        return;
                    }
                    if (urunKodu == null)
                    {
                        return;
                    }
                    if (urunMarka == null)
                    {
                        return;
                    }


                    var modelList = new List<CrossGeneralModel>();
                    modelList.Add(new CrossGeneralModel
                    {
                        Oem = oem.ToString(),
                        Marka = oemMarka.ToString(),
                        UrunKodu = urunKodu.ToString(),
                        AracTipi = "",
                        UrunMarka = urunMarka.ToString()
                    });
                    CrossGeneralManager crossGeneralManager = new CrossGeneralManager();
                    crossGeneralManager.AddData(modelList);
                    MessageBox.Show("Yeni Kayıt Eklendi.");
                }

            }
            catch (Exception ex)
            {

             
            }
        }

        private void GridItems_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //GOEM = GridItems.Rows[e.RowIndex].Cells["OEM"].Value.ToString();
            //GOEMMarka = GridItems.Rows[e.RowIndex].Cells["Marka"].Value.ToString();
            //GUrunKodu = GridItems.Rows[e.RowIndex].Cells["UrunKodu"].Value.ToString();
            //GUrunMarka = GridItems.Rows[e.RowIndex].Cells["CatalogName"].Value.ToString();
            //GId = GridItems.Rows[e.RowIndex].Cells["Id"].Value.ToString();

            //GDMLType = "U";
            //FrmNewCross frmNewCross = new FrmNewCross();
            //frmNewCross.Show();
        }

        private void GridItems_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                GOEM = GridItems.Rows[e.RowIndex].Cells["OEM"].Value.ToString();
                GOEMMarka = GridItems.Rows[e.RowIndex].Cells["Marka"].Value.ToString();
                GUrunKodu = GridItems.Rows[e.RowIndex].Cells["UrunKodu"].Value.ToString();
                GUrunMarka = GridItems.Rows[e.RowIndex].Cells["CatalogName"].Value.ToString();
                GId = GridItems.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (GUrunMarka != "MANN HUMMEL" && GUrunMarka != "FLEETGUARD")
                {
                    BTNSil.Visible = true;
                }
                else
                {
                    BTNSil.Visible = false;
                }

            }
            catch (Exception)
            {

            }
        }

        private void BTNSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(GOEM + " Oem Kaydı Silinecektir Emin misiniz ?", "Kayıt Sil", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!String.IsNullOrEmpty(GId))
                {
                    CrossGeneralManager crossGeneralManager = new CrossGeneralManager();
                    var deleteResult = crossGeneralManager.DeleteCross(GId);
                    if (deleteResult)
                    {
                        gezginGetir();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }


    }
}
