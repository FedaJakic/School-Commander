using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace School_Commander
{
    public class RadnaMjestaDataAccess
    {
        public List<RadnaMjesta> PopulateComboBox()
        {
            try
            {
                List<RadnaMjesta> listRadnaMjesta = new List<RadnaMjesta>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Radna_Mjesta ORDER BY nazivRadnogMjesta ASC";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            RadnaMjesta radnaMjesta = new RadnaMjesta();

                            radnaMjesta.ID_radnogMjesta = (int)dataReader["ID_radnogMjesta"];
                            radnaMjesta.nazivRadnogMjesta = dataReader["nazivRadnogMjesta"].ToString();

                            listRadnaMjesta.Add(radnaMjesta);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listRadnaMjesta;
                }
            }
            catch
            {
                MessageBox.Show("Greška pri ostvarivanju konekcije sa bazom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
