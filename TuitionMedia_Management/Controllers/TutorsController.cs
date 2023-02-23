using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuitionMedia_Management.Models;
using TuitionMedia_Management.ViewModel;

namespace TuitionMedia_Management.Controllers
{

    public class TutorsController : Controller
    {
        TutorDbContext db = new TutorDbContext();
        // GET: Tutors
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TutorList()
        {
            return PartialView("_TutorPartial", db.Tutors.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Create(TutorViewModel data)
        {
            if (ModelState.IsValid)
            {
                var c = new Tutor
                {
                    Tutorname = data.Tutorname,
                    JoinDate = data.JoinDate,
                    Phone = data.Phone,
                    Email = data.Email,
                    Available = data.Available
                };
                if (data.Picture.ContentLength > 0)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
                db.Tutors.Add(c);
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        public ActionResult Edit(int id)
        {
            var data = db.Tutors.FirstOrDefault(c => c.Tutorid == id);
            if (data == null) return new HttpNotFoundResult();
            ViewBag.CurrentPicture = data.Picture;
            return View(new TutorEditModel
            {
                Tutorid = id,
                Tutorname = data.Tutorname,
                JoinDate = data.JoinDate,
                Phone = data.Phone,
                Email = data.Email,
                Available=data.Available.HasValue ? data.Available.Value:false
            });
        }
        [HttpPost]
        public PartialViewResult Edit(TutorEditModel data)
        {
            var c = db.Tutors.FirstOrDefault(x => x.Tutorid == data.Tutorid);
            if (c == null) return PartialView("_FailPartial");
            if (ModelState.IsValid)
            {
                c.Tutorid = data.Tutorid;
                    c.Tutorname = data.Tutorname;
                    c.JoinDate = data.JoinDate;
                    c.Phone = data.Phone;
                    c.Email = data.Email;
                    c.Available = data?.Available;
                
                if (data.Picture!= null)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
                
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (db.Qualifications.Any(x => x.Tutorid == id))
            {
                return Json(new { success = false, id = 0 });
            }
            else
            {
                var c = new Tutor { Tutorid = id };
                db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Json (new {success=true, id=id});
            }
        }
        [Route ("Custom/Master")]
        public ActionResult MasterDetailInsert()
        {
            return View();
        }
        public ActionResult CreateMaster(TutorViewModel data)
        {
            if (ModelState.IsValid)
            {
                Tutor c = new Tutor
                {
                    Tutorname = data.Tutorname,
                    Available = data.Available,
                    JoinDate = data.JoinDate,
                    Phone = data.Phone,
                    Email = data.Email
                };
                if (data.Picture.ContentLength > 0)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
                db.Tutors.Add(c);
                db.SaveChanges();
                return Json(c);
            }
            return Json(data);
        }
        [HttpPost]
        public ActionResult AddQualifications(int id, Qualification[] data)
        {
            var c = db.Tutors.FirstOrDefault(x => x.Tutorid == id);
            if (c == null) return new HttpNotFoundResult();
            foreach (var q in data)
            {
                c.Qualifications.Add(q);
            }
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
    
}