using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace School_Commander
{
    public partial class IspisiSatnicu : Form
    {
        public static Uposlenik uposlenik = new Uposlenik();

        public IspisiSatnicu(Uposlenik izabraniUposlenik)
        {
            InitializeComponent();
            uposlenik = izabraniUposlenik;
        }

        private void IspisiSatnicu_Load(object sender, EventArgs e)
        {
            labelImePrezimeUposlenika.Text = uposlenik.GetFullName();
            labelRadnoMjesto.Text = uposlenik.radnoMjesto;
            labelProgressBar.Text = "";
            progressBar.Visible = false;
        }

        private void btnIspisiSatnicu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Želite li ispisati satnicu za {uposlenik.GetFullName()} od {monthCalendarOd.SelectionStart.Date.ToString("dd.MM.yyyy.")} do {monthCalendarDo.SelectionStart.Date.ToString("dd.MM.yyyy.")}", "Ispis satnice!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                CreateTemplateInWord createTemplateInWord = new CreateTemplateInWord();

                int numOfMonths = GetNumberOfMonths(monthCalendarDo.SelectionStart, monthCalendarOd.SelectionStart);
                DateTime startDate = monthCalendarOd.SelectionStart.Date;
                DateTime endDate = monthCalendarDo.SelectionStart.Date;
                DateTime currentDateInfo = startDate;
                DateTime currentEndDateInfo = DateTime.Now;
                int numOfDays = 0;

                ProgressBarUpdates("Učitani datumi! Kreira se dokument", false);

                for (int i = 0; i <= numOfMonths; i++)
                {
                    numOfDays =  DateTime.DaysInMonth(currentDateInfo.Year, currentDateInfo.Month);
                    currentEndDateInfo = new DateTime(currentDateInfo.Year, currentDateInfo.Month, numOfDays);

                    if(currentEndDateInfo.Date < endDate.Date)
                    {
                        createTemplateInWord.CreateWordDocument(GetExampleWord(), GetWordDocumentName(uposlenik.GetFullName(), currentDateInfo), uposlenik.ID_uposlenika, currentDateInfo, currentEndDateInfo, progressBar.Value);
                        currentDateInfo = currentEndDateInfo.AddDays(1);
                        ProgressBarUpdates($"Kreiran je {i+1}/{numOfMonths +1} dokument!\nKreira se idući dokument.", false);
                    }
                    else
                    {
                        createTemplateInWord.CreateWordDocument(GetExampleWord(), GetWordDocumentName(uposlenik.GetFullName(), currentDateInfo), uposlenik.ID_uposlenika, currentDateInfo, endDate, progressBar.Value);
                        ProgressBarUpdates("Ispis završen! Možete nastaviti sa radom.", true);
                    }
                }
            }
        }

        private void iconButtonNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetExampleWord()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathOfExampleWordDocument = $"{desktopPath}\\Satnica_Exmp.docx";
            return pathOfExampleWordDocument;
        }

        private string GetWordDocumentName(string name, DateTime dateTimeMjeseca)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nameOfFile = $"{uposlenik.GetFullName().ToString()}_{dateTimeMjeseca.Month.ToString()}_{dateTimeMjeseca.Year.ToString()}.docx";
            string exmpWordDocumentName = $"{desktopPath}\\{nameOfFile}";
            return exmpWordDocumentName;
        }

        private int GetNumberOfMonths(DateTime dateTimeOd, DateTime dateTimeDo)
        {
            return (dateTimeOd.Month - dateTimeDo.Month) + 12 * (dateTimeOd.Year - dateTimeDo.Year);
        }



        public void ProgressBarUpdates(string labelText, bool end)
        {
            progressBar.Visible = true;
            if (end)
            {
                progressBar.Maximum = 100;
                progressBar.Minimum = 0;
                progressBar.Value = 100;
                labelProgressBar.Text = labelText;
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.MarqueeAnimationSpeed = 0;
            }
            else
            {

                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 50;
                labelProgressBar.Text = labelText;
            }
            
       }
    }
}
