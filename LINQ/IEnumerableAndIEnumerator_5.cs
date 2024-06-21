using System.Collections;

namespace LINQ
{
    public class IEnumerableAndIEnumerator_5
    {
        // IEnumerable
        // When we use collections in C# we need to iterate the items of the collection by using foreach loop.
        // In C#, IEnumerable is an interface and it is usefull to enable an iteration over generic and non-generic collections.
        // Every collection class whether it is generic or non-generic collection implements IEnumerable Interface.
        // IEnumerable in C#, is an interface that defines one method GetEnumerator which returns an IEnumerator interface.
        // This allows readonly access to a collection then a collection that implements IEnumerable can be used with a foreach statement.


        // Every collection class implements three interfaces.
        // 1. IEnumerable
        // 2. ICollection
        // 3. IList(if index based) or IDictionary(if key value pair base).

        // List, Array, ArrayList -> IEnumerable, ICollection, IList
        // Dictionary, HashTable -> IEnumerable, ICollection, IDictionary

        // IList Collections
        List<int> list;
        ArrayList list2;

        // IDictionary Collections
        Dictionary<int, int> dict;
        Hashtable hash;

        // IEnumerator
        // The IEnumerator interface in C# is used to iterate over a collection of objects. It is part of the System.Collections namespace.
        // The IEnumerator interface provides the mechanism to traverse through a collection, and it defines three key members:

        // 1. MoveNext()
        // Purpose: Advances the enumerator to the next element of the collection.
        // Returns: bool - true if the enumerator successfully advanced to the next element; false if the enumerator has passed the end of the collection.

        // 2. Current
        // Purpose: Gets the element in the collection at the current position of the enumerator.
        // Type: object - Represents the current element in the collection.
        // Usage: Access this property after calling MoveNext() to get the element at the current position.

        // 3. Reset()
        // Purpose: Sets the enumerator to its initial position, which is before the first element in the collection.
        // Returns: void
        // Usage: Typically used to restart the iteration over the collection.

    }
}
