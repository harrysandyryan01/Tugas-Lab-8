using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class FrmHasil : Form
    {
        private IList<Hasil> listOfHasil = new List<Hasil>();

        public FrmHasil()
        {
            InitializeComponent();
        }

        public int Penambahan(int a, int b)
        {
            return a + b;
        }
        public int Pengurangan(int a, int b)
        {
            return a - b;
        }
        public int Perkalian(int a, int b)
        {
            return a * b;
        }
        public int Pembagian(int a, int b)
        {
            return a / b;
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            FrmEntryHasil frmEntry = new FrmEntryHasil("Calculator");
            
            frmEntry.OnCreate += FrmEntry_OnCreate;
 
            frmEntry.ShowDialog();
        }
    }
}
