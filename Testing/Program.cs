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
            //Student student = new Student();
            switch (perform)
            {
                case 1:
                    insertStudent();
                    MainMenu();
                    break;
                case 2:
                    displayStudents();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the system!");
                    break;
            }
        }

        static void insertStudent()
        {
            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine("|| Register New Students ||");
            Console.WriteLine("===========================");
            Console.WriteLine();
            //name
            string phrase = @"^[a-zA-Z ]+$";
            Console.Write("Enter Student's Name: ");
            string studentName = Console.ReadLine();
            bool nameValid = Regex.IsMatch(studentName, phrase);

            while (!nameValid)
            {
                Console.WriteLine("\nInvalid Input! Please insert a proper name!\n");
                Console.Write("Enter Student's Name: ");
                studentName = Console.ReadLine();
                nameValid = Regex.IsMatch(studentName, phrase);
            }

            //birthday
            string datepattern = @"^(0[1-9]|1[0-2])/([0-2][0-9]|3[01])/\d{4}$";
            Console.Write("Enter Student's Birthday(MM/DD/YYYY): ");
            string studentBirthday = Console.ReadLine();
            bool bdayValid = Regex.IsMatch(studentBirthday, datepattern);
            while (!bdayValid)
            {
                Console.WriteLine("Incorrect Format or Invalid Birthday! Please insert again!)");
                Console.Write("Enter Student's Birthday(MM/DD/YYYY): ");
                studentBirthday = Console.ReadLine();
                bdayValid = Regex.IsMatch(studentBirthday, datepattern);
            }
            DateTime bday = DateTime.Parse(studentBirthday);


            //grade
            Console.Write("Please insert Student's Grade Number: ");
            int studentGrade = Convert.ToInt32(Console.ReadLine());

            switch (studentGrade)
            {
                case 1:
                    G1toG2Student g1Student = new G1toG2Student();
                    g1Student.name = studentName;
                    g1Student.birthday = bday;
                    g1Student.calculateAge();
                    g1Student.grade = studentGrade;
                    g1Student.collectMarks();
                    g1Student.totalMarks();
                    g1Student.statusCheck();
                    g1Student.countDistinctions();
                    StudentDetail.g1Details.Add(g1Student);
                    break;
                case 2:
                    G1toG2Student g2Student = new G1toG2Student();
                    g2Student.name = studentName;
                    g2Student.birthday = bday;
                    g2Student.calculateAge();
                    g2Student.grade = studentGrade;
                    g2Student.collectMarks();
                    g2Student.totalMarks();
                    g2Student.statusCheck();
                    g2Student.countDistinctions();
                    StudentDetail.g2Details.Add(g2Student);
                    break;
                case 3:
                    G3toG4Student g3Student = new G3toG4Student();
                    g3Student.name = studentName;
                    g3Student.birthday = bday;
                    g3Student.calculateAge();
                    g3Student.grade = studentGrade;
                    g3Student.collectMarks();
                    g3Student.totalMarks();
                    g3Student.statusCheck();
                    g3Student.countDistinctions();
                    StudentDetail.g3Details.Add(g3Student);
                    break;
                case 4:
                    G3toG4Student g4Student = new G3toG4Student();
                    g4Student.name = studentName;
                    g4Student.birthday = bday;
                    g4Student.calculateAge();
                    g4Student.grade = studentGrade;
                    g4Student.collectMarks();
                    g4Student.totalMarks();
                    g4Student.statusCheck();
                    g4Student.countDistinctions();
                    StudentDetail.g4Details.Add(g4Student);
                    break;
                case 5:
                    G5toG8Student g5Student = new G5toG8Student();
                    g5Student.name = studentName;
                    g5Student.birthday = bday;
                    g5Student.calculateAge();
                    g5Student.grade = studentGrade;
                    g5Student.collectMarks();
                    g5Student.totalMarks();
                    g5Student.statusCheck();
                    g5Student.countDistinctions();
                    StudentDetail.g5Details.Add(g5Student);
                    break;
                case 6:
                    G5toG8Student g6Student = new G5toG8Student();
                    g6Student.name = studentName;
                    g6Student.birthday = bday;
                    g6Student.calculateAge();
                    g6Student.grade = studentGrade;
                    g6Student.collectMarks();
                    g6Student.totalMarks();
                    g6Student.statusCheck();
                    g6Student.countDistinctions();
                    StudentDetail.g6Details.Add(g6Student);
                    break;
                case 7:
                    G5toG8Student g7Student = new G5toG8Student();
                    g7Student.name = studentName;
                    g7Student.birthday = bday;
                    g7Student.calculateAge();
                    g7Student.grade = studentGrade;
                    g7Student.collectMarks();
                    g7Student.totalMarks();
                    g7Student.statusCheck();
                    g7Student.countDistinctions();
                    StudentDetail.g7Details.Add(g7Student);
                    break;
                case 8:
                    G5toG8Student g8Student = new G5toG8Student();
                    g8Student.name = studentName;
                    g8Student.birthday = bday;
                    g8Student.calculateAge();
                    g8Student.grade = studentGrade;
                    g8Student.collectMarks();
                    g8Student.totalMarks();
                    g8Student.statusCheck();
                    g8Student.countDistinctions();
                    StudentDetail.g8Details.Add(g8Student);
                    break;
                case 9:
                    G9toG10Student g9Student = new G9toG10Student();
                    g9Student.name = studentName;
                    g9Student.birthday = bday;
                    g9Student.calculateAge();
                    g9Student.grade = studentGrade;
                    g9Student.collectMarks();
                    g9Student.totalMarks();
                    g9Student.statusCheck();
                    g9Student.countDistinctions();
                    StudentDetail.g9Details.Add(g9Student);
                    break;
                case 10:
                    G9toG10Student g10Student = new G9toG10Student();
                    g10Student.name = studentName;
                    g10Student.birthday = bday;
                    g10Student.calculateAge();
                    g10Student.grade = studentGrade;
                    g10Student.collectMarks();
                    g10Student.totalMarks();
                    g10Student.statusCheck();
                    g10Student.countDistinctions();
                    StudentDetail.g10Details.Add(g10Student);
                    break;
                default:
                    Console.WriteLine("\nInvalid Input! Please insert a proper Grade (1 to 10)!\n");
                    insertStudent();
                    break;
            }
        }
        static void displayStudents()
        {
            Console.WriteLine();
            Console.WriteLine(" ==========================");
            Console.WriteLine("| View Registered Students |");
            Console.WriteLine(" ==========================");
            Console.WriteLine();
            Console.Write("Please insert the Grade that you want to see the students: ");
            int dGrade = Convert.ToInt32(Console.ReadLine());
            //Subjects subject = new Subjects();
            switch (dGrade)
            {
                case 1:
                    foreach (G1toG2Student student in StudentDetail.g1Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    foreach (G1toG2Student student in StudentDetail.g2Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    foreach (G3toG4Student student in StudentDetail.g3Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    foreach (G3toG4Student student in StudentDetail.g4Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 5:
                    foreach (G5toG8Student student in StudentDetail.g5Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 6:
                    foreach (G5toG8Student student in StudentDetail.g6Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 7:
                    foreach (G5toG8Student student in StudentDetail.g7Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 8:
                    foreach (G5toG8Student student in StudentDetail.g8Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 9:
                    foreach (G9toG10Student student in StudentDetail.g9Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 10:
                    foreach (G9toG10Student student in StudentDetail.g10Details)
                    {
                        Console.Write($"{student.name,-20} {student.birthday.ToShortDateString(),-20} {student.age,-4} {student.grade,-2} {student.totalmarks,-4} {student.status,-4} {student.distinctions,-2}");
                        foreach (double mark in student.Marks)
                        {
                            Console.Write($"{mark,-3}");
                        }
                        Console.WriteLine();
                    }
                    break;
                default:
                    displayStudents();
                    break;
            }
        }

        //static void showStudents(int g, List<string> stusubj, List<List<Student>> stulist)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("==================================");
        //    Console.WriteLine($" Registered students for Grade {g}");
        //    Console.WriteLine("==================================");
        //    Console.WriteLine();

        //    //Console.Write(string.Format("{0,-20}{1,-20}{2,-20}", "Name", "Age", "Grade"));

        //    //for (int i = 0; i < stusubj.Count; i++)
        //    //{
        //    //    Console.Write(string.Format("{0,-20}", stusubj[i]));
        //    //}

        //    //Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Total Marks", "Subject Status", "Total Distinctions"));

        //    if (stulist.Count == 0)
        //    {
        //        Console.WriteLine("\nRecord is Empty!\n");
        //    }
        //    else
        //    {

        //        foreach (var student in stulist)
        //        {
        //            foreach (var detail in student)
        //            {
        //                Console.Write(string.Format("{0,-20}", detail));
        //            }

        //            Console.WriteLine();
        //        }
        //    }
        //}
    }
}
