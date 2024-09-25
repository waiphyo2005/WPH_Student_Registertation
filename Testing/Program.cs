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
            List<Student> StudentDetails = new List<Student>();
            StudentGrading StudentGrading = new StudentGrading();
            StudentGrading.SubjectGrading();

            Console.WriteLine("============================================");
            Console.WriteLine("|| Welcome to Student Registration System ||");
            Console.WriteLine("============================================");
            Console.WriteLine();
            bool isEnding = false;
            while (!isEnding)
            {
                try
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
                            bool isValidChoice = false;
                            while (!isValidChoice)
                            {
                                try
                                {
                                    Console.WriteLine("\nPlease select the standard that you want to register:\n1.Elimentary School\n2.Middle School\n3.High School");
                                    int choice = Convert.ToInt32(Console.ReadLine());

                                    switch (choice)
                                    {
                                        case 1:
                                            isValidChoice = true;
                                            StudentDetails.Add(ElementarySchool.InsertStudent(StudentGrading.gradeSubjects));
                                            Console.WriteLine("\nStudent Registered Successfully.");
                                            break;
                                        case 2:
                                            isValidChoice = true;
                                            StudentDetails.Add(MiddleSchool.InsertStudent(StudentGrading.gradeSubjects));
                                            Console.WriteLine("\nStudent Registered Successfully.");
                                            break;
                                        case 3:
                                            isValidChoice = true;
                                            StudentDetails.Add(HighSchool.InsertStudent(StudentGrading.gradeSubjects));
                                            Console.WriteLine("\nStudent Registered Successfully.");
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Input!");
                                            break;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid Input!");
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.WriteLine(" ==========================");
                            Console.WriteLine("| View Registered Students |");
                            Console.WriteLine(" ==========================");
                            Console.WriteLine();
                            if (StudentDetails.Count == 0)
                            {
                                Console.WriteLine("There is no registered students!");
                            }
                            foreach (Student student in StudentDetails)
                            {
                                student.DisplayStudent();
                                Console.WriteLine();
                            }
                            break;
                        case 3:
                            isEnding = true;
                            Console.WriteLine("Thank you for using the system!");
                            break;
                        default:
                            Console.WriteLine("Invalid Input!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
        }
    }
}