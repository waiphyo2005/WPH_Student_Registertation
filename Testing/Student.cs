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
        public (DateTime bday, int stuage) askBirthday()
        {
            //birthday
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
    }
}
