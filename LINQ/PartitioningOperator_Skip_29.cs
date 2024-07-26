using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class PartitioningOperator_Skip_29
    {
        // Skip() - Operator is used to skip the first n number of elements from the data source where n is integer.
        // Skip element will not make any changes into the positions of elements.

        public static void Example1()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var names = new List<string> { "Abbas", "Bilal", "Abdullah", "Qasim", "Zaheer" };

            var methodSyntax = nums.Skip(4).ToArray();

            var querySyntax = (from src in names select src)
                              .Skip(2).ToList();
        }

        // With Where
        public static void Example2()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var methodSyntax = nums.Where(x => x > 4).Skip(4).ToList();
            var querySyntax = (from num in nums select num).Where(x => x > 4).Skip(4).ToList();
        }


    }
    
    public class PartitioningOperator_Skip
    {
        public static void Example()
        {
            //PartitioningOperator_Skip_29.Example1();
            PartitioningOperator_Skip_29.Example2();
        }
    }
}
