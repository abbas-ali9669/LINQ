using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class SortingOperator_ThenByDescending_15
    {

        // ThenByDescending() - is used to sort the data on the second level and so on in desscending order
        // We can apply n number of ThenByDescending() method on the data source, same as ThenBy().
        // Means we can apply muktiple ThenByDescending() on data source.

        // Lets understand this with an example()
        // Suppose we have a data with firstname, lastname.
        // And the firstname is repeating in the data.
        // Then we can apply sorting based on lastname.
        // And if the lastname is repeating, then we can on more properties.

        public static void Example1()
        {
            List<Person> peoples = new()
            {
                new Person {FirstName = "Abbas", LastName="Ali", Age=21},
                new Person {FirstName = "Ahmed", LastName="Khan", Age=30},
                new Person {FirstName = "Usama", LastName="Irshad", Age=24},
                new Person {FirstName = "Ahmed", LastName="Khan", Age=24},
            };

            var querySyntax = (from people in  peoples
                               orderby people.FirstName descending,   // Primary sort on FirstName
                               people.LastName descending,   // Secondary sort on LastName
                               people.Age descending   // Tertiary sort on Age
                               select people).ToList();
            
            var methodSyntax = peoples.OrderByDescending(fname => fname.FirstName)
                                        .ThenByDescending(lname => lname.LastName)
                                        .ThenByDescending(age => age.Age)
                                        .ToList();

            foreach (var item in methodSyntax)
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
    
    class SortingOperator_ThenByDescending
    {
        public static void Example()
        {
            SortingOperator_ThenByDescending_15.Example1();
        }
    }
}
