using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class QuantiferOperator_All_17
    {
        // Quantifier operations are used on a data source to check if some or all elements of that data source satisfy a confition or not.
        // All the methods in quantifier operations returns a boolean values.
        // Condition may be for some or all the elements.

        // It has three main methods.
        // 1. All() - Whether all the elements of data source satisfy a condition.
        // 2. Any() - Whether at least one element of a data source satisfy a condition.
        // 3. Contains() - Checks whether the data source contains a specified element.

        // All() - method is check whether all the elements are satisfying a specified condition or not. If not return false.
        // It returns boolean value.
        public static void Example1()
        {
            Student[] students =
            {
                new() { Name = "Abbas", Marks = 79},
                new() { Name = "Ahmed", Marks = 77},
                new() { Name = "Faizan", Marks = 71},
                new() { Name = "Usaama", Marks = 76},
            };

            var methodSyntax = students.All(std => std.Marks > 70);

            var querySyntax = (from std in students
                               select std).All(std => std.Marks > 70);

        }

        public static void Example2()
        {
            Student[] students =
            {
                new(){Name = "Abbas", Marks=80, Subject = new List<Subject>()
                {
                    new(){SubjectName = "English", SubjectMarks = 96},
                    new(){SubjectName = "Urdu", SubjectMarks = 99},
                    new(){SubjectName = "Math", SubjectMarks = 91}
                } },
                new(){Name = "Ahmed", Marks = 85, Subject = new List<Subject>()
                {
                    new(){SubjectName = "English", SubjectMarks = 81},
                    new(){SubjectName = "Urdu", SubjectMarks = 82},
                    new(){SubjectName = "Math", SubjectMarks = 87},

                } },
                new(){Name = "Usama", Marks = 90, Subject = new List<Subject>()
                {
                    new (){SubjectName = "English", SubjectMarks = 75},
                    new (){SubjectName = "Urdu", SubjectMarks = 76},
                    new (){SubjectName = "Math", SubjectMarks = 70}
                } }

            };

            var methodSyntax = students.All(std => std.Subject.All(marks => marks.SubjectMarks > 70));

            var withSelect = students.Where(std => std.Subject.All(x => x.SubjectMarks > 82)).Select(std => std).ToList();   // We can also remove .Select() Method.
    
            var wuerySyntax = (from std in students
                              where std.Subject.All(x => x.SubjectMarks > 80)
                              select std).ToList();

            Console.WriteLine("BreakPoint");

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

    public class QuantiferOperator_All
    {
        public static void Example()
        {
            //QuantiferOperator_All_17.Example1();
            QuantiferOperator_All_17.Example2();
        }
    }
}
