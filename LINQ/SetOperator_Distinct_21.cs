using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SetOperator_Distinct_21
    {
        // Distinct - operator is used to return Distinct(unique) record from a data source
        // It has two overloaded versions
        // Distinct can be used with comparer also.
        // We will see the example of Distinct with IEqualityComparer and IEquatable interfaces.

        // What is the difference between the IEquatable and IEqualityCmparer ?

        // IEqualityComparer - Works with two different object.
        // It comperer one object data with another object data.

        // IEquatable - The class compares to itself, it has only one type and that type compares values with itself.


        public static void Example1()
        {
            int[] nums = { 1, 2, 3, 4, 3, 2, 4, 5, 7, 8, 0, 7, 5, 4, 3, 2, 1, 3, 5, 7, 4, 5, 6, 7 };

            var methodSyntax = nums.Distinct().ToList();

            var querySyntax = (from num in nums
                               select num).Distinct().ToList();

            Console.WriteLine("Breakpoint");
        }

        public static void Example2()
        {
            List<Student> students = new()
            {
                new(){Id = 1, Name="Abbas"},
                new(){Id = 2, Name="Ahmed"},
                new(){Id = 3, Name="Abbas"},
                new(){Id = 4, Name="Ali"},
                new(){Id = 5, Name="Ali"},
            };

            // Removing duplicates based on names
            var methodSyntax = students.Select(x => x.Name).Distinct().ToList();

            var querySyntax = (from std in students
                               select std.Name).Distinct().ToList();

            Console.WriteLine("Breakpoint");
        }

        // Example for the IEqautable
        public static void Example3()
        {
            List<Student2> students = new()
            {
                new(){Id = 1, Name="Abbas"},
                new(){Id = 2, Name="Ahmed"},
                new(){Id = 1, Name="Abbas"},
                new(){Id = 4, Name="Ali"},
                new(){Id = 4, Name="Ali"},
            };

            // Removing duplicates based on names
            var methodSyntax = students.Distinct().ToList();

            var querySyntax = (from std in students
                               select std).Distinct().ToList();

            Console.WriteLine("Breakpoint");
        }
        
        // Example for the IEqualityComparer
        public static void Example4()
        {
            List<Student3> students = new()
            {
                new(){Id = 1, Name="Abbas"},
                new(){Id = 2, Name="Ahmed"},
                new(){Id = 1, Name="Abbas"},
                new(){Id = 4, Name="Ali"},
                new(){Id = 4, Name="Ali"},
            };

            // Removing duplicates based on names
            var methodSyntax = students.Distinct(new Student3Comparer()).ToList();

            var querySyntax = (from std in students
                               select std).Distinct(new Student3Comparer()).ToList();

            Console.WriteLine("Breakpoint");
        }




        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // Example of IEquatable
        class Student2 : IEquatable<Student2>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public bool Equals(Student2? other)
            {
                if (object.ReferenceEquals(other, null))
                {
                    return false;
                }
                if (object.ReferenceEquals(this, other))
                {
                    return true;
                }
                return Id.Equals(other.Id) && Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
            }
            public override int GetHashCode()
            {
                int idHashCode = Id.GetHashCode();
                int nameHashCode = Name.GetHashCode();
                return idHashCode ^ nameHashCode;
            }
        }

        // Now lets see the example for the IEqualityComparer.
        class Student3
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Student3Comparer : IEqualityComparer<Student3>
        {
            public bool Equals(Student3? x, Student3? y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }
                return x.Id.Equals(y.Id) && x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(Student3 obj)
            {
                if (object.ReferenceEquals(obj, null))
                {
                    return 0;
                }
                int idHashCode = obj.Id.GetHashCode();
                int nameHashCode = obj.Name.GetHashCode();
                return idHashCode ^ nameHashCode;

            }
        }
    }


    public class SetOperator_Distinct
    {
        public static void Example()
        {
            //SetOperator_Distinct_21.Example1();
            //SetOperator_Distinct_21.Example2();
            //SetOperator_Distinct_21.Example3();
            SetOperator_Distinct_21.Example4();
        }
    }
}
