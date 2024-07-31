namespace LINQ
{
    public class ImplementPagination_32
    {
        // Pagination - is the process of dividing the n number of records into multiple pages.
        // At per-page a certain number of record will be visible.
        // And the next record set can be visible with next.

        // Beneifts: 
        // Fast Travel (Because the less number of record will be travels)
        // Imporve memory management.
        // Easy to read
        // And the one drwaback is it increases the number request to the server.

        // Structure:
        // Paging can be implemented by using Linq
        // Skip() and Take() operator are the major operator in Pagination.
        
        // Formulas:
        // Suppose Total Pages => t
        // Number of Records per Page => n

        // ForIndex : Skip(index * n) Take(n)
        // For Pages : Skip((PageNumber - 1) * n) Take(n)

        public static void Example1()
        {
            int totalRecordPerPage = 4;

            Console.Write("Enter Page Number : ");
            if (int.TryParse(Console.ReadLine(), out int PageNumber))
            {
                var pagedData = GetEmployee()
                                   .Skip((PageNumber - 1) * totalRecordPerPage)
                                   .Take(totalRecordPerPage);

                // var pagedData = await data.Skip((filter.PageNumber - 1) * filter.PageSize ?? 0).Take(filter.PageSize ?? 0)
                //                                   .ProjectTo<GADTO>(_mapper.ConfigurationProvider).ToListAsync();

                foreach (var item in pagedData)
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Please Enter Valid Number.");
            }
        }
        
        // With infinite Loop.
        public static void Example2()
        {
            int totalRecordPerPage = 5;

            while (true)
            {
                Console.Write("Enter Page Number : ");
                if (int.TryParse(Console.ReadLine(), out int PageNumber))
                {
                    var pagedData = GetEmployee()
                                       .Skip((PageNumber - 1) * totalRecordPerPage)
                                       .Take(totalRecordPerPage);

                    // var pagedData = await data.Skip((filter.PageNumber - 1) * filter.PageSize ?? 0).Take(filter.PageSize ?? 0)
                    //                                   .ProjectTo<GADTO>(_mapper.ConfigurationProvider).ToListAsync();

                    foreach (var item in pagedData)
                    {
                        Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Number.");
                    break;
                }
            }
        }

        private static List<Employee> GetEmployee()
        {
            return new List<Employee>()
            {
                new (){ Id = 1, Name = "Abbas Ali" },
                new (){ Id = 2, Name = "Usama Khan" },
                new (){ Id = 3, Name = "Ahmed Ali" },
                new (){ Id = 4, Name = "Faizan Khan" },
                new (){ Id = 5, Name = "Arslan Khan" },
                new (){ Id = 6, Name = "Abdullah" },
                new (){ Id = 7, Name = "Bilal Kareem" },
                new (){ Id = 8, Name = "Ali Akbar" },
                new (){ Id = 9, Name = "Muneeb Swati" },
                new (){ Id = 10, Name = "Waqas Shah" },
                new (){ Id = 11, Name = "Hamza Khan" },
                new (){ Id = 12, Name = "Shahab" },
                new (){ Id = 13, Name = "Mudassar Khan" },
                new (){ Id = 14, Name = "Abdur Rehman" },
                new (){ Id = 15, Name = "Qasim Ali" },
                new (){ Id = 16, Name = "Ubaidullah" },
                new (){ Id = 17, Name = "Ahsan" },
                new (){ Id = 18, Name = "Umair" },
                new (){ Id = 19, Name = "Mubashar" },
                new (){ Id = 20, Name = "Danish" },
            };
        }

        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
    
    public class ImplementPagination
    {
        public static void Example()
        {
            //ImplementPagination_32.Example1();
            ImplementPagination_32.Example2();
        }
    }
}
