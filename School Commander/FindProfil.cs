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
    public partial class FindProfil : Form
    {
        List<Uposlenik> findUposenik = new List<Uposlenik>();
        public int formID = 0;
        //1 -> Uredi Profil
        //2 -> Ispisi Satnicu
        public FindProfil(int _formID)
        {
            InitializeComponent();
            this.formID = _formID;
        }

        #region Methods

        private void ResetTexboxes()
        {
            textBoxIme.Text = string.Empty;
            textBoxPrezime.Text = string.Empty;
            findUposenik.Clear();
        }

        private void SearchForEmployee()
        {
            listBoxPronađeniRezultati.Items.Clear();
            findUposenik.Clear();
            UposlenikDataAccess uposlenikDataAccess = new UposlenikDataAccess();

            if (Helper.IsEmpty(textBoxIme.Text.ToString()))
            {
                findUposenik = uposlenikDataAccess.FindUposlenikByLastName(textBoxPrezime.Text.ToString());
            }
            else if (Helper.IsEmpty(textBoxPrezime.Text.ToString()))
            {
                findUposenik = uposlenikDataAccess.FindUposlenikByFirstName(textBoxIme.Text.ToString());
            }
            else
            {
                findUposenik = uposlenikDataAccess.FindUposlenikByFirstNameAndALastName(textBoxIme.Text.ToString(), textBoxPrezime.Text.ToString());
            }



            if (findUposenik == null)
            {
                MessageBox.Show("Ovaj prozor će se zatvorit!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetTexboxes();
                this.Close();
            }
            else if (findUposenik.Count == 0)
            {
                MessageBox.Show("Nije pronađen nijedan korisnik sa ovim imenom i prezimenom", "Nema rezultata!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetTexboxes();
            }
            else
            {
                foreach (var uposlenik in findUposenik)
                {
                    listBoxPronađeniRezultati.Items.Add(uposlenik.GetFullName());
                }
            }
        }

        #endregion

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            SearchForEmployee();
        }

        private void listBoxPronađeniRezultati_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(formID == 1)
                {
                    UrediSatnicu openUrediSatnicu = new UrediSatnicu(findUposenik[listBoxPronađeniRezultati.SelectedIndex]);
                    this.Close();
                    openUrediSatnicu.Show();
                }
                else if(formID == 2)
                {
                    IspisiSatnicu openIspisiSatnicu = new IspisiSatnicu(findUposenik[listBoxPronađeniRezultati.SelectedIndex]);
                    this.Close();
                    openIspisiSatnicu.Show();
                }
                else if(formID == 3)
                {
                    UrediProfil openUrediProfil = new UrediProfil(findUposenik[listBoxPronađeniRezultati.SelectedIndex]);
                    this.Close();
                    openUrediProfil.Show();
                }
            }
            catch
            {
                MessageBox.Show("Nije odabran nijedan korisnik!");
            }
            
        }
    }
}
