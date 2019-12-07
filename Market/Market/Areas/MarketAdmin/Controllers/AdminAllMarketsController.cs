using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Market.Models;

namespace Market.Areas.MarketAdmin.Controllers
{
    public class AdminAllMarketsController : Controller
    {
        private FursatEntities1 db = new FursatEntities1();

        // GET: MarketAdmin/AdminAllMarkets
        public ActionResult Index()
        {
            return View(db.AllMarkets.ToList());
        }

        // GET: MarketAdmin/AdminAllMarkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllMarket allMarket = db.AllMarkets.Find(id);
            if (allMarket == null)
            {
                return HttpNotFound();
            }
            return View(allMarket);
        }

        // GET: MarketAdmin/AdminAllMarkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarketAdmin/AdminAllMarkets/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MarketName,Image")] AllMarket allMarket,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (
                        Photo.ContentType.ToLower() == "image/jpg" ||
                        Photo.ContentType.ToLower() == "image/png" ||
                        Photo.ContentType.ToLower() == "image/gif" ||
                        Photo.ContentType.ToLower() == "image/jpeg")
                    {
                        WebImage image = new WebImage(Photo.InputStream);
                        FileInfo photoInfo = new FileInfo(Photo.FileName);
                        string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                        image.Save("~/Uploads/MarketImage/" + newPhoto);
                        allMarket.Image= "/Uploads/MarketImage/"+newPhoto;
                    }
                }
                db.AllMarkets.Add(allMarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allMarket);
        }

        // GET: MarketAdmin/AdminAllMarkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllMarket allMarket = db.AllMarkets.Find(id);
            if (allMarket == null)
            {
                return HttpNotFound();
            }
            return View(allMarket);
        }

        // POST: MarketAdmin/AdminAllMarkets/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MarketName,Image")] AllMarket allMarket,HttpPostedFileBase Photo,int? id)
        {
            if (ModelState.IsValid)
            {
                var productContents = db.AllMarkets.SingleOrDefault(m => m.Id == id);
                if (Photo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(productContents.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(productContents.Image));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/MarketImage/" + newPhoto);
                    productContents.Image = "/Uploads/MarketImage/" + newPhoto;
                }

                productContents.MarketName = allMarket.MarketName;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allMarket);
        }

        // GET: MarketAdmin/AdminAllMarkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllMarket allMarket = db.AllMarkets.Find(id);
            if (allMarket == null)
            {
                return HttpNotFound();
            }
            return View(allMarket);
        }

        // POST: MarketAdmin/AdminAllMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllMarket allMarket = db.AllMarkets.Find(id);
            db.AllMarkets.Remove(allMarket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
