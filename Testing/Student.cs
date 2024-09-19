﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TEST
{
    public class Student
    {
        StudentGrading studentGrading = new StudentGrading();
        Student student = new Student();
        
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public int age { get; private set; }
        public string grade { get; private set; }
        public Dictionary<string, double> marks { get; private set; }
        public double totalMarks { get; private set; }
        public int distinctions { get; private set; }
        public string result { get; private set; }
        public double findTotalMarks()
        {
            totalMarks = marks.Values.Sum();
            return totalMarks;
        }
        public string resultCheck()
        {
            foreach (var mark in marks.Values)
            {
                if (mark < 40)
                {
                    result = "Fail";
                    return result;
                }
            }
            result = "Pass";
            return result;
        }
        public int countDistinctions()
        {
            if (result == "Fail")
            {
                distinctions = 0;
                return distinctions;
            }
            else
            {
                distinctions = 0;

                foreach (var mark in marks.Values)
                {
                    if (mark > 80)
                    {
                        distinctions++;
                    }
                }
                return distinctions;
            }
        }
        public (DateTime bday, int stuage) askBirthday()
        {
            int stuage = 0;
            bool ageValid = true;
            DateTime bday = DateTime.Now;
            do
            {
                string datepattern = @"^(0[1-9]|1[0-2])/([0-2][0-9]|3[01])/\d{4}$";
                Console.Write("Enter Student's Birthday(MM/DD/YYYY): ");
                string studentBirthday = Console.ReadLine();
                bool bdayValid = Regex.IsMatch(studentBirthday, datepattern);
                while (!bdayValid)
                {
                    Console.WriteLine("Incorrect Format or Invalid Birthday! Please insert again!");
                    Console.Write("Enter Student's Birthday(MM/DD/YYYY): ");
                    studentBirthday = Console.ReadLine();
                    bdayValid = Regex.IsMatch(studentBirthday, datepattern);
                }
                DateTime sBday = DateTime.Parse(studentBirthday);
                int sAge = DateTime.Now.Year - sBday.Year;
                if (sAge < 5 || sAge > 120)
                {
                    Console.WriteLine("Invalid Birthday");
                    ageValid = false;
                }
                else
                {
                    ageValid = true;
                    stuage = sAge;
                    bday = sBday;
                }
            } while (!ageValid);
            return (bday, stuage);
        }
        public void CreateStudent(string studName, DateTime studBirthday, int studAge, string studgrade, Dictionary<string, double> studmarks)
        {
            Name = studName;
            Birthday = studBirthday;
            age = studAge;
            marks = studmarks;
            grade = studgrade;
            findTotalMarks();
            resultCheck();
            countDistinctions();
        }

        public void getStudentInfo(string studGrade, List<string> subjects)
        {
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
            (DateTime bday, int stuage) = askBirthday();

            //marks
            Dictionary<string, double> studentMarks = new Dictionary<string, double>();
            for (int i = 0; i < subjects.Count; i++)
            {
                Console.Write($"Insert marks for {subjects[i]}: ");
                double sMarks = Convert.ToDouble(Console.ReadLine());
                while (sMarks < 0 || sMarks > 100)
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {subjects[i]}: ");
                    sMarks = Convert.ToDouble(Console.ReadLine());
                }
                studentMarks.Add(subjects[i], sMarks);
            }
            CreateStudent(studentName, bday, stuage, studGrade, studentMarks);
        }
        public Student insertStudent()
        {
            studentGrading.SubjectGrading();
            char field;
            Console.Write("Please insert Student's Grade Number: ");
            int grade = Convert.ToInt32(Console.ReadLine());

            switch (grade)
            {
                case 1:
                    student.getStudentInfo("1", studentGrading.gradeSubjects["1"]);
                    return student;
                case 2:
                    student.getStudentInfo("2", studentGrading.gradeSubjects["2"]);
                    return student;
                case 3:
                    student.getStudentInfo("3", studentGrading.gradeSubjects["3"]);
                    return student;
                case 4:
                    student.getStudentInfo("4", studentGrading.gradeSubjects["4"]);
                    return student;
                case 5:
                    student.getStudentInfo("5", studentGrading.gradeSubjects["5"]);
                    return student;
                case 6:
                    student.getStudentInfo("6", studentGrading.gradeSubjects["6"]);
                    return student;
                case 7:
                    student.getStudentInfo("7", studentGrading.gradeSubjects["7"]);
                    return student;
                case 8:
                    student.getStudentInfo("8", studentGrading.gradeSubjects["8"]);
                    return student;
                case 9:
                    Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                    field = Convert.ToChar(Console.ReadLine());
                    if (field == 'B')
                    {
                        student.getStudentInfo("9B", studentGrading.gradeSubjects["9B"]);
                        return student;
                    }
                    else if (field == 'E')
                    {
                        student.getStudentInfo("9E", studentGrading.gradeSubjects["9E"]);
                        return student;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                        student.insertStudent();
                        return student;
                    }
                case 10:
                    Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                    field = Convert.ToChar(Console.ReadLine());
                    if (field == 'B')
                    {
                        student.getStudentInfo("10B", studentGrading.gradeSubjects["10B"]);
                        return student;
                    }
                    else if (field == 'E')
                    {
                        student.getStudentInfo("10E", studentGrading.gradeSubjects["10E"]);
                        return student;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                        insertStudent();
                        return student;
                    }
                default:
                    Console.WriteLine("Invalid Input!");
                    insertStudent();
                    return student;
            }
        }
        public void displayStudent(List<Student> details)
        {
            Console.WriteLine("1.View All Students\n2.Filter by Grades");
            Console.Write("Please select the option: ");
            int viewOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (viewOption)
            {
                case 1:
                    foreach (Student student in details)
                    {
                        Console.WriteLine($"Student Name: {student.Name}");
                        Console.WriteLine($"Student Grade: {student.grade}");
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
                    break;
                case 2:
                    char filterField;
                    Console.Write("Please insert the grade that you want to see: ");
                    int filterGrade = Convert.ToInt32(Console.ReadLine());
                    switch (filterGrade)
                    {
                        case 1:
                            student.viewStudents(details,"1");
                            break;
                        case 2:
                            student.viewStudents(details, "2");
                            break;
                        case 3:
                            student.viewStudents(details, "3");
                            break;
                        case 4:
                            student.viewStudents(details, "4");
                            break;
                        case 5:
                            student.viewStudents(details, "5");
                            break;
                        case 6:
                            student.viewStudents(details, "6");
                            break;
                        case 7:
                            student.viewStudents(details, "7");
                            break;
                        case 8:
                            student.viewStudents(details, "8");
                            break;
                        case 9:
                            Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                            filterField = Convert.ToChar(Console.ReadLine());
                            if (filterField == 'B')
                            {
                                student.viewStudents(details, "9B");
                                break;
                            }
                            else if (filterField == 'E')
                            {
                                student.viewStudents(details, "9E");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input!");
                                displayStudent(details);
                                break;
                            }
                        case 10:
                            Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                            filterField = Convert.ToChar(Console.ReadLine());
                            if (filterField == 'B')
                            {
                                student.viewStudents(details, "10B");
                                break;
                            }
                            else if (filterField == 'E')
                            {
                                student.viewStudents(details, "10E");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input!");
                                displayStudent(details);
                                break;
                            }
                    }
                    break;
            }
        }
        public void viewStudents(List<Student> sDetails, string studentGradeFilter)
        {
            List<Student> filteredStudents = new List<Student>();
            Console.Write(string.Format("{0,-20} {1,-12} {2,-5} {3,-7}", "Name", "Birthday", "Age", "Grade"));
            foreach (var subject in studentGrading.gradeSubjects[studentGradeFilter])
            {
                Console.Write($"{subject,-16}");
            }
            Console.WriteLine(string.Format("{0,-12} {1,-8} {2,-14}", "Total Marks", "Results", "Distinctions"));
            foreach (Student student in sDetails)
            {
                if (student.grade == studentGradeFilter)
                {

                    filteredStudents.Add(student);
                }
            }
            if (filteredStudents.Count > 0)
            {
                foreach (Student student in filteredStudents)
                {
                    Console.Write($"{student.Name,-20} {student.Birthday.ToShortDateString(),-12} {student.age,-5} {student.grade,-7}");
                    foreach (double mark in student.marks.Values)
                    {
                        Console.Write($"{mark,-16}");
                    }
                    Console.WriteLine($"{student.totalMarks,-12} {student.result,-8} {student.distinctions,-14}");
                }
            }
            else
            {
                Console.WriteLine("There is no registered students in this grade!");
            }
        }
    }
}
