using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
    public class AdventureWorksModel
    {
        public IEnumerable<DatabaseLog> databaseLogs;
        public int PageSize = 15;
        public int PageCount = 0;
        public int CurrentIndex = 0;
        public int PageNumber = 1;
    }
}