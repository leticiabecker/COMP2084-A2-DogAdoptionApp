using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogAdoptionApp.Models;
using Assignment2.Models;

namespace DogAdoptionApp.Controllers
{
    [Authorize]
    public class PetDogsController : Controller
    {
        // db connection moved to Models/EFPetDogsRepository.cs
        //private DogAdoptionAppModel db = new DogAdoptionAppModel();
        private IPetDogsRepository db;

        // if no mock specified, use db
        public PetDogsController()
        {
            this.db = new EFPetDogsRepository();
        }

        // if we tell the controller we are testing, use the mock interface
        public PetDogsController (IPetDogsRepository db)
        {
            this.db = db;
        }

        [AllowAnonymous]
        // GET: PetDogs
        public ActionResult Index()
        {
            var petDogs = db.PetDogs.Include(p => p.Shelter);
            return View(petDogs.ToList());
        }

        //// GET: PetDogs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PetDog petDog = db.PetDogs.Find(id);
        //    if (petDog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(petDog);
        //}

        //// GET: PetDogs/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ShelterId = new SelectList(db.Shelters, "ShelterId", "ShelterName");
        //    return View();
        //}

        //// POST: PetDogs/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "DogId,DogName,DogBreed,DogAge,DogGender,ShelterId")] PetDog petDog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PetDogs.Add(petDog);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ShelterId = new SelectList(db.Shelters, "ShelterId", "ShelterName", petDog.ShelterId);
        //    return View(petDog);
        //}

        //// GET: PetDogs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PetDog petDog = db.PetDogs.Find(id);
        //    if (petDog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ShelterId = new SelectList(db.Shelters, "ShelterId", "ShelterName", petDog.ShelterId);
        //    return View(petDog);
        //}

        //// POST: PetDogs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "DogId,DogName,DogBreed,DogAge,DogGender,ShelterId")] PetDog petDog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(petDog).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ShelterId = new SelectList(db.Shelters, "ShelterId", "ShelterName", petDog.ShelterId);
        //    return View(petDog);
        //}

        //// GET: PetDogs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PetDog petDog = db.PetDogs.Find(id);
        //    if (petDog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(petDog);
        //}

        //// POST: PetDogs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PetDog petDog = db.PetDogs.Find(id);
        //    db.PetDogs.Remove(petDog);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
