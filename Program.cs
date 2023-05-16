using RoomBooking.Context;
using RoomBooking.Controller;
using RoomBooking.View;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RoomBooking
{
    public class Program
    {
        /*private static readonly string connectionString =
           "Data Source=MALINAAFEMI;Database=db_employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;MultipleActiveResultSets=true";
*/
        private UniversityController universityController = new();
        private MenuView menuView = new();
        public static void Main()
        {
            Menu();

        }


        public static void Menu()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("                    MENU                     ");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Select");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Insert All");
            Console.WriteLine("6. Join Table");
            Console.WriteLine("7. Exit");
            Console.WriteLine("=============================================");
            Console.Write("Enter your choice: ");
            int pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    MenuView.ChooseTable();
                    int gChoice = Convert.ToInt32(Console.ReadLine());
                    GetTable(gChoice);
                    break;

                case 2:
                    MenuView.ChooseTable();
                    int iChoice = Convert.ToInt32(Console.ReadLine());
                    InsertTable(iChoice);
                    // Dictionary<string, object> columnValues = new Dictionary<string, object>();
                    break;

                case 3:
                    MenuView.ChooseTable();
                    int uChoice = Convert.ToInt32(Console.ReadLine());
                    UpdateTable(uChoice);
                    break;

                case 4:
                    MenuView.ChooseTable();
                    int dChoice = Convert.ToInt32(Console.ReadLine());
                    DeleteTable(dChoice);
                    break;

                case 5:
                    InsertDataToTables();
                    break;
                case 6:
                    JoinTable();
                    break;
                case 7:
                    break;
            }
        }

        public static void GetTable(int choice)
        {
            switch (choice)
            {
                case 1:
                    UniversityController.GetAll();
                    break;

                case 2:
                    EducationController.GetAll();
                    break;

                case 3:
                    EmployeeController.GetAll();      
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

        }

        public static void InsertTable(int choice)
        {
            switch(choice)
            {
                case 1:
                    UniversityController.Insert();
                    break;
                
                case 2:
                    EducationController.Insert();
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        public static void UpdateTable(int choice)
        {
            switch (choice)
            {
                case 1:
                    UniversityController.Update();
                    break;
                    

                case 2:
                    EducationView.UpdateEducation();
                    EducationController.Update();
                    break;


                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        public static void DeleteTable(int choice)
        {
            switch (choice)
            {
                case 1:
                    UniversityController.Delete();
                    break;
                
                case 2:
                    EducationController.Delete();
                    break;
            }
        }

        // Insert data to employee, universities, education
        public static void InsertDataToTables()
        {
            EmployeeController.InsertAll();
        }

        // Join table using LINQ
        public static void JoinTable()
        {

            var employees = Employee.Get();
            var profilings = Profiling.Get();
            var educations = Education.Get();
            var universities = University.Get();

            var query = from employee in employees
                        //join profiling in profilings on employee.Id equals Guid.Parse(profiling.EmployeeId)
                        join profiling in profilings on employee.Id equals profiling.EmployeeId
                        join education in educations on profiling.EducationId equals education.Id
                        join university in universities on education.universityID equals university.Id
                        select new
                        {
                            employee.NIK,
                            FullName = employee.FirstName + " " + employee.LastName,
                            employee.FirstName,
                            employee.LastName,
                            employee.BirthDate,
                            employee.Gender,
                            employee.HiringDate,
                            employee.Email,
                            employee.PhoneNumber,
                            education.Major,
                            education.Degree,
                            education.GPA,
                            university.Name
                        };

            foreach (var item in query)
            {
                Console.WriteLine("NIK: " + item.NIK);
                Console.WriteLine("Full Name: " + item.FullName);
                //Console.WriteLine("First Name: " + item.FirstName);
                //Console.WriteLine("Last Name: " + item.LastName);
                Console.WriteLine("Birtdate: " + item.BirthDate);
                Console.WriteLine("Gender: " + item.Gender);
                Console.WriteLine("Hiring Date: " + item.HiringDate);
                Console.WriteLine("Email: " + item.Email);
                Console.WriteLine("Phone Number: " + item.PhoneNumber);
                Console.WriteLine("Major: " + item.Major);
                Console.WriteLine("Degree: " + item.Degree);
                Console.WriteLine("GPA: " + item.GPA);
                Console.WriteLine("University Name: " + item.Name);

                Console.WriteLine("\n");
            }
            return;

        }
    }
}

