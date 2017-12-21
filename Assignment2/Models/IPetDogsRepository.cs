using DogAdoptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public interface IPetDogsRepository
    {
        IQueryable<PetDog> PetDogs { get; }
        IQueryable<Shelter> Shelters { get; }
        PetDog Save(PetDog dogs);
        void Delete(PetDog dogs);
    }
}
