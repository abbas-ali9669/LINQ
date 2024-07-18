using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SetOperator_Except_22
    {
        // Except() - is use to ignore the specified value inside it.
        // Excpet() has the two overloaded versions.
        // We can also used the IEqualityComperer with the Except method.

        public static void Example1()
        {
            var sourceOne = new List<string>() { "A", "B", "C", "D" };
            var sourceTwo = new List<string>() { "C", "D", "E", "F" };

            var methodSyntax = sourceOne.Except(sourceTwo).ToList();

            var querySyntax = (from std in sourceOne
                               select std).Except(sourceTwo).ToList();

           
        }

        // Example with Select Mehtod
        public static void Example2()
        {
            var student1 = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Abbas" },
                new Student(){ Id = 2, Name = "Abdullah" },
                new Student(){ Id = 3, Name = "Ali" },
                new Student(){ Id = 4, Name = "Ahmed" },
                new Student(){ Id = 5, Name = "Wasim" },
            };
            
            
            var student2 = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Abbas" },
                new Student(){ Id = 2, Name = "Abdullah" },
                new Student(){ Id = 3, Name = "Ali" },
                new Student(){ Id = 4, Name = "Ahmed" },
                
            };

            var methodSyntax = student1.Select(x => x.Name).Except(student2.Select(x => x.Name)).ToList();

            var querySyntax = (from std in student1
                               select std.Name ).Except(student2.Select(x => x.Name)).ToList();

            Console.WriteLine("Breakpoint");
        }

        public static void Example3()
        {
            var student1 = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Abbas" },
                new Student(){ Id = 2, Name = "Abdullah" },
                new Student(){ Id = 3, Name = "Ali" },
                new Student(){ Id = 4, Name = "Ahmed" },
                new Student(){ Id = 5, Name = "Wasim" },
            };


            var student2 = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Abbas" },
                new Student(){ Id = 2, Name = "Abdullah" },
                new Student(){ Id = 3, Name = "Ali" },
                new Student(){ Id = 4, Name = "Ahmed" }
            };

            var methodSyntax = student1.Except(student2).ToList();   // Result : 5


            var methodSyntaxTwo = student1.Except(student2, new StudentComparer()).ToList();   // Result : 1
            // Because as we know this only checks for references when it comes to the objects.
            // We can also do this work with IEquatable.

            var querySyntax = (from std in student1
                              select std).Except(student2, new StudentComparer()).ToList();

            Console.WriteLine("Breakpoint");
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student? x, Student? y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }
                return x.Id.Equals(y.Id) && x.Name.Equals(y.Name);
            }

            public int GetHashCode([DisallowNull] Student obj)
            {
                if (object.ReferenceEquals(obj, null))
                {
                    return 0;
                }
                return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
            }
        }
    }

    public class SetOperator_Except
    {
        public static void Example()
        {
            //SetOperator_Except_22.Example1();
            //SetOperator_Except_22.Example2();
            SetOperator_Except_22.Example3();
        }
    }
}
