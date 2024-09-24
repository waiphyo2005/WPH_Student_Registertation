using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class ElementarySchool : Student
    {
        public Dictionary<string, string> Marks { get; private set; }
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
}
