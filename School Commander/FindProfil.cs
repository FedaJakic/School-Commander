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
        public FindProfil()
        {
            InitializeComponent();
        }

        #region Methods

        private void ResetTexboxes()
        {
            textBoxIme.Text = string.Empty;
            textBoxPrezime.Text = string.Empty;
            findUposenik.Clear();
        }

        #endregion

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            listBoxPronađeniRezultati.Items.Clear();
            findUposenik.Clear();
            UposlenikDataAccess uposlenikDataAccess = new UposlenikDataAccess();
            
            if(Helper.IsEmpty(textBoxIme.Text.ToString()))
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

            

            if(findUposenik == null)
            {
                MessageBox.Show("Ovaj prozor će se zatvorit!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetTexboxes();
                this.Close();
            }
            else if(findUposenik.Count == 0)
            {
                MessageBox.Show("Nije pronađen nijedan korisnik sa ovim imenom i prezimenom", "Nema rezultata!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetTexboxes();
            }
            else
            {
                foreach(var uposlenik in findUposenik)
                {
                    listBoxPronađeniRezultati.Items.Add(uposlenik.GetFullName());
                }
            }
        }

        private void listBoxPronađeniRezultati_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                UrediSatnicu openIspisiSatnicu = new UrediSatnicu(findUposenik[listBoxPronađeniRezultati.SelectedIndex]);
                this.Close();
                openIspisiSatnicu.Show();
            }
            catch
            {
                MessageBox.Show("Nije odabran nijedan korisnik!");
            }
            
        }
    }
}
