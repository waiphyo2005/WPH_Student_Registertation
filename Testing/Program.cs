using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace TEST
{
    public class Program
    {
        static void Main(string[] args)
        {
            //----declare list to store registered students----\\
            List<Student> studentDetails = new List<Student>();

            //----initialize data for grades and subjects-----\\
            StudentGrading studentGrading = new StudentGrading();
            studentGrading.SubjectGrading();

            Console.WriteLine("============================================");
            Console.WriteLine("|| Welcome to Student Registration System ||");
            Console.WriteLine("============================================");
            Console.WriteLine();
            bool again = false;
            while (!again)
            {
                int perform;
                Console.WriteLine("\nPlease select option that you want to perform: \n1.Register Students\n2.View registered students\n3.Exit");
                perform = Convert.ToInt32(Console.ReadLine());
                switch (perform)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine(" =======================");
                        Console.WriteLine("| Register New Students |");
                        Console.WriteLine(" =======================");
                        Console.WriteLine();
                        //----building student object----\\
                        Student s = new Student();
                        //***Debug***
                        //***Birth Month Check
                        //----using return method to store student info inside student object return the object----\\
                        //----gradeSuubjects Dictionary is set as perimeter to get the list of subjects according to grades----\\
                        s = s.insertStudent(studentGrading.gradeSubjects);

                        //----inserting student object into registered students list----\\
                        studentDetails.Add(s);
                        Console.WriteLine("\nStudent Registered Successfully.");
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine(" ==========================");
                        Console.WriteLine("| View Registered Students |");
                        Console.WriteLine(" ==========================");
                        Console.WriteLine();
                        //----building student object to access displayStudent method----\\
                        Student student = new Student();

                        //----Calling displayStudent method to view registered students----\\
                        //----Registered Student List is set as perimeter for the method from student class to access the list in Main----\\
                        student.displayStudent(studentDetails);
                        break;
                    case 3:
                        again = true;
                        Console.WriteLine("Thank you for using the system!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }
    }
}