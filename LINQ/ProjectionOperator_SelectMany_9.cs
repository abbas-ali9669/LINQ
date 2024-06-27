using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ProjectionOperator_SelectMany_9
    {
        // In this lecture we will discuss about the socond projection operator called "SelecrMany()".
        // SelectMany() is used to projects each element of a sequence to an IEnumerable<T> and flatten the resulting into one sequence.
        // SelectMany() combines records from a sequence of result and convert it into one result.
        // SelectMany() comes under the projection category.


        public static void Example1()
        {
            List<string> strings = new List<string> { "Abbas", "Ali" };

            var methodSyntax = strings.SelectMany(x => x).ToList();

            // There is no such case in the query syntax because there is no "selectmany" keyword inside query.
            var querySyntax = (from str in strings
                               from nestStr in str
                               select nestStr).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
        }


        public static void Example2()
        {
            List<Employee> employees = new List<Employee>()
            {
                new() {Id = 1, Name ="Abbas", Email="abbas@gmail.com", Programming = new List<string>{"Python", "JAVA", "C#"}},
                new() {Id = 2, Name ="Ali", Email="ali@gmail.com", Programming = new List<string>{"Javascript", "SQL", "HTML"}},
                new() {Id = 2, Name ="Ahmed", Email="ahmad@gmail.com", Programming = new List<string>{"PHP", "Bootstrap", "CSS"}},
            };

            var methodSyntax = employees.SelectMany(emp => emp.Programming).ToList();

            var querySyntax = (from emp in employees
                              from skill in emp.Programming
                              select skill).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
        }

        public static void Example3()
        {
            List<Employee2> employees = new List<Employee2>()
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
                } },
                new() {Id = 2, Name ="Ahmed", Email="ahmad@gmail.com", Programming = new List<Tech>() 
                {
                    new() { Technology = "Javascript"},
                    new() { Technology = "SQL"}
                }}
            };

            var methodSyntax = employees.SelectMany(emp => emp.Programming).ToList();

            var querySyntax = (from emp in employees
                              from skill in emp.Programming
                              select skill).ToList();

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
            public List<string> Programming { get; set; }
        }
        
        class Employee2
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

    class ProjectionOperator_SelectMany
    {
        public static void Example()
        {
            // ProjectionOperator_SelectMany_9.Example1();
            // ProjectionOperator_SelectMany_9.Example2();
            ProjectionOperator_SelectMany_9.Example3();
        }
    }
}
