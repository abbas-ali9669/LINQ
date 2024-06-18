using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class IEnumerableAndIQueryable_4
    {
        // IEnumerable - is an interface uses to iterate and query the in-memory object.
        // IEnumerable is best for iterating the collection like list, array, Dictionary etc.
        // IEnumerable is available in System.Collection namespace.
        // All the Collections in C# implememnts IEnumerable.
        // This interface is a type of iteration design pattern.
        // So, Because of this interface we can iterate(Foreach) over the collection.
        // IEnumerable also has a child for generic classes IEnumerable<T>.
        // IEnumerable/IEnumerable<T> should be used for in memory data objects.


        public static void IenumerableExample()
        {
            // Every collection is derived from IEnumerable interface.(This List also).
            List<Employee> employees = new()
            {
                new() {Id=1, Name="Abbas"},
                new() {Id=2,Name="Ahmad"}
            };

            // NOTE - The "Where()" method of both IEnumerable and IQueryable is different.
            IEnumerable<Employee> query = from emp in employees
                                          where emp.Id == 1
                                          select emp;
            foreach (var item in query)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
        }

        // IQueryable.
        // IQueryable is also an interface, which inherits the IEnumerable interface.(Child of an IEnumerable).
        // IQueryble is present in the System.Linq namespace.
        // IQueryable has a property which is of type IQueryProvider interface. And it is used n LinqProvider.
        // The IQueryable is used query over the data which comes from external data source (SQL, MYSQL, etc).
        // The benefit of using IQueryable is, is taht execute on the server side
        // While IEnumerable executes the collection inside the system memory.

        public static void IQueryableExample()
        {
            List<Employee> employees = new()
            {
                new() {Id=1, Name="Abbas"},
                new() {Id=2,Name="Ahmad"}
            };

            IQueryable<Employee> query = employees.AsQueryable().Where(x => x.Id == 2);

            foreach (var item in query)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
        }

        // Difference Between IQueryable and IEnumerble.
        // IEnumerable first grab all the data into the system memory and then filters it.
        // While the IQueryable filter all the data on server side then grab into the memory.
        // Therefore IEnumerable is best for iterating the in memory object.
        // And IQuerable is best for the external data source.

        // Complex Type class
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }

    class IEnumerableAndIQueryable
    {
        public static void Example()
        {
            // IEnumerableAndIQueryable_4.IenumerableExample();
            IEnumerableAndIQueryable_4.IQueryableExample();
        }
    }
}
