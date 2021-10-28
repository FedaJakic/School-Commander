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
    public partial class NoviProfil : Form
    {
        public NoviProfil()
        {
            InitializeComponent();
            comboBoxRadnoMjesto2.Enabled = false;
        }

        private void NoviProfil_Load(object sender, EventArgs e)
        {
            PopulateAllComboBoxes();
        }

        #region Methods

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

        private void ResetAllBoxes()
        {
            textBoxIme.Clear();
            textBoxPrezime.Clear();
            comboBoxRadnoMjesto.ResetText();
            comboBoxRadnoMjesto2.ResetText();
            checkBoxObavljaDvaRadnaMjesta.Checked = false;
            comboBoxRadnoMjesto2.Enabled = false;
            textBoxIme.Focus();
        }

        private void CorrectInput()
        {
            textBoxIme.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxIme.Text.ToLower());
            textBoxPrezime.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxPrezime.Text.ToLower());
        }
        #endregion

        private void checkBoxObavljaDvaRadnaMjesta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxObavljaDvaRadnaMjesta.Checked)
                comboBoxRadnoMjesto2.Enabled = true;
            else
                comboBoxRadnoMjesto2.Enabled = false;
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
                DialogResult dialogResult = MessageBox.Show($"Želite li unijeti uposlenika {textBoxIme.Text.ToString()} {textBoxPrezime.Text.ToString()} - {radnoMjesto}", "Potvrda unosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (dataAccess.CheckExistingData(textBoxIme.Text.ToString(), textBoxPrezime.Text.ToString()))
                    {
                        MessageBox.Show("Profil već postoji u bazi podataka!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetAllBoxes();
                    }
                    else
                    {
                        dataAccess.Insert(textBoxIme.Text.ToString(), textBoxPrezime.Text.ToString(), radnoMjesto);
                        ResetAllBoxes();
                    }
                }
                else
                {
                    MessageBox.Show("Unos uposlenika odbijen!", "Odbijeno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
