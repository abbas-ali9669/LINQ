using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class PartitioningOperator_Take_26
    {
        // Take() - used to get the the n number of records from a data source
        // Where n is an integer which will be passed in Take() method.
        // Take can also be used in method and querySyntax
        // Take() method will not make any changes in order of elements.

        public static void Example1()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var methodSyntax = source.Take(5).ToArray();
            // No here the Take method has taken only 5 record from the data source.

            var querySyntax = (from src in source
                               select src).Take(5).ToArray();

        }
        
        // With Filtering
        public static void Example2()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var methodSyntax = source.Where(x => x > 3).Take(5).ToArray();
            // No here the Take method will take the first five element from filtered data.

            var querySyntax = (from src in source
                               where src > 3
                               select src).Take(5).ToArray();

        }
        
        public static void Example3()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            // But what if we Take first and then filter the data
            var methodSyntax = source.Take(5).Where(x => x > 3).ToArray();
            

            var querySyntax = (from src in source
                               select src).Take(5).Where(x => x > 3).ToArray();

            // Now what happened here, first we grab data five record from the data source.
            // And then we have applied the filter on grabbed data.
            // So, the order in linq query is very important.

        }
    }
    
    public class PartitioningOperator_Take
    {
        public static void Example()
        {
            //PartitioningOperator_Take_26.Example1();
            //PartitioningOperator_Take_26.Example2();
            PartitioningOperator_Take_26.Example3();
        }
    }
}
