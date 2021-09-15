using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.MySqlCFSample.Models;
using RnD.MySqlCFSample.Helpers;

namespace RnD.MySqlCFSample.Controllers
{
    public class CategoryController : Controller
    {

        AppDbContext _db = new AppDbContext();
        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategoryList()
        {
            var categoryList = _db.Category.ToList();

            return Json(categoryList.Select(c => new { CategoryId = c.CategoryId, CategoryName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        // for display datatable
        public ActionResult GetCategories(DataTableParamModel param)
        {
            var categories = _db.Category.ToList();

            var viewCategorys = categories.Select(cat => new CategoryTableModel() { CategoryId = Convert.ToString(cat.CategoryId), Name = cat.Name });

            IEnumerable<CategoryTableModel> filteredCategorys;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredCategorys = viewCategorys.Where(cat => (cat.Name ?? "").Contains(param.sSearch)).ToList();
            }
            else
            {
                filteredCategorys = viewCategorys;
            }

            var viewOdjects = filteredCategorys.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from catMdl in viewOdjects
                         select new[] { catMdl.CategoryId, catMdl.Name };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = categories.Count(),
                iTotalDisplayRecords = filteredCategorys.Count(),
                aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }
    }
}
