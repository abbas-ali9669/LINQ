

namespace LINQ
{
    public class PartitioningOperator_TakeWhile_28
    {
        // TakeWhile() - operator is used to get all records from a data source until a specified condition is true.
        // Once a condition is failed TakeWhile will not validate rest elements even if the condition is true for remaining elements
        // TakeWhile() operator can be used with the both techniques (Method/Syntax)
        // TakeWhile method will not make any changes in the elements position.
        
        public static void Example1()
        {
            int[] numbers = { 1, 5, 6, 7, 9, 10, 2, 3, 4 };

            var methodSyntax = numbers.TakeWhile(x => x < 7).ToList();
            // Now here the TakeWhile() method will not check after the condition, the condition is (number should less than 7).
            // And when the number reaches to the 7 it terminates the iteration, even if there is an elements after the number 7.
            // TakeWhile will not check for those.
            var querySyntax = (from num in numbers select num)
                            .TakeWhile(x => x < 7).ToList();
        }
        
        // Second overloaded version
        public static void Example2()
        {
            var source = new List<string> { "Ali", "Awais", "Umar", "Umair", "Ali", "Abbas" };

            var methodSyntax = source.TakeWhile((source, index) => source.Length > index).ToList();


            var querySyntax = (from src in source select src)
                            .TakeWhile((src, index) => src.Length > index).ToList();
        }
    }
    
    public class PartitioningOperator_TakeWhile
    {
        public static void Example()
        {
            //PartitioningOperator_TakeWhile_28.Example1();
            PartitioningOperator_TakeWhile_28.Example2();
        }
    }
}
