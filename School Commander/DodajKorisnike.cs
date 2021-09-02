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
    public partial class DodajKorisnike : Form
    {
        #region Global Variables

        public static List<Uposlenik> checkedUposlenik = new List<Uposlenik>();
        List<Uposlenik> popisUposlenika = new List<Uposlenik>();

        #endregion

        #region Constructors and OnLoad

        public DodajKorisnike()
        {
            InitializeComponent();
        }

        public DodajKorisnike(Uposlenik uposlenik)
        {
            InitializeComponent();
            popisUposlenika.Clear();
            popisUposlenika.Add(uposlenik);
        }

        private void DodajKorisnike_Load(object sender, EventArgs e)
        {
            UposlenikDataAccess uposlenikDataAccess = new UposlenikDataAccess();

            popisUposlenika = uposlenikDataAccess.FindAllExceptWithThisID(popisUposlenika.First().ID_uposlenika);

            foreach (var uposlenik in popisUposlenika)
            {
                checkedListBoxKorisnici.Items.Add(uposlenik.GetFullName());
            }

            if (checkedUposlenik.Any())
            {
                foreach(var uposlenik in checkedUposlenik)
                {
                    var check = checkedListBoxKorisnici.FindString(uposlenik.GetFullName());
                    checkedListBoxKorisnici.SetItemChecked(check, true);
                }
            }
        }

        #endregion

        #region Events

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            checkedUposlenik.Clear();
            foreach (int uposlenikIndex in checkedListBoxKorisnici.CheckedIndices)
            {
                checkedUposlenik.Add(popisUposlenika[uposlenikIndex]);
            }

            UrediSatnicu izracunSatnice = new UrediSatnicu(checkedUposlenik);
            this.Hide();
        }

        private void btnNatrag_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
