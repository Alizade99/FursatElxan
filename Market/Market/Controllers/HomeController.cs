using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Market.Views.ViewModel.Default;
using Market.Areas.MarketAdmin.Controllers;
using PagedList;
using PagedList.Mvc;
using System.Web.Services.Description;
using Market.Services;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        FursatEntities1 db = new FursatEntities1();

        public ActionResult Index(string searchBy, string search, int? catId, int? subId, int? marId)
        {
            List<Product> productListItem;

            if (catId != null)
            {
                productListItem = db.Products.Where(pr => pr.SubCategory.CategoryId == catId).Take(4).ToList();
            }
            else
            {
                productListItem = db.Products.OrderByDescending(m => m.Id).ToList();
            }
            if (subId != null)
            {
                productListItem = db.Products.Where(pr => pr.subCategoryId == subId).OrderByDescending(m => m.Id).ToList();
            }
            if (marId != null)
            {
                productListItem = db.Products.Where(pr => pr.MarketId==marId).OrderByDescending(m => m.Id).ToList();
            }
            var defaultModel = new DefaultViewModel
            {

                Category = db.Categories.ToList(),
                SubCategory = db.SubCategories.ToList(),
                Slide = db.Slides.ToList(),
                allMarket=db.AllMarkets.ToList(),
                productList = productListItem,
            };
            return View(defaultModel);
        }

        public ActionResult About()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult Index(SubCategory subId, string filterpro, string search_pro)
        {
            List<Product> productListItem=new List<Product>();
            if (subId.İd != 0)
            {
                switch (filterpro)
                {
                    case "desc_name":

                        productListItem = db.Products.Where(pr => pr.subCategoryId == subId.İd).OrderByDescending(m => m.Id).ToList();
                        productListItem = SortForNameAndPrice.Sort(productListItem, e => e.Name[0].ToString().ToLower(), SortDirection.Ascending);
                        productListItem = SortForNameAndPrice.Sort(productListItem, e => e.Name[1].ToString().ToLower(), SortDirection.Ascending);

                        break;

                }
                switch (filterpro)
                {
                    case "inc_name":
                        productListItem = db.Products.Where(pr => pr.subCategoryId == subId.İd).ToList();
                        productListItem = SortForNameAndPrice.Sort(productListItem, e => e.Name[0].ToString().ToLower(), SortDirection.Descending);
                        productListItem = SortForNameAndPrice.Sort(productListItem, e => e.Name[1].ToString().ToLower(), SortDirection.Descending);
                        break;

                }
                switch (filterpro)
                {
                    case "desc_price":
                        productListItem = db.Products.Where(pr => pr.subCategoryId == subId.İd /*&& pr.Discount_price.Contains(search_pro).OrderBy(pr => pr.Discount_price*/).ToList();
                        productListItem = SortForNameAndPrice.Sort(productListItem, e => e.Discount_price, SortDirection.Descending);
                        break;
                }
                switch (filterpro)
                {
                    case "inc_price":
                        productListItem = db.Products.Where(pr => pr.subCategoryId == subId.İd).ToList();
                        productListItem = SortForNameAndPrice.Sort(productListItem, e => e.Discount_price, SortDirection.Ascending);
                        break;
                }
            }
            else
            {
                productListItem = db.Products.Where(pr => pr.Name.Contains(search_pro)).ToList();
            }

            var defaultModel = new DefaultViewModel
            {
                Category = db.Categories.ToList(),
                productList = productListItem,
                SubCategory = db.SubCategories.ToList(),
                allMarket = db.AllMarkets.ToList(),
            };

            return View(defaultModel);
        }
        public ActionResult Contact()
        {
            var defaultModel = new DefaultViewModel
            {
                Contact = db.Contacts.Find(1)
            };
            return View(defaultModel);
        }
    }
}