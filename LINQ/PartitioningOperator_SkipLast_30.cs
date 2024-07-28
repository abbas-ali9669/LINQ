

namespace LINQ
{
    public class PartitioningOperator_SkipLast_30
    {
        // SkipLast() - is used to Skip n number of Last elements from a data source.
        // This will not effect the position in the elements.

        public static void Example1()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var methodSyntax = numbers.SkipLast(5).ToArray();

            var querySyntax = (from src in numbers select src)
                .SkipLast(5).ToArray();
        }

        public static void Example2()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var methodSyntax = numbers.Where(num => num > 2).SkipLast(5).ToArray();

            var querySyntax = (from src in numbers where src > 2 select src)
                .SkipLast(5).ToArray();
        }
    }
    
    public class PartitioningOperator_SkipLast
    {
        public static void Example()
        {
            //PartitioningOperator_SkipLast_30.Example1();
            PartitioningOperator_SkipLast_30.Example2();
        }
    }
}
