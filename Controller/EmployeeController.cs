using RoomBooking.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Controller
{
    public class EmployeeController
    {
        public static void GetAll()
        {
            var results = Employee.Get();
            var view = new EmployeeView();
            if (results.Count == 0)
            {
                view.Output("Data tidak ditemukan");
            }
            else
            {
                view.Output(results);
            }
        }

        public static void InsertAll()
        {
            var employee = new Employee();

            Console.Write("NIK : ");
            var niks = Console.ReadLine();
            employee.NIK = niks;

            Console.Write("First Name : ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Last Name : ");
            employee.LastName = Console.ReadLine();

            Console.Write("Birthdate : ");
            employee.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Gender : ");
            employee.Gender = Console.ReadLine();

            Console.Write("Hiring Date : ");
            employee.HiringDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Email : ");
            employee.Email = Console.ReadLine();

            Console.Write("Phone Number : ");
            employee.PhoneNumber = Console.ReadLine();

            Console.Write("Department ID : ");
            employee.DepartmentId = Console.ReadLine();

            
            var eResult = Employee.Insert(employee);
            var view = new EmployeeView();
            if (eResult > 0)
            {
                view.Output("Insert success.");
            }
            else
            {
                view.Output("Insert Failed");
            }

            // University

            var university = new University();
            Console.Write("University name: ");
            university.Name = Console.ReadLine();

            var uResult = University.Insert(university);
            var uView = new UniversityView();
            if (uResult > 0)
            {
                uView.Output("Insert university success.");
            }
            else
            {
                uView.Output("Insert university failed");
            }

            // Education
            var education = new Education();
            education.Id = University.GetUniversityID();

            Education.Insert(education);
            // Profilings
            var profiling = new Profiling();
            profiling.EducationId = Education.GetId();
            profiling.EmployeeId = new Guid(Employee.GetId(niks));

            var pResult = Profiling.Insert(profiling);
            var pView = new ProfilingView();
            if (pResult > 0)
            {
                pView.Output("Insert profilings success.");
            }
            else
            {
                pView.Output("Insert profilings failed.");
            }

        }
    }
}
