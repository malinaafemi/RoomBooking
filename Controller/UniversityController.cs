using RoomBooking.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Controller
{
    public class UniversityController
    {
        // private University _university = new University();

        // private University _university = new University();
        
        public static void GetAll()
        {
            var results = University.Get();
            var view = new UniversityView();
            if (results.Count == 0)
            {
                view.Output("Data tidak ditemukan");
            }
            else
            {
                view.Output(results);
            }
        }

        public static void Insert()
        {
            var university = new University();
            Console.Write("Name : ");
            university.Name = Console.ReadLine();

            var result = University.Insert(university);
            var view = new UniversityView();
            if (result > 0)
            {
                view.Output("Insert success.");
            }
            else
            {
                view.Output("Insert failed");
            }

        }

        public static void Update()
        {
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

            var result = University.Update(updateColumns, columnsToUpdate, primaryKeyName, primaryKeyValue);

            var view = new UniversityView();
            if (result > 0)
            {
                view.Output("Update Success.");
            }
            else
            {
                view.Output("Update Success");
            }

        }

        public static void Delete()
        {
            var university = new University();
            Console.Write("Insert number of row: ");
            university.Id = Convert.ToInt32(Console.ReadLine());

            var result = University.Delete(university);
            var view = new UniversityView();
            if (result > 0)
            {
                view.Output("Delete success.");
            }
            else
            {
                view.Output("Delete Failed");
            }

        }
    }
}
