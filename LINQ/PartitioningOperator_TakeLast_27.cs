using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class PartitioningOperator_TakeLast_27
    {
        // TaksLast() - is used to get the last n number of element from the data source.
        // While Take() method was getting the elements starts of the data source.
        
        public static void Example1()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var methodSyntax = source.TakeLast(5).ToArray();

            var querySyntax  = (from src in source
                                select src).TakeLast(5).ToArray();
        }

        public static void Example2()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var methodSyntax = source.Where(x => x < 7).TakeLast(5).ToArray();

            var querySyntax = (from src in source
                               where src < 7
                               select src).TakeLast(5).ToArray();
        }
        
        public static void Example3()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var methodSyntax = source.TakeLast(5).Where(x => x < 7).ToArray();

            var querySyntax = (from src in source
                               select src).TakeLast(5).Where(x => x < 7).ToArray();

            // Here we are taking last 5 elements from the data source, and then applying the filter on it.
        }
    }

    public class PartitioningOperator_TakeLast
    {
        public static void Example()
        {
            //PartitioningOperator_TakeLast_27.Example1();
            //PartitioningOperator_TakeLast_27.Example2();
            PartitioningOperator_TakeLast_27.Example3();
        }
    }
}
