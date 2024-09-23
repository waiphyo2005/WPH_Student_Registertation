using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testing
{
    public class Student
    {
        public string name { get; private set; }
        public DateTime birthday { get; private set; }
        public int age { get; private set; }
        public string grade { get; private set; }
        public string result { get; protected set; }

        public Student()
        {
            name = string.Empty;
            birthday = DateTime.MinValue;
            age = 0;
            grade = string.Empty;
        }
        protected virtual void getStudentInfo(string studGrade, List<string> subjects)
        {
            name = askName();
            (birthday, age) = askBirthday();
            grade = studGrade;
        }
        private string askName()
        {
            string phrase = @"^[a-zA-Z ]+$";
            Console.Write("\nEnter Student's Name: ");
            string studentName = Console.ReadLine();
            bool nameValid = Regex.IsMatch(studentName, phrase);

            while (!nameValid)
            {
                Console.WriteLine("\nInvalid Input! Please insert a proper name!\n");
                Console.Write("Enter Student's Name: ");
                studentName = Console.ReadLine();
                nameValid = Regex.IsMatch(studentName, phrase);
            }
            return studentName;
        }
        private (DateTime, int) askBirthday()
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
        public virtual void displayStudent()
        {
            Console.WriteLine($"Student Name: {name}");
            Console.WriteLine($"Student Grade: {grade}");
            Console.WriteLine($"Student Birthday: {birthday.ToShortDateString()}");
            Console.WriteLine($"Student Age: {age}");
        }
    }

    //ELEMENTARY SCHOOL STUDENTS
    public class ElementarySchool : Student
    {

        public Dictionary<string, string> marks { get; private set; }
        public ElementarySchool() : base()
        {
            marks = new Dictionary<string, string>();
            result = string.Empty;
        }
        public ElementarySchool insertStudent(Dictionary<string, List<string>> gradeSubjects)
        {
            bool validGrade = false;
            ElementarySchool eStudent = new ElementarySchool();
            while (!validGrade)
            {
                Console.WriteLine("\nPlease choose Elementary School Student's Grade:\n1.Grade 1\n2.Grade 2\n3.Grade 3\n4.Grade 4");
                int grade = Convert.ToInt32(Console.ReadLine());
                switch (grade)
                {
                    case 1:
                        validGrade = true;
                        eStudent.getStudentInfo("1", gradeSubjects["1"]);
                        break;
                    case 2:

                        validGrade = true;
                        eStudent.getStudentInfo("2", gradeSubjects["2"]);
                        break;
                    case 3:

                        validGrade = true;
                        eStudent.getStudentInfo("3", gradeSubjects["3"]);
                        break;
                    case 4:

                        validGrade = true;
                        eStudent.getStudentInfo("4", gradeSubjects["4"]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                }
            }
            return eStudent;
        }
        protected override void getStudentInfo(string studGrade, List<string> subjects)
        {
            base.getStudentInfo(studGrade, subjects);
            marks = askMarks(studGrade, subjects);
            result = checkResult(marks);
        }
        private Dictionary<string, string> askMarks(string studGrade, List<string> subjects)
        {
            Dictionary<string, string> studMarks = new Dictionary<string, string>();
            for (int i = 0; i < subjects.Count; i++)
            {
                bool validMarks = false;
                string sMarks;
                while (!validMarks)
                {
                    Console.Write($"Insert marks for {subjects[i]}(\"Pass\" or \"Fail\"): ");
                    sMarks = Console.ReadLine();
                    if (sMarks == "Pass" || sMarks == "Fail")
                    {
                        validMarks = true;
                        studMarks.Add(subjects[i], sMarks);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (\"Pass\" or \"Fail\")!\n");
                    }
                }
            }
            return studMarks;
        }
        private string checkResult(Dictionary<string, string> studMarks)
        {
            string studResults;
            foreach (var mark in studMarks.Values)
            {
                if (mark == "Fail")
                {
                    studResults = "Fail";
                    return studResults;
                }
            }
            studResults = "Pass";
            return studResults;
        }
        public override void displayStudent()
        {
            base.displayStudent();
            foreach (var subject in marks)
            {
                Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
            }
            Console.WriteLine($"Student Results: {result}");
        }
    }

    //MIDDLE SCHOOL STUDENTS
    public class MiddleSchool : Student
    {
        public Dictionary<string, char> marks { get; private set; }
        public MiddleSchool() : base()
        {
            marks = new Dictionary<string, char>();
            result = string.Empty;
        }
        public MiddleSchool insertStudent(Dictionary<string, List<string>> gradeSubjects)
        {
            bool validGrade = false;
            MiddleSchool mStudent = new MiddleSchool();
            while (!validGrade)
            {
                Console.WriteLine("\nPlease choose Middle School Student's Grade:\n1.Grade 5\n2.Grade 6\n3.Grade 7\n4.Grade 8");
                int grade = Convert.ToInt32(Console.ReadLine());
                switch (grade)
                {
                    case 1:
                        validGrade = true;
                        mStudent.getStudentInfo("5", gradeSubjects["5"]);
                        break;
                    case 2:

                        validGrade = true;
                        mStudent.getStudentInfo("6", gradeSubjects["6"]);
                        break;
                    case 3:

                        validGrade = true;
                        mStudent.getStudentInfo("7", gradeSubjects["7"]);
                        break;
                    case 4:

                        validGrade = true;
                        mStudent.getStudentInfo("8", gradeSubjects["8"]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                }
            }
            return mStudent;
        }
        protected override void getStudentInfo(string studGrade, List<string> subjects)
        {
            base.getStudentInfo(studGrade, subjects);
            marks = askMarks(studGrade, subjects);
            result = checkResult(marks);
        }
        private Dictionary<string, char> askMarks(string studGrade, List<string> subjects)
        {
            Dictionary<string, char> studMarks = new Dictionary<string, char>();
            for (int i = 0; i < subjects.Count; i++)
            {
                bool validMarks = false;
                char sMarks;
                while (!validMarks)
                {
                    Console.Write($"Insert marks for {subjects[i]}(\"A\", \"B\", \"C\", \"D\", \"F\"): ");
                    sMarks = Convert.ToChar(Console.ReadLine());
                    if (sMarks == 'A' || sMarks == 'B' || sMarks == 'C' || sMarks == 'D' || sMarks == 'F')
                    {
                        validMarks = true;
                        studMarks.Add(subjects[i], sMarks);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (\"Pass\" or \"Fail\")!\n");
                    }
                }
            }
            return studMarks;
        }
        private string checkResult(Dictionary<string, char> studMarks)
        {
            string studResults;
            foreach (var mark in studMarks.Values)
            {
                if (mark == 'F')
                {
                    studResults = "Fail";
                    return studResults;
                }
            }
            studResults = "Pass";
            return studResults;
        }
        public override void displayStudent()
        {
            base.displayStudent();
            foreach (var subject in marks)
            {
                Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
            }
            Console.WriteLine($"Student Results: {result}");
        }
    }

    //HIGH SCHOOL STUDENTS
    public class HighSchool : Student
    {
        public Dictionary<string, double> marks { get; private set; }
        public double totalMarks { get; private set; }
        public int distinctions { get; private set; }

        public HighSchool() : base()
        {
            marks = new Dictionary<string, double>();
            result = string.Empty;
            totalMarks = 0;
            distinctions = 0;
        }
        public HighSchool insertStudent(Dictionary<string, List<string>> gradeSubjects)
        {
            bool validGrade = false;
            HighSchool hStudent = new HighSchool();
            while (!validGrade)
            {
                Console.WriteLine("\nPlease choose High School Student's Grade: \n1.Grade 9 (Science)\n2.Grade 9 (Arts)\n3.Grade 10 (Science)\n4.Grade 10 (Arts)");
                int grade = Convert.ToInt32(Console.ReadLine());
                switch (grade)
                {
                    case 1:
                        validGrade = true;
                        hStudent.getStudentInfo("9S", gradeSubjects["9S"]);
                        break;
                    case 2:

                        validGrade = true;
                        hStudent.getStudentInfo("9A", gradeSubjects["9A"]);
                        break;
                    case 3:

                        validGrade = true;
                        hStudent.getStudentInfo("10S", gradeSubjects["10S"]);
                        break;
                    case 4:

                        validGrade = true;
                        hStudent.getStudentInfo("10A", gradeSubjects["10A"]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                }
            }
            return hStudent;
        }
        protected override void getStudentInfo(string studGrade, List<string> subjects)
        {
            base.getStudentInfo(studGrade, subjects);
            marks = askMarks(studGrade, subjects);
            result = checkResult(marks);
            totalMarks = calculateTotalMarks(marks);
            distinctions = countDistinctions(marks);

        }
        private Dictionary<string, double> askMarks(string studGrade, List<string> subjects)
        {
            Dictionary<string, double> studMarks = new Dictionary<string, double>();
            for (int i = 0; i < subjects.Count; i++)
            {
                bool validMarks = false;
                double sMarks;
                while (!validMarks)
                {
                    Console.Write($"Insert marks for {subjects[i]}(0 - 100): ");
                    sMarks = Convert.ToDouble(Console.ReadLine());
                    if (sMarks >= 0 || sMarks <= 100)
                    {
                        validMarks = true;
                        studMarks.Add(subjects[i], sMarks);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (0 - 100)!\n");
                    }
                }
            }
            return studMarks;
        }
        private string checkResult(Dictionary<string, double> studMarks)
        {
            string studResults;
            foreach (var mark in studMarks.Values)
            {
                if (mark < 40)
                {
                    studResults = "Fail";
                    return studResults;
                }
            }
            studResults = "Pass";
            return studResults;
        }
        private double calculateTotalMarks(Dictionary<string, double> studMarks)
        {
            double studTotalMarks = studMarks.Values.Sum();
            return studTotalMarks;
        }
        private int countDistinctions(Dictionary<string, double> studMarks)
        {
            int studDistinctions = 0;
            foreach (var mark in studMarks.Values)
            {
                if (mark < 40)
                {
                    studDistinctions = 0;
                    break;
                }
                else if (mark < 80)
                {
                    studDistinctions++;
                }
            }
            return studDistinctions;
        }
        public override void displayStudent()
        {
            base.displayStudent();
            foreach (var subject in marks)
            {
                Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
            }
            Console.WriteLine($"Student Results: {result}");
            Console.WriteLine($"Student Total Marks: {totalMarks}");
            Console.WriteLine($"Student Distinctions: {distinctions}");
        }
    }
}
