using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace School_Commander
{
    public class CreateTemplateInWord
    {
        public void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWords = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWords,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        public void CreateWordDocument(object filename, object SaveAs, int ID_uposlenika, DateTime odDate, DateTime doDate)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing);

                myWordDoc.Activate();

                InserIntoWord(wordApp, ID_uposlenika, odDate, doDate);
            }
            else
            {
                Console.WriteLine("File doesnt exist\n");
            }

            myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            Console.WriteLine("File kreiran\n");
        }

        private void InserIntoWord(Word.Application wordApp, int ID_Uposlenika, DateTime odDate, DateTime doDate)
        {
            List<Satnica> satnicaUposlenika = new List<Satnica>();
            List<Uposlenik> infoUposlenika = new List<Uposlenik>();

            UposlenikDataAccess uposlenikDataAccess = new UposlenikDataAccess();
            SatnicaDataAccess satnicaDataAccess = new SatnicaDataAccess();
            infoUposlenika = uposlenikDataAccess.FindUposlenikByID(ID_Uposlenika);
            satnicaUposlenika = satnicaDataAccess.FindSatnicaByEmployeeID_TwoDates(ID_Uposlenika, odDate, doDate);

            this.FindAndReplace(wordApp, "<imePrezimeUposlenika>", $"{infoUposlenika[0].ime.ToString()} {infoUposlenika[0].prezime.ToString()}");
            this.FindAndReplace(wordApp, "<god>", odDate.Year.ToString());
            this.FindAndReplace(wordApp, "<mj>", odDate.Month.ToString());
            int i = 0, check = 1;
            float ukupnoDnevnoRadnoVrijeme = 0;
            float ukupnoNocniRad = 0;
            float ukupnoPrekovremeniRad = 0;
            float ukupnoRadNedjeljom = 0;
            float ukupnoRadZaPraznik = 0;
            float ukupnoGodisnjiOdmor = 0;
            float ukupnoBolovanje = 0;
            float ukupnoDopustPN = 0;
            float ukupnoNapomena = 0;
            float ukupnoSati = 0;

            while (i < satnicaUposlenika.Count)
            {
                if (check != satnicaUposlenika[i].datumRada.Day)
                {
                    this.FindAndReplace(wordApp, $"<od{check}>", "");
                    this.FindAndReplace(wordApp, $"<do{check}>", "");
                    this.FindAndReplace(wordApp, $"<uk{check}>", "");
                    this.FindAndReplace(wordApp, $"<nr{check}>", "");
                    this.FindAndReplace(wordApp, $"<pr{check}>", "");
                    this.FindAndReplace(wordApp, $"<rn{check}>", "");
                    this.FindAndReplace(wordApp, $"<rzp{check}>", "");
                    this.FindAndReplace(wordApp, $"<go{check}>", "");
                    this.FindAndReplace(wordApp, $"<b{check}>", "");
                    this.FindAndReplace(wordApp, $"<dpn{check}>", "");
                    this.FindAndReplace(wordApp, $"<n{check}>", "");
                    this.FindAndReplace(wordApp, $"<us{check}>", "");
                    ++check;
                }
                else
                {
                    if (satnicaUposlenika[i].nacinRada.Equals("po rasporedu"))
                    {
                        this.FindAndReplace(wordApp, $"<od{satnicaUposlenika[i].datumRada.Day}>", "po");
                        this.FindAndReplace(wordApp, $"<do{satnicaUposlenika[i].datumRada.Day}>", "raspo.");
                    }
                    else if (satnicaUposlenika[i].nacinRada.Equals("vremenski"))
                    {
                        this.FindAndReplace(wordApp, $"<od{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].radiOd);
                        this.FindAndReplace(wordApp, $"<do{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].radiDo);

                    }
                    else if (satnicaUposlenika[i].nacinRada.Equals("po rasporedu i vremenski"))
                    {
                        this.FindAndReplace(wordApp, $"<od{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].radiOd);
                        this.FindAndReplace(wordApp, $"<do{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].radiDo);

                    }
                    this.FindAndReplace(wordApp, $"<uk{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].ukupnoRadnoVrijeme.ToString());
                    this.FindAndReplace(wordApp, $"<nr{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].nocniRad.ToString());
                    this.FindAndReplace(wordApp, $"<pr{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].prekovremenoVrijeme.ToString());
                    this.FindAndReplace(wordApp, $"<rn{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].radNedjeljom.ToString());
                    this.FindAndReplace(wordApp, $"<rzp{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].radZaPraznike.ToString());
                    this.FindAndReplace(wordApp, $"<go{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].godisnjiOdmor.ToString());
                    this.FindAndReplace(wordApp, $"<b{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].bolovanje.ToString());
                    this.FindAndReplace(wordApp, $"<dpn{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].dopustPN.ToString());
                    this.FindAndReplace(wordApp, $"<n{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].napomena.ToString());
                    this.FindAndReplace(wordApp, $"<us{satnicaUposlenika[i].datumRada.Day}>", satnicaUposlenika[i].UkupnoSati.ToString());

                    ukupnoDnevnoRadnoVrijeme += (float)satnicaUposlenika[i].ukupnoRadnoVrijeme;
                    ukupnoNocniRad += (float)satnicaUposlenika[i].nocniRad;
                    ukupnoPrekovremeniRad += (float)satnicaUposlenika[i].prekovremenoVrijeme;
                    ukupnoRadNedjeljom += (float)satnicaUposlenika[i].radNedjeljom;
                    ukupnoRadZaPraznik += (float)satnicaUposlenika[i].radZaPraznike;
                    ukupnoGodisnjiOdmor += (float)satnicaUposlenika[i].godisnjiOdmor;
                    ukupnoBolovanje += (float)satnicaUposlenika[i].bolovanje;
                    ukupnoDopustPN += (float)satnicaUposlenika[i].dopustPN;
                    ukupnoNapomena += (float)satnicaUposlenika[i].napomena;
                    ukupnoSati += (float)satnicaUposlenika[i].UkupnoSati;

                    ++i;
                    ++check;
                }
            }

            if (check <= 31)
            {
                for (int j = check; j <= 31; j++)
                {
                    this.FindAndReplace(wordApp, $"<od{j}>", "");
                    this.FindAndReplace(wordApp, $"<do{j}>", "");
                    this.FindAndReplace(wordApp, $"<uk{j}>", "");
                    this.FindAndReplace(wordApp, $"<nr{j}>", "");
                    this.FindAndReplace(wordApp, $"<pr{j}>", "");
                    this.FindAndReplace(wordApp, $"<rn{j}>", "");
                    this.FindAndReplace(wordApp, $"<rzp{j}>", "");
                    this.FindAndReplace(wordApp, $"<go{j}>", "");
                    this.FindAndReplace(wordApp, $"<b{j}>", "");
                    this.FindAndReplace(wordApp, $"<dpn{j}>", "");
                    this.FindAndReplace(wordApp, $"<n{j}>", "");
                    this.FindAndReplace(wordApp, $"<us{j}>", "");
                }
            }

            this.FindAndReplace(wordApp, "<ursuk1>", ukupnoDnevnoRadnoVrijeme);
            this.FindAndReplace(wordApp, "<ursnr1>", ukupnoNocniRad);
            this.FindAndReplace(wordApp, "<urspr1>", ukupnoPrekovremeniRad);
            this.FindAndReplace(wordApp, "<ursrn1>", ukupnoRadNedjeljom);
            this.FindAndReplace(wordApp, "<ursrzp1>", ukupnoRadZaPraznik);
            this.FindAndReplace(wordApp, "<ursgo1>", ukupnoGodisnjiOdmor);
            this.FindAndReplace(wordApp, "<ursb1>", ukupnoBolovanje);
            this.FindAndReplace(wordApp, "<ursdpn1>", ukupnoDopustPN);
            this.FindAndReplace(wordApp, "<ursn1>", ukupnoNapomena);
            this.FindAndReplace(wordApp, "<ursus1>", ukupnoSati);
        }
    }
}
