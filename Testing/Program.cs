using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace Testing
{
    internal class Program
    {
        //Global Variables
        //jagged array to store subjects by grades.
        string[][] gradeSubjects = new string[][]
        {
            new string[] { "Myanmar", "English", "Maths" },
            new string[] { "Myanmar", "English", "Maths" },
            new string[] { "Myanmar", "English", "Maths", "Social Studies" },
            new string[] { "Myanmar", "English", "Maths", "Social Studies" },
            new string[] { "Myanmar", "English", "Maths", "Social Studies" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Geography", "History", "Science" },
            new string[] { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" },
            new string[] { "Myanmar", "English", "Maths", "Physics", "Chemistry", "Biology" },
        };
        //2D list to store all the student details of each grade.
        List<List<object>> g1Details = new List<List<object>>();
        List<List<object>> g2Details = new List<List<object>>();
        List<List<object>> g3Details = new List<List<object>>();
        List<List<object>> g4Details = new List<List<object>>();
        List<List<object>> g5Details = new List<List<object>>();
        List<List<object>> g6Details = new List<List<object>>();
        List<List<object>> g7Details = new List<List<object>>();
        List<List<object>> g8Details = new List<List<object>>();
        List<List<object>> g9Details = new List<List<object>>();
        List<List<object>> g10Details = new List<List<object>>();

        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|| Welcome to Student Registration System ||");
            Console.WriteLine("============================================");
            Console.WriteLine();
            //cannot call void method from static void method.
            //Because its an intance method.
            //Therefore creating an instance of the class to call the void method.
            Program student = new Program();
            student.MainMenu();
        }
        //Method for Main Menu.
        void MainMenu()
        {
            int perform;
            Console.WriteLine();
            Console.WriteLine("Please select option that you want to perform: \n1.Register Students\n2.View registered students\n3.Exit");
            perform = Convert.ToInt32(Console.ReadLine());
            //Using while loop to check for invalid input and loop until user insert the correct input.
            while (perform != 1 && perform != 2 && perform != 3)
            {
                Console.WriteLine("\nInvalid Input!\n");
                Console.WriteLine("Please select option that you want to perform: \n1.Register Students\n2.View registered students\n3.Exit");
                perform = Convert.ToInt32(Console.ReadLine());
            }
            //using swtich case that will call the method of the function that the user choose to perform.
            switch (perform)
            {
                case 1:
                    insertStudent();
                    break;
                case 2:
                    displayStudents();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the system!");
                    break;
            }
        }
        //Method which allows user to choose which Grade user wants to reigster students for.
        void insertStudent()
        {
            Console.WriteLine();
            Console.WriteLine(" =======================");
            Console.WriteLine("| Register New Students |");
            Console.WriteLine(" =======================");
            Console.WriteLine();

            Console.Write("Please insert Student's Grade Number: ");
            int grade = Convert.ToInt32(Console.ReadLine());
            //Using switch case that will call the register method with perimeters according to the grade.
            switch (grade)
            {
                case 1:
                    register(grade, g1Details); //calling the register method. First perimeter representing the grade and Second perimeter is the global variable to store student details inside.
                    break;
                case 2:
                    register(grade, g2Details);
                    break;
                case 3:
                    register(grade, g3Details);
                    break;
                case 4:
                    register(grade, g4Details);
                    break;
                case 5:
                    register(grade, g5Details);
                    break;
                case 6:
                    register(grade, g6Details);
                    break;
                case 7:
                    register(grade, g7Details);
                    break;
                case 8:
                    register(grade, g8Details);
                    break;
                case 9:
                    register(grade, g9Details);
                    break;
                case 10:
                    register(grade, g10Details);
                    break;
                default:
                    Console.WriteLine("\nInvalid Input! Please insert a proper Grade (1 to 10)!\n");
                    insertStudent(); //if the user input is invalid, it will call back this function
                    break;
            }
        }
        //Method for registering student details. 
        //Accepts user input for details and store it in the global variable list according to the perimeter.
        void register(int studentGrade, List<List<object>> list)
        {
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine($" Register students for Grade {studentGrade}"); //gets the student grade number from the first perimeter.
            Console.WriteLine("===============================");
            Console.WriteLine();

            bool another = true;
            var phrase = @"^[a-zA-Z ]+$"; //phrase order to validate student name.

            while (another)
            {
                double totalmarks = 0; //initialize as 0 so that totalmarks will reset when user insert another student details.
                char status;
                int distinction = 0; //initialize as 0 so that number of dinctinctions will reset when user insert another student details.
                List<object> student = new List<object>(); //list for storing one student details temporarily before inserting into the global variable list.
                List<char> subjStatus = new List<char>(); //list for storing student's subject status to decide whether student pass or fail and how many distinctions student got.

                Console.Write("Enter Student's Name: ");
                string name = Console.ReadLine();
                bool nameValid = Regex.IsMatch(name, phrase); //student name validation. Check if the student name matches with the Regex phrase format.
                //using while loop. Loops until user insert the correct name format.
                while (!nameValid)
                {
                    Console.WriteLine("\nInvalid Input! Please insert a proper name!\n");
                    Console.Write("Enter Student's Name: ");
                    name = Console.ReadLine();
                    nameValid = Regex.IsMatch(name, phrase);
                }

                student.Add(name); //If the name is valid, it will add to the student list.

                Console.Write("Enter Student's Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                // using while loop. Loops until user insert the valid student age.
                while (age < 5 || age > 120)
                {
                    Console.WriteLine("\nInvalid Input! Please insert a proper age!\n");
                    Console.Write("Enter Student's Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                }

                student.Add(age); //If the age is valid, it will add to student list.
                student.Add(studentGrade); //Adding student grade from the perimeter into the student list.
                //using for loop to collect marks of all subjects.
                for (int i = 0; i < gradeSubjects[studentGrade - 1].Length; i++)
                {
                    //printing out subjects.
                    Console.Write($"Please Insert the marks of {gradeSubjects[studentGrade - 1][i]}: ");
                    //collecting marks for subject.
                    double marks = Convert.ToDouble(Console.ReadLine());
                    //using while loop. Loops until user inser the valid marks (0 to 100).
                    while (marks < 0 || marks > 100)
                    {
                        Console.WriteLine("\nInvalid Input! Please insert proper marks (0 to 100)!\n");
                        Console.Write($"Please Insert the marks of {gradeSubjects[studentGrade - 1][i]}: ");
                        marks = Convert.ToDouble(Console.ReadLine());
                    }
                    //if the marks are valid, it will be added to the student list.
                    student.Add(marks);
                    //checking whether the student pass, fail or got distinction in each subject according to the marks inserted.
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
                    subjStatus.Add(status); //adding the subject status in the subjStatus list.
                    totalmarks += marks; //calculating the total marks by adding up the marks inseted for each subject.
                }
                student.Add(totalmarks); // if marks for all subjects has been inserted and added up, the total marks will be added to the student list.
                //checking the subjStatus list to see if the student fails any of the subjects.
                if (subjStatus.Contains('F'))
                {
                    student.Add("Fail"); //if the student fails at least one subject, it will add Fail to the student list.
                }
                else
                {
                    student.Add("Pass"); //if student doesn't fail any subject, it will add Pass to the student list.
                }
                //checking the subjStatus list to see if student got any distinctions.
                //if there is distinctions, it will add up the number of distinctions.
                for (int i = 0;i < subjStatus.Count; i++)
                {
                    if (subjStatus[i] == 'D')
                    {
                        distinction++;
                    }
                }
                student.Add(distinction); //adding the number of distinctions to student list.
                list.Add(student); //after adding every details, the student list will be added to the global variable according to the perimeter.
                //checking if user wants to register another student within the same grade.
                Console.WriteLine($"\nDo you want to register another student in Grade {studentGrade}?\n1.Yes\n2.No");
                int rAnother = Convert.ToInt32(Console.ReadLine());

                switch (rAnother)
                {
                    case 1:
                        another = true;
                        break;
                    case 2:
                        another = false;
                        break;
                }
            }

            MainMenu();
        }
        //Method that allow users to choose which grade student details that they want to see. 
        void displayStudents()
        {
            Console.WriteLine();
            Console.WriteLine(" ==========================");
            Console.WriteLine("| View Registered Students |");
            Console.WriteLine(" ==========================");
            Console.WriteLine();
            Console.Write("Please insert the Grade that you want to see the students: ");
            int dGrade = Convert.ToInt32(Console.ReadLine());
            //using switch case to call showStudents method with perimeters according to the grade that user inserts.
            switch (dGrade)
            {
                case 1:
                    //calling showStudents mwthod to display students in grade 1.
                    //First perimeter is to show grade number, second perimeter is to display subjects in grade 1 and third perimeter is for displaying all students with thier details in grade 1.
                    showStudents(1, gradeSubjects[0], g1Details); 
                    break;
                case 2:
                    showStudents(2, gradeSubjects[1], g2Details);
                    break;
                case 3:
                    showStudents(3, gradeSubjects[2], g3Details);
                    break;
                case 4:
                    showStudents(4, gradeSubjects[3], g4Details);
                    break;
                case 5:
                    showStudents(5, gradeSubjects[4], g5Details);
                    break;
                case 6:
                    showStudents(6, gradeSubjects[5], g6Details);
                    break;
                case 7:
                    showStudents(7, gradeSubjects[6], g7Details);
                    break;
                case 8:
                    showStudents(8, gradeSubjects[7], g8Details);
                    break;
                case 9:
                    showStudents(9, gradeSubjects[8], g9Details);
                    break;
                case 10:
                    showStudents(10, gradeSubjects[9], g10Details);
                    break;
                default:
                    displayStudents(); //if the user input is invalid, it will call back this function.
                    break;
            }
        }
        //Method to display all students with their details in thier respective grades. 
        //First perimeter is to show grade number, second perimeter is to display subjects and third perimeter is for displaying all students with their details.
        void showStudents(int g, string[] stusubj, List<List<object>> stulist)
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine($" Registered students for Grade {g}");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.Write(string.Format("{0,-20}{1,-20}{2,-20}","Name", "Age", "Grade"));
            //using for loop to display subjects from global variable array.
            for (int i = 0; i < stusubj.Length; i++)
            {
                Console.Write(string.Format("{0,-20}", stusubj[i]));
            }

            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Total Marks","Subject Status","Total Distinctions"));
            //using nested for loop to display all the students with their details from the global variable list.
            foreach (var student in stulist)
            {
                foreach (var detail in student)
                {
                    Console.Write(string.Format("{0,-20}",detail));
                }

                Console.WriteLine();
            }

            MainMenu();
        }
    }
}
