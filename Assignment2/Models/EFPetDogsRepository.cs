using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogAdoptionApp.Models;

namespace Assignment2.Models
{
    public class EFPetDogsRepository : IPetDogsRepository
    {
        // repository for CRUD with Dogs in SQL Server db

        // db connection moved here from PetDogsController
        DogAdoptionAppModel db = new DogAdoptionAppModel();

        public IQueryable<PetDog> PetDogs { get { return db.PetDogs; } }

        public IQueryable<Shelter> Shelters { get { return db.Shelters; } }

        public void Delete(PetDog dog)
        {
            db.PetDogs.Remove(dog);
            db.SaveChanges();
        }

        public PetDog Save(PetDog dog)
        {
            if (dog.DogId == 0)
            {
                db.PetDogs.Add(dog);
            }
            else
            {
                db.Entry(dog).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return dog;
        }
    }
}