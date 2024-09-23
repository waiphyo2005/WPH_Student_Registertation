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

namespace Testing
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
                        bool choiceValid = false;
                        while (!choiceValid)
                        {
                            Console.WriteLine("\nPlease select the standard that you want to register:\n1.Elimentary School\n2.Middle School\n3.High School");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    choiceValid = true;
                                    ElementarySchool elementaryStudent = new ElementarySchool();
                                    elementaryStudent = elementaryStudent.insertStudent(studentGrading.gradeSubjects);
                                    studentDetails.Add(elementaryStudent);
                                    Console.WriteLine("\nStudent Registered Successfully.");
                                    break;
                                case 2:
                                    choiceValid = true;
                                    MiddleSchool middleStudent = new MiddleSchool();
                                    middleStudent = middleStudent.insertStudent(studentGrading.gradeSubjects);
                                    studentDetails.Add(middleStudent);
                                    Console.WriteLine("\nStudent Registered Successfully.");
                                    break;
                                case 3:
                                    choiceValid = true;
                                    HighSchool highStudent = new HighSchool();
                                    highStudent = highStudent.insertStudent(studentGrading.gradeSubjects);
                                    studentDetails.Add(highStudent);
                                    Console.WriteLine("\nStudent Registered Successfully.");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Input!");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine(" ==========================");
                        Console.WriteLine("| View Registered Students |");
                        Console.WriteLine(" ==========================");
                        Console.WriteLine();
                        Student s = new Student();
                        foreach (var student in studentDetails)
                        {
                            student.displayStudent();
                            Console.WriteLine();
                        }
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