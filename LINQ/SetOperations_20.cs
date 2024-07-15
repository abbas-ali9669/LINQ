using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LINQ
{
    public class SetOperations_20
    {
        // Set operations in LINQ (Language Integrated Query) are used to perform operations on sets of data.
        // These operations include finding the union, intersection, difference, and distinct elements of collections
        // Set operations are used for those query operations that produces result set based on presence and absense of element within same or second data source.

        // There are five types of set operations
        // 1. Distinct() - Removes duplicate values from data source
        // The Distinct method returns distinct elements from a collection, removing any duplicates.

        // 2. Except() - Return all the elements form one data source that do not exist in second data source.
        // The Except method produces the set difference of two sequences, which includes the elements of the first sequence that do not appear in the second sequence.

        // 3. Intersect() - Return all the elements which exist in both the data sources.
        // The Intersect method produces the set intersection of two sequences, which includes only the elements that are present in both collections.

        // 4. Union () - Returns all the elements that appear in either of two data sources.
        // The Union method produces the set union of two sequences, which includes all unique elements from both collections.

        // 5. Concat() - The Concat method concatenates two sequences, essentially appending the second sequence to the first. Unlike Union, Concat does not remove duplicates.
    }

    public class SetOperations
    {
    }
}
