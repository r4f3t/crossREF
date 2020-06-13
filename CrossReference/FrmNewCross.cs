using CrossReference.CrossGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossReference
{
    public partial class FrmNewCross : Form
    {
        public FrmNewCross()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrossGeneralManager crossGeneralManager = new CrossGeneralManager();
            if (Form1.GDMLType == "U")
            {
                crossGeneralManager.UpdateCode(TXTCode.Text, Form1.GUrunMarka, Form1.GId);
                MessageBox.Show("Kayıt Güncellendi.");
            }
            else if (Form1.GDMLType == "I")
            {

             
                var modelList = new List<CrossGeneralModel>();
                modelList.Add(new CrossGeneralModel
                {
                    Oem = TXTOem.Text,
                    Marka = TXTOemMarka.Text,
                    UrunKodu = TXTCode.Text,
                    AracTipi = TXTCarType.Text,
                    UrunMarka = TXTMarka.Text
                });

                crossGeneralManager.AddData(modelList);
                MessageBox.Show("Yeni Kayıt Eklendi.");

            }
          
            this.Close();
        }

        private void FrmNewCross_Load(object sender, EventArgs e)
        {
            if (Form1.GDMLType == "U")
            {
                TXTCarType.ReadOnly = true;
                TXTMarka.ReadOnly = true;
                TXTOem.ReadOnly = true;
                TXTOemMarka.ReadOnly = true;
            }
            TXTOem.Text = Form1.GOEM;
            TXTOemMarka.Text = Form1.GOEMMarka;
        }
    }
}
