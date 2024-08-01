using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class JoinOperator_InnerJoin_34
    {

        // Inner Join - produces a result set in which each elememt of the first collection appears one time for every element in the second collection.
        // If an element in the first collection has no matching element, it does not appear in the result.
        // In simple words, the inner join is about, Elements which has a common properties in both the dara sources.

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

        public static void Example1()
        {
            // QuerySyntax
            var querySyntax = (from std in students   // Called Outer source
                              join addr in addresses   // called inner source
                              on std.Id equals addr.StudentId    // join condition
                              select new
                              {
                                  Name = std.Name,
                                  Address = addr.StdAddress
                              }).ToList();

            // Parameters
            // public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector);

            // Method Syntax
            var methodSyntax = students.Join(addresses,   // Inner Source
                                        std => std.Id,   // Outer Selector
                                        addr => addr.StudentId,   // Inner Selector
                                        (std, addr) => new   // Result Selector
                                        {
                                            Name = std.Name,
                                            Address = addr.StdAddress
                                        }).ToList();
        }

        // With Filtering
        public static void Example2()
        {
            // QuerySyntax
            var querySyntax = (from std in students   // Called Outer source
                              where std.Id == 1
                              join addr in addresses   // called inner source
                              on std.Id equals addr.StudentId    // join condition
                              select new
                              {
                                  Name = std.Name,
                                  Address = addr.StdAddress
                              }).ToList();

         
            // Method Syntax
            var methodSyntax = students.Where(std => std.Id == 1)
                                        .Join(addresses,   // Inner Source
                                        std => std.Id,   // Outer Selector
                                        addr => addr.StudentId,   // Inner Selector
                                        (std, addr) => new   // Result Selector
                                        {
                                            Name = std.Name,
                                            Address = addr.StdAddress
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
    
    public class JoinOperator_InnerJoin
    {
        public static void Example()
        {
            //JoinOperator_InnerJoin_34.Example1();
            JoinOperator_InnerJoin_34.Example2();
        }
    }
}
