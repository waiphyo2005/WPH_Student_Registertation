using System;
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
        public virtual int countDistinctions()
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
        public Student insertStudent(Dictionary<string, List<string>> gradeSubjects)
        {
            char field;
            bool validGrade = false;
            Student student = new Student();
            while (!validGrade)
            {
                Console.Write("Please insert Student's Grade Number: ");
                int grade = Convert.ToInt32(Console.ReadLine());
                switch (grade)
                {
                    case 1:
                        validGrade = true;
                        student.getStudentInfo("1", gradeSubjects["1"]);
                        break;
                    case 2:
                        validGrade = true;
                        student.getStudentInfo("2", gradeSubjects["2"]);
                        break;
                    case 3:
                        validGrade = true;
                        student.getStudentInfo("3", gradeSubjects["3"]);
                        break;
                    case 4:
                        validGrade = true;
                        student.getStudentInfo("4", gradeSubjects["4"]);
                        break;
                    case 5:
                        validGrade = true;
                        student.getStudentInfo("5", gradeSubjects["5"]);
                        break;
                    case 6:
                        validGrade = true;
                        student.getStudentInfo("6", gradeSubjects["6"]);
                        break;
                    case 7:
                        validGrade = true;
                        student.getStudentInfo("7", gradeSubjects["7"]);
                        break;
                    case 8:
                        validGrade = true;
                        student.getStudentInfo("8", gradeSubjects["8"]);
                        break;
                    case 9:
                        validGrade = true;
                        Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                        field = Convert.ToChar(Console.ReadLine());
                        if (field == 'B')
                        {
                            validGrade = true;
                            student.getStudentInfo("9B", gradeSubjects["9B"]);
                            break;
                        }
                        else if (field == 'E')
                        {
                            validGrade = true;
                            student.getStudentInfo("9E", gradeSubjects["9E"]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input!\n");
                            validGrade= false;
                            break;
                        }
                    case 10:
                        Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                        field = Convert.ToChar(Console.ReadLine());
                        if (field == 'B')
                        {
                            validGrade = true;
                            student.getStudentInfo("10B", gradeSubjects["10B"]);
                            break;
                        }
                        else if (field == 'E')
                        {
                            validGrade = true;
                            student.getStudentInfo("10E", gradeSubjects["10E"]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!");
                            validGrade = false;
                            break;
                        }
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        validGrade = false;
                        break;
                }
            }
            return student;
        }
        public void displayStudent(List<Student> details)
        {
            bool validOption = false;
            while (!validOption)
            {
                Console.WriteLine("1.View All Students\n2.Filter by Grades");
                Console.Write("Please select the option: ");
                int viewOption = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Student sView = new Student();
                switch (viewOption)
                {
                    case 1:
                        validOption = true;
                        if (details.Count == 0)
                        {
                            Console.WriteLine("There is no student registered!");
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine(" =========================");
                        Console.WriteLine("| All Registered Students |");
                        Console.WriteLine(" =========================");
                        Console.WriteLine();
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
                        validOption = true;
                        char filterField;
                        Console.Write("Please insert the grade that you want to see: ");
                        int filterGrade = Convert.ToInt32(Console.ReadLine());
                        switch (filterGrade)
                        {
                            case 1:
                                sView.viewStudents(details, "1");
                                break;
                            case 2:
                                sView.viewStudents(details, "2");
                                break;
                            case 3:
                                sView.viewStudents(details, "3");
                                break;
                            case 4:
                                sView.viewStudents(details, "4");
                                break;
                            case 5:
                                sView.viewStudents(details, "5");
                                break;
                            case 6:
                                sView.viewStudents(details, "6");
                                break;
                            case 7:
                                sView.viewStudents(details, "7");
                                break;
                            case 8:
                                sView.viewStudents(details, "8");
                                break;
                            case 9:
                                Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                                filterField = Convert.ToChar(Console.ReadLine());
                                if (filterField == 'B')
                                {
                                    sView.viewStudents(details, "9B");
                                    break;
                                }
                                else if (filterField == 'E')
                                {
                                    sView.viewStudents(details, "9E");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Input!\n");
                                    validOption = false;
                                    break;
                                }
                            case 10:
                                Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                                filterField = Convert.ToChar(Console.ReadLine());
                                if (filterField == 'B')
                                {
                                    sView.viewStudents(details, "10B");
                                    break;
                                }
                                else if (filterField == 'E')
                                {
                                    sView.viewStudents(details, "10E");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Input!\n");
                                    validOption = false;
                                    break;
                                }
                            default:
                                Console.WriteLine("\nInvalid Input!\n");
                                validOption = false;
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        validOption = false;
                        break;
                }
            }
        }
        public void viewStudents(List<Student> sDetails, string studentGradeFilter)
        {
            List<Student> filteredStudents = new List<Student>();
            
            foreach (Student student in sDetails)
            {
                if (student.grade == studentGradeFilter)
                {
                    filteredStudents.Add(student);
                }
            }
            Console.WriteLine();
            Console.Write(string.Format("{0,-20} {1,-12} {2,-5} {3,-7}", "Name", "Birthday", "Age", "Grade"));
            foreach (var subject in filteredStudents[0].marks.Keys)
            {
                Console.Write($"{subject,-16}");
            }
            Console.WriteLine(string.Format("{0,-12} {1,-8} {2,-14}", "Total Marks", "Results", "Distinctions"));
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
    public class Primary: Student
    {
        public override 
    }
}
