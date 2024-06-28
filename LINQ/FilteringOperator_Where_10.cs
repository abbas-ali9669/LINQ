using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class FilteringOperator_Where_10
    {
        // Filtering operator - Is used to filter someting and grab the desired data from a data source.
        // Filtering is the process to get only those data/element from a data source which satisfy a specified condition.
        // We can write more than one condition based on requirement.
        // There are two method available in LINQ for filtering.
        // 1. Where()
        // 1. OfType()

        // Where().
        // Where comes under the filtering operators.
        // Where is used to filter specific data from a dat source based on a condition.
        // Where always expects a condition.
        // Condition can written using following operator(==, >, <, ||, && etc) or custom condition.

        public static void Example1()
        {
            var dataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var querySyntax = from lessNum in dataSource
                              where lessNum < 5
                              select lessNum;

            var methodSyntax = dataSource.Where(data => data > 5);

            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }
        }
        
        public static void Example2()
        {
            var dataSource = new List<string> { "Abbas", "Ali", "Ahmed", "Arslan", "Faizan", "Bilal", "Abdullah" };

            var querySyntax = from lessNum in dataSource
                              where lessNum.Length > 5
                              select lessNum;

            var methodSyntax = dataSource.Where(data => data.Length < 5);

            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }
        }
        
        public static void Example3()
        {
            List<Employee> dataSource = new List<Employee>()
            {
                new() {Id = 1, Name ="Abbas", Email="abbas@gmail.com", Programming = new List<Tech>()
                {
                    new() { Technology = "PHP"},
                    new() { Technology = "JAVA"}
                }},
                new() {Id = 2, Name ="Ali", Email="ali@gmail.com", Programming = new List<Tech>()
                {
                    new() { Technology = "Python"},
                    new() { Technology = "C#"}
                }},
                new() {Id = 2, Name ="Ahmed", Email="ahmad@gmail.com", Programming = new List<Tech>()
                {
                    new() { Technology = "Javascript"},
                    new() { Technology = "SQL"}
                }},
                new() {Id = 2, Name ="Umair", Email="umair@gmail.com", Programming = new List<Tech>()}
            };



            var querySyntax = from lessNum in dataSource
                              where lessNum.Programming.Count > 1
                              select lessNum;

            var methodSyntax = dataSource.Where(data => data.Programming.Count == 0);

            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }
        }

        
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public List<Tech> Programming { get; set; }
        }

        class Tech
        {
            public string Technology { get; set; }
        }
    }
    
    class FilteringOperator_Where
    {
        public static void Example()
        {
            //FilteringOperator_Where_10.Example1();
            //FiteringOperator_Where_10.Example2();
            FilteringOperator_Where_10.Example3();
        }
    }
}
