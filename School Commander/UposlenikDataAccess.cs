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
    public class UposlenikDataAccess
    {
        public void Insert(string ime, string prezime, string radnoMjesto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"INSERT INTO Uposlenik VALUES('{ime}', '{prezime}', '{radnoMjesto}')";
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Uspješno unesen uposlenik {ime} {prezime} - {radnoMjesto}", "Uspješan unos!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void Update(int uposlenikID,string ime, string prezime, string radnoMjesto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"UPDATE Uposlenik SET ime = '{ime}', prezime = '{prezime}', radnoMjesto = '{radnoMjesto}' WHERE ID_Uposlenika = {uposlenikID}";
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Promjene odrađene!", "Obavljeno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public List<Uposlenik> FindUposlenikByID(int ID)
        {
            try
            {
                List<Uposlenik> listUposlenik = new List<Uposlenik>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE Uposlenik.ID_uposlenika = {ID}";
                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.Read())
                        {
                            Uposlenik uposlenik = new Uposlenik();

                            uposlenik.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            uposlenik.ime = dataReader["ime"].ToString();
                            uposlenik.prezime = dataReader["prezime"].ToString();
                            uposlenik.radnoMjesto = dataReader["radnoMjesto"].ToString();

                            listUposlenik.Add(uposlenik);
                        }
                        else
                        {
                            listUposlenik = null;
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listUposlenik;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public List<Uposlenik> FindUposlenikByFirstNameAndALastName(string ime, string prezime)
        {
            try
            {
                List<Uposlenik> listUposlenik = new List<Uposlenik>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE Uposlenik.ime = '{ime}' and Uposlenik.prezime = '{prezime}' ORDER BY Uposlenik.ime ASC";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Uposlenik uposlenik = new Uposlenik();

                            uposlenik.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            uposlenik.ime = dataReader["ime"].ToString();
                            uposlenik.prezime = dataReader["prezime"].ToString();
                            uposlenik.radnoMjesto = dataReader["radnoMjesto"].ToString();

                            listUposlenik.Add(uposlenik);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listUposlenik;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public List<Uposlenik> FindAllExceptWithThisName(string ime, string prezime)
        {
            try
            {
                List<Uposlenik> listUposlenik = new List<Uposlenik>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE Uposlenik.ime <> '{ime}' and Uposlenik.prezime <> '{prezime}' ORDER BY Uposlenik.ime ASC";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Uposlenik uposlenik = new Uposlenik();

                            uposlenik.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            uposlenik.ime = dataReader["ime"].ToString();
                            uposlenik.prezime = dataReader["prezime"].ToString();
                            uposlenik.radnoMjesto = dataReader["radnoMjesto"].ToString();

                            listUposlenik.Add(uposlenik);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listUposlenik;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public List<Uposlenik> FindAllExceptWithThisID(int ID)
        {
            try
            {
                List<Uposlenik> listUposlenik = new List<Uposlenik>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE Uposlenik.ID_uposlenika <> {ID} ORDER BY Uposlenik.ime ASC";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Uposlenik uposlenik = new Uposlenik();

                            uposlenik.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            uposlenik.ime = dataReader["ime"].ToString();
                            uposlenik.prezime = dataReader["prezime"].ToString();
                            uposlenik.radnoMjesto = dataReader["radnoMjesto"].ToString();

                            listUposlenik.Add(uposlenik);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listUposlenik;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public List<Uposlenik> FindUposlenikByFirstName(string ime)
        {
            try
            {
                List<Uposlenik> listUposlenik = new List<Uposlenik>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE Uposlenik.ime = '{ime}' ORDER BY Uposlenik.ime ASC";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Uposlenik uposlenik = new Uposlenik();

                            uposlenik.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            uposlenik.ime = dataReader["ime"].ToString();
                            uposlenik.prezime = dataReader["prezime"].ToString();
                            uposlenik.radnoMjesto = dataReader["radnoMjesto"].ToString();

                            listUposlenik.Add(uposlenik);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listUposlenik;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public List<Uposlenik> FindUposlenikByLastName(string prezime)
        {
            try
            {
                List<Uposlenik> listUposlenik = new List<Uposlenik>();
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE Uposlenik.prezime = '{prezime}' ORDER BY Uposlenik.ime ASC";
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Uposlenik uposlenik = new Uposlenik();

                            uposlenik.ID_uposlenika = (int)dataReader["ID_uposlenika"];
                            uposlenik.ime = dataReader["ime"].ToString();
                            uposlenik.prezime = dataReader["prezime"].ToString();
                            uposlenik.radnoMjesto = dataReader["radnoMjesto"].ToString();

                            listUposlenik.Add(uposlenik);
                        }
                        dataReader.Close();
                    }
                    connection.Close();

                    return listUposlenik;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public bool CheckExistingData(string ime, string prezime)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionVal("SchoolCommander")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = $"SELECT * FROM Uposlenik WHERE ime = '{ime}' and prezime = '{prezime}'";
                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.Read())
                        {
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            connection.Close();
                            return false;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Greška u učitavanju baze podataka!\nProgram će se ugasiti!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            
        }
    }
}
