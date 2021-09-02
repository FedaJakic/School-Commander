using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace School_Commander
{
    class SatnicaDataAccess
    {
        public List<Satnica> FindSatnicaByIDandDate(int ID, DateTime dateTime)
        {
            try
            {
                List<Satnica> listSatnica = new List<Satnica>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Satnica WHERE Satnica.ID_uposlenika = {ID} and Satnica.datumRada = '{dateTime.Date}'";
                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.Read())
                        {
                            Satnica satnica = new Satnica();

                            satnica.ID_satnice = (int)dataReader["ID_satnice"];
                            satnica.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            satnica.datumRada = (DateTime)dataReader["datumRada"];
                            satnica.nacinRada = dataReader["nacinRada"].ToString();
                            satnica.radiOd = (double)dataReader["radiOd"];
                            satnica.radiDo = (double)dataReader["radiDo"];
                            satnica.ukupnoRadnoVrijeme = (double)dataReader["ukupnoRadnoVrijeme"];
                            satnica.nocniRad = (double)dataReader["nocniRad"];
                            satnica.prekovremenoVrijeme = (double)dataReader["prekovremenoVrijeme"];
                            satnica.radNedjeljom = (double)dataReader["radNedjeljom"];
                            satnica.radZaPraznike = (double)dataReader["radZaPraznike"];
                            satnica.godisnjiOdmor = (double)dataReader["godisnjiOdmor"];
                            satnica.bolovanje = (double)dataReader["bolovanje"];
                            satnica.dopustPN = (double)dataReader["dopustPN"];
                            satnica.napomena = (double)dataReader["napomena"];
                            satnica.posebnaNapomena = dataReader["posebnaNapomena"].ToString();
                            satnica.UkupnoSati = (double)dataReader["UkupnoSati"];

                            listSatnica.Add(satnica);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listSatnica;
                }
            }
            catch
            {
                MessageBox.Show("Greška pri ostvarivanju konekcije sa bazom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void Insert(int ID_uposlenika, DateTime datumRada, string nacinRada, decimal radiOd, decimal radiDo,
            decimal ukupnoRadnoVrijeme, decimal nocniRad, decimal prekovremenRad, decimal radNedjeljom, decimal radZaPraznike,
            decimal godisnjiOdmor, decimal bolovanje, decimal dopustPN, decimal napomena, string posebnaNapomena, decimal UkupnoSati)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO Satnica VALUES({ID_uposlenika}, '{datumRada.Date}', '{nacinRada}', '{radiOd}', '{radiDo}', {ukupnoRadnoVrijeme}, {nocniRad}, {prekovremenRad}, {radNedjeljom}, {radZaPraznike}, {godisnjiOdmor}, {bolovanje}, {dopustPN}, {napomena}, '{posebnaNapomena.ToString()}', {UkupnoSati})";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(int ID_uposlenika, DateTime datumRada, string nacinRada, decimal radiOd, decimal radiDo,
            decimal ukupnoRadnoVrijeme, decimal nocniRad, decimal prekovremenRad, decimal radNedjeljom, decimal radZaPraznike,
            decimal godisnjiOdmor, decimal bolovanje, decimal dopustPN, decimal napomena, string posebnaNapomena, decimal UkupnoSati)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"UPDATE Satnica SET nacinRada = '{nacinRada}', radiOd = '{radiOd}', radiDo = '{radiDo}', ukupnoRadnoVrijeme = {ukupnoRadnoVrijeme}, nocniRad = {nocniRad}, prekovremenoVrijeme = {prekovremenRad}, radNedjeljom = {radNedjeljom}, radZaPraznike = {radZaPraznike}, godisnjiOdmor = {godisnjiOdmor}, bolovanje = {bolovanje}, dopustPN = {dopustPN}, napomena = {napomena}, posebnaNapomena = '{posebnaNapomena.ToString()}', UkupnoSati = {UkupnoSati} WHERE ID_Uposlenika = {ID_uposlenika} and datumRada = '{datumRada.Date}'";
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Delete(int ID_Uposlenika, DateTime dateTime)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"DELETE Satnica WHERE ID_uposlenika = '{ID_Uposlenika}' and datumRada = '{dateTime.Date}'";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Satnica izbrisana", "Uspješan unos!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connection.Close();
            }
        }
    }
}
