namespace LINQ
{
    public class SortingOperator_Reverse_16
    {
        // Reverse() - is used to reverse all the elements of the data source.
        // Reverse method is avaiable in Systme.Linqnamespace.
        // Reverse method will not make any changes in source it will just reverse all the elements in output.
        // Reverse() method will return data as IEnumerable<TSource> or IQueryable<TSource> as per the use.
        // Now here the Reverse method is avaiable in both namspaces Systenm.Ling and System.Collection.Generic.
        // We will also see how we can use the Linq Reverse method on the generic List.

        public static void Example1()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var methodSyntax = numbers.Reverse();
            // Now here the Reverse method is coming from the System.Linq namespace, means the Reverse method is same which we want.

            var querySyntax = (from number in numbers
                              select number).Reverse();

            foreach (var number in querySyntax)
            {
                Console.WriteLine(number);
            }
        }

        public static void Example2()
        {
            List<string> names = new() { "Abbas", "Ali", "Ahmed", "Usama" };

            // var reversed = names.Reverse();   // Error
            names.Reverse();   // No Error
            // Now here the abpve line will raise the error, because this Reverse method isn't of the Linq.
            // The Reverse method is coming from System.Collection.Generic, which is type void.
            // And we cannot store in the variable, because it is not returning any value

            var querySyntax = (from name in names
                               select name).Reverse();
            // Now here above the Linq's Reverse method is getting invoke.

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }

        public static void Example3()
        {
            // Now in this example we will convert void List's Reverse method into Linq's Reverse method.

            List<string> newName = new() { "Arslan", "Danish", "Awais", "Umar" };

            var methodSyntax  = newName.AsEnumerable().Reverse();
            // Now here above the Linq's Reverse method is of type IEnumerable, So we convert this into type IEnumerable.

            // We can also change this into IQueryable, Because same as IEnumerable class, The IQueryable class also has the same Reverse method.
            var methodSyntax2 = newName.AsQueryable().Reverse();

            // NOTE - The Linq namespace has two classes IEnumerable and IQueryable, and these both have their own Reverse methods.

            foreach (var item in methodSyntax2)
            {
                Console.WriteLine(item);
            }
        }

    }
    
    public class SortingOperator_Reverse
    {
        public static void Example()
        {
            //SortingOperator_Reverse_16.Example1();
            //SortingOperator_Reverse_16.Example2();
            SortingOperator_Reverse_16.Example3();
        }
    }
}
