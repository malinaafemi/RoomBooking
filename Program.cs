using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace RoomBooking
{
    public class Program
    {
        private static readonly string connectionString =
            "Data Source=MALINAAFEMI;Database=db_employee;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public static void Main()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            /*try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally { 
                connection.Close();
                Console.WriteLine("Connection closed successfully.");
            };*/

            // Menu();

            Console.WriteLine(GetUniversityID());

            /*var results = GetUniversityID();
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Name: " + result.Name);
            }*/

            // INSERT EMPLOYEE

            /*string[] tableNames = { "tb_m_employees" };
            string[] columnNames = { "nik", "first_name", "last_name", "birthdate", "gender", "hiring_date", "email", "phone_number", "department_id"};
            object[] values = { "118104", "Abdalla", "Putra", "2002-08-17 06:24:00.000", "male", "2023-04-01 00:00:00.000", "ABDALLAPUTRA", "089690007658" , "A004"};

            InsertDataToTables(tableNames, columnNames, values);*/
            // UPDATE

            /*Console.WriteLine("What table do you want to update?");
            Console.WriteLine("1. Universities table");
            Console.WriteLine("2. Educations table");
            Console.Write("Enter which one: ");
            string tableName = Console.ReadLine();

            if (tableName == "1")
            {
                tableName = "tb_m_universities";

                Console.WriteLine("Which columns do you want to update?");
                Console.WriteLine("1. Name");
             
                string input = Console.ReadLine();
                List<string> columnsToUpdate = new List<string>();
                if (input.Contains("1"))
                {
                    columnsToUpdate.Add("name");
                }

                Dictionary<string, object> updateColumns = new Dictionary<string, object>();
                foreach (string column in columnsToUpdate)
                {
                    Console.Write($"Enter new {column}: ");
                    string newValue = Console.ReadLine();
                    updateColumns.Add(column, newValue);
                }

                updateRow(tableName, updateColumns, columnsToUpdate, "id", 8);

            } else if (tableName == "2")
            {
                tableName = "tb_m_educations";

                Console.WriteLine("Which columns do you want to update?");
                Console.WriteLine("1. Major");
                Console.WriteLine("2. Degree");
                Console.WriteLine("3. GPA");
                Console.WriteLine("4. University ID");

                string input = Console.ReadLine();
                List<string> columnsToUpdate = new List<string>();
                if (input.Contains("1"))
                {
                    columnsToUpdate.Add("major");
                }
                if (input.Contains("2")) 
                {
                    columnsToUpdate.Add("degree");
                }
                if (input.Contains("3"))
                {
                    columnsToUpdate.Add("gpa");
                }
                if (input.Contains("4"))
                {
                    columnsToUpdate.Add("university_id");
                }

                Dictionary<string, object> updateColumns = new Dictionary<string, object>();
                foreach (string column in columnsToUpdate)
                {
                    Console.Write($"Enter new {column}: ");
                    string newValue = Console.ReadLine();
                    updateColumns.Add(column, newValue);
                }

                updateRow(tableName, updateColumns, columnsToUpdate, "id", 8);
            }*/



            // COBA
            /*Dictionary<string, Type> columnTypes = new Dictionary<string, Type>()
            {
                { "major", typeof(string) },
                { "degree", typeof(string) },
                { "gpa", typeof(string) },
                { "university_id", typeof(int) }
            };*/


            /*List<object> values = new List<object>();
            foreach (var columnType in columnTypes)
            {
                Console.Write($"Enter value for {columnType.Key}: ");
                string input = Console.ReadLine();

                object value = Convert.ChangeType(input, columnType.Value);
                values.Add(value);
            }

            string contoh = string.Join(",", columnTypes.Keys);
            Console.WriteLine(contoh);

            string contoh2 = string.Join(",", columnTypes.Keys.Select((key,i) => $"@p{i}"));
            Console.WriteLine(contoh2);

            string tableName = "tb_m_educations";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"INSERT INTO {tableName}({string.Join(",", columnTypes.Keys)}) VALUES({ string.Join(",", columnTypes.Keys.Select((key, i) => $"@p{i}"))})";

            Console.WriteLine(command.CommandText);

            for (int i = 0; i < values.Count; i++)
            {
                command.Parameters.AddWithValue($"p{i}", values[i]);
            }

            Console.WriteLine(command.Parameters);*/


            // NEW INSERT

            // Menu();

            /* string tableName = "tb_m_educations";
             Dictionary<string, object> columnValues = new Dictionary<string, object>()
             {
                 { "major", null},
                 { "degree", null},
                 { "gpa", null},
                 { "university_id", null }
             };

             foreach (var columnValue in columnValues)
             {
                 Console.Write($"Enter value for {columnValue.Key}: ");
                 columnValues[columnValue.Key] = Console.ReadLine();
             }

             var result = InsertRow(tableName, columnValues);
             if (result > 0)
             {
                 Console.WriteLine("Insert success.");
             }
             else
             {
                 Console.WriteLine("Insert failed.");
             }*/

            /*string tableName = "tb_m_educations";
            Dictionary<string, Type> columnTypes = new Dictionary<string, Type>
            {
                { "major", typeof(string) },
                { "degree", typeof (string) },
                { "gpa", typeof(string) },
                { "university_id", typeof(int) }
            };

            var result = InsertUniversity(tableName, columnTypes);
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            
            // Get Universities

            /*var results = GetUniversities();
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Name: " + result.Name);
            }*/

            // Get Universities with Id

            /*Console.WriteLine("Get University with ID");

            var university = new Universities();
            university.Id = 5;

            var results = GetUniversitiesWithID(university);
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Name: " + result.Name);
            }

            Console.WriteLine("\nMalina Putri Afemi");*/

            /*var results = GetUniversitiesWithID(university);
            Console.WriteLine("Id: " + results.Id);
            Console.WriteLine("Name: " + results.Name);*/

            // INSERT

            /*Console.WriteLine("Menambahkan Universitas Pamulang");

            var university = new Universities();
            university.Name = "Universitas Pamulang";

            var result = InsertUniversity(university);
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            var results = GetUniversities();
            foreach (var result2 in results)
            {
                Console.WriteLine("Id: " + result2.Id);
                Console.WriteLine("Name: " + result2.Name);
            }

            Console.WriteLine("\nMalina Putri Afemi");*/



            // Delete

            /*Console.WriteLine("Menghapus Universitas Pamulang");

            var university = new Universities();
            university.Id = 11;

            var result = DeleteUniversity(university);
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            var results = GetUniversities();
            foreach (var result2 in results)
            {
                Console.WriteLine("Id: " + result2.Id);
                Console.WriteLine("Name: " + result2.Name);
            }

            Console.WriteLine("Malina Putri Afemi");*/


            // Update

            /*Console.WriteLine("Mengganti Universitas Udayana dengan Universitas Trisakti");
            var university = new Universities();
            university.Name = "Universitas Negeri Surakarta";
            university.Id = 5;


            var result = UpdateUniversity(university);
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed");
            }

            var results = GetUniversities();
            foreach (var result2 in results)
            {
                Console.WriteLine("Id: " + result2.Id);
                Console.WriteLine("Name: " + result2.Name);
            }


            Console.WriteLine("Malina Putri Afemi");*/
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

        // SELECT TABLE

        public static List<Universities> GetUniversities()
        {
            var universities = new List<Universities>();
            using SqlConnection connection = new SqlConnection(connectionString);
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
                        var university = new Universities();
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
            return new List<Universities>();
        }

        public static List<Education> GetEducations()
        {
            var educations = new List<Education>();
            using SqlConnection connection = new SqlConnection(connectionString);
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

        // GET : Universities

        /*public static List<Universities> GetUniversities()
        {
            var universities = new List<Universities>();
            using SqlConnection connection = new SqlConnection(connectionString);
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
                        var university = new Universities();
                        university.Id = reader.GetInt32(0);
                        university.Name = reader.GetString(1);

                        universities.Add(university);
                    }

                    return universities;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                connection.Close();
            }
            return new List<Universities>();
        }*/

        // NEW Insert Universities

        static void Menu()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("                    MENU                     ");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Select");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    Console.WriteLine("Select table: ");
                    Console.WriteLine("1. Universities");
                    Console.WriteLine("2. Educations");
                    Console.Write("Enter table: ");
                    string tableName = Console.ReadLine();

                    if (tableName == "1")
                    {
                        var results = GetUniversities();
                        foreach (var rslt in results)
                        {
                            Console.WriteLine("Id: " + rslt.Id);
                            Console.WriteLine("Name: " + rslt.Name);
                        }
                    }
                    if (tableName == "2")
                    {
                        var results = GetEducations();
                        foreach (var rslt in results)
                        {
                            Console.WriteLine("Id: " + rslt.Id);
                            Console.WriteLine("Major: " + rslt.Major);
                            Console.WriteLine("Degree: " + rslt.Degree);
                            Console.WriteLine("GPA: " + rslt.GPA);
                            Console.WriteLine("University ID: " + rslt.universityID);
                        }

                    }
                    return;


                case 2:
                    Console.Write("Select table: ");
                    Console.WriteLine("1. Universities");
                    Console.WriteLine("2. Educations");
                    Console.Write("Enter table: ");
                    string tableName2 = Console.ReadLine();

                    Dictionary<string, object> columnValues = new Dictionary<string, object>();

                    if (tableName2 == "1")
                    {
                        tableName2 = "tb_m_universities";

                        columnValues.Add("name", null);

                        foreach (var columnValue in columnValues)
                        {
                            Console.Write($"Enter value for {columnValue.Key}: ");
                            columnValues[columnValue.Key] = Console.ReadLine();
                        };


                    }
                    else if (tableName2 == "2")
                    {
                        tableName2 = "tb_m_educations";

                        columnValues.Add("major", null);
                        columnValues.Add("degree", null);
                        columnValues.Add("gpa", null);
                        columnValues.Add("university_id", null);

                        foreach (var columnValue in columnValues)
                        {
                            Console.Write($"Enter value for {columnValue.Key}: ");
                            columnValues[columnValue.Key] = Console.ReadLine();
                        }

                    }

                    var result = InsertRow(tableName2, columnValues);
                    if (result > 0)
                    {
                        Console.WriteLine("Insert success.");
                    }
                    else
                    {
                        Console.WriteLine("Insert failed.");
                    }

                    return;

                case 3:
                    Console.WriteLine("What table do you want to update?");
                    Console.WriteLine("1. Universities table");
                    Console.WriteLine("2. Educations table");
                    Console.Write("Enter table: ");
                    string tableName3 = Console.ReadLine();

                    if (tableName3 == "1")
                    {
                        tableName3 = "tb_m_universities";


                        List<string> columnsToUpdate = new List<string>();
                        columnsToUpdate.Add("name");

                        Dictionary<string, object> updateColumns = new Dictionary<string, object>();
                        foreach (string column in columnsToUpdate)
                        {
                            Console.Write($"Enter new {column}: ");
                            string newValue = Console.ReadLine();
                            updateColumns.Add(column, newValue);
                        }

                        Console.Write("Insert column name as primary key: ");
                        string primaryKeyName = Console.ReadLine();

                        Console.Write("Insert value of primary key: ");
                        object primaryKeyValue = Console.ReadLine();

                        updateRow(tableName3, updateColumns, columnsToUpdate, primaryKeyName, primaryKeyValue);

                    }
                    else if (tableName3 == "2")
                    {
                        tableName3 = "tb_m_educations";

                        Console.WriteLine("Which columns do you want to update?");
                        Console.WriteLine("1. Major");
                        Console.WriteLine("2. Degree");
                        Console.WriteLine("3. GPA");
                        Console.WriteLine("4. University ID");
                        Console.Write("Enter numbers of columns in comma-separated: ");
                        string input = Console.ReadLine();
                        List<string> columnsToUpdate = new List<string>();
                        if (input.Contains("1"))
                        {
                            columnsToUpdate.Add("major");
                        }
                        if (input.Contains("2"))
                        {
                            columnsToUpdate.Add("degree");
                        }
                        if (input.Contains("3"))
                        {
                            columnsToUpdate.Add("gpa");
                        }
                        if (input.Contains("4"))
                        {
                            columnsToUpdate.Add("university_id");
                        }

                        Dictionary<string, object> updateColumns = new Dictionary<string, object>();
                        foreach (string column in columnsToUpdate)
                        {
                            Console.Write($"Enter new {column}: ");
                            string newValue = Console.ReadLine();
                            updateColumns.Add(column, newValue);
                        }

                        Console.Write("Insert column name as primary key: ");
                        string primaryKeyName = Console.ReadLine();

                        Console.Write("Insert value of primary key: ");
                        object primaryKeyValue = Console.ReadLine();

                        updateRow(tableName3, updateColumns, columnsToUpdate, primaryKeyName, primaryKeyValue);
                    }
                    return;

                case 4:
                    Console.WriteLine("Select table: ");
                    Console.WriteLine("1. Universities");
                    Console.WriteLine("2. Educations");
                    Console.Write("Enter table: ");
                    string tableName4 = Console.ReadLine();

                    if (tableName4 == "1")
                    {
                        tableName4 = "tb_m_universities";

                        var university = new Universities();
                        Console.Write("Insert number of row: ");
                        university.Id = Convert.ToInt32(Console.ReadLine());

                        var result2 = DeleteUniversity(university);
                        if (result2 > 0)
                        {
                            Console.WriteLine("Delete success.");
                        }
                        else
                        {
                            Console.WriteLine("Delete failed.");
                        }

                    } else if (tableName4 == "2")
                    {
                        tableName4 = "tb_m_educations";

                        var education = new Education();
                        Console.Write("Insert number of row: ");
                        education.Id = Convert.ToInt32(Console.ReadLine());

                        var result2 = DeleteEducation(education);
                        if (result2 > 0)
                        {
                            Console.WriteLine("Delete success.");
                        }
                        else
                        {
                            Console.WriteLine("Delete failed.");
                        }

                    }
                    return;

                case 5:
                    break;
            }
        }

        // SELECT TABLE

        /*public static DataTable selectTable(string tableName)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT COUNT(*) FROM {tableName}";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }*/

        // Insert Row
        public static int InsertRow(string tableName, Dictionary<string, object> columnValues)
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
                //
                /*List<object> columnValues = new List<object>();

                foreach (var columnType in columnTypes)
                {
                    Console.Write($"Enter value for {columnType.Key}: ");
                    string input = Console.ReadLine();

                    object value = Convert.ChangeType(input, columnType.Value);

                    columnValues.Add(value);

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO {tableName}({string.Join(",", columnTypes.Keys)}) VALUES({string.Join(",", columnTypes.Keys.Select((key, i) => $"@p{i}"))})";
                    command.Transaction = transaction;


                 for (int i=0; i<columnValues.Count;i++)
                 {
                     command.Parameters.AddWithValue($"@p{i}", columnValues[i]);
                 }*/

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
        }


        // INSERT : Universities
        /*public static int InsertUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
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
            } catch (Exception e)
            {
                transaction.Rollback();
            } finally
            {
                connection.Close();
            }

            return result;
        }*/

        // DELETE : Educations(5)

        // DELETE : Universities(5)

        public static int DeleteEducation(Education education)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
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
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        // DELETE : Universities(5)

        public static int DeleteUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
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
        // UPDATE ROW

        public static int updateRow(string tableName, Dictionary<string, object> updateColumns, List<string> columnsToUpdate, string primaryKeyName, object primaryKeyValue)
        {
            int result = 0;
            using var connection = new SqlConnection( connectionString);
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
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            } finally
            {
                connection.Close();
            }
            return result;
        }


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

        // INSERT EMPLOYEE, PROFILINGS, EDUCATION, UNIVERSITY

        public static int GetUniversityID()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP 1 id FROM tb_m_universities ORDER BY id desc";

            connection.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
                
        }

        public static void InsertDataToTables()
        {
            // Employee
            string tableName = "tb_m_employees";

            Dictionary<string, object> columnValues = new Dictionary<string, object>();

            columnValues.Add("nik", null);
            columnValues.Add("first_name", null);
            columnValues.Add("last_name", null);
            columnValues.Add("birthdate", null);
            columnValues.Add("gender", null);
            columnValues.Add("hiring_date", null);
            columnValues.Add("email", null);
            columnValues.Add("phone_number", null);
            columnValues.Add("department_id", null);

            foreach (var columnValue in columnValues)
            {
                Console.Write($"Enter value for {columnValue.Key}: ");
                columnValues[columnValue.Key] = Console.ReadLine();
            }

            // Universities

            string tableName2 = "tb_m_universities";
            Dictionary<string, object> columnValues2 = new Dictionary<string, object>();

            columnValues2.Add("name", null);

            foreach (var columnValue in columnValues2)
            {
                Console.Write($"Enter value for {columnValue.Key}: ");
                columnValues2[columnValue.Key] = Console.ReadLine();
            }

            // Educations

            string tableName3 = "tb_m_educations";
            Dictionary<string, object> columnValues3 = new Dictionary<string, object>();

            columnValues3.Add("major", null);
            columnValues3.Add("degree", null);
            columnValues3.Add("GPA", null);

            foreach (var columnValue in columnValues3)
            {
                Console.Write($"Enter value for {columnValue.Key}: ");
                columnValues3[columnValue.Key] = Console.ReadLine();
            }

        }

        /*public static void InsertDataToTables(string[] tableNames, string[] columnNames, object[] values)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            string parameterHolders = string.Join(",", columnNames.Select(c => "@" + c));
            foreach (string tableName in  tableNames)
            {
                string query = $"INSERT INTO {tableName} ({string.Join(",", columnNames)}) VALUES ({parameterHolders})";
                command.CommandText = query ;

                for (int i = 0; i < columnNames.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + columnNames[i], values[i]);
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);

                } finally
                {
                    connection.Close();
                }

                command.Parameters.Clear();
            }
        }*/

    }
}

