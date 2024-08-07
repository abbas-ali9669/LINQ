using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ElementOperator_SingleAndSingleOrDefault_42
    {
        // Single() and SingleOrDefault() - Are both used to retreive single record from the data source.
        // If the same element is present in the data source more than 1 time, the method will throw an exception.
        // Diffrence
        // Single() - This method throws an exception if the given index is not found
        // SingleOrDefualt() - This method return null/0 (0, In case of value type. null, in case of reference type), if the specified condition doesn't met.

        private static List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 5, 11 };

        public static void Example1()
        {
            // Case 1 - With empty source
            List<int> numbers1 = new() {  };
            //var ms1 = numbers1.Single();   // System.InvalidOperationException
            var ms2 = numbers1.SingleOrDefault();   // 0

            // Case 2 - With only one element
            List<int> numbers2 = new() { 1 };
            var ms3 = numbers2.Single();   // 1
            var ms4 = numbers2.SingleOrDefault();   // 1

            // Case 3 - With two element
            List<int> numbers3 = new() { 1, 2 };
            //var ms5 = numbers3.Single();   // System.InvalidOperationException
            //var ms6 = numbers3.SingleOrDefault();   // System.InvalidOperationException
            // The exception occurs in both the methods, because it just works with only 1 element if there is no condition.

            // Case 4 - Two elements with condition
            List<int> numbers4 = new() { 1, 2 };
            var ms7 = numbers4.Single(x => x > 1);   // 2
            var ms8 = numbers4.SingleOrDefault(x => x > 1);   // 2


            // Case 5 - Three elements with condition
            List<int> numbers5 = new() { 1, 2, 3 };
            //var ms9 = numbers5.Single(x => x > 1);   // System.InvalidOperationException
            //var ms10 = numbers5.SingleOrDefault(x => x > 1);   // System.InvalidOperationException
            // The exception occurs in both the cases becuase after the condition there are two element left.

        }

        public static void Example2()
        {
            var methodSyntax = numbers.Single(x => x == 4);
            var methodSyntax2 = numbers.SingleOrDefault(x => x == 4);
            // Now there is no exception occurs, because the appearance of specified number is only one.

            //var methodSyntax3 = numbers.Single(x => x == 5);   // Error, appearance of specified number is more than one.
            //var methodSyntax4 = numbers.SingleOrDefault(x => x == 5);   // Error, appearance of specified number is more than one.

            var querySytax = (from num in numbers where num == 4 select num).Single();
            var querySytax2 = (from num in numbers where num == 5 select num).SingleOrDefault();   // System.InvalidOperationException

            var querySytax3 = (from num in numbers where num > 10 select num).SingleOrDefault();   // 11
            var querySytax4 = (from num in numbers where num > 11 select num).SingleOrDefault();   // System.InvalidOperationException
            // This is because there is more than one element present in data source.
        }
    }

    public class ElementOperator_SingleAndSingleOrDefault
    {
        public static void Example()
        {
            //ElementOperator_SingleAndSingleOrDefault_42.Example1();
            ElementOperator_SingleAndSingleOrDefault_42.Example2();
        }
    }
}
