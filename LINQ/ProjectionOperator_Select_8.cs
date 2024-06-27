using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ProjectionOperator_Select_8
    {
        // Projection is used to select tha data from a data source and cretaing a new form of data.
        // We can select the original data in its original state also in other form by applying some operator on it.
        // There are two method of Projection 
        // 1. Select()
        // 2. SelectMany()

        // We will see the Select() in this lecture.
        static List<Employee> employees = new()
        {
            new Employee{ Id = 1, Name = "Abbas", Email = "abbas.ali@gmail.com" },
            new Employee{ Id = 2, Name = "Ahmad", Email = "ahmad.khan@gmail.com" },
            new Employee{ Id = 3, Name = "Usama", Email = "usama.khan@hotmail.com" },
            new Employee{ Id = 4, Name = "Muneeb", Email = "muneeb.ali@outlook.com" }
        };

        // Basic Select
        public static void BasicSelect()
        {
            var querySyntax = from emp in employees
                              select emp;

            var methodSyntax = employees.ToList();

            foreach (var item in methodSyntax)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Email: {item.Email}");
            }
        }

        // Select one column/property form class
        public static void SelectOne()
        {
            var querySyntax = from emp in employees
                              select emp.Id;

            // We can also perform some actions on the selection (optional).
            var querySyntax2 = (from emp in employees
                                select emp.Id).ToList();

            var querySyntax3 = (from emp in employees
                                select emp.Id + 1).ToList();

            var querySyntax4 = (from emp in employees
                                select emp.Id.ToString()).ToList();

            var methodSyntax = employees.Select(x => x.Id).ToList();

            foreach (var item in querySyntax4)
            {
                Console.WriteLine($"Id: {item}");
            }
        }

        // Selecting two or more properties
        public static void SelectTwoOrMore()
        {
            var querySyntax = (from emp in employees
                               select new Employee
                               {
                                   Id = emp.Id,
                                   Name = emp.Name
                               }).ToList();

            var methodSyntax = employees.Select(emp => new Employee
            {
                Id = emp.Id,
                Name = emp.Name
            }).ToList();

            // We can also use the other class object here
            var querySyntaxWithOtherClass = (from emp in employees
                                             select new Student()
                                             {
                                                 StdName = emp.Name,
                                                 StdEmail = emp.Email
                                             }).ToList();

            var methodSyntaxWithOtherClass = employees.Select(emp => new Student()
            {
                StdName = emp.Name,
                StdEmail = emp.Email
            }).ToList();

            // And at the last we can also use anonymous object.
            // It returns the List<a(anonymous)>.

            var querySyntaxWithAnonymousObject = (from emp in employees
                                                  select new
                                                  {
                                                      EmployeeName = emp.Name,
                                                      EmployeeEmail = emp.Email
                                                  }).ToList();

            var methodSyntaxWithAnonymousObject = employees.Select(emp => new
            {
                EmployeeName = emp.Name,
                EmployeeEmail = emp.Email
            }).ToList();

            foreach (var item in methodSyntaxWithAnonymousObject)
            {
                Console.WriteLine($"Name: {item.EmployeeName}, Email: {item.EmployeeEmail}");
            }
        }

        // Getting index of each prop
        public static void GetIndex()
        {
            var methodSyntax = employees.Select((emp, index) => new { Index = index, FullName = emp.Name }).ToList();
            foreach (var item in methodSyntax)
            {
                Console.WriteLine($"Index: {item.Index}, Name: {item.FullName}");
            }
        }


        // Entity Class.
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        class Student
        {
            public int Id { get; set; }
            public string StdName { get; set; }
            public string StdEmail { get; set; }
        }
    }

    class ProjectionOperator_Select
    {
        public static void Example()
        {
            //ProjectionOperator_Select_8.BasicSelect();
            // ProjectionOperator_Select_8.SelectOne();
            //ProjectionOperator_Select_8.SelectTwoOrMore();
            ProjectionOperator_Select_8.GetIndex();
        }
    }
}
