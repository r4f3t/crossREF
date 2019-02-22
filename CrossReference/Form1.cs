using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CrossReference
{
    public partial class Form1 : Form
    {
        CROSSDBEntities1 db = new CROSSDBEntities1();
        public Form1()
        {
            InitializeComponent();
        }
        #region UrunArama
        private void gezginVeriYolla()
        {
            string referans = GridGezgin.CurrentRow.Cells[2].Value.ToString();
            TXTCode.Text = GridGezgin.CurrentRow.Cells[1].Value.ToString();
            VeriGetir(referans);
            GridGezgin.Visible = false;
        }

        public void VeriGetir(string referans)
        {

            if (referans == null)
            {
                return;
            }
            var model = db.CROSS.Where(x => x.CLASS.ToString() == referans).ToList();
            GridItems.DataSource = model;

        }
        private void gezginGetir()
        {
            string itemCode = TXTCode.Text;
            var modelItems = db.CROSS.Where(x => x.ITEMCODE.Replace(" ", "").Contains(itemCode.Replace(" ", ""))).ToList();
            GridGezgin.Visible = true;
            GridGezgin.DataSource = modelItems;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            gezginGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gezginVeriYolla();
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
            gezginGetir();
        }

        private void TXTCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                GridGezgin.Focus();
            }
        }
        private void GridGezgin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                GridGezgin.Focus();
            }
            else if(e.KeyCode==Keys.Up)
            {
                if (GridGezgin.CurrentRow.Index == 0) TXTCode.Focus();
            }
        }
        private void TXTCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                GridGezgin.ClearSelection();
                int index = GridGezgin.CurrentRow.Index;

                if (index != 0)
                {
                    index--;
                }
                GridGezgin.Rows[index].Selected = true;
            }
        }

        private void GridGezgin_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("rafet");
        }

        private void GridGezgin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) GridGezgin_CellContentDoubleClick(new object(), new DataGridViewCellEventArgs(0, 0));


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
        }
        public Func<string, string, bool> compareSpaceless = (a, b) => a.Trim(' ') == b.Trim(' ');
        private void veriAktar(string veriyolu, string extension)
        {

            List<Urun> uruns = new List<Urun>();
            FileStream streamTemp = File.Open(veriyolu, FileMode.Open, FileAccess.Read);
            using (var package = new ExcelPackage(streamTemp))
            {
                var currentSheet = package.Workbook.Worksheets;
                var workSheet = currentSheet.First();
                var noOfCol = workSheet.Dimension.End.Column;
                var noOfRow = workSheet.Dimension.End.Row;
                string[,] gridVeri = new string[50, 50];
                for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
                {
                    var urun = new Urun();
                    urun.Kod1 = workSheet.Cells[rowIterator, 1].Value != null ? workSheet.Cells[rowIterator, 1].Value.ToString() : string.Empty;
                    urun.Kod2 = workSheet.Cells[rowIterator, 2].Value != null ? workSheet.Cells[rowIterator, 2].Value.ToString() : string.Empty;
                    uruns.Add(urun);
                    progressBar1.Value = (progressBar1.Value >= 100) ? 0 : progressBar1.Value;
                    progressBar1.Value++;

                    // ListExcel.Items.Add($"{urun.Kod1}<---> {urun.Kod2}");
                   
                }
                GRPLoader.Text = "Veriler Okundu";
                foreach (var item in uruns)
                {
                    var veri = db.CROSS.Where(x => x.ITEMCODE.Replace(" ", "") == item.Kod1.Replace(" ", "")).FirstOrDefault();
                    var veri2 = db.CROSS.Where(x => x.ITEMCODE.Replace(" ", "") == item.Kod2.Replace(" ", "")).FirstOrDefault();
                    if (veri != null && veri2 == null)
                    {
                        db.CROSS.Add(new CROSS() { ITEMCODE = item.Kod2, CLASS = veri.CLASS });
                    }
                    else if (veri == null && veri2 != null)
                    {
                        db.CROSS.Add(new CROSS() { ITEMCODE = item.Kod1, CLASS = veri2.CLASS });
                    }
                    else if (veri==null && veri2==null)
                    {
                        var modelNumarator = db.NUMARATOR.Find(1);
                        db.CROSS.Add(new CROSS() { ITEMCODE = item.Kod1, CLASS = modelNumarator.NUMBER});
                        db.CROSS.Add(new CROSS() { ITEMCODE = item.Kod2, CLASS = modelNumarator.NUMBER });
                        modelNumarator.NUMBER++;
                        db.NUMARATOR.AddOrUpdate(modelNumarator);
                        
                    }
                    progressBar1.Value = (progressBar1.Value >= 100) ? 0 : progressBar1.Value;
                    progressBar1.Value++;
                    GRPLoader.Text = "Veriler Dbye Yazılıyor.";
                }

                db.SaveChanges();
                GRPLoader.Text = "Veriler Dbye Yazıldı";
                GRPLoader.Visible = false;
                MessageBox.Show("Aktarım Tamamlandı");
            }
        }
        private async void BTNAktar_Click(object sender, EventArgs e)
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
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void GridGezgin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TXTCode.Text = GridGezgin.CurrentRow.Cells[1].Value.ToString();
            GridGezgin.Visible = false;
            VeriGetir(GridGezgin.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
