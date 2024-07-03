namespace LINQ
{
    public class SortingOperator_ThenBy_14
    {
        // ThenBy() - is used to sort the data on the second level and so on in ascending order
        // We can apply n number of ThenBy() method on the data source.
        // Means we can apply muktiple ThenBy() on on data source.

        // Lets understand this with an example()
        // Suppose ew have a data with firstname, lastname.
        // An the firstname is repeating in the data.
        // Then we can apply sorting based on lastname.
        // And if the lastname is repeating, then we can on more properties

        public static void Example1()
        {
            List<Person> peoples = new()
            {
                new Person {FirstName = "Abbas", LastName="Ali", Age=21},
                new Person {FirstName = "Ahmed", LastName="Khan", Age=30},
                new Person {FirstName = "Usama", LastName="Irshad", Age=24},
                new Person {FirstName = "Ahmed", LastName="Khan", Age=24},
            };

            var querySyntax = (from people in peoples
                              orderby people.FirstName,   // Primary sort on FirstName
                              people.LastName ascending,   // Secondary sort on LastName
                              people.Age ascending   // Tertiary sort on Age
                              select people).ToList();

            var methodSyntax = peoples.OrderBy(fname => fname.FirstName)
                                      .ThenBy(lname => lname.LastName)
                                      .ThenBy(age => age.Age)
                                      .ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine($"FirstName: {item.FirstName}, LastName: {item.LastName}, Age: {item.Age}");
            }

        }


        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }

    public class SortingOperator_ThenBy
    {
        public static void Example()
        {
            SortingOperator_ThenBy_14.Example1();
        }

    }
}
