using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecordManagementSystem.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=(LocalDb)/MSSQLLocalDB; Initial Catalog=OLX_DB";
        public static string CName
        {
            get => cName;
        }
    }
}