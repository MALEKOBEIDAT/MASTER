using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Mster.Models;

namespace Mster.Controllers
{
    public class EstatesController : Controller
    {
        private BuytnaEntities db = new BuytnaEntities();

        // GET: Estates
        public ActionResult Index()
        {
            var estates = db.Estates.Include(e => e.AspNetUser).Include(e => e.category);


            return View(estates.ToList());
            
        }

      
        public ActionResult Singlepage(int? id)
        {
            ViewBag.Message = "Your application description page.";

            var Es = db.Estates.FirstOrDefault(c => c.EstateId == id);


            return View(Es);
        }

        


        // GET: Estates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return HttpNotFound();
            }
            return View(estate);
        }

        // GET: Estates/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Estates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstateId,CategoryId,UserId,EstatePrice,Image1,Image2,Image3,Image4,Image5,Image6,Image7,EstateSize,EstateLocation,EstateStatus,RoomNum,BathRoomNum,BalconyNum")] Estate estate,HttpPostedFileBase Image1, HttpPostedFileBase Image2,HttpPostedFileBase Image3,HttpPostedFileBase Image4,HttpPostedFileBase Image5,HttpPostedFileBase Image6,HttpPostedFileBase Image7 )
        {
            if (ModelState.IsValid)
            {

                if (Image1  != null)
                {
                    if (!Image1.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(estate);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))  
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(Image1.FileName);
                    string fileName2 = Path.GetFileName(Image2.FileName);
                    string fileName3 = Path.GetFileName(Image3.FileName);
                    string fileName4 = Path.GetFileName(Image4.FileName);
                    string fileName5 = Path.GetFileName(Image5.FileName);
                    string fileName6 = Path.GetFileName(Image6.FileName);
                    string fileName7 = Path.GetFileName(Image7.FileName);



                    string path = Path.Combine(folderPath, fileName);
                    Image1.SaveAs(path);
                    estate.Image1 = "../Content/Images/" + fileName;


                    string path2 = Path.Combine(folderPath, fileName2);
                    Image2.SaveAs(path2);
                    estate.Image2 = "../Content/Images/" + fileName2;



                    string path3 = Path.Combine(folderPath, fileName3);
                    Image3.SaveAs(path3);
                    estate.Image3 = "../Content/Images/" + fileName3;



                    string path4 = Path.Combine(folderPath, fileName4);
                    Image4.SaveAs(path4);
                    estate.Image4 = "../Content/Images/" + fileName4;


                    string path5 = Path.Combine(folderPath, fileName5);
                    Image5.SaveAs(path5);
                    estate.Image5 = "../Content/Images/" + fileName5;



                    string path6 = Path.Combine(folderPath, fileName6);
                    Image6.SaveAs(path6);
                    estate.Image6 = "../Content/Images/" + fileName6;

                    string path7 = Path.Combine(folderPath, fileName7);
                    Image7.SaveAs(path7);
                    estate.Image7 = "../Content/Images/" + fileName7;
                }

                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(estate);
                }

               
                db.Estates.Add(estate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", estate.UserId);
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "CategoryName", estate.CategoryId);
            return View(estate);
        }

        // GET: Estates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", estate.UserId);
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "CategoryName", estate.CategoryId);
            return View(estate);
        }

        // POST: Estates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstateId,CategoryId,UserId,EstatePrice,Image1,Image2,Image3,Image4,Image5,Image6,Image7,EstateSize,EstateLocation,EstateStatus,RoomNum,BathRoomNum,BalconyNum")] Estate estate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", estate.UserId);
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "CategoryName", estate.CategoryId);
            return View(estate);
        }

        // GET: Estates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return HttpNotFound();
            }
            return View(estate);
        }


        //__________________________________________________________________________________________



        public ActionResult Accept(int? id)
        {

            Estate estate = db.Estates.Find(id);
            estate.EstateStatus = 1;
       
            db.SaveChanges();
           

            return View("Index", db.Estates.ToList());

        }




        public ActionResult Acceptt()
        {
            var acc = db.Estates.Where(a => a.EstateStatus == 1).ToList();
            db.SaveChanges();
            return View("Acceptt", acc);

        }


        public ActionResult Reject(int? id)
        {

            Estate estate = db.Estates.Find(id);
            estate.EstateStatus = 2;

            db.SaveChanges();


            return View("Index", db.Estates.ToList());

        }








        //________________________________________________________________________________________



        // POST: Estates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estate estate = db.Estates.Find(id);
            db.Estates.Remove(estate);
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
