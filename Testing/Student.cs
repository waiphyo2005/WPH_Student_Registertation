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
                }
                else
                {
                    isNameValid = true;
                }
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
}
