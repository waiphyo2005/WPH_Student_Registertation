using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testing
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }


    }
    public abstract class Details
    {
        public string id { get; }
        public string name { get; set; }
        public int age { get; set; }
        public int grade { get; set; }
        public double totalMarks { get; set; }
        public bool status { get; }
        public int distinctions { get; set; }
        public abstract void marksCollection();
    }
    public class G1Details: Details
    {
        public override void marksCollection()
        {
            Subjects subjects = new Subjects();
            for (int i = 0; i < subjects.g1Subjects.Count; i++)
            {

                Console.Write($"Please Insert the marks of {subjects.g1Subjects[i]}: ");

                double marks = Convert.ToDouble(Console.ReadLine());

                while (marks < 0 || marks > 100)
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {subjects.g1Subjects[i]}: ");
                    marks = Convert.ToDouble(Console.ReadLine());
                }

                //allMarks.Add(marks);

                if (marks < 40)
                {
                    status = 'F';
                }
                else if (marks > 80)
                {
                    status = 'D';
                }
                else
                {
                    status = 'P';
                }
                subjStatus.Add(status);
                totalmarks += marks;
            }
            additional.Add(totalmarks);

            if (subjStatus.Contains('F'))
            {
                additional.Add("Fail");
            }
            else
            {
                additional.Add("Pass");
            }

            for (int i = 0; i < subjStatus.Count; i++)
            {
                if (subjStatus[i] == 'D')
                {
                    distinction++;
                }
            }

        }
    }
}
