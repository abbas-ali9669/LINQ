using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ElementOperator_LastAndLastOrDefault_41
    {
        // Last() and LastOrDefualt() - Are both used to return the last element from the specified data source.

        // Diffrence
        // Last() - This method throws an exception if the given index is not found
        // LastOrDefualt() - This method return null/0 (0, In case of value type. null, in case of reference type), if the specified condition doesn't met.

        private static List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void Example1()
        {
            var methodSyntax = numbers.Last();
            var methodSyntax1 = numbers.LastOrDefault();

            var querySyntax = (from num in numbers select num).Last();
            var querySyntax1 = (from num in numbers select num).LastOrDefault();
        }
        
        // With Filtering
        public static void Example2()
        {
            //var methodSyntax = numbers.Last(x => x > 11);   // Will throw Exception
            var methodSyntax1 = numbers.LastOrDefault(x => x > 11);   // 0

            //var querySyntax = (from num in numbers select num).Last(x => x > 11);   // Will throw Exception
            var querySyntax1 = (from num in numbers select num).LastOrDefault(x => x > 11);   // 0

        }
    }

    public class ElementOperator_LastAndLastOrDefault
    {
        public static void Example()
        {
            //ElementOperator_LastAndLastOrDefault_41.Example1();
            ElementOperator_LastAndLastOrDefault_41.Example2();
        }
    }
}
