using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public void VeriGetir( string referans)
        {
          
            if (referans==null)
            {
                return;
            }
            var model = db.CROSS.Where(x => x.CLASS.ToString() == referans).ToList();
            GridItems.DataSource = model;

        }
        private void gezginGetir()
        {
            string itemCode = TXTCode.Text;
            var modelItems = db.CROSS.Where(x => x.ITEMCODE.Replace(" ","").Contains(itemCode.Replace(" ", ""))).ToList();
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
            if (e.KeyChar==13)
            {
                gezginGetir();
            }
            else if (e.KeyChar==27)
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
            if (e.KeyCode==Keys.Down)
            {
                GridGezgin.ClearSelection();
                int index = GridGezgin.CurrentRow.Index;
                
                if (index!=GridGezgin.Rows.Count)
                {
                    index++;
                }
                GridGezgin.Rows[index].Selected = true;
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
            if (e.KeyChar == 13) GridGezgin_CellContentDoubleClick(new object(), new DataGridViewCellEventArgs(0,0));


        }

        private void GridGezgin_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TXTCode.Text= GridGezgin.CurrentRow.Cells[1].Value.ToString();
            GridGezgin.Visible = false;
            VeriGetir(GridGezgin.CurrentRow.Cells[2].Value.ToString());
        }
        #endregion
        #region Exel
        private void veriAktar(string veriyolu)
        {
            // Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@veriyolu);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int RowNumber = xlRange.Rows.Count;
            int ColNumber = xlRange.Columns.Count;
            string[,] gridVeri = new string[50, 50];
            for (int i = 0; i < RowNumber; i++)
            {
                for (int j = 0; j < ColNumber; j++)
                {
                    gridVeri[i, j] = xlRange.Cells[i + 1, j + 1].Value2.toString();
                }
            }

            


        }
        private void BTNAktar_Click(object sender, EventArgs e)
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
            veriAktar(DosyaYolu);
            
        }
        #endregion
    }
}
