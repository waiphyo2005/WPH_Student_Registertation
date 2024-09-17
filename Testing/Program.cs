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
        static StudentGrading studentGrading = new StudentGrading();
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            studentGrading.SubjectGrading();

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
                    Console.WriteLine();
                    Console.WriteLine(" =======================");
                    Console.WriteLine("| Register New Students |");
                    Console.WriteLine(" =======================");
                    Console.WriteLine();
                    insertStudent();
                    MainMenu();
                    break;
                case 2:
                    displayStudent();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the system!");
                    break;
            }
        }
        static void insertStudent()
        {
            char field;
            Student student = new Student();
            Console.Write("Please insert Student's Grade Number: ");
            int grade = Convert.ToInt32(Console.ReadLine());

            switch (grade)
            {
                case 1:
                    student.getStudentInfo("1", studentGrading.gradeSubjects["1"]);
                    students.Add(student);
                    break;
                case 2:
                    student.getStudentInfo("2", studentGrading.gradeSubjects["2"]);
                    students.Add(student);
                    break;
                case 3:
                    student.getStudentInfo("3", studentGrading.gradeSubjects["3"]);
                    students.Add(student);
                    break;
                case 4:
                    student.getStudentInfo("4", studentGrading.gradeSubjects["4"]);
                    students.Add(student);
                    break;
                case 5:
                    student.getStudentInfo("5", studentGrading.gradeSubjects["5"]);
                    students.Add(student);
                    break;
                case 6:
                    student.getStudentInfo("6", studentGrading.gradeSubjects["6"]);
                    students.Add(student);
                    break;
                case 7:
                    student.getStudentInfo("7", studentGrading.gradeSubjects["7"]);
                    students.Add(student);
                    break;
                case 8:
                    student.getStudentInfo("8", studentGrading.gradeSubjects["8"]);
                    students.Add(student);
                    break;
                case 9:
                    Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                    field = Convert.ToChar(Console.ReadLine());
                    if (field == 'B')
                    {
                        student.getStudentInfo("9B", studentGrading.gradeSubjects["9B"]);
                        students.Add(student);
                        break;
                    }
                    else if (field == 'E')
                    {
                        student.getStudentInfo("9E", studentGrading.gradeSubjects["9E"]);
                        students.Add(student);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                        insertStudent();
                        break;
                    }
                case 10:
                    Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                    field = Convert.ToChar(Console.ReadLine());
                    if (field == 'B')
                    {
                        student.getStudentInfo("10B", studentGrading.gradeSubjects["10B"]);
                        students.Add(student);
                        break;
                    }
                    else if (field == 'E')
                    {
                        student.getStudentInfo("10E", studentGrading.gradeSubjects["10E"]);
                        students.Add(student);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                        insertStudent();
                        break;
                    }
                default:
                    Console.WriteLine("Invalid Input!");
                    insertStudent();
                    break;
            }
        }
        static void displayStudent()
        {
            Console.WriteLine();
            Console.WriteLine(" ==========================");
            Console.WriteLine("| View Registered Students |");
            Console.WriteLine(" ==========================");
            Console.WriteLine();
            foreach (Student student in students)
            {
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Student Birthday: {student.Birthday.ToShortDateString()}");
                Console.WriteLine($"Student Age: {student.age}");
                foreach (var subject in student.marks)
                {
                    Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
                }
                Console.WriteLine($"Student Total Marks: {student.totalMarks}");
                Console.WriteLine($"Student Result: {student.result}");
                Console.WriteLine($"Student Distinctions: {student.distinctions}");
                Console.WriteLine();
            }
        }
    }
}