using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace Testing
{
    public abstract class Student
    {
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public int age { get; private set; }
        public int grade { get; set; }
        public List<double> Marks { get; set; }
        public double totalmarks { get; private set; }
        public bool status { get; set; }
        public int distinctions { get; set; }
        public void calculateAge()
        {
            age = DateTime.Now.Year - birthday.Year;
        }

        public abstract void collectMarks();
        public double totalMarks()
        {
            totalmarks = 0;
            foreach (var mark in Marks)
            {
                totalmarks += mark;
            }
            return totalmarks;
        }
        public bool statusCheck()
        {
            foreach (var mark in Marks)
            {
                if (mark < 40)
                {
                    status = false;
                    return status;
                }
            }
            status = true;
            return status;
        }
        public int countDistinctions()
        {
            distinctions = 0;
            foreach (var mark in Marks)
            {
                if (mark > 80)
                {
                    distinctions++;
                }
            }
            return distinctions;
        }


    }
    public class G1toG2Student : Student
    {
        public override void collectMarks()
        {
            Marks = new List<double>();
            Subjects s1s2 = new Subjects();
            for (int i = 0; i < s1s2.g1tog2Subjects.Count; i++)
            {

                Console.Write($"Please Insert the marks of {s1s2.g1tog2Subjects[i]}: ");

                double marks = Convert.ToDouble(Console.ReadLine());

                while (marks < 0 || marks > 100)
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {s1s2.g1tog2Subjects[i]}: ");
                    marks = Convert.ToDouble(Console.ReadLine());
                }
                Marks.Add(marks);
            }
        }
    }
    public class G3toG4Student : Student
    {
        public override void collectMarks()
        {
            Marks = new List<double>();
            Subjects s3s5 = new Subjects();
            for (int i = 0; i < s3s5.g3tog5Subjects.Count; i++)
            {
                Console.Write($"Please Insert the marks of {s3s5.g3tog5Subjects[i]}: ");

                double marks = Convert.ToDouble(Console.ReadLine());

                while (marks < 0 || marks > 100)
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {s3s5.g3tog5Subjects[i]}: ");
                    marks = Convert.ToDouble(Console.ReadLine());
                }
                Marks.Add(marks);
            }

        }
    }
    public class G5toG8Student : Student
    {
        
        public override void collectMarks()
        {
            Marks = new List<double>();
            Subjects s6s8 = new Subjects();
            for (int i = 0; i < s6s8.g6tog8Subjects.Count; i++)
            {
                Console.Write($"Please Insert the marks of {s6s8.g6tog8Subjects[i]}: ");

                double marks = Convert.ToDouble(Console.ReadLine());

                while (marks < 0 || marks > 100)
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {s6s8.g6tog8Subjects[i]}: ");
                    marks = Convert.ToDouble(Console.ReadLine());
                }
                Marks.Add(marks);
            }

        }
    }
    public class G9toG10Student : Student
    {
        public override void collectMarks()
        {
            Marks = new List<double>();
            Subjects s9s10 = new Subjects();
            for (int i = 0; i < s9s10.g9tog10Subjects.Count; i++)
            {

                Console.Write($"Please Insert the marks of {s9s10.g9tog10Subjects[i]}: ");

                double marks = Convert.ToDouble(Console.ReadLine());

                while (marks < 0 || marks > 100)
                {
                    Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                    Console.Write($"Please Insert the marks of {s9s10.g9tog10Subjects[i]}: ");
                    marks = Convert.ToDouble(Console.ReadLine());
                }
                Marks.Add(marks);
            }
        }
    }
}
