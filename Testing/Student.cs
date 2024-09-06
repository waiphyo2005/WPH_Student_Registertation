using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testing
{
    public class Student
    {
        public void insertStudent()
        {
            Console.WriteLine();
            Console.WriteLine(" =======================");
            Console.WriteLine("| Register New Students |");
            Console.WriteLine(" =======================");
            Console.WriteLine();

            Console.Write("Please insert Student's Grade Number: ");
            int grade = Convert.ToInt32(Console.ReadLine());

            Subjects subject = new Subjects();
            StudentDetail studentDetail = new StudentDetail();
            switch (grade)
            {
                case 1:
                    register(1, subject.g1Subjects, StudentDetail.g1Details);
                    break;
                case 2:
                    register(2, subject.g2Subjects, StudentDetail.g2Details);
                    break;
                case 3:
                    register(3, subject.g3Subjects, StudentDetail.g3Details);
                    break;
                case 4:
                    register(4, subject.g4Subjects, StudentDetail.g4Details);
                    break;
                case 5:
                    register(5, subject.g5Subjects, StudentDetail.g5Details);
                    break;
                case 6:
                    register(6, subject.g6Subjects, StudentDetail.g6Details);
                    break;
                case 7:
                    register(7, subject.g7Subjects, StudentDetail.g7Details);
                    break;
                case 8:
                    register(8, subject.g8Subjects, StudentDetail.g8Details);
                    break;
                case 9:
                    register(9, subject.g9Subjects, StudentDetail.g9Details);
                    break;
                case 10:
                    register(10, subject.g10Subjects, StudentDetail.g10Details);
                    break;
                default:
                    Console.WriteLine("\nInvalid Input! Please insert a proper Grade (1 to 10)!\n");
                    insertStudent();
                    break;
            }
        }

        public void register(int studentGrade, List<string> stuSubject, List<List<object>> list)
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
                List<object> personalDetails = new List<object>();
                List<object> allMarks = new List<object>();
                List<object> additional = new List<object>();
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

                personalDetails.Add(name);

                Console.Write("Enter Student's Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                while (age < 5 || age > 120)
                {
                    Console.WriteLine("\nInvalid Input! Please insert a proper age!\n");
                    Console.Write("Enter Student's Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                }

                personalDetails.Add(age);
                personalDetails.Add(studentGrade);

                for (int i = 0; i < stuSubject.Count; i++)
                {

                    Console.Write($"Please Insert the marks of {stuSubject[i]}: ");

                    double marks = Convert.ToDouble(Console.ReadLine());

                    while (marks < 0 || marks > 100)
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                        Console.Write($"Please Insert the marks of {stuSubject[i]}: ");
                        marks = Convert.ToDouble(Console.ReadLine());
                    }

                    allMarks.Add(marks);

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
                additional.Add(totalmarks);

                if (subjStatus.Contains('F'))
                {
                    additional.Add("Fail");
                }
                else
                {
                    additional.Add("Pass");
                }

                for (int i = 0; i < subjStatus.Count; i++)
                {
                    if (subjStatus[i] == 'D')
                    {
                        distinction++;
                    }
                }
                additional.Add(distinction);
                student.AddRange(personalDetails);
                student.AddRange(allMarks);
                student.AddRange(additional);
                list.Add(student);
                Console.WriteLine("\nThe following student record has been created.");
                Console.WriteLine($"Student Name: {personalDetails[0]}");
                Console.WriteLine($"Student Age: {personalDetails[1]}");
                Console.WriteLine($"Student Grade: {personalDetails[2]}");
                for (int i = 0; i < allMarks.Count; i++)
                {
                    Console.WriteLine($"Marks for {stuSubject[i]}: {allMarks[i]} ({subjStatus[i]})");
                }
                Console.WriteLine($"Student Total Marks: {additional[0]}/{stuSubject.Count * 100}");
                Console.WriteLine($"Student Overall Grade: {additional[1]}");
                Console.WriteLine($"Student Total Distinctions: {additional[2]}");
                Console.WriteLine();

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
        }

        public void displayStudents()
        {
            Console.WriteLine();
            Console.WriteLine(" ==========================");
            Console.WriteLine("| View Registered Students |");
            Console.WriteLine(" ==========================");
            Console.WriteLine();
            Console.Write("Please insert the Grade that you want to see the students: ");
            int dGrade = Convert.ToInt32(Console.ReadLine());
            Subjects subject = new Subjects();
            switch (dGrade)
            {
                case 1:

                    showStudents(1, subject.g1Subjects, StudentDetail.g1Details);
                    break;
                case 2:
                    showStudents(2, subject.g2Subjects, StudentDetail.g2Details);
                    break;
                case 3:
                    showStudents(3, subject.g3Subjects, StudentDetail.g3Details);
                    break;
                case 4:
                    showStudents(4, subject.g4Subjects, StudentDetail.g4Details);
                    break;
                case 5:
                    showStudents(5, subject.g5Subjects, StudentDetail.g5Details);
                    break;
                case 6:
                    showStudents(6, subject.g6Subjects, StudentDetail.g6Details);
                    break;
                case 7:
                    showStudents(7, subject.g7Subjects, StudentDetail.g7Details);
                    break;
                case 8:
                    showStudents(8, subject.g8Subjects, StudentDetail.g8Details);
                    break;
                case 9:
                    showStudents(9, subject.g9Subjects, StudentDetail.g9Details);
                    break;
                case 10:
                    showStudents(10, subject.g10Subjects, StudentDetail.g10Details);
                    break;
                default:
                    displayStudents();
                    break;
            }
        }

        public void showStudents(int g, List<string> stusubj, List<List<object>> stulist)
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine($" Registered students for Grade {g}");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.Write(string.Format("{0,-20}{1,-20}{2,-20}", "Name", "Age", "Grade"));

            for (int i = 0; i < stusubj.Count; i++)
            {
                Console.Write(string.Format("{0,-20}", stusubj[i]));
            }

            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Total Marks", "Subject Status", "Total Distinctions"));

            if (stulist.Count == 0)
            {
                Console.WriteLine("\nRecord is Empty!\n");
            }
            else
            {

                foreach (var student in stulist)
                {
                    foreach (var detail in student)
                    {
                        Console.Write(string.Format("{0,-20}", detail));
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
