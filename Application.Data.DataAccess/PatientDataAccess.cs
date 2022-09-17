using Application.DAL.Contract;
using Application.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Application.Data.DataAccess
{

    public class PatientDataAccess : IDataAccess<Patient, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public PatientDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Patient Create(Patient entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO patient VALUES ({entity.PatientID} ,'{entity.FirstName}' ,'{entity.MiddleName}' ,'{entity.LastName}' ,'{entity.Mobile}' ,'{entity.Email}' ,'{entity.DOB}' ,'{entity.Gender}')";

                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entity;
        }

        public Patient Delete(int id)
        {
            Patient entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From patient where patient_id={id}";

                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }

        public IEnumerable<Patient> Get()
        {
            List<Patient> entities = new List<Patient>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from patient";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Patient()
                          {
                              PatientID = Convert.ToInt32(reader["patient_id"]),
                              FirstName = reader["first_name"].ToString(),
                              MiddleName = reader["middle_name"].ToString(),
                              LastName = reader["last_name"].ToString(),
                              Mobile = reader["mobile"].ToString(),
                              Email = reader["email"].ToString(),
                              DOB = reader["dob"].ToString(),
                              Gender = reader["gender"].ToString()
                          }
                        );
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entities;
        }

        public Patient Get(int id)
        {
            Patient entity = new Patient();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from patient where patient_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Patient()
                {
                    PatientID = Convert.ToInt32(reader["patient_id"]),
                    FirstName = reader["first_name"].ToString(),
                    MiddleName = reader["middle_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    Mobile = reader["mobile"].ToString(),
                    Email = reader["email"].ToString(),
                    DOB = reader["dob"].ToString(),
                    Gender = reader["gender"].ToString()
                };

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entity;
        }

        public Patient Update(int id, Patient entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE patient SET patient_id = {entity.PatientID} ,first_name = '{entity.FirstName}' ,middle_name = '{entity.MiddleName}' ,last_name = '{entity.LastName}' ,mobile = '{entity.Mobile}' ,email = '{entity.Email}' ,dob = '{entity.DOB}' ,gender = '{entity.Gender}' WHERE patient_id={id}";

                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entity;
        }
    }
}