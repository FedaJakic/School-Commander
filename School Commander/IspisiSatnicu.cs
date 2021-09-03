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
        }

        private void btnIspisiSatnicu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Želite li ispisati satnicu za {uposlenik.GetFullName()} od {monthCalendarOd.SelectionStart.Date.ToString("dd.MM.yyyy.")} do {monthCalendarDo.SelectionStart.Date.ToString("dd.MM.yyyy.")}", "Ispis satnice!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                CreateTemplateInWord createTemplateInWord = new CreateTemplateInWord();
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                createTemplateInWord.CreateWordDocument($"{desktopPath}\\Satnica_Exmp.docx", $"{desktopPath}\\{uposlenik.GetFullName()}_{monthCalendarOd.SelectionStart.Month}_{monthCalendarOd.SelectionStart.Year}.docx", uposlenik.ID_uposlenika, monthCalendarOd.SelectionStart.Date, monthCalendarDo.SelectionStart.Date);
            }
        }

        private void iconButtonNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
