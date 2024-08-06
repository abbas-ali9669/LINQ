using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ElementOperator_FirstAndFirstOrDefault_40
    {
        // First and FirstOrDefault - both are used to retreive the first element from the specified data source
        // These both the method have also the overloaded versions, where both the methods acceps predicates.

        // Diffrence
        // First() - This method throws an exception if the given index is not found
        // FirstOrDefault() - This method return null/0 (0, In case of value type. null, in case of reference type), if the specified condition doesn't met.

        private static readonly List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void Example1()
        {
            var methodSyntax = numbers.First();   // 1
            var methodSyntax1 = numbers.FirstOrDefault();  // 1

            var querySyntax = (from num in numbers select num).First();
            var querySyntax1 = (from num in numbers select num).FirstOrDefault();
        }

        // With Filtering.
        public static void Example2()
        { 
            var methodSyntax = numbers.Where(x => x > 6).First();   // 7
            //var methodSyntax1 = numbers.Where(x => x > 12).First();   // System.InvalidOperationException
            // The overloaded version
            var methodSyntax2 = numbers.First(x => x > 7);   // Recommended

            var querySyntax = (from num in numbers where num > 6 select num).First();
            var querySyntax1 = (from num in numbers select num).First(x => x > 6);   // Recommended

        }

        // NOTE - Which one should be used ? 
        // The recommended way of using the condition is, always use First()/FirstOrDefault() conditional method.
        // Because when ever we use Where(), the Where() method will filter all the data source and then pass to the First()/FirstOrDefault() method.
        // While the First()/FirstOrDefault() will filter the source and grab the first element from there. no need to filter entire the data source.
        // This will reduce execution time. and make the code faster.

        public static void Example3()
        { 
            var methodSyntax = numbers.Where(x => x > 6).FirstOrDefault();   // 7
            var methodSyntax1 = numbers.Where(x => x > 12).FirstOrDefault();   // 0
            // The overloaded version
            var methodSyntax2 = numbers.FirstOrDefault(x => x > 7);   // Recommended

            var querySyntax = (from num in numbers where num > 6 select num).FirstOrDefault();
            var querySyntax1 = (from num in numbers select num).FirstOrDefault(x => x > 6);   // Recommended
        }
        
        public static void Example4()
        { 
            var students = new List<Student>()
            {
                new(){ Id = 1, Name = "Abbas", Age = 23 },
                new(){ Id = 2, Name = "Ahmed", Age = 29 },
                new(){ Id = 3, Name = "Faizan", Age = 28 },
                new(){ Id = 3, Name = "Usama", Age = 26 }
            };

            var methodSyntax = students.First();
            var methodSyntax1 = students.FirstOrDefault();

            var methodSyntax2 = students.FirstOrDefault(x => x.Id == 2);
            var methodSyntax3 = students.FirstOrDefault(x => x.Id == 10);   // null
            //var methodSyntax4 = students.First(x => x.Id == 10);   // System.InvalidOperationException


            var querySyntax = (from std in students select std).First();
            var querySyntax1 = (from std in students select std).FirstOrDefault();

            var querySyntax2 = (from std in students select std).First(x => x.Id == 3);
            var querySyntax3 = (from std in students select std).FirstOrDefault(x => x.Id == 3);
            
            //var querySyntax4 = (from std in students select std).First(x => x.Id == 10);   // System.InvalidOperationException
            var querySyntax5 = (from std in students select std).FirstOrDefault(x => x.Id == 10);   // null
        }


        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }

    public class ElementOperator_FirstAndFirstOrDefault
    {
        public static void Example()
        {
            //ElementOperator_FirstAndFirstOrDefault_40.Example1();
            //ElementOperator_FirstAndFirstOrDefault_40.Example2();
            //ElementOperator_FirstAndFirstOrDefault_40.Example3();
            ElementOperator_FirstAndFirstOrDefault_40.Example4();
        }
    }
}
