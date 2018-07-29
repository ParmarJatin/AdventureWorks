using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
    public class DatabaseLog
    {
        public string DatabaseLogID;
        public string DatabaseUser;
        public string Event;
        public string Schema;
        public string Object;
        public string TSQL;
        //public int PageCount;
        //public int PageSize = 15;
        //public int currentIndex = 0;
    }
}