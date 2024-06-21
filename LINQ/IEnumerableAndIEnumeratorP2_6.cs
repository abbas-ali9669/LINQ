using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class IEnumerableAndIEnumeratorP2_6
    {
        // We have IEnumerable generic collection as well as non-generic collection
        // Generic IEnumerable interface contains in the System.Collection.Generic namespace.
        // Non-Generic IEnumerable interface contains in the System.Collection namespace.
        // IEnumerable interface is a generic interface which allows looping over generic and non-generic collections.
        // IEnumerable interface also works with LINQ query expression.
        // IEnumerable interface returns an enumerator that iterates through the collection.
        // Enumerator means counter.

        static List<int> listOfInt = new List<int>() { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

        // Difference between the iteration of IEnumerable and IEnumerator iteration
        public static void Example1()
        {
            // NOTE - Behind the scene IEnumerable uses IEnumerator
            // But for ease of use we have an IEnumerable.

            // IEnmerable Iteration
            Console.WriteLine("IEnumerable");
            foreach (int item in listOfInt)
            {
                Console.WriteLine(item);
            }

            // IEnumerator Iteration
            // First we have to get the method "GetEnumerator()"
            IEnumerator<int> nums = listOfInt.GetEnumerator();

            // Then loop through the IEnumerator instance using while loop
            Console.WriteLine("IEnumerator");
            while (nums.MoveNext())
            {
                Console.WriteLine(nums.Current.ToString());
            }
            // The result for both of them are same.
            // But while using IEnumerator we have to manage everything inside the IEnumerator contains.
            // Therefore we use IEnumerable for ease of use.
        }

        // IEnumerable and IEnumerator are both interfaces.
        // IEnumerable has just one method "GetEnumerator()". This method returns another type which is an interface called "IEnumerator".
        // If we want to implement enumrator logic in any collection class, it needs to implement IEnumerable interface (Either generic or non-generic).
        // IEnumerable has just one method "GetEnumerator()", whereas IEnumerator has two methods (MoveNet() and Reset()) and a property called "Current".
        // IEnumerable is most preferable.
        // It has a method called GetEnumerator which gives you an Enumerator that looks at its items.
        // When you write a foreach loop in C#, the code that is generates calls GetEnumerator to create the Enumerator used by the loop.
        // The IEnumerable interface actually uses IEnumerator internally.
        // The main reason to create the IEnumerable is to make the syntax shorter and simpler.

        // IMPORTANT
        // The main Difference between IEnumerable and IEnumerator is an IEnumerator retains its cursor's current state.

        // Statae Examples.
        // Exmaple - IEnumerator
        static void IEnumeratorState(IEnumerator<int> para)
        {
            while (para.MoveNext())
            {
                Console.WriteLine(para.Current);
                if (para.Current == 44)
                {
                    IEnumeratorState2(para);
                }
            }
        }
        
        static void IEnumeratorState2(IEnumerator<int> para)
        {
            while (para.MoveNext())
            {
                Console.WriteLine(para.Current);
            }
        }

        // Example 2 - IEnumerable
        static void IEnumerableState(IEnumerable<int> para)
        {
            foreach (var item in para)
            {
                Console.WriteLine(item);
                if (item == 44)
                {
                    IEnumerableState2(para);
                }
            }
        }

        static void IEnumerableState2(IEnumerable<int> para)
        {
            foreach (var item in para)
            {
                Console.WriteLine(item);
            }
        }

        // For calling methods.
        public static void CallState()
        {
            //IEnumeratorState(listOfInt.GetEnumerator());
            IEnumerableState(listOfInt);

            // Now the behaviour of both the States are are totally different.
            // The IEnuerator remembers the state of cursor, whereas IEnumerable doesn't.
        }

    }

    class IEnumerableAndIEnumerator
    {
        public static void Example()
        {
            //IEnumerableAndIEnumeratorP2_6.Example1();
            IEnumerableAndIEnumeratorP2_6.CallState();
        }
    }
}
