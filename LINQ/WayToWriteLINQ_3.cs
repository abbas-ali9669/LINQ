using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class WayToWriteLINQ_3
    {
        // To work with a LINQ, We need following things.
        // 1. Data Source, 1. Query, 3. Execution.

        // A query is a set instruction which is applied on a data source to perform an action(CRUD) and tells the shape of output from that query.
        // Each query is a combination of Initialization, Condition and Selection.

        // In LINQ, There are three ways to write query.
        // 1. Query Syntax.
        // 2. Method Syntax.
        // 3. Mixed Syntax (Method + Query).

        // Query Syntax.
        // This is one of the easy way to write query in easy and readable format/
        // It is very similar to the SQL query.

        // Method Syntax.
        // Mehtod Syntax is most popular in these days.
        // Method syntax uses lambda expression to define any condition.
        // Method syntax are easy to read/write and maintain for simple query.
        // But for complex query these are little hard to write as ocmpare to query syntax.
        // In this approach query is written by using multiple methods and combining them with a dot(.).

        // Mixed Syntax
        // This is the combination of query and method syntax.

        // Data Source
        private static readonly List<int> integers = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        
        public static void QuerySyntax()
        {
            Console.WriteLine("------------Query Syntax--------------");
            var result = from integer in integers   // Initialization
                         where integer %2 == 0   // Condition
                         select integer;   // Selection

            foreach (int integer in result)
            {
                Console.WriteLine(integer);
            }
        }

        public static void MethodSyntax()
        {
            Console.WriteLine("------------Method Syntax--------------");
            var result = integers.Where((x) => x % 2 == 0) ;

            foreach (int integer in result)
            {
                Console.WriteLine(integer);
            }
        }
        
        public static void MixedSyntax()
        {
            Console.WriteLine("------------Mixed Syntax--------------");
            var result = (from integer in integers
                          select integer).Where(x => x%2 == 0);
            
            var result2 = (from integer in integers
                          select integer).Max();

            Console.WriteLine("Max Integer is: " + result2);
            foreach (int integer in result)
            {
                Console.WriteLine(integer);
            }

        }
    }

    class WayToWriteLINQ
    {
        public static void Example()
        {
            WayToWriteLINQ_3.QuerySyntax();
            WayToWriteLINQ_3.MethodSyntax();
            WayToWriteLINQ_3.MixedSyntax();
        }
    }
}
