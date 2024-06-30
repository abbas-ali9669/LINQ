namespace LINQ
{
    public class FilteringoOperator_OfType_11
    {
        // OfType<Type>() - Is a generic method which filters out the data based on the specified data type.
        // That is also comes under the filtering operator.
        
        public static void Example1()
        {
            // The list of object that contains the different type of data.
            var dataSource = new List<object> { 1, 2, 3, "Abbas", "Ali", "Ahmad", "Umair", true, 4.55, 3.11f };

            var methodSyntax = dataSource.OfType<string>().ToList();
            var integers = dataSource.OfType<int>().ToList();
            var boolean = dataSource.OfType<bool>().ToList();
            var typeDouble = dataSource.OfType<double>().ToList();

            // Applying Where
            var filterWithWhere = dataSource.OfType<string>().Where(con => con.Length > 3).ToList();

            // The query syntax does not have such method for type filtering, but we can do with other ways
            var querySyntax = (from strType in dataSource
                              where strType is string
                              select strType).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
        }
    }
    
    public class FilteringoOperator_OfType
    {
        public static void Example()
        {
            FilteringoOperator_OfType_11.Example1();
        }
    }
}
