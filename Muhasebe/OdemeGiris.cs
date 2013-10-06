﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class OdemeGiris : Form
    {
        public Form1.Odeme odeme;
        public Boolean okay = false;
        public Boolean sil = false;

        public OdemeGiris()
        {
            InitializeComponent();
        }

        public OdemeGiris(Form1.Odeme _odeme)
        {
            InitializeComponent();
            odeme = _odeme;
            btSil.Enabled = true;
            tbTarih.Text = odeme.tarih;
            tbSekil.Text = odeme.odemeSekli;
            tbAciklama.Text = odeme.aciklama;
            tbTutar.Text = odeme.tutar.ToString();
        }

        private void btEkle_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                okay = true;
                odeme = new Form1.Odeme(tbTarih.Text, tbSekil.Text, double.Parse(tbTutar.Text), tbAciklama.Text);
                this.Hide();
            }
            else MessageBox.Show("Lütfen yıldızlı alanları eksiksiz doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Check()
        {
            long number1 = 0;
            if (long.TryParse(tbTutar.Text, out number1) && tbTarih.Text != "") return true;
            else return false;
        }

        private void btIptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btSil_Click(object sender, EventArgs e)
        {
            sil = true;
            this.Hide();
        }
    }
}
