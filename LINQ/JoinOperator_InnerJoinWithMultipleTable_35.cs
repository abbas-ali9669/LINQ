using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class JoinOperator_InnerJoinWithMultipleTable_35
    {
        // So, along with the previous Example, We will add one more table inside it and will see how it works.
        private static List<Student> students = new()
        {
            new(){ Id = 1, Name = "Abbas" },
            new(){ Id = 2, Name = "Bilal" },
            new(){ Id = 3, Name = "Ahmed" },
            new(){ Id = 4, Name = "Faizan" },
            new(){ Id = 5, Name = "Usama" },
        };

        private static List<Address> addresses = new()
        {
            new(){ Id = 1, StudentId = 1, StdAddress = "Mansehra" },
            new(){ Id = 2, StudentId = 2, StdAddress = "Dubai" },
            new(){ Id = 3, StudentId = 3, StdAddress = "Abbottabad" },
            new(){ Id = 4, StudentId = 4, StdAddress = "Uggi" },
            new(){ Id = 5, StudentId = 5, StdAddress = "Balakot" },
        };
        
        private static List<Marks> marks = new()
        {
            new(){ Id = 1, StudentId = 1, SubjMarks = 75 },
            new(){ Id = 2, StudentId = 3, SubjMarks = 81 },
            new(){ Id = 3, StudentId = 5, SubjMarks = 68 },
        };

        public static void Example1()
        {
            // Query Syntax
            var querySyntax = (from std in students   // Join with first source
                               join addr in addresses
                               on std.Id equals addr.StudentId
                               join mark in marks   // Join with the second source
                               on std.Id equals mark.StudentId
                               select new
                               {
                                   Name = std.Name,
                                   Address = addr.StdAddress,
                                   Marks = mark.SubjMarks
                               }).ToList();


            // Method Syntax
            var methodSyntax = students.Join(addresses,    // Join with first source
                                std => std.Id,
                                addr => addr.StudentId,
                                (s, a) => new { s, a })
                                .Join(marks,   // Join with the second source
                                std => std.s.Id,
                                mark => mark.StudentId,
                                (s, m) => new {s, m})   // Now here we have to select the properties hierarchy wise
                                .Select(sel => new
                                {
                                    // Now here we have to select the properties hierarchy wise
                                    Name = sel.s.s.Name,
                                    Address = sel.s.a.StdAddress,
                                    Marks = sel.m.SubjMarks
                                }).ToList();

        }
        
        // With Filters
        public static void Example2()
        {
            // Query Syntax
            var querySyntax = (from std in students   // Join with first source
                               where std.Id == 1
                               join addr in addresses
                               on std.Id equals addr.StudentId
                               join mark in marks   // Join with the second source
                               on std.Id equals mark.StudentId
                               select new
                               {
                                   Name = std.Name,
                                   Address = addr.StdAddress,
                                   Marks = mark.SubjMarks
                               }).ToList();


            // Method Syntax
            var methodSyntax = students.Where(x => x.Id == 3)
                                .Join(addresses,    // Join with first source
                                std => std.Id,
                                addr => addr.StudentId,
                                (s, a) => new { s, a })
                                .Join(marks,   // Join with the second source
                                std => std.s.Id,
                                mark => mark.StudentId,
                                (s, m) => new {s, m})   // Now here we have to select the properties hierarchy wise
                                .Select(sel => new
                                {
                                    // Now here we have to select the properties hierarchy wise
                                    Name = sel.s.s.Name,
                                    Address = sel.s.a.StdAddress,
                                    Marks = sel.m.SubjMarks
                                }).ToList();

        }


        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Address
        {
            public int Id { get; set; }
            public int? StudentId { get; set; }
            public string StdAddress { get; set; }
        }

        class Marks
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int SubjMarks { get; set; }
        }
    }
    
    public class JoinOperator_InnerJoinWithMultipleTable
    {
        public static void Example()
        {
            //JoinOperator_InnerJoinWithMultipleTable_35.Example1();
            JoinOperator_InnerJoinWithMultipleTable_35.Example2();
        }
    }
}
