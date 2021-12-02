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
    public partial class FrmEntryHasil : Form
    {
        public delegate void CreateUpdateEventHandler(Hasil hsl);
        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private bool isNewData = true;
        private Hasil hsl;

        public FrmEntryHasil(string title)
            : this()
        {
            this.Text = title;
        }
        public FrmEntryHasil(string title, Hasil obj)
         : this()
        {
            this.Text = title;
            isNewData = false;
            hsl = obj;

            cmbOperasi.Text = hsl.Operasi;
            txtNilaiA.Text = hsl.NilaiA;
            txtNilaiB.Text = hsl.NilaiB;
        }
        
        public FrmEntryHasil()
        {
            InitializeComponent();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (isNewData) hsl = new Hasil();
            hsl.Operasi = cmbOperasi.Text;
            hsl.NilaiA = txtNilaiA.Text;
            hsl.NilaiB = txtNilaiB.Text;
            if (isNewData)
            {
                OnCreate(hsl);

                cmbOperasi.Clear();
                txtNilaiA.Clear();
                txtNilaiB.Clear();
                cmbOperasi.Focus();
            }
            else
            {
                OnUpdate(hsl);
                this.Close();
            }

            var a = int.Parse(txtNilaiA.Text);
            var b = Convert.ToInt32(txtNilaiB.Text);

            lstHasil.Items.Add(string.Format("Hasil Penambahan: {0} + {1} = {2}", a, b, Penambahan(a, b)));
            lstHasil.Items.Add(string.Format("Hasil Pengurangan: {0} - {1} = {2}", a, b, Pengurangan(a, b)));
            lstHasil.Items.Add(string.Format("Hasil Perkalian: {0} x {1} = {2}", a, b, Perkalian(a, b)));
            lstHasil.Items.Add(string.Format("Hasil Pembagian: {0} / {1} = {2}", a, b, Pembagian(a, b)));
        }
    }
}
