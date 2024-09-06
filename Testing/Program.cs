using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace Testing
{
    internal class Program
    {

        static void Main(string[] args)
        {
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
                    student.insertStudent();
                    MainMenu();
                    break;
                case 2:
                    student.displayStudents();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the system!");
                    break;
            }
        }
    }
    public class Subjects
    {
        public List<string> g1Subjects = new List<string> { "Myanmar", "English", "Maths" };
        public List<string> g2Subjects = new List<string> { "Myanmar", "English", "Maths" };
        public List<string> g3Subjects = new List<string> { "Myanmar", "English", "Maths", "Social Studies" };
        public List<string> g4Subjects = new List<string> { "Myanmar", "English", "Maths", "Social Studies" };
        public List<string> g5Subjects = new List<string> { "Myanmar", "English", "Maths", "Social Studies" };
        public List<string> g6Subjects = new List<string> { "Myanmar", "English", "Maths", "Geography", "History", "Science" };
        public List<string> g7Subjects = new List<string> { "Myanmar", "English", "Maths", "Geography", "History", "Science" };
        public List<string> g8Subjects = new List<string> { "Myanmar", "English", "Maths", "Geography", "History", "Science" };
        public List<string> g9Subjects = new List<string> { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" };
        public List<string> g10Subjects = new List<string> { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" };

    }
    public class StudentDetail
    {
        public static List<List<object>> g1Details = new List<List<object>>();
        public static List<List<object>> g2Details = new List<List<object>>();
        public static List<List<object>> g3Details = new List<List<object>>();
        public static List<List<object>> g4Details = new List<List<object>>();
        public static List<List<object>> g5Details = new List<List<object>>();
        public static List<List<object>> g6Details = new List<List<object>>();
        public static List<List<object>> g7Details = new List<List<object>>();
        public static List<List<object>> g8Details = new List<List<object>>();
        public static List<List<object>> g9Details = new List<List<object>>();
        public static List<List<object>> g10Details = new List<List<object>>();
    }
}
