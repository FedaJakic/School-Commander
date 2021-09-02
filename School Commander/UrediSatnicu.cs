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
    public partial class UrediSatnicu : Form
    {
        #region Global Variabel

        public static List<Uposlenik> uposlenici = new List<Uposlenik>();
        private bool isNotFirstTime = false;

        #endregion

        #region Constructor and OnLoad
        public UrediSatnicu()
        {
            InitializeComponent();
        }

        public UrediSatnicu(Uposlenik izabraniUposlenik)
        {
            InitializeComponent();
            uposlenici.Add(izabraniUposlenik);
        }

        public UrediSatnicu(List<Uposlenik> izabraniUposlenik)
        {
            InitializeComponent();
            ClearEveythingFromListButNotFirst(uposlenici);

            foreach (var uposlenik in izabraniUposlenik)
            {
                uposlenici.Add(uposlenik);
            }
            
        }

        private void UrediSatnicu_Load(object sender, EventArgs e)
        {
            labelImePrezimeUposlenika.Text = uposlenici.FirstOrDefault().GetFullName();
            labelRadnoMjesto.Text = uposlenici.FirstOrDefault().radnoMjesto;
            SetParamatersOnLoad();
        }

        #endregion

        #region Methods

        private void SetParameterToDefault()
        {
            btnDodajKorisnike.Hide();
            checkBoxDodajSatnicuNa.Checked = false;

            checkBoxPoRasporedu.Checked = true;
            checkBoxVremenski.Checked = false;
            textBoxOd.Text = "0";
            textBoxDo.Text = "0";
            textBoxUkupnoDnevnoRadnoVrijeme.Text = "0";
            textBoxNocniRad.Text = "0";
            textBoxPrekovremeniRad.Text = "0";
            textBoxRadNedjeljom.Text = "0";
            textBoxRadZaPraznik.Text = "0";
            textBoxGodisnjiOdmor.Text = "0";
            textBoxBolovanje.Text = "0";
            textBoxDopustPN.Text = "0";
            textBoxNapomena.Text = "0";
            textBoxPosebneNapomene.Text = string.Empty;
            textBoxUkupnoSati.Text = "0";

            MessageBox.Show($"Za datum {monthCalendarKalendarSatnice.SelectionStart.Date.ToString("dd.MM.yyyy.")} nije uneseno radno vrijeme korisniku {uposlenici.First().GetFullName()}", "Satnica nije pronađena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //for TextChangeEvent
            isNotFirstTime = true;
        }

        private void SetParamatersOnLoad()
        {
            labelOsobuJeZamijenio.Hide();
            comboBoxOsobuJeZamijenio.Hide();
            btnDodajKorisnike.Hide();
            checkBoxDodajSatnicuNa.Checked = false;

            SatnicaDataAccess satnicaDataAccess = new SatnicaDataAccess();

            var satnica = satnicaDataAccess.FindSatnicaByIDandDate(uposlenici.First().ID_uposlenika, monthCalendarKalendarSatnice.SelectionStart.Date);

            if (satnica.Count != 0)
            {
                if(satnica.First().nacinRada.Equals("po rasporedu"))
                {
                    checkBoxPoRasporedu.Checked = true;
                    checkBoxVremenski.Checked = false;
                    textBoxOd.Text = satnica.First().radiOd.ToString();
                    textBoxDo.Text = satnica.First().radiDo.ToString();
                }
                else if (satnica.First().nacinRada.Equals("vremenski"))
                {
                    checkBoxVremenski.Checked = true;
                    checkBoxPoRasporedu.Checked = false;
                    textBoxOd.Text = satnica.First().radiOd.ToString();
                    textBoxDo.Text = satnica.First().radiDo.ToString();
                }
                textBoxUkupnoDnevnoRadnoVrijeme.Text = satnica.First().ukupnoRadnoVrijeme.ToString();
                textBoxNocniRad.Text = satnica.First().nocniRad.ToString();
                textBoxPrekovremeniRad.Text = satnica.First().prekovremenoVrijeme.ToString();
                textBoxRadNedjeljom.Text = satnica.First().radNedjeljom.ToString();
                textBoxRadZaPraznik.Text = satnica[0].radZaPraznike.ToString();
                textBoxGodisnjiOdmor.Text = satnica.First().godisnjiOdmor.ToString();
                textBoxBolovanje.Text = satnica.First().bolovanje.ToString();
                textBoxDopustPN.Text = satnica.First().dopustPN.ToString();
                textBoxNapomena.Text = satnica.First().napomena.ToString();
                textBoxPosebneNapomene.Text = satnica.First().posebnaNapomena.ToString();
                textBoxUkupnoSati.Text = satnica.First().UkupnoSati.ToString();

                //for TextChange
                isNotFirstTime = true;
            }
            else
            {
                SetParameterToDefault();
            }


        }

        private bool CorrectInputText()
        {
            if(checkBoxPoRasporedu.Checked == false && checkBoxVremenski.Checked == false)
            {
                MessageBox.Show("Nije označeno na koji način je uposlenik radio (npr. po rasporedu ili vremenski)!", "Neispravan unos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                //check za zareze
                textBoxOd.Text = textBoxOd.Text.Replace(",", ".");
                textBoxDo.Text = textBoxOd.Text.Replace(",", ".");
                textBoxUkupnoDnevnoRadnoVrijeme.Text = textBoxUkupnoDnevnoRadnoVrijeme.Text.Replace(",", ".");
                textBoxNocniRad.Text = textBoxNocniRad.Text.Replace(",", ".");
                textBoxPrekovremeniRad.Text = textBoxPrekovremeniRad.Text.Replace(",", ".");
                textBoxRadNedjeljom.Text = textBoxRadNedjeljom.Text.Replace(",", ".");
                textBoxRadZaPraznik.Text = textBoxRadZaPraznik.Text.Replace(",", ".");
                textBoxGodisnjiOdmor.Text = textBoxGodisnjiOdmor.Text.Replace(",", ".");
                textBoxBolovanje.Text = textBoxBolovanje.Text.Replace(",", ".");
                textBoxDopustPN.Text = textBoxDopustPN.Text.Replace(",", ".");
                textBoxNapomena.Text = textBoxNapomena.Text.Replace(",", ".");
                textBoxUkupnoSati.Text = textBoxUkupnoSati.Text.Replace(",", ".");

                //check za prazna mjesta
                if (textBoxOd.Text.Trim() == string.Empty)
                {
                    textBoxOd.Text = "0";
                }
                if (textBoxDo.Text.Trim() == string.Empty)
                {
                    textBoxDo.Text = "0";
                }
                if (textBoxUkupnoDnevnoRadnoVrijeme.Text.Trim() == string.Empty)
                {
                    textBoxUkupnoDnevnoRadnoVrijeme.Text = "0";
                }
                if (textBoxNocniRad.Text.Trim() == string.Empty)
                {
                    textBoxNocniRad.Text = "0";
                }
                if (textBoxPrekovremeniRad.Text.Trim() == string.Empty)
                {
                    textBoxPrekovremeniRad.Text = "0";
                }
                if (textBoxRadNedjeljom.Text.Trim() == string.Empty)
                {
                    textBoxRadNedjeljom.Text = "0";
                }
                if (textBoxRadZaPraznik.Text.Trim() == string.Empty)
                {
                    textBoxRadZaPraznik.Text = "0";
                }
                if (textBoxGodisnjiOdmor.Text.Trim() == string.Empty)
                {
                    textBoxGodisnjiOdmor.Text = "0";
                }
                if (textBoxBolovanje.Text.Trim() == string.Empty)
                {
                    textBoxBolovanje.Text = "0";
                }
                if (textBoxDopustPN.Text.Trim() == string.Empty)
                {
                    textBoxDopustPN.Text = "0";
                }
                if (textBoxNapomena.Text.Trim() == string.Empty)
                {
                    textBoxNapomena.Text = "0";
                }
                if (textBoxUkupnoSati.Text.Trim() == string.Empty)
                {
                    textBoxUkupnoSati.Text = "0";
                }

                return true;
            }
            
        }

        private string WhichNacinRadaIsChecked()
        {
            if (checkBoxPoRasporedu.Checked == true)
            {
                return "po rasporedu";
            }
            else
            {
                return "vremenski";
            }
        }

        private void ClearEveythingFromListButNotFirst(List<Uposlenik> uposlenici)
        {
            if(uposlenici.Count > 1)
            {
                uposlenici.RemoveRange(1, uposlenici.Count - 1);
            }
        }

        private int NumberOfIterration(string stringIterration)
        {
            if (stringIterration == "na još 1 dan")
            {
                return 1;
            }
            else if (stringIterration == "na još 2 dana")
            {
                return 2;
            }
            else if (stringIterration == "na još 3 dana")
            {
                return 3;
            }
            else if (stringIterration == "na još 4 dana")
            {
                return 4;
            }
            else if (stringIterration == "na 2 sedmice")
            {
                return 9;
            }
            else if (stringIterration == "na 4 sedmice")
            {
                return 19;
            }
            else if (stringIterration == "na isti dan u idućem tjednu")
            {
                return 10;
            }
            else if (stringIterration == "na isti dan u iduća 3 tjedna")
            {
                return 20;
            }
            else if (stringIterration == "na isti dan u iduća 4 tjedna")
            {
                return 30;
            }
            else if (stringIterration == "uposlenik nije radio, imao je zamjenu")
            {
                return 101;
            }
            else
            {
                return 0;
            }
        }

        private void InsertElemntsIntoDatabase(List<Uposlenik> uposlenici, string nacinRada)
        {
            DateTime dateToIterrate = monthCalendarKalendarSatnice.SelectionStart.Date;
            SatnicaDataAccess satnicaDataAccess = new SatnicaDataAccess();
            UposlenikDataAccess uposlenikDataAccess = new UposlenikDataAccess();

            foreach (var uposlenik in uposlenici)
            {
                int iterration = NumberOfIterration(comboBoxPrimjeniOvuSatnicuNa.Text.ToString());
                if (iterration % 10 == 0)
                {
                    iterration /= 10;
                    for (int i = 0; i <= iterration; i++)
                    {
                        if (satnicaDataAccess.FindSatnicaByIDandDate(uposlenik.ID_uposlenika, dateToIterrate.Date).Count == 0)
                        {
                            satnicaDataAccess.Insert(uposlenik.ID_uposlenika, dateToIterrate.Date, nacinRada.ToString(), Convert.ToDecimal(textBoxOd.Text), Convert.ToDecimal(textBoxDo.Text), Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text),
                            Convert.ToDecimal(textBoxNocniRad.Text), Convert.ToDecimal(textBoxPrekovremeniRad.Text), Convert.ToDecimal(textBoxRadNedjeljom.Text), Convert.ToDecimal(textBoxRadZaPraznik.Text),
                            Convert.ToDecimal(textBoxGodisnjiOdmor.Text), Convert.ToDecimal(textBoxBolovanje.Text), Convert.ToDecimal(textBoxDopustPN.Text), Convert.ToDecimal(textBoxNapomena.Text), textBoxPosebneNapomene.Text, Convert.ToDecimal(textBoxUkupnoSati.Text));
                        }
                        else
                        {
                            satnicaDataAccess.Update(uposlenik.ID_uposlenika, dateToIterrate.Date, nacinRada.ToString(), Convert.ToDecimal(textBoxOd.Text), Convert.ToDecimal(textBoxDo.Text), Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text),
                            Convert.ToDecimal(textBoxNocniRad.Text), Convert.ToDecimal(textBoxPrekovremeniRad.Text), Convert.ToDecimal(textBoxRadNedjeljom.Text), Convert.ToDecimal(textBoxRadZaPraznik.Text),
                            Convert.ToDecimal(textBoxGodisnjiOdmor.Text), Convert.ToDecimal(textBoxBolovanje.Text), Convert.ToDecimal(textBoxDopustPN.Text), Convert.ToDecimal(textBoxNapomena.Text), textBoxPosebneNapomene.Text, Convert.ToDecimal(textBoxUkupnoSati.Text));
                        }
                        if (iterration != 0)
                            dateToIterrate = dateToIterrate.AddDays(7);
                    }
                }
                else if (iterration == 101)
                {
                    var imePrezime = comboBoxOsobuJeZamijenio.Text.Split(' ');
                    var detaljiUposlenika = uposlenikDataAccess.FindUposlenikByFirstNameAndALastName(imePrezime[0], imePrezime[1]);

                    if (satnicaDataAccess.FindSatnicaByIDandDate(uposlenik.ID_uposlenika, dateToIterrate.Date).Count == 0)
                    {
                        satnicaDataAccess.Insert(detaljiUposlenika[0].ID_uposlenika, monthCalendarKalendarSatnice.SelectionStart.Date, nacinRada.ToString(), Convert.ToDecimal(textBoxOd.Text), Convert.ToDecimal(textBoxDo.Text), Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text),
                        Convert.ToDecimal(textBoxNocniRad.Text), Convert.ToDecimal(textBoxPrekovremeniRad.Text), Convert.ToDecimal(textBoxRadNedjeljom.Text), Convert.ToDecimal(textBoxRadZaPraznik.Text),
                        Convert.ToDecimal(textBoxGodisnjiOdmor.Text), Convert.ToDecimal(textBoxBolovanje.Text), Convert.ToDecimal(textBoxDopustPN.Text), Convert.ToDecimal(textBoxNapomena.Text), textBoxPosebneNapomene.Text, Convert.ToDecimal(textBoxUkupnoSati.Text));
                    }
                    else
                    {
                        satnicaDataAccess.Update(detaljiUposlenika[0].ID_uposlenika, monthCalendarKalendarSatnice.SelectionStart.Date, nacinRada.ToString(), Convert.ToDecimal(textBoxOd.Text), Convert.ToDecimal(textBoxDo.Text), Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text),
                        Convert.ToDecimal(textBoxNocniRad.Text), Convert.ToDecimal(textBoxPrekovremeniRad.Text), Convert.ToDecimal(textBoxRadNedjeljom.Text), Convert.ToDecimal(textBoxRadZaPraznik.Text),
                        Convert.ToDecimal(textBoxGodisnjiOdmor.Text), Convert.ToDecimal(textBoxBolovanje.Text), Convert.ToDecimal(textBoxDopustPN.Text), Convert.ToDecimal(textBoxNapomena.Text), textBoxPosebneNapomene.Text, Convert.ToDecimal(textBoxUkupnoSati.Text));
                    }

                    satnicaDataAccess.Delete(uposlenik.ID_uposlenika, monthCalendarKalendarSatnice.SelectionStart.Date);
                    SetParamatersOnLoad();
                }
                else
                {
                    try
                    {
                        for (int i = 0; i <= iterration; i++)
                        {
                            if (satnicaDataAccess.FindSatnicaByIDandDate(uposlenik.ID_uposlenika, dateToIterrate.Date).Count == 0)
                            {
                                satnicaDataAccess.Insert(uposlenik.ID_uposlenika, dateToIterrate.Date, nacinRada.ToString(), Convert.ToDecimal(textBoxOd.Text), Convert.ToDecimal(textBoxDo.Text), Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text),
                                Convert.ToDecimal(textBoxNocniRad.Text), Convert.ToDecimal(textBoxPrekovremeniRad.Text), Convert.ToDecimal(textBoxRadNedjeljom.Text), Convert.ToDecimal(textBoxRadZaPraznik.Text),
                                Convert.ToDecimal(textBoxGodisnjiOdmor.Text), Convert.ToDecimal(textBoxBolovanje.Text), Convert.ToDecimal(textBoxDopustPN.Text), Convert.ToDecimal(textBoxNapomena.Text), textBoxPosebneNapomene.Text, Convert.ToDecimal(textBoxUkupnoSati.Text));
                            }
                            else
                            {
                                satnicaDataAccess.Update(uposlenik.ID_uposlenika, dateToIterrate.Date, nacinRada.ToString(), Convert.ToDecimal(textBoxOd.Text), Convert.ToDecimal(textBoxDo.Text), Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text),
                                Convert.ToDecimal(textBoxNocniRad.Text), Convert.ToDecimal(textBoxPrekovremeniRad.Text), Convert.ToDecimal(textBoxRadNedjeljom.Text), Convert.ToDecimal(textBoxRadZaPraznik.Text),
                                Convert.ToDecimal(textBoxGodisnjiOdmor.Text), Convert.ToDecimal(textBoxBolovanje.Text), Convert.ToDecimal(textBoxDopustPN.Text), Convert.ToDecimal(textBoxNapomena.Text), textBoxPosebneNapomene.Text, Convert.ToDecimal(textBoxUkupnoSati.Text));
                            }

                            if (iterration != 0)
                            {
                                dateToIterrate = dateToIterrate.AddDays(1);
                                string temp = dateToIterrate.DayOfWeek.ToString();
                                if (dateToIterrate.DayOfWeek.ToString() == "Saturday" || dateToIterrate.DayOfWeek.ToString() == "Sunday")
                                {
                                    dateToIterrate = dateToIterrate.AddDays(2);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            ClearEveythingFromListButNotFirst(uposlenici);
            MessageBox.Show("Uspješno unesena satnica!", "Uneseno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Events

        private void btnNatrag_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendarKalendarSatnice_DateChanged(object sender, DateRangeEventArgs e)
        {
            SetParamatersOnLoad();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Želite li unijet satnicu za uposlenika {uposlenici.First().GetFullName()} za datum {monthCalendarKalendarSatnice.SelectionStart.Date.ToString("dd.MM.yyyy.")} sa ukupni radnim vremenom {textBoxUkupnoSati.Text.ToString()} sati\n(Primjenjeni filter: {comboBoxPrimjeniOvuSatnicuNa.Text.ToString()})", "Unos nove satnice!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (CorrectInputText())
                {
                    string nacinRada = WhichNacinRadaIsChecked();
                    InsertElemntsIntoDatabase(uposlenici, nacinRada);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                SetParamatersOnLoad();
            }
        }

        private void btnIzbrisiSatnicu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Želite li izbrisati satnicu {uposlenici.First().GetFullName()} na dan {monthCalendarKalendarSatnice.SelectionStart.Date.ToString()}?", "Brisanje satnice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialogResult == DialogResult.Yes)
            {
                SatnicaDataAccess satnicaDataAccess = new SatnicaDataAccess();
                satnicaDataAccess.Delete(uposlenici.First().ID_uposlenika, monthCalendarKalendarSatnice.SelectionStart.Date);
                SetParamatersOnLoad();
            }
            else
            {
                MessageBox.Show("Satnica neće biti obrisana!", "Nema brisanja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxPrimjeniOvuSatnicuNa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPrimjeniOvuSatnicuNa.SelectedItem.ToString() == "uposlenik nije radio, imao je zamjenu")
            {
                labelOsobuJeZamijenio.Show();
                comboBoxOsobuJeZamijenio.Show();
                btnDodajKorisnike.Hide();
                checkBoxDodajSatnicuNa.Checked = false;
                checkBoxDodajSatnicuNa.Enabled = false;

                UposlenikDataAccess uposlenikDataAccess = new UposlenikDataAccess();

                var findUposlenici = uposlenikDataAccess.FindAllExceptWithThisName(uposlenici.First().ime, uposlenici.First().prezime);

                foreach (var uposlenik in findUposlenici)
                {
                    comboBoxOsobuJeZamijenio.Items.Add(uposlenik.GetFullName());
                }
            }
            else
            {
                labelOsobuJeZamijenio.Hide();
                comboBoxOsobuJeZamijenio.Hide();
                checkBoxDodajSatnicuNa.Enabled = true;
            }
        }

        private void checkBoxDodajSatnicuNa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDodajSatnicuNa.Checked)
                btnDodajKorisnike.Show();
            else
            {
                uposlenici.RemoveRange(1, uposlenici.Count - 1);
                btnDodajKorisnike.Hide();
            }             
        }

        private void btnDodajKorisnike_Click(object sender, EventArgs e)
        {
            DodajKorisnike openDodajKorisnike = new DodajKorisnike(uposlenici.First());
            openDodajKorisnike.Show();
        }

        private void textBoxDo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isNotFirstTime)
                {
                    decimal timeOd = Convert.ToDecimal(textBoxOd.Text.ToString());
                    decimal timeDo = Convert.ToDecimal(textBoxDo.Text.ToString());
                    if (timeOd > timeDo)
                    {
                        textBoxUkupnoDnevnoRadnoVrijeme.Text = ((Convert.ToDecimal(textBoxDo.Text.ToString()) + 12) - (Convert.ToDecimal(textBoxOd.Text.ToString()) - 12)).ToString();

                    }
                    else
                    {
                        textBoxUkupnoDnevnoRadnoVrijeme.Text = (Convert.ToDecimal(textBoxDo.Text.ToString()) - Convert.ToDecimal(textBoxOd.Text.ToString())).ToString();
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Možete koristit samo numeričke znakove! Vrijeme pišite u formatu [sat.min]", "Greška formata unosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBox textBox = sender as TextBox;
                textBox.Text = "";
            }

}

        private void textBoxUkupnoDnevnoRadnoVrijeme_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isNotFirstTime)
                {
                    textBoxUkupnoSati.Text = (Convert.ToDecimal(textBoxUkupnoDnevnoRadnoVrijeme.Text.ToString()) + Convert.ToDecimal(textBoxNocniRad.Text.ToString()) + Convert.ToDecimal(textBoxPrekovremeniRad.Text.ToString()) + Convert.ToDecimal(textBoxRadNedjeljom.Text.ToString()) + Convert.ToDecimal(textBoxRadZaPraznik.Text.ToString()) + Convert.ToDecimal(textBoxGodisnjiOdmor.Text.ToString()) + Convert.ToDecimal(textBoxBolovanje.Text.ToString()) + Convert.ToDecimal(textBoxDopustPN.Text.ToString())).ToString();
                }
            }
            catch
            {
                //MessageBox.Show("Možete koristit samo numeričke znakove! Vrijeme pišite u formatu [sat.min]", "Greška formata unosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBox textBox = sender as TextBox;
                textBox.Text = "";
            }

        }

        #endregion
    }
}