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
    public class University
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        // GET
        public static List<University> Get()
        {
            var universities = new List<University>();
            using var connection = MyConnection.Get();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var university = new University();
                        university.Id = reader.GetInt32(0);
                        university.Name = reader.GetString(1);

                        universities.Add(university);
                    }

                    return universities;
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
            return new List<University>();
        }

        // Insert
        public static int Insert(University university)
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
                command.CommandText = "INSERT INTO tb_m_universities(name) VALUES (@name)";
                command.Transaction = transaction;

                //Membuat parameter
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Size = 50;
                pName.Value = university.Name;

                // Menambahkan parameter ke command
                command.Parameters.Add(pName);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

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
                command.CommandText = $"UPDATE tb_m_universities SET ";
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
        public static int Delete(University university)
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
                command.CommandText = "DELETE FROM tb_m_universities WHERE id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = university.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

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

        public static int GetUniversityID()
        {
            using var connection = MyConnection.Get();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP 1 id FROM tb_m_universities ORDER BY id desc";

            connection.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }

        // GET Universities(id)

        /*public static List<Universities> GetUniversitiesWithID(Universities university)
        {
            var universities = new List<Universities>();
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities WHERE id=@id";

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Size = 20;
                pId.Value = university.Id;

                command.Parameters.Add(pId);

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var university2 = new Universities();
                        university2.Id = reader.GetInt32(0);
                        university2.Name = reader.GetString(1);

                        universities.Add(university2);
                    }

                    return universities;
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
            return new List<Universities>();
        }*/

        /*public static int updateRow(string tableName, Dictionary<string, object> updateColumns, List<string> columnsToUpdate, string primaryKeyName, object primaryKeyValue)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE {tableName} SET ";
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
            return result;*/


        // UPDATE : Universities(obj)
        /*public static int UpdateUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection( connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {   
                // Command melakukan update
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_universities SET name=@name WHERE id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Size = 50;
                pName.Value = university.Name;

                command.Parameters.Add(pName);

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Size = 25;
                pId.Value = university.Id;

                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            } catch (Exception e)
            {
                transaction.Rollback();
            } finally
            {
                connection.Close();
            }
            return result;
        }*/


    }
}
