using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class IEnumerableVsIQueryable_7
    {
        // A we have already discuused IEnumerable and IQueryable.
        // But in this lecture we will pnly focus on major differences between these both of them.

        // These both of them are interfaces.
        // IEnumerable and IQueryable are used for data manipulation in LINQ from the database and collection.
        // IQueryable is inherited by the IEnumerable, Hence IQueryable hasall the features that IEnumerable has, except IQueryable has its own.
        // Both have their own importance to query and manipulate data.
        
        // Major Difference.
        // If we grab the data from database, the IEnumerable first grab all the data from the database to the memory.
        // Aand then filters the data inside the memory. Means client side filtering
        // Which causes alot of memory consumption.
        
        // But IQueryable has totally different baheviour.
        // It creates the query and execute that query on the server side not memory.
        // And grab only filtered data to the memory.
        // Which causes less memory consumption.

        // Hence:
        // IEnumerable is best for only work with in memory objects like; List, Array, ArrayList etc.
        // IQueryable is best for for only working with external data source like; SQL, MYSQL, etc.
    }
}
