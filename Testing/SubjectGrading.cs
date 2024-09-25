using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class StudentGrading
    {
        public Dictionary<string, List<string>> gradeSubjects { get; private set; }
        public StudentGrading()
        {
            gradeSubjects = new Dictionary<string, List<string>>();
        }
        public void SubjectGrading()
        {
            gradeSubjects.Add("1", new List<string> { "Myanmar", "English" });
            gradeSubjects.Add("2", new List<string> { "Myanmar", "English", "Maths" });
            gradeSubjects.Add("3", new List<string> { "Myanmar", "English", "Maths", "Science" });
            gradeSubjects.Add("4", new List<string> { "Myanmar", "English", "Maths", "Science" });
            gradeSubjects.Add("5", new List<string> { "Myanmar", "English", "Maths", "Science", "Social Studies" });
            gradeSubjects.Add("6", new List<string> { "Myanmar", "English", "Maths", "Science", "Geography", "History" });
            gradeSubjects.Add("7", new List<string> { "Myanmar", "English", "Maths", "Science", "Geography", "History" });
            gradeSubjects.Add("8", new List<string> { "Myanmar", "English", "Maths", "Science", "Geography", "History" });
            gradeSubjects.Add("9S", new List<string> { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" });
            gradeSubjects.Add("9A", new List<string> { "Myanmar", "English", "Maths", "Geography", "History", "Economics" });
            gradeSubjects.Add("10S", new List<string> { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" });
            gradeSubjects.Add("10A", new List<string> { "Myanmar", "English", "Maths", "Geography", "History", "Economics" });
        }
    }
}
