using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SortingOperators_OrderBy_12
    {
        // Sorting Operators - is ued to manage the data in a particular order
        // Order mat be ascending or descending.
        // We can sort the data based on different data types.

        // OrderBy() - method is used to sort the data in ascending order.
        // We can apply OrderBy() method on the different type of data.
        // orderby is available in both(query and method) syntax.

        public static void Example1()
        {
            var dataSource = new List<int>() { 9, 12, 3, 4, 6, 4, 3, 8, 3, 74, 32, 4, 8, 78, 65, 54, 2, 1, 2, 4, 6, 7, 8, 8, 8 };

            var querySyntax = from num in dataSource
                              orderby num
                              select num;

            var methodSyntax = dataSource.OrderBy(num => num).ToList();

            // With Where
            var querySyntaxWithWhere = from num in dataSource
                                       where num > 10
                                       orderby num
                                       select num;

            var methodSyntaxWithWhere = dataSource.Where(num => num > 8).OrderBy(num => num).ToList();

            foreach (var item in querySyntaxWithWhere)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void Example2()
        {
            var dataSource = new List<string>()
            {
                "Abbas", "Bilal", "Danish", "Ali", "Ahmed", "Usama", "Amir", "Faizan", "Qasim", "Zohaib"
            };

            var querySyntax = from alph in dataSource
                              orderby alph
                              select alph;

            var methodSyntax = dataSource.OrderBy(name => name).ToList();

            // With Where
            var querySyntaxWithWhere = from name in dataSource
                                       where name.Length > 5
                                       orderby name
                                       select name;

            var methodSyntaxWithWhere = dataSource.Where(name => name.Length > 5).OrderBy(name => name).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public static void Example3()
        {
            List<Employee> dataSource = new List<Employee>()
            {
                new() {Id = 3, Name ="Abbas", Email="abbas@gmail.com"},
                new() {Id = 4, Name ="Ali", Email="ali@gmail.com"},
                new() {Id = 1, Name ="Ahmed", Email="ahmad@gmail.com"},
                new() {Id = 2, Name ="Umair", Email="umair@gmail.com"}
            };

            var querySyntax = (from emp in dataSource
                              orderby emp.Id
                              select emp).ToList();

            var methodSyntax = dataSource.OrderBy(x => x.Name).ToList();

            // With Where
            var querySyntaxWithWhere = (from emp in dataSource
                                       where emp.Name.Length > 3
                                       orderby emp.Id
                                       select emp).ToList();

            var methodSyntaxWithWhere = dataSource.Where(name => name.Name.Length > 3).OrderBy(name => name.Id).ToList();

            
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

    public class SortingOperators_OrderBy
    {
        public static void Example()
        {
            // SortingOperators_OrderBy_12.Example1();
            // SortingOperators_OrderBy_12.Example2();
            SortingOperators_OrderBy_12.Example3();
        }

    }
}
