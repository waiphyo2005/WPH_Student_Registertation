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
        public string Name { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public int age { get; protected set; }
        public string grade { get; protected set; }
        //public Dictionary<string, double> marks { get; private set; }
        //public double totalMarks { get; private set; }
        //public int distinctions { get; protected set; }
        public string result { get; protected set; }
        //public double findTotalMarks()
        //{
        //    totalMarks = marks.Values.Sum();
        //    return totalMarks;
        //}
        //public virtual string resultCheck()
        //{
        //    foreach (var mark in marks.Values)
        //    {
        //        if (mark < 40)
        //        {
        //            result = "Fail";
        //            return result;
        //        }
        //    }
        //    result = "Pass";
        //    return result;
        //}
        //public int countDistinctions()
        //{
        //    if (result == "Fail")
        //    {
        //        distinctions = 0;
        //        return distinctions;
        //    }
        //    else
        //    {
        //        distinctions = 0;

        //        foreach (var mark in marks.Values)
        //        {
        //            if (mark > 80)
        //            {
        //                distinctions++;
        //            }
        //        }
        //        return distinctions;
        //    }
        //}
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
        public Student()
        {
            Name = null;
            Birthday = DateTime.MinValue;
            age = 0;
            grade = null;
        }
        public Student(string studName, DateTime studBirthday, int studAge, string studgrade)
        {
            Name = studName;
            Birthday = studBirthday;
            age = studAge;
            grade = studgrade;
        }
        public virtual void getStudentInfo(string studGrade, List<string> subjects)
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

            Student student = new Student(studentName, bday, stuage, studGrade);
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
                                Student sP1 = new Primary();
                                sP1.viewStudents(details, "1");
                                break;
                            case 2:
                                Student sP2 = new Primary();
                                sP2.viewStudents(details, "2");
                                break;
                            case 3:
                                Student sP3 = new Primary();
                                sP3.viewStudents(details, "3");
                                break;
                            case 4:
                                Student sP4 = new Primary();
                                sP4.viewStudents(details, "4");
                                break;
                            case 5:
                                Student sP5 = new Secondary();
                                sP5.viewStudents(details, "5");
                                break;
                            case 6:
                                Student sP6 = new Secondary();
                                sP6.viewStudents(details, "6");
                                break;
                            case 7:
                                Student sP7 = new Secondary();
                                sP7.viewStudents(details, "7");
                                break;
                            case 8:
                                Student sP8 = new Secondary();
                                sP8.viewStudents(details, "8");
                                break;
                            case 9:
                                Console.WriteLine("Choose Biology or Economics by inserting B/E: ");
                                filterField = Convert.ToChar(Console.ReadLine());
                                if (filterField == 'B')
                                {
                                    Student sP9B = new HighSchool();
                                    sP9B.viewStudents(details, "9B");
                                    break;
                                }
                                else if (filterField == 'E')
                                {
                                    Student sP9E = new HighSchool();
                                    sP9E.viewStudents(details, "9E");
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
                                    Student sP10B = new HighSchool();
                                    sP10B.viewStudents(details, "10B");
                                    break;
                                }
                                else if (filterField == 'E')
                                {
                                    Student sP10E = new HighSchool();
                                    sP10E.viewStudents(details, "10E");
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
        public virtual void viewStudents(List<Student> sDetails, string studentGradeFilter)
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
        public Dictionary <string, string> marks { get; private set; }
        //public override void CreateStudent(string studName, DateTime studBirthday, int studAge, string studgrade, Dictionary<string, string> studmarks)
        //{
        //    Name = studName;
        //    Birthday = studBirthday;
        //    age = studAge;
        //    marks = studmarks;
        //    grade = studgrade;
        //    marks = studmarks;
        //    resultCheck();
        //}
        public Primary(string studName, DateTime studBirthday, int studAge, string studGrade, Dictionary<string, string> studMarks)
        : base(studName, studBirthday, studAge, studGrade)
        {
            marks = studMarks;
            resultCheck();
        }
        public string resultCheck()
        {
            foreach (var mark in marks.Values)
            {
                if (mark == "Fail")
                {
                    result = "Fail";
                    return result;
                }
            }
            result = "Pass";
            return result;
        }
        public override void getStudentInfo(string studGrade, List<string> subjects)
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
            Dictionary<string, string> studentMarks = new Dictionary<string, string>();
            for (int i = 0; i < subjects.Count; i++)
            {
                Console.Write($"Insert marks for {subjects[i]}(Pass or Fail): ");
                string sMarks = Console.ReadLine();
                while (sMarks != "Pass" || sMarks != "Fail")
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {subjects[i]}: ");
                    sMarks = Console.ReadLine();
                }
                studentMarks.Add(subjects[i], sMarks);
            }
            CreateStudent(studentName, bday, stuage, studGrade, studentMarks);
        }
        public override void viewStudents(List<Student> sDetails, string studentGradeFilter)
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
            Console.WriteLine(string.Format("{0,-8}", "Results"));
            if (filteredStudents.Count > 0)
            {
                foreach (Student student in filteredStudents)
                {
                    Console.Write($"{student.Name,-20} {student.Birthday.ToShortDateString(),-12} {student.age,-5} {student.grade,-7}");
                    Console.WriteLine($"{student.result,-8}");
                }
            }
            else
            {
                Console.WriteLine("There is no registered students in this grade!");
            }
        }
    }
    public class Secondary : Student
    {
        public Dictionary<string, char> marks { get; private set; }
        public override void CreateStudent(string studName, DateTime studBirthday, int studAge, string studgrade, Dictionary<string, char> studmarks)
        {
            Name = studName;
            Birthday = studBirthday;
            age = studAge;
            marks = studmarks;
            grade = studgrade;
            marks = studmarks;
            resultCheck();
        }
        public string resultCheck()
        {
            foreach (var mark in marks.Values)
            {
                if (mark == 'F')
                {
                    result = "Fail";
                    return result;
                }
            }
            result = "Pass";
            return result;
        }
        public override void getStudentInfo(string studGrade, List<string> subjects)
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
            Dictionary<string, char> studentMarks = new Dictionary<string, char>();
            for (int i = 0; i < subjects.Count; i++)
            {
                Console.Write($"Insert marks for {subjects[i]}(A, B, C, D, F): ");
                char sMarks = Convert.ToChar(Console.ReadLine());
                while (sMarks != 'A' || sMarks != 'B' || sMarks != 'C' || sMarks != 'D' || sMarks != 'F')
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {subjects[i]}: ");
                    sMarks = Convert.ToChar(Console.ReadLine());
                }
                studentMarks.Add(subjects[i], sMarks);
            }
            CreateStudent(studentName, bday, stuage, studGrade, studentMarks);
        }
        public override void viewStudents(List<Student> sDetails, string studentGradeFilter)
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
            Console.WriteLine(string.Format("{0,-8} {1,-14}", "Results", "Distinctions"));
            if (filteredStudents.Count > 0)
            {
                foreach (Student student in filteredStudents)
                {
                    Console.Write($"{student.Name,-20} {student.Birthday.ToShortDateString(),-12} {student.age,-5} {student.grade,-7}");
                    Console.WriteLine($"{student.result,-8} {student.distinctions,-14}");
                }
            }
            else
            {
                Console.WriteLine("There is no registered students in this grade!");
            }
        }
    }
    public class HighSchool : Student
    {
        public virtual void viewStudents(List<Student> sDetails, string studentGradeFilter)
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
}
