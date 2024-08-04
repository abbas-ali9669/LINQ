

namespace LINQ
{
    public class JoinOperator_GroupJoin_36
    {
        // Groupjoin - is used to combine two or more than tow data sources absed on a common key.
        // Group join is usef ull when you work in the data which has the categories.
        // And you have to divide/structure the data based on a specific key

        private static List<Particpant> particpants = new List<Particpant>
        {
            new (){ Id = 1, Name = "Abbas", NationalityId = 1 },
            new (){ Id = 2, Name = "Faizan", NationalityId = 1 },
            new (){ Id = 3, Name = "Usama", NationalityId = 1 },
            new (){ Id = 4, Name = "Rizwan", NationalityId = 2 },
            new (){ Id = 5, Name = "Nitish", NationalityId = 3 },
            new (){ Id = 6, Name = "Bilal", NationalityId = 4 },
            new (){ Id = 7, Name = "Shani", NationalityId = 4 },
            new (){ Id = 8, Name = "Wajahat", NationalityId = 5 },
        };
        
        
        private static List<PartNationality> Nationalities = new List<PartNationality>
        {
            new (){ Id = 1, Nationality = "Pakistani" },
            new (){ Id = 2, Nationality = "Saudi Arabian" },
            new (){ Id = 3, Nationality = "Indian" },
            new (){ Id = 4, Nationality = "Dubai" },
            new (){ Id = 5, Nationality = "American" },
        };

        public static void Example1()
        {
            // Method Syntax
            // For group join we have to make our outer data source is LOVS.
            // This is the rule/convention to divide it by.

            var methodSynatx = Nationalities.GroupJoin(particpants,
                                             cat => cat.Id,
                                             part => part.NationalityId,
                                             (cat, part) => new { cat, part }).ToList();

            //foreach (var item in methodSynatx)
            //{
            //    Console.WriteLine($"Nationlaity : {item.cat.Nationality}");
            //    foreach (var innertItem in item.part)
            //    {
            //        Console.WriteLine($"\tName : {innertItem.Name}");
            //    }
            //}

            var querySyntax = (from nat in Nationalities
                               join part in particpants
                               on nat.Id equals part.NationalityId
                               into partGroup   // There is no GorupJoin method/keyword in querysyntax. PartGroup will be consider as Participants.
                               select new { nat, partGroup });

            foreach (var item in querySyntax)
            {
                Console.WriteLine($"Nationlaity : {item.nat.Nationality}");
                foreach (var innerItem in item.partGroup)
                {
                    Console.WriteLine($"\tName : {innerItem.Name}");

                }
            }
        }


        class Particpant
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int NationalityId { get; set; }
        }

        class PartNationality
        {
            public int Id { get; set; }
            public string Nationality { get; set; }
        }
    }

    public class JoinOperator_GroupJoin
    {
        public static void Example()
        {
            JoinOperator_GroupJoin_36.Example1();
        }
    }
}
