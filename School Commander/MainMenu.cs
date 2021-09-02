using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Commander
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            btnIzlaz.Focus();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Želite li izaći iz aplikacije?", "Izlaz iz aplikacije", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNoviProfil_Click(object sender, EventArgs e)
        {
            NoviProfil openNoviProfil = new NoviProfil();
            openNoviProfil.Show();
        }

        private void btnUrediSatnicu_Click(object sender, EventArgs e)
        {
            FindProfil openfindProfil= new FindProfil();
            openfindProfil.Show();
        }

        private void btnUrediProfil_Click(object sender, EventArgs e)
        {
            UrediProfil openUrediProfil = new UrediProfil();
            openUrediProfil.Show();
        }
    }
}
