using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class JoinOperator_LeftOrLeftOuterJoin_37
    {
        // In Left or Left Outer Join - all the data from first data source is returned, regardless of whether it has any related data in the second data source.
        // If all or few, if the data is not available in th second data source then nbull value will be returned for the second data source.
        // Left or Left Outer Join, both are same, Outer keyword is optional.
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
            new(){ Id = 3, StudentId = null, StdAddress = "Abbottabad" },
            new(){ Id = 4, StudentId = 4, StdAddress = "Uggi" },
            new(){ Id = 5, StudentId = null, StdAddress = "Balakot" },
        };

        public static void Example1()
        {
            // QuerySyntax
            var querySyntax = (from std in students
                               join addr in addresses
                               on std.Id equals addr.StudentId
                               into stdaddress   // Till yet the normal join is applying, now from here we will apply left join on it.
                               from address in stdaddress.DefaultIfEmpty()  // This method will work with references, if the reference is empty it will assign null. it helps prevent errors.
                               //select new { std, address }).ToList();
                               select new { StudentName = std.Name, StudentAddress = address != null ? address.StdAddress : null }).ToList();

            // MethodSyntax
            var methodSyntax = students.GroupJoin(addresses,
                                        std => std.Id,
                                        addr => addr.StudentId,
                                        (std, addr) => new { std, addr })
                                        .SelectMany(x => x.addr.DefaultIfEmpty(),
                                        (student, address) => new
                                        //{
                                        //    student.std,
                                        //    address
                                        //}).ToList();
                                        {
                                            StudentName = student.std.Name,
                                            StudentAddress = address != null ? address.StdAddress : null
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
    }

    public class JoinOperator_LeftOrLeftOuterJoin
    {
        public static void Example()
        {
            JoinOperator_LeftOrLeftOuterJoin_37.Example1();
        }
    }
}
