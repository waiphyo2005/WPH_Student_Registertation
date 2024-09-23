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
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public int Age { get; private set; }
        public string Grade { get; private set; }
        public string Result { get; protected set; }

        public Student()
        {
            Name = null;
            Birthday = DateTime.MinValue;
            Age = 0;
            Grade = null;
        }
        protected virtual void GetStudentInfo(string studGrade, List<string> subjects)
        {
            Name = AskName();
            (Birthday, Age) = AskBirthday();
            Grade = studGrade;
        }
        private string AskName()
        {
            bool isNameValid = false;
            string studentName = null;
            while (!isNameValid)
            {
                string phrase = @"^[a-zA-Z ]+$";
                Console.Write("\nEnter Student's Name: ");
                studentName = Console.ReadLine();
                bool checkName = Regex.IsMatch(studentName, phrase);
                if (checkName == false)
                {
                    Console.WriteLine("\nInvalid Input! Please insert a proper name!\n");
                    break;
                }
                isNameValid = true;
            }
            return studentName;
        }
        private (DateTime, int) AskBirthday()
        {
            int studentAge = 0;
            bool isAgeValid = false;
            DateTime studentBirthday = DateTime.Now;
            while (!isAgeValid)
            {
                bool isBirthdayInputValid = false;
                while (!isBirthdayInputValid)
                {
                    Console.Write("Enter Student's Birthday(MM/DD/YYYY): ");
                    string sBirthday = Console.ReadLine();
                    bool isBirthdayValid = DateTime.TryParse(sBirthday, out studentBirthday);
                    if (isBirthdayValid == true)
                    {
                        isBirthdayInputValid = true;
                        DateTime studBirthday = DateTime.Parse(sBirthday);
                        int studAge = DateTime.Now.Year - studBirthday.Year;
                        if (studAge < 5 || studAge > 120)
                        {
                            Console.WriteLine("Invalid Birthday!");
                        }
                        else
                        {
                            isAgeValid = true;
                            studentAge = studAge;
                            studentBirthday = studBirthday;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Birthday Input Format! Please insert againin this fromat (MM/DD/YYYY)!");
                    }
                }                
            }
            return (studentBirthday, studentAge);
        }
        public virtual void DisplayStudent()
        {
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Student Grade: {Grade}");
            Console.WriteLine($"Student Birthday: {Birthday.ToShortDateString()}");
            Console.WriteLine($"Student Age: {Age}");
        }
    }

    //ELEMENTARY SCHOOL STUDENTS
    public class ElementarySchool : Student
    {

        public Dictionary<string, string> Marks { get; private set; }
        public ElementarySchool() : base()
        {
            Marks = new Dictionary<string, string>();
            Result = null;
        }
        public ElementarySchool InsertStudent(Dictionary<string, List<string>> gradeSubjects)
        {
            bool isGradeValid = false;
            ElementarySchool eStudent = new ElementarySchool();
            while (!isGradeValid)
            {
                Console.WriteLine("\nPlease choose Elementary School Student's Grade:\n1.Grade 1\n2.Grade 2\n3.Grade 3\n4.Grade 4");
                int grade = Convert.ToInt32(Console.ReadLine());
                switch (grade)
                {
                    case 1:
                        isGradeValid = true;
                        eStudent.GetStudentInfo("1", gradeSubjects["1"]);
                        break;
                    case 2:

                        isGradeValid = true;
                        eStudent.GetStudentInfo("2", gradeSubjects["2"]);
                        break;
                    case 3:

                        isGradeValid = true;
                        eStudent.GetStudentInfo("3", gradeSubjects["3"]);
                        break;
                    case 4:

                        isGradeValid = true;
                        eStudent.GetStudentInfo("4", gradeSubjects["4"]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                }
            }
            return eStudent;
        }
        protected override void GetStudentInfo(string studGrade, List<string> subjects)
        {
            base.GetStudentInfo(studGrade, subjects);
            Marks = AskMarks(studGrade, subjects);
            Result = CheckResult(Marks);
        }
        private Dictionary<string, string> AskMarks(string studGrade, List<string> subjects)
        {
            Dictionary<string, string> studMarks = new Dictionary<string, string>();
            for (int i = 0; i < subjects.Count; i++)
            {
                bool isMarksValid = false;
                string sMarks;
                while (!isMarksValid)
                {
                    Console.Write($"Insert marks for {subjects[i]}(\"Pass\" or \"Fail\"): ");
                    sMarks = Console.ReadLine();
                    if (sMarks == "Pass" || sMarks == "Fail")
                    {
                        isMarksValid = true;
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
        private string CheckResult(Dictionary<string, string> studMarks)
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
        public override void DisplayStudent()
        {
            base.DisplayStudent();
            foreach (var subject in Marks)
            {
                Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
            }
            Console.WriteLine($"Student Results: {Result}");
        }
    }

    //MIDDLE SCHOOL STUDENTS
    public class MiddleSchool : Student
    {
        public Dictionary<string, char> Marks { get; private set; }
        public MiddleSchool() : base()
        {
            Marks = new Dictionary<string, char>();
            Result = null;
        }
        public MiddleSchool InsertStudent(Dictionary<string, List<string>> gradeSubjects)
        {
            bool isGradeValid = false;
            MiddleSchool mStudent = new MiddleSchool();
            while (!isGradeValid)
            {
                Console.WriteLine("\nPlease choose Middle School Student's Grade:\n1.Grade 5\n2.Grade 6\n3.Grade 7\n4.Grade 8");
                int grade = Convert.ToInt32(Console.ReadLine());
                switch (grade)
                {
                    case 1:
                        isGradeValid = true;
                        mStudent.GetStudentInfo("5", gradeSubjects["5"]);
                        break;
                    case 2:

                        isGradeValid = true;
                        mStudent.GetStudentInfo("6", gradeSubjects["6"]);
                        break;
                    case 3:
                        isGradeValid = true;
                        mStudent.GetStudentInfo("7", gradeSubjects["7"]);
                        break;
                    case 4:

                        isGradeValid = true;
                        mStudent.GetStudentInfo("8", gradeSubjects["8"]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                }
            }
            return mStudent;
        }
        protected override void GetStudentInfo(string studGrade, List<string> subjects)
        {
            base.GetStudentInfo(studGrade, subjects);
            Marks = AskMarks(studGrade, subjects);
            Result = CheckResult(Marks);
        }
        private Dictionary<string, char> AskMarks(string studGrade, List<string> subjects)
        {
            Dictionary<string, char> studMarks = new Dictionary<string, char>();
            for (int i = 0; i < subjects.Count; i++)
            {
                bool isMarksValid = false;
                char sMarks;
                while (!isMarksValid)
                {
                    Console.Write($"Insert marks for {subjects[i]}(\"A\", \"B\", \"C\", \"D\", \"F\"): ");
                    sMarks = Convert.ToChar(Console.ReadLine());
                    char.ToUpper(sMarks);
                    if (sMarks == 'A' || sMarks == 'B' || sMarks == 'C' || sMarks == 'D' || sMarks == 'F')
                    {
                        isMarksValid = true;
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
        private string CheckResult(Dictionary<string, char> studMarks)
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
        public override void DisplayStudent()
        {
            base.DisplayStudent();
            foreach (var subject in Marks)
            {
                Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
            }
            Console.WriteLine($"Student Results: {Result}");
        }
    }

    //HIGH SCHOOL STUDENTS
    public class HighSchool : Student
    {
        public Dictionary<string, double> Marks { get; private set; }
        public double TotalMarks { get; private set; }
        public int Distinctions { get; private set; }

        public HighSchool() : base()
        {
            Marks = new Dictionary<string, double>();
            Result = null;
            TotalMarks = 0;
            Distinctions = 0;
        }
        public HighSchool InsertStudent(Dictionary<string, List<string>> gradeSubjects)
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
                        hStudent.GetStudentInfo("9S", gradeSubjects["9S"]);
                        break;
                    case 2:

                        validGrade = true;
                        hStudent.GetStudentInfo("9A", gradeSubjects["9A"]);
                        break;
                    case 3:

                        validGrade = true;
                        hStudent.GetStudentInfo("10S", gradeSubjects["10S"]);
                        break;
                    case 4:

                        validGrade = true;
                        hStudent.GetStudentInfo("10A", gradeSubjects["10A"]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                }
            }
            return hStudent;
        }
        protected override void GetStudentInfo(string studGrade, List<string> subjects)
        {
            base.GetStudentInfo(studGrade, subjects);
            Marks = AskMarks(studGrade, subjects);
            Result = CheckResult(Marks);
            TotalMarks = CalculateTotalMarks(Marks);
            Distinctions = CountDistinctions(Marks);

        }
        private Dictionary<string, double> AskMarks(string studGrade, List<string> subjects)
        {
            Dictionary<string, double> studMarks = new Dictionary<string, double>();
            for (int i = 0; i < subjects.Count; i++)
            {
                bool isMarksValid = false;
                double sMarks;
                while (!isMarksValid)
                {
                    Console.Write($"Insert marks for {subjects[i]}(0 - 100): ");
                    sMarks = Convert.ToDouble(Console.ReadLine());
                    if (sMarks >= 0 || sMarks <= 100)
                    {
                        isMarksValid = true;
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
        private string CheckResult(Dictionary<string, double> studMarks)
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
        private double CalculateTotalMarks(Dictionary<string, double> studMarks)
        {
            double studTotalMarks = studMarks.Values.Sum();
            return studTotalMarks;
        }
        private int CountDistinctions(Dictionary<string, double> studMarks)
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
        public override void DisplayStudent()
        {
            base.DisplayStudent();
            foreach (var subject in Marks)
            {
                Console.WriteLine($"Student Marks for {subject.Key}: {subject.Value}");
            }
            Console.WriteLine($"Student Results: {Result}");
            Console.WriteLine($"Student Total Marks: {TotalMarks}");
            Console.WriteLine($"Student Distinctions: {Distinctions}");
        }
    }
}
