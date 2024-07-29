using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class PartitioningOperator_SkipWhile_31
    {
        // SkipWhile() - operator is used to skip all the elements until a specified condtion is satisfied.
        // But when the condition satfisfies SkipWhile() operator wont check for the next elements.
        
        public static void Example1()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,3, 2 };
            // Now here at the last 2 and three are the small number from 4.
            // But SkipWhile will not check for those because the condition is satisfied before.

            var methodSyntax = numbers.SkipWhile(num => num < 4).ToArray();

            var querySyntax = (from num in numbers select num)
                .SkipWhile(num => num < 5).ToArray();
        }
        
        public static void Example2()
        {
            string[] names = { "Ali", "Abbas", "Umar", "Yasira", "Ali" };

            var methodSyntax = names.SkipWhile(src => src.Length < 4).ToArray();

            var querySyntax = (from src in names select src)
                .SkipWhile(src => src.Length < 6).ToArray();
        }
        
        public static void Example3()
        {
            string[] names = { "Ali", "Abbas", "Amir", "Awais", "Ali", "Umar", "Yasira" };

            var methodSyntax = names.SkipWhile((src, index) => src.Length > index).ToArray();

            var querySyntax = (from src in names select src)
                .SkipWhile((src, index) => src.Length > index).ToArray();
        }


    }
    
    
    public class PartitioningOperator_SkipWhile
    {
        public static void Example()
        {
            //PartitioningOperator_SkipWhile_31.Example1();
            //PartitioningOperator_SkipWhile_31.Example2();
            PartitioningOperator_SkipWhile_31.Example3();
        }
    }
}
