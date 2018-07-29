using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace AdventureWorks.Controllers
{
    public class AdventureWorksController : Controller
    {
        // GET: AdventureWorks
        //public ActionResult Index(string Sorting_Order, int? Page_No)
        //{
        //    // var adventureWorksModel = new AdventureWorksModel();
        //    ViewBag.CurrentSortOrder = Sorting_Order;
        //    ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "DatabaseLogID" : "";
        //    ViewBag.SortingDate = Sorting_Order == "DatabaseUser" ? "Date_Description" : "Date";

        //    var databaselogs = new List<DatabaseLog>();
        //    string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString.ToString();
        //    SqlConnection oMySqlConnection = new SqlConnection(connectionString);
        //    oMySqlConnection.Open();
        //    SqlCommand command = new SqlCommand("SELECT [DatabaseLogID],[DatabaseUser],[Event],[Schema],[Object],[TSQL]  FROM  dbo.DatabaseLog",oMySqlConnection);
        //    SqlDataReader oMySqlDataReader = command.ExecuteReader();
        //    while (oMySqlDataReader.Read())
        //    {
        //        databaselogs.Add(new DatabaseLog
        //        {
        //            DatabaseLogID = oMySqlDataReader["DatabaseLogID"].ToString(),
        //            DatabaseUser = oMySqlDataReader["DatabaseUser"].ToString(),
        //            Event = oMySqlDataReader["Event"].ToString(),
        //            Schema = oMySqlDataReader["Schema"].ToString(),
        //            Object = oMySqlDataReader["Object"].ToString(),
        //            TSQL = oMySqlDataReader["TSQL"].ToString()
        //        });
        //    }

        //    var data  = from stu in databaselogs select stu;
        //    int No_Of_Page = 1;
        //    oMySqlConnection.Close();
        //    return View(data.ToPagedList(No_Of_Page, 15));

        //}


        public ActionResult Index(string sortOrder, string CurrentSort, int? page, int? pageSize)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            // int pageSize = 15;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            //Ddefault size is 5 otherwise take pageSize value  
            int defaSize = (pageSize ?? 15);
            ViewBag.psize = defaSize;

            ViewBag.PageSize = new List<SelectListItem>()
             {
                 new SelectListItem() { Value="5", Text= "5" },
                 new SelectListItem() { Value="10", Text= "10" },
                 new SelectListItem() { Value="15", Text= "15" },
                 new SelectListItem() { Value="25", Text= "25" },
                 new SelectListItem() { Value="50", Text= "50" },
             };


            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "DatabaseLogID" : sortOrder;
            IPagedList<DatabaseLog> databaseLogs = null;
            switch (sortOrder)
            {
                case "DatabaseLogID":
                    if (sortOrder.Equals(CurrentSort))
                        databaseLogs = db.databaseLogs.OrderByDescending
                                (m => m.DatabaseLogID).ToPagedList(pageIndex, defaSize);
                    else
                        databaseLogs = db.databaseLogs.OrderBy
                                (m => m.DatabaseLogID).ToPagedList(pageIndex, defaSize);
                    break;
                case "DatabaseUser":
                    if (sortOrder.Equals(CurrentSort))
                        databaseLogs = db.databaseLogs.OrderByDescending
                                (m => m.DatabaseUser).ToPagedList(pageIndex, defaSize);
                    else
                        databaseLogs = db.databaseLogs.OrderBy
                                (m => m.DatabaseUser).ToPagedList(pageIndex, defaSize);
                    break;
                case "Event":
                    if (sortOrder.Equals(CurrentSort))
                        databaseLogs = db.databaseLogs.OrderByDescending
                                (m => m.Event).ToPagedList(pageIndex, defaSize);
                    else
                        databaseLogs = db.databaseLogs.OrderBy
                                (m => m.Event).ToPagedList(pageIndex, defaSize);
                    break;
                case "Schema":
                    if (sortOrder.Equals(CurrentSort))
                        databaseLogs = db.databaseLogs.OrderByDescending
                                (m => m.Schema).ToPagedList(pageIndex, defaSize);
                    else
                        databaseLogs = db.databaseLogs.OrderBy
                                (m => m.Schema).ToPagedList(pageIndex, defaSize);
                    break;
                case "Object":
                    if (sortOrder.Equals(CurrentSort))
                        databaseLogs = db.databaseLogs.OrderByDescending
                                (m => m.Object).ToPagedList(pageIndex, defaSize);
                    else
                        databaseLogs = db.databaseLogs.OrderBy
                                (m => m.Object).ToPagedList(pageIndex, defaSize);
                    break;
                case "TSQL":
                    if (sortOrder.Equals(CurrentSort))
                        databaseLogs = db.databaseLogs.OrderByDescending
                                (m => m.TSQL).ToPagedList(pageIndex, defaSize);
                    else
                        databaseLogs = db.databaseLogs.OrderBy
                                (m => m.TSQL).ToPagedList(pageIndex, defaSize);
                    break;
                case "Default":
                    databaseLogs = db.databaseLogs.OrderBy
                        (m => m.DatabaseLogID).ToPagedList(pageIndex, defaSize);
                    break;
            }
            return View(databaseLogs);
        }
    }
}