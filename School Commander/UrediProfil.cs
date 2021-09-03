using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace School_Commander
{
    public partial class UrediProfil : Form
    {
        public static Uposlenik uposlenik = new Uposlenik();

        public UrediProfil(Uposlenik izabraniUposlenik)
        {
            InitializeComponent();
            PopulateAllComboBoxes();

            uposlenik = izabraniUposlenik;
        }

        private void UrediProfil_Load(object sender, EventArgs e)
        {
            textBoxIme.Text = uposlenik.ime.ToString();
            textBoxPrezime.Text = uposlenik.prezime.ToString();
            if (uposlenik.radnoMjesto.Contains(","))
            {
                checkBoxObavljaDvaRadnaMjesta.Checked = true;
                int getIndex = uposlenik.radnoMjesto.IndexOf(",");
                string job = uposlenik.radnoMjesto.Substring(0, getIndex);
                comboBoxRadnoMjesto.SelectedIndex = comboBoxRadnoMjesto.FindStringExact(job);
                job = uposlenik.radnoMjesto.Substring(getIndex + 2);
                comboBoxRadnoMjesto2.SelectedIndex = comboBoxRadnoMjesto2.FindStringExact(job);
            }
            else
            {
                checkBoxObavljaDvaRadnaMjesta.Checked = false;
                comboBoxRadnoMjesto2.Enabled = false;
                comboBoxRadnoMjesto.SelectedIndex = comboBoxRadnoMjesto.FindStringExact(uposlenik.radnoMjesto.ToString());
            }
        }

        private void checkBoxObavljaDvaRadnaMjesta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxObavljaDvaRadnaMjesta.Checked)
                comboBoxRadnoMjesto2.Enabled = true;
            else
                comboBoxRadnoMjesto2.Enabled = false;
        }

        private void PopulateAllComboBoxes()
        {
            RadnaMjestaDataAccess radnaMjestaDataAccess = new RadnaMjestaDataAccess();
            List<RadnaMjesta> radnaMjesta = new List<RadnaMjesta>();

            radnaMjesta = radnaMjestaDataAccess.PopulateComboBox();

            if (radnaMjesta == null)
            {
                this.Close();
            }
            else
            {
                foreach (var radnoMjesto in radnaMjesta)
                {
                    comboBoxRadnoMjesto.Items.Add(radnoMjesto.nazivRadnogMjesta.ToString());
                    comboBoxRadnoMjesto2.Items.Add(radnoMjesto.nazivRadnogMjesta.ToString());
                }
            }
        }

        private void CorrectInput()
        {
            textBoxIme.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxIme.Text.ToLower());
            textBoxPrezime.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxPrezime.Text.ToLower());
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            string radnoMjesto = string.Empty;
            UposlenikDataAccess dataAccess = new UposlenikDataAccess();

            if (checkBoxObavljaDvaRadnaMjesta.Checked == false)
            {
                radnoMjesto = comboBoxRadnoMjesto.Text.ToString();
            }
            else
            {
                radnoMjesto = $"{comboBoxRadnoMjesto.Text.ToString()}, {comboBoxRadnoMjesto2.Text.ToString()}";
            }

            if (textBoxIme.Text == "" || textBoxPrezime.Text == "" || comboBoxRadnoMjesto.Text == "")
            {
                MessageBox.Show("Niste popunili sva predviđena mjesta!", "Odbijeno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIme.Focus();
            }
            else
            {
                CorrectInput();
                DialogResult dialogResult = MessageBox.Show($"Želite li izvršiti promjene uposlenika {textBoxIme.Text.ToString()} {textBoxPrezime.Text.ToString()} - {radnoMjesto}", "Potvrda promjene", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    dataAccess.Update(uposlenik.ID_uposlenika, textBoxIme.Text.ToString(), textBoxPrezime.Text.ToString(), radnoMjesto);
                }
                else
                {
                    MessageBox.Show("Unos uposlenika odbijen!", "Odbijeno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
