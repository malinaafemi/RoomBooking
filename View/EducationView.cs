using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.View
{
    public class EducationView
    {
        public static void Output(Education education)
        {
            Console.WriteLine("Id: " + education.Id);
            Console.WriteLine("Major: " + education.Major);
            Console.WriteLine("Degree: " + education.Degree);
            Console.WriteLine("GPA: " + education.GPA);
            Console.WriteLine("University ID: " + education.universityID);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<Education> educations)
        {
            foreach (var education in educations)
            {
                Output(education);
            }
        }
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
        public static void UpdateEducation()
        {
            Console.WriteLine("Which columns do you want to update?");
            Console.WriteLine("1. Major");
            Console.WriteLine("2. Degree");
            Console.WriteLine("3. GPA");
            Console.WriteLine("4. University ID");
            Console.Write("Enter numbers of columns in comma-separated: ");
        }
    }
}
