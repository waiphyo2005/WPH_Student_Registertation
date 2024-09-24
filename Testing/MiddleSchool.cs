using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class MiddleSchool : Student
    {
        public Dictionary<string, char> Marks { get; private set; }
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
                    char insertMarks = Convert.ToChar(Console.ReadLine());
                    sMarks = char.ToUpper(insertMarks);
                    if (sMarks == 'A' || sMarks == 'B' || sMarks == 'C' || sMarks == 'D' || sMarks == 'F')
                    {
                        isMarksValid = true;
                        studMarks.Add(subjects[i], sMarks);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (\"A\", \"B\", \"C\", \"D\", \"F\")!\n");
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
}
