using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogAdoptionApp.Models;

namespace Assignment2.Models
{
    public class EFPetDogsRepository : IPetDogsRepository
    {
        // db connection moved here from PetDogsController
        DogAdoptionAppModel db = new DogAdoptionAppModel();

        public IQueryable<PetDog> PetDogs { get { return db.PetDogs; } }

        public IQueryable<Shelter> Shelters { get { return db.Shelters; } }

        public void Delete(PetDog dogs)
        {
            db.PetDogs.Remove(dogs);
            db.SaveChanges();
        }

        public PetDog Save(PetDog dogs)
        {
            if (dogs.DogId == 0)
            {
                db.PetDogs.Add(dogs);
            }
            else
            {
                db.Entry(dogs).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return dogs;
        }
    }
}