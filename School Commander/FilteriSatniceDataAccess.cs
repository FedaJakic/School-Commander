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
    public class FilteriSatniceDataAccess
    {
        public List<FilteriSatnice> PopulateComboBox()
        {
            try
            {
                List<FilteriSatnice> listFilteriSatnice = new List<FilteriSatnice>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Filteri_Satnice";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            FilteriSatnice filterSatnice = new FilteriSatnice();

                            filterSatnice.ID_Filtera = (int)dataReader["ID_Filtera"];
                            filterSatnice.nazivFiltera = dataReader["nazivFiltera"].ToString();

                            listFilteriSatnice.Add(filterSatnice);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listFilteriSatnice;
                }
            }
            catch
            {
                MessageBox.Show("Greška pri ostvarivanju konekcije sa bazom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public int GetNumberOfIterration(string nazivFiltera)
        {
            try
            {
                int inkrement = 0;
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Filteri_Satnice WHERE nazivFiltera = '{nazivFiltera}'";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            FilteriSatnice filterSatnice = new FilteriSatnice();

                            filterSatnice.inkrementiranje = (int)dataReader["inkrementiranje"];

                            inkrement = filterSatnice.inkrementiranje;
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return inkrement;
                }
            }
            catch
            {
                MessageBox.Show("Greška pri ostvarivanju konekcije sa bazom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 404;
            }

        }
    }
}
