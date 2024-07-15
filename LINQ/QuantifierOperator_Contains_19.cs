using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class QuantifierOperator_Contains_19
    {
        // Contains() - operator is used to check whether a sequenceor data source contains a specified element.
        // Contains operator is also present in System.Collection.Generic namespace.
        // Which is mostly used in List, But we will use the System.Linq namespace's Contains method.
        // Where there is two overloaded versions of Contains method.
        // One is for simple comparing and second one is taking the IEqualityComparer as an argument.
        // The second Contains method check the source of object, Contains() only checks for references.
        // If the reference is equals, it will return true, else false
        // To work with the value we need to do some extra things
        // It returns boolean.

        public static void Example1()
        {
            var data = new List<string>() { "Abbas", "Ahmed", "Ali" , "Usama", "Bilal", "Umar" };

            var fromCollection = data.Contains("Abbas");   // This method is coming from System.Collections.Generic namespace.

            var methodSyntax = data.AsEnumerable().Contains("Alli");

            var querySyntax = (from source in data
                               select source).Contains("Usama");

            Console.WriteLine("Breakpoint");
        }

        public static void Example2()
        {
            // So now we will see the reference comparison in Contains() method.
            var students = new List<Student>()
            {
                new (){ Id = 1, Name = "Abbas" },
                new (){ Id = 2, Name = "Ali" }
            };

            // Example 1
            bool isExist = students.AsEnumerable().Contains(new() { Id = 1, Name = "Abbas" });
            // Now here it is returning false, because it is not checking for the values, it checks for the reference.
            // And in the memory the both object has the different references.

            // Example 2
            var std = new Student{ Id = 3, Name = "Ahmed" };
            students.Add(std);

            bool isExist2 = students.AsEnumerable().Contains(std);
            // Now here, the result is true, because first we are adding the reference to the list and then we are comparing the same reference we have added.
            // Therefore the result is true.
            // But how can we make the Contains() method to check only the value not for the references.
            // So here comes the IEqualityComparer.
            // See the Example 3.


            Console.WriteLine("Breakpoint");
        }

        public static void Example3()
        {
            // So, now we wil see how we can compare the values of the different references using contains.
            // So for this we have to create the Comparer class and inherit that class with the IEqualityComparer<OurClass>.
            var students = new List<Student>()
            {
                new (){ Id = 1, Name = "Abbas" },
                new (){ Id = 2, Name = "Ali" }
            };

            var comparer = new StudentComparer();

            bool isExistOrMethodSyntax = students.Contains(new() { Id = 2, Name = "Ali" }, comparer);   // Now the output is expected -> true
            // With doing this we have make this contains() method to check only for the values not for the reference.

            var querySyntax = (from std in students
                              select std).Contains(new() { Id = 2, Name = "Ali" }, comparer);

            Console.WriteLine("Breakpoint");
        }
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class StudentComparer : IEqualityComparer<Student>
        {
            // These two methods are coming from IEqualityComparer interface.
            public bool Equals(Student? x, Student? y)
            {
                if (object.ReferenceEquals(x,y))
                {
                    return true;
                }

                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }

                return x.Id == y.Id && x.Name == y.Name;

            }

            public int GetHashCode(Student obj)
            {
                if (Object.ReferenceEquals(obj, null))
                {
                    return 0;
                }

                int idHashCode = obj.Id.GetHashCode();
                // The 'Name' property can be null so it should be handled
                int nameHashCode = obj.Name.GetHashCode() == null ? 0 : obj.Name.GetHashCode();
                return idHashCode ^ nameHashCode;
            }
        }
    }
    
    public class QuantifierOperator_Contains
    {
        public static void Example()
        {
            //QuantifierOperator_Contains_19.Example1 ();
            //QuantifierOperator_Contains_19.Example2 ();
            QuantifierOperator_Contains_19.Example3 ();
        }
    }
}
