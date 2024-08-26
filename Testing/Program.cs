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
        string[][] gradeSubjects = new string[][]
        {
            new string[] { "Myanmar", "English", "Maths" },
            new string[] { "Myanmar", "English", "Maths" },
            new string[] { "Myanmar", "English", "Maths", "Social Studies" },
            new string[] { "Myanmar", "English", "Maths", "Social Studies" },
            new string[] { "Myanmar", "English", "Maths", "Social Studies" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" },
            new string[] { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" },
        };

        List<List<object>> g1Details = new List<List<object>>();
        List<List<object>> g2Details = new List<List<object>>();
        List<List<object>> g3Details = new List<List<object>>();
        List<List<object>> g4Details = new List<List<object>>();
        List<List<object>> g5Details = new List<List<object>>();
        List<List<object>> g6Details = new List<List<object>>();
        List<List<object>> g7Details = new List<List<object>>();
        List<List<object>> g8Details = new List<List<object>>();
        List<List<object>> g9Details = new List<List<object>>();
        List<List<object>> g10Details = new List<List<object>>();

        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|| Welcome to Student Registration System ||");
            Console.WriteLine("============================================");
            Console.WriteLine();

            Program student = new Program();
            student.MainMenu();
        }

        void MainMenu()
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

            switch (perform)
            {
                case 1:
                    insertStudent();
                    break;
                case 2:
                    displayStudents();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the system!");
                    break;
            }
        }

        void insertStudent()
        {
            Console.WriteLine();
            Console.WriteLine(" =======================");
            Console.WriteLine("| Register New Students |");
            Console.WriteLine(" =======================");
            Console.WriteLine();

            Console.Write("Please insert Student's Grade Number: ");
            int grade = Convert.ToInt32(Console.ReadLine());

            switch (grade)
            {
                case 1:
                    register(grade, g1Details);
                    break;
                case 2:
                    register(grade, g2Details);
                    break;
                case 3:
                    register(grade, g3Details);
                    break;
                case 4:
                    register(grade, g4Details);
                    break;
                case 5:
                    register(grade, g5Details);
                    break;
                case 6:
                    register(grade, g6Details);
                    break;
                case 7:
                    register(grade, g7Details);
                    break;
                case 8:
                    register(grade, g8Details);
                    break;
                case 9:
                    register(grade, g9Details);
                    break;
                case 10:
                    register(grade, g10Details);
                    break;
                default:
                    Console.WriteLine("\nInvalid Input! Please insert a proper Grade (1 to 10)!\n");
                    insertStudent();
                    break;
            }
        }

        void register(int studentGrade, List<List<object>> list)
        {
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine($" Register students for Grade {studentGrade}");
            Console.WriteLine("===============================");
            Console.WriteLine();

            bool another = true;
            var phrase = @"^[a-zA-Z ]+$";

            while (another)
            {
                double totalmarks = 0;
                char status;
                int distinction = 0;
                List<object> student = new List<object>();
                List<char> subjStatus = new List<char>();

                Console.Write("Enter Student's Name: ");
                string name = Console.ReadLine();
                bool nameValid = Regex.IsMatch(name, phrase);

                while (!nameValid)
                {
                    Console.WriteLine("\nInvalid Input! Please insert a proper name!\n");
                    Console.Write("Enter Student's Name: ");
                    name = Console.ReadLine();
                    nameValid = Regex.IsMatch(name, phrase);
                }

                student.Add(name);

                Console.Write("Enter Student's Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                while (age < 5 || age > 120)
                {
                    Console.WriteLine("\nInvalid Input! Please insert a proper age!\n");
                    Console.Write("Enter Student's Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                }

                student.Add(age);
                student.Add(studentGrade);

                for (int i = 0; i < gradeSubjects[studentGrade - 1].Length; i++)
                {
                    Console.Write($"Please Insert the marks of {gradeSubjects[studentGrade - 1][i]}: ");
                    double marks = Convert.ToDouble(Console.ReadLine());

                    while (marks < 0 || marks > 100)
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                        Console.Write($"Please Insert the marks of {gradeSubjects[studentGrade - 1][i]}: ");
                        marks = Convert.ToDouble(Console.ReadLine());
                    }

                    student.Add(marks);

                    if (marks < 40)
                    {
                        status = 'F';
                    }
                    else if (marks > 80)
                    {
                        status = 'D';
                    }
                    else
                    {
                        status = 'P';
                    }
                    subjStatus.Add(status);
                    totalmarks += marks;
                }
                student.Add(totalmarks);
                if (subjStatus.Contains('F'))
                {
                    student.Add("Fail");
                }
                else
                {
                    student.Add("Passed");
                }
                for (int i = 0;i < subjStatus.Count; i++)
                {
                    if (subjStatus[i] == 'D')
                    {
                        distinction++;
                    }
                }
                student.Add(distinction);
                list.Add(student);

                Console.WriteLine($"\nDo you want to register another student in Grade {studentGrade}?\n1.Yes\n2.No");
                int rAnother = Convert.ToInt32(Console.ReadLine());

                switch (rAnother)
                {
                    case 1:
                        another = true;
                        break;
                    case 2:
                        another = false;
                        break;
                }
            }

            MainMenu();
        }

        void displayStudents()
        {
            Console.Write("Please insert the Grade that you want to see the students: ");
            int dGrade = Convert.ToInt32(Console.ReadLine());

            switch (dGrade)
            {
                case 1:
                    showStudents(1, gradeSubjects[0], g1Details);
                    break;
                case 2:
                    showStudents(2, gradeSubjects[1], g2Details);
                    break;
                case 3:
                    showStudents(3, gradeSubjects[2], g3Details);
                    break;
                case 4:
                    showStudents(4, gradeSubjects[3], g4Details);
                    break;
                case 5:
                    showStudents(5, gradeSubjects[4], g5Details);
                    break;
                case 6:
                    showStudents(6, gradeSubjects[5], g6Details);
                    break;
                case 7:
                    showStudents(7, gradeSubjects[6], g7Details);
                    break;
                case 8:
                    showStudents(8, gradeSubjects[7], g8Details);
                    break;
                case 9:
                    showStudents(9, gradeSubjects[8], g9Details);
                    break;
                case 10:
                    showStudents(10, gradeSubjects[9], g10Details);
                    break;
                default:
                    displayStudents();
                    break;
            }
        }

        void showStudents(int g, string[] stusubj, List<List<object>> stulist)
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine($" Registered students for Grade {g}");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.Write(string.Format("{0,-20}{1,-20}{2,-20}","Name", "Age", "Grade"));

            for (int i = 0; i < stusubj.Length; i++)
            {
                Console.Write(string.Format("{0,-20}", stusubj[i]));
            }

            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Total Marks","Subject Status","Total Distinctions"));

            foreach (var student in stulist)
            {
                foreach (var detail in student)
                {
                    Console.Write(string.Format("{0,-20}",detail));
                }

                Console.WriteLine();
            }

            MainMenu();
        }
    }
}
