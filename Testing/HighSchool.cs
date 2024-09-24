using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class HighSchool : Student
    {
        public Dictionary<string, double> Marks { get; private set; }
        public double TotalMarks { get; private set; }
        public int Distinctions { get; private set; }
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
