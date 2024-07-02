using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SortingOperator_OrderByDescending_13
    {
        // OrderByDescending - is used to sort the data reversely.
        // It is the opposite of OrderBy operator.
        // We can sort the data in descending order based on different data types.

        public static void Example1()
        {
            var dataSource = new List<int> { 3, 40, 6, 7, 8, 95, 4, 13, 2, 32, };

            var querySyntax = (from num in dataSource
                              orderby num descending   // The 'descending' will sort the data in descending order
                              select num).ToList();

            var methodSyntax = dataSource.OrderByDescending(num => num).ToList();


            // With Where
            var qsWithWhere = (from num in dataSource
                               where num > 10
                               orderby num descending
                               select num).ToList();

            var msWithWhere = dataSource.Where(num => num > 10).OrderByDescending(num => num).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
        }

        public static void Example2()
        {
            var dataSource = new List<string>
            {
                "Abbas", "Zohaib", "Osama", "Abdullah", "Wahid", "Faizan", "Yasir"
            };

            // The operators sorts the data based on the first letter/character of the string.
            // If the record/multiple data starts from the same characters, then it will go for the second character in the string.
            // And if the socond matches, then go for the third.

            var querySyntax = (from name in dataSource
                               orderby name descending
                               select name).ToList();

            var methodSyntax = dataSource.OrderByDescending(name => name).ToList();

            // With Where
            var qsWithWhere = (from name in dataSource
                               where name.Length > 5
                               orderby name descending
                               select name).ToList();

            var msWithWhere = dataSource.Where(name => name.Length > 5).OrderByDescending(name => name).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
        }

        public static void Example3()
        {
            List<Employee> dataSource = new()
            {
                new() {Id = 3, Name ="Abbas", Email="abbas@gmail.com"},
                new() {Id = 4, Name ="Ali", Email="ali@gmail.com"},
                new() {Id = 1, Name ="Ahmed", Email="ahmad@gmail.com"},
                new() {Id = 2, Name ="Umair", Email="umair@gmail.com"}
            };

            var querySyntax = (from data in dataSource
                               orderby data.Id descending
                               select data).ToList();

            // Sorting based on Name
            var nameSort = (from data in dataSource
                               orderby data.Name descending
                               select data).ToList();

            var methodSyntax = dataSource.OrderByDescending(data => data.Id).ToList();

            // With Where
            var qsWithWhere = (from data in dataSource
                               where data.Name.Length > 3
                               orderby data.Id descending
                               select data).ToList();

            var msWithWhere = dataSource.Where(data => data.Name.Length > 3).OrderByDescending(dataId => dataId.Id).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Email: {item.Email}");
            }
        }

        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
    
    public class SortingOperator_OrderByDescending
    {
        public static void Example()
        {
            //SortingOperator_OrderByDescending_13.Example1();
            //SortingOperator_OrderByDescending_13.Example2();
            SortingOperator_OrderByDescending_13.Example3();
        }
    }
}
