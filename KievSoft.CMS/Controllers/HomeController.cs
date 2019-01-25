using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DBHelpers;
using KievSoft.CMSLib;

namespace KievSoft.CMS.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var db = new DBHelper("KievCMSConnect");
            //var ids = await db.ExecuteScalarAsync<int>("select * from Users");
            //var list = db.ExecuteListAsync("select * from Users", r => new {
            //    UserId = r.Get<int>("UserId"),
            //    UserName = r.Get<string>("UserName"),
            //    Password = r.Get<string>("Password")
            //});
            var command = db.GetStoredProcCommond("Users_GetPage");
            db.AddInParameter(command, "UserId", DbType.Int32, 0);
            db.AddOutParameter(command, "RowCount", DbType.Int32, 0);
            List<Users> list = null;

            using (DbConnection connection = db.CreateConnection())
            {
                await connection.OpenAsync();

                using (DbDataReader reader = await db.ExecuteReaderAsync(command, connection))
                {
                    while (await reader.ReadAsync())
                    {
                        string col1 = (string)reader["UserName"];
                        //list.Add(Converter<DbDataReader, Users>(reader));
                    }

                    reader.Close();
                }

                connection.Close();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}