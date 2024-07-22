using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SetOperator_Intersect_23
    {
        // Intersect() - is used to target tose values which is common on both the data sources.
        // A1 = (A,B,C,D), A2 = (C,D,E,F) -> Output -> (C, D).
        // It aslo has two overloaded versions, to work with IEqualtiyOperator.

        public static void Example1()
        {
            var source1 = new List<string>() { "A", "B", "C", "D" };
            var source2 = new List<string>() { "C", "D", "E", "F" };

            var methodSyntax = source1.Intersect(source2).ToList();
            var querySyntax = (from source in source1
                              select source).Intersect(source2).ToList();

            Console.WriteLine("Breakpoint");
        }

        // Using Select/Anoynmous object.
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
                new Student(){ Id = 6, Name = "Ali" },
                new Student(){ Id = 7, Name = "Ahmed" }
            };

            var methodSynatx = student1.Select(s1 => new {s1.Id, s1.Name}).Intersect(student2.Select(s2 => new { s2.Id, s2.Name })).ToList();

            var querySyntax = (from source in student1
                              select new {source.Id, source.Name})
                              .Intersect(student2.Select(source => new { source.Id, source.Name }))
                              .ToList();

            Console.WriteLine("Breakpoint");
        }
        
        public static void Example3()
        {
            // Comparison with the three values.
            var student1 = new List<Student2>()
            {
                new Student2(){ Id = 1, Name = "Abbas", Age = 21 },
                new Student2(){ Id = 2, Name = "Abdullah", Age = 18 },
                new Student2(){ Id = 3, Name = "Ali", Age = 25 },
                new Student2(){ Id = 4, Name = "Ahmed", Age = 30 },
                new Student2(){ Id = 5, Name = "Wasim", Age = 24 },
            };
            
            var student2 = new List<Student2>()
            {
                new Student2(){ Id = 1, Name = "Abbas", Age = 21 },
                new Student2(){ Id = 2, Name = "Abdullah", Age = 18 },
                new Student2(){ Id = 6, Name = "Ali", Age = 25 },
                new Student2(){ Id = 4, Name = "Ahmed", Age = 30 },
                new Student2(){ Id = 8, Name = "Wasim", Age = 24 },
            };

            var methodSyntax = student1.Intersect(student2, new StudentTwoComparer()).ToList();

            Console.WriteLine("Breakpoint");
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        
        class Student2
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        class StudentTwoComparer : IEqualityComparer<Student2>
        {
            public bool Equals(Student2? x, Student2? y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }
                return x.Id.Equals(y.Id) &&
                    x.Name.Equals(y.Name) &&
                    x.Age.Equals(y.Age);
            }

            public int GetHashCode([DisallowNull] Student2 obj)
            {
                int idHashCode = obj.Id.GetHashCode();
                int nameHashCode = obj.Name.GetHashCode();
                int ageHashCode = obj.Age.GetHashCode();

                return idHashCode ^ nameHashCode ^ ageHashCode;
            }
        }
    }

    public class SetOperator_Intersect
    {
        public static void Example()
        {
            //SetOperator_Intersect_23.Example1();
            //SetOperator_Intersect_23.Example2();
            SetOperator_Intersect_23.Example3();
        }
    }
}
