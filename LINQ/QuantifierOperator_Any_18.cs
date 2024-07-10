using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class QuantifierOperator_Any_18
    {
        // Any() - is ued to check whether at least one element of a data source satfisfy a specified condtion.
        // Any method has to two overloaded version
        // One is for checking if the collection is empty or not.
        // Second is for checking, if one of the condition is satisfying the specified condition or not.
        // The both method return boolean.

        public static void Example1()
        {
            var coll = new List<int>() {};
            bool isEmpty = coll.Any();

            if (isEmpty)
            {
                Console.WriteLine("List is not empty.");
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }

        public static void Example2()
        {
            Student[] students =
            {
                new() { Name = "Abbas", Marks = 79},
                new() { Name = "Ahmed", Marks = 77},
                new() { Name = "Faizan", Marks = 71},
                new() { Name = "Usaama", Marks = 76},
            };

            var methodSyntax = students.Any(std => std.Marks > 70);

            var querySyntax = (from std in students
                              select std).Any(std => std.Marks > 78);

        }

        public  static void Example3()
        {
            Student[] students =
            {
                new() {Name = "Abbas", Marks = 79, Subject = new List<Subject>()
                {
                    new (){SubjectName = "English", SubjectMarks = 92},
                    new (){SubjectName = "Urdu", SubjectMarks = 91},
                    new (){SubjectName = "Math", SubjectMarks = 97}
                } },
                new() {Name = "Ahmed", Marks = 69, Subject = new List<Subject>()
                {
                    new (){SubjectName = "English", SubjectMarks = 82},
                    new (){SubjectName = "Urdu", SubjectMarks = 85},
                    new (){SubjectName = "Math", SubjectMarks = 89}
                } },
                new() {Name = "Usama", Marks = 76, Subject = new List<Subject>()
                {
                    new (){SubjectName = "English", SubjectMarks = 72},
                    new (){SubjectName = "Urdu", SubjectMarks = 75},
                    new (){SubjectName = "Math", SubjectMarks = 79}
                } }
            };

            var methodSyntax = students.Any(std => std.Subject.Any(mark => mark.SubjectMarks > 90));

            var querySyntax = (from std in students
                               select std).Any(x => x.Subject.Any(mark => mark.SubjectMarks > 98));

            var methodWithFilter = students.Where(std => std.Subject.Any(mark => mark.SubjectMarks > 88)).ToList();
            var methodWithNameFilter = students.Where(std => std.Subject.Any(mark => mark.SubjectMarks > 88)).Select(attr => attr.Name).ToList();

            var queryWithFilter = (from std in students
                                  where std.Subject.Any(mark => mark.SubjectMarks > 90)
                                  select std).ToList();

            var queryWithNameFilter = (from std in students
                                  where std.Subject.Any(mark => mark.SubjectMarks > 80)
                                  select std).Select(attr => attr.Name).ToList();

            Console.WriteLine("Breakpoint");
        }

        class Student
        {
            public string Name { get; set; }
            public int Marks { get; set; }

            public List<Subject> Subject { get; set; }
        }

        class Subject
        {
            public string SubjectName { get; set; }
            public int SubjectMarks { get; set; }
        }
    }    
    public class QuantifierOperator_Any
    {
        public static void Example()
        {
            //QuantifierOperator_Any_18.Example1();
            //QuantifierOperator_Any_18.Example2();
            QuantifierOperator_Any_18.Example3();
        }
    }
}
