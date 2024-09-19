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
        public static List<Student> studentDetails = new List<Student>();

        static void Main(string[] args)
        {
            //studentGrading.SubjectGrading();

            Console.WriteLine("============================================");
            Console.WriteLine("|| Welcome to Student Registration System ||");
            Console.WriteLine("============================================");
            Console.WriteLine();

            MainMenu();
        }
        static void MainMenu()
        {
            int perform;
            Console.WriteLine();
            Console.WriteLine("Please select option that you want to perform: \n1.Register Students\n2.View registered students\n3.Exit");
            perform = Convert.ToInt32(Console.ReadLine());

            while (perform != 1 && perform != 2 && perform != 3)
            {
                Console.WriteLine("\nInvalid Input!\n");
                Console.WriteLine("Please select option that you want to perform: \n1.Register Students\n2.View registered students\n3.Exit");
                perform = Convert.ToInt32(Console.ReadLine());
            }
            Student student = new Student();
            switch (perform)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine(" =======================");
                    Console.WriteLine("| Register New Students |");
                    Console.WriteLine(" =======================");
                    Console.WriteLine();
                    student = student.insertStudent();
                    studentDetails.Add(student);
                    MainMenu();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine(" ==========================");
                    Console.WriteLine("| View Registered Students |");
                    Console.WriteLine(" ==========================");
                    Console.WriteLine();
                    student.displayStudent(studentDetails);
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the system!");
                    break;
            }
        }
    }
}