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
            List<Student> studentDetails = new List<Student>();
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
                        Student s = new Student();
                        s = s.insertStudent(studentGrading.gradeSubjects);
                        studentDetails.Add(s);
                        Console.WriteLine("\nStudent Registered Successfully.");
                        again = false;
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine(" ==========================");
                        Console.WriteLine("| View Registered Students |");
                        Console.WriteLine(" ==========================");
                        Console.WriteLine();
                        Student student = new Student();
                        student.displayStudent(studentDetails);
                        again = false;
                        break;
                    case 3:
                        again = true;
                        Console.WriteLine("Thank you for using the system!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        again = false;
                        break;
                }
            }
        }
    }
}