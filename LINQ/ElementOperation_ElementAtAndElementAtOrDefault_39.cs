using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ElementOperation_ElementAtAndElementAtOrDefault_39
    {
        // ElementAt and ElementAtOrDefault - are both used to retreive the element at a given index.
        // These both methods works with the index.
        // The only difference in between these both of two 

        // Diffrence
        // ElementAt() - This method throws an exception if the given index is not found
        // ElementAtOrDefault() - This method return null/0 (0, In case of value type. null, in case of reference type), if the specified index element not found

        static List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static List<string> names = new() { "Abbas", "Ahmed", "Ali", "Usama", "Faizan", "Umar"};
        
        // ElementAt
        public static void Example1()
        {
            var methodSyntax = numbers.ElementAt(3);   // 4
            //var methodSyntax1 = numbers.ElementAt(10);   // System.ArgumentOutOfRangeException

            var querySyntax = (from name in names select name).ElementAt(2);   // "Ali"
            //var querySyntax1 = (from name in names select name).ElementAt(-1);   // System.ArgumentOutOfRangeException

        }
        
        // ElementAtOrDefault
        public static void Example2()
        {
            var methodSyntax = numbers.ElementAtOrDefault(5);   // 6
            var methodSyntax1 = numbers.ElementAtOrDefault(10);   // 0

            var querySyntax = (from name in names select name).ElementAtOrDefault(3);   // "Usama"
            var querySyntax1 = (from name in names select name).ElementAtOrDefault(6);   // null
        }
        
        // With Filtering
        public static void Example3()
        {
            var methodSyntax = numbers.Where(x => x > 5).ElementAt(0);   // 6 - First we are filtering element then retreiving.
            var methodSyntax1 = numbers.Where(x => x > 7).ElementAtOrDefault(10);   // 0

            // NOTE - In Linq, the order of query operators matter alot.

            var querySyntax = (from name in names where name.Length > 3 select name).ElementAt(2);   // "Usama"
            var querySyntax1 = (from name in names where name.Length > 8 select name).ElementAtOrDefault(2);   // null
        }



    }
    
    public class ElementOperation_ElementAndElemetntOrDefault
    {
        public static void Example()
        {
            //ElementOperation_ElementAtAndElementAtOrDefault_39.Example1();
            //ElementOperation_ElementAtAndElementAtOrDefault_39.Example2();
            ElementOperation_ElementAtAndElementAtOrDefault_39.Example3();
        }
    }
}
