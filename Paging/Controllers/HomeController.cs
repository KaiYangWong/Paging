using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Paging.Models;

namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        //指定每一頁要顯示的資料筆數
        int pageSize = 10;
        
        //預設為顯示第一頁
        public ActionResult Index(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            var customers = db.客戶.OrderBy(m => m.客戶編號).ToList();
            var result = customers.ToPagedList(currentPage,pageSize);
            return View(result);
        }
    }
}