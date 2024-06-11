using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class HowLINQWorks_2
    {
        // So in this lecture we will see how LINQ works.
        // How it interacts with the various data sources.

        // .Net Language(Any) --> LINQ --> (InMemoryObjects, EntityFramework, XMLDocument, SQLDatabase, OtherSources).

        // But how LINQ Knows the every langauge ?
        // Because there is a LINQ provider for each data source with manipulate the LINQ Query to the specified query language.

        // Some LINQ Providers.
        // LINQ to Object
        // LINQ to Entity
        // LINQ to XML 
        // LINQ to SQL etc

        // .Net Language(Any) --> LINQ --> (LINQ Provider) --> (InMemoryObjects, EntityFramework, XMLDocument, SQLDatabase, OtherSources).

        // .Net Language(Any) --> LINQ --> (LINQ to Entity) --> (EntityFramework).
        // .Net Language(Any) --> LINQ --> (LINQ to SQL) --> (SQLDatabase).
        // .Net Language(Any) --> LINQ --> (LINQ to Object) --> (InMemoryObject) etc.

        // A LINQ provider is software that implements the IQueryProvider and IQueryable interfaces for a particular data store.
        // In simple words, it allows you to write LINQ queries against that data store.
    }
}
