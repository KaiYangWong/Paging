### 說明:
* 這裡我使用LocalDB，所以只要將這個專案下載下來，就可以直接執行專案來看執行的結果
* 使用Northwind的客戶資料表

### 分頁:
* 分頁是使用第三方套件PagedList.Mvc
* 於NuGet套件管理中就可以下載

### 步驟:

HomeController.cs
```
using PagedList;
using Paging.Models;
```
```
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
```
* 在Controller中要記得加入引用
* 指定預設分頁是在第一頁

Index.cshtml
```
@using PagedList
@using PagedList.Mvc
@model IPagedList<Paging.Models.客戶>
```
```
@Html.PagedListPager(Model,page=>Url.Action("Index",new { page }))
```

* 最上方要記得加入引用，跟在Controller一樣
* 使用@Html.PagedListPager()顯示分頁工具列






