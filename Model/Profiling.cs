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
    public class Profiling
    {
        public Guid EmployeeId { get; set; }
        // public Guid EmployeeId { get; set; }
        public int EducationId { get; set; }

        private static readonly string connectionString =
            "Data Source=MALINAAFEMI;Database=db_employee;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        // GET
        public static List<Profiling> Get()
        {
            var profilings = new List<Profiling>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profilings";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var profiling = new Profiling();
                        profiling.EmployeeId = reader.GetGuid(0);
                        //profiling.EmployeeId = reader.GetGuid(0);
                        profiling.EducationId = reader.GetInt32(1);

                        profilings.Add(profiling);
                    }

                    return profilings;
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
            return new List<Profiling>();
        }

        public static int Insert(Profiling profiling)
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
                command.CommandText = "INSERT INTO tb_tr_profilings VALUES (@emid, @eid)";
                command.Transaction = transaction;

                //Membuat parameter
                var pEmid = new SqlParameter();
                pEmid.ParameterName = "@emid";
                pEmid.SqlDbType = SqlDbType.UniqueIdentifier;
                //pEmid.Value = Guid.Parse(profiling.EmployeeId);
                pEmid.Value = profiling.EmployeeId;

                var pEid = new SqlParameter();
                pEid.ParameterName = "@eid";
                pEid.Value = profiling.EducationId; 

                // Menambahkan parameter ke command
                command.Parameters.Add(pEmid);
                command.Parameters.Add(pEid);
                

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
    }
}
