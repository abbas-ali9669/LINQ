using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SetOperator_Union_24
    {
        // Union() - Operator is used to combine two data source.
        // And removes all the duplicate from both the data sources, and make it one.
        // It has two overloaded version to also work with IEqualityComparer.

        public static void Example1()
        {
            var sourceOne = new List<string>() { "A", "B", "C", "D" };
            var sourceTwo = new List<string>() { "C", "D", "E", "F" };

            var methodSyntax = sourceOne.Union(sourceTwo).ToList();

            var querySyntax = (from source in sourceOne
                              select source).Union(sourceTwo).ToList();

        }

        // With Anonymous Object
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
                new Student(){ Id = 5, Name = "Ali" },
                new Student(){ Id = 6, Name = "Ahmed" }
            };

            var methodSyntax = student1.Union(student2).ToList();
            // Now, the comparison with the objects does not work.
            // Because default comparer works woth the references not the values.

            var methodSyntax2 = methodSyntax.Select(x => new {x.Id, x.Name}).Union(student2.Select(x => new { x.Id, x.Name })).ToList();
            
            var querySyntax = (from std in student1
                              select new { std.Id, std.Name})
                              .Union(student2.Select(x => new { x.Id, x.Name }))
                              .ToList();
        }

        // With Comparer
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
                new Student(){ Id = 5, Name = "Ali" },
                new Student(){ Id = 6, Name = "Ahmed" }
            };

            var methodSyntax = student1.Union(student2).ToList();
            // Now, the comparison with the objects does not work.
            // Because default comparer works woth the references not the values.

            var methodSyntaxWithComparer = student1.Union(student2, new StudentComparer()).ToList();

            var querySyntax = (from std in student1
                               select std)
                               .Union(student2, new StudentComparer())
                               .ToList();

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
                int idHashCode = obj.Id.GetHashCode();
                int nameHashCode = obj.Name.GetHashCode();
                return idHashCode ^ nameHashCode;
            }
        }
    }
    
    public class SetOperator_Union
    {
        public static void Example()
        {
            //SetOperator_Union_24.Example1();
            //SetOperator_Union_24.Example2();
            SetOperator_Union_24.Example3();
        }
    }
}
