using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Context;

namespace RoomBooking
{
    public class Education
    {
        public int? Id { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int universityID { get; set; }

        private static readonly string connectionString =
            "Data Source=MALINAAFEMI;Database=db_employee;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        // GET
        public static List<Education> Get()
        {
            var educations = new List<Education>();
            using var connection = MyConnection.Get();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Education();
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(2);
                        education.GPA = reader.GetString(3);
                        education.universityID = reader.GetInt32(4);

                        educations.Add(education);
                    }

                    return educations;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<Education>();
        }

        // UPDATE
        public static int Update(Dictionary<string, object> updateColumns, List<string> columnsToUpdate, string primaryKeyName, object primaryKeyValue)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE tb_m_educations SET ";
                foreach (string column in columnsToUpdate)
                {
                    command.CommandText += $"{column} = @{column}, ";
                }

                command.CommandText = command.CommandText.Substring(0, command.CommandText.Length - 2);
                command.CommandText += $" WHERE {primaryKeyName} = @primaryKeyValue";
                command.Transaction = transaction;

                foreach (string column in columnsToUpdate)
                {
                    if (updateColumns.ContainsKey(column))
                    {
                        command.Parameters.AddWithValue($"@{column}", updateColumns[column]);
                    }
                    else
                    {
                        throw new ArgumentException($"Column '{column}' is not in the updateColumns dictionary");

                    }
                }
                command.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        // DELETE
        public static int Delete(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan delete
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = education.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        // INSERT

        public static int Insert(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Command melakukan insert

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations (major,degree,gpa,university_id) VALUES (@major, @degree, @gpa, @uid)";
                command.Transaction = transaction;

                //Membuat parameter
                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 50;
                pMajor.Value = education.Major;
                command.Parameters.Add(pMajor);

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 50;
                pDegree.Value = education.Degree;
                command.Parameters.Add(pDegree);

                var pGPA = new SqlParameter();
                pGPA.ParameterName = "@gpa";
                pGPA.SqlDbType = SqlDbType.VarChar;
                pGPA.Size = 50;
                pGPA.Value = education.GPA;
                command.Parameters.Add(pGPA);

                var pUID = new SqlParameter();
                pUID.ParameterName = "@uid";
                pUID.SqlDbType = SqlDbType.VarChar;
                pUID.Size = 50;
                pUID.Value = education.universityID;
                command.Parameters.Add(pUID);


                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        // GET EDUCATION ID
        public static int GetId()
        {
            using var connection = MyConnection.Get();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP 1 id FROM tb_m_educations ORDER BY id desc";

            connection.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;

        }

        /*public static int InsertRow(string tableName, Dictionary<string, object> columnValues)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO {tableName} ({string.Join(",", columnValues.Keys)}) VALUES ({string.Join(",", columnValues.Keys.Select(key => $"@{key}"))})";
                command.Transaction = transaction;

                foreach (var columnValue in columnValues)
                {
                    command.Parameters.AddWithValue($"@{columnValue.Key}", columnValue.Value ?? DBNull.Value);

                }

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }*/
    }
}
