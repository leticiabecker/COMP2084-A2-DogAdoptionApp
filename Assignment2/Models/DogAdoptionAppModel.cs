namespace DogAdoptionApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DogAdoptionAppModel : DbContext
    {
        public DogAdoptionAppModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<PetDog> PetDogs { get; set; }
        public virtual DbSet<Shelter> Shelters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetDog>()
                .Property(e => e.DogName)
                .IsFixedLength();

            modelBuilder.Entity<PetDog>()
                .Property(e => e.DogBreed)
                .IsFixedLength();

            modelBuilder.Entity<PetDog>()
                .Property(e => e.DogGender)
                .IsFixedLength();

            modelBuilder.Entity<Shelter>()
                .Property(e => e.ShelterName)
                .IsFixedLength();

            modelBuilder.Entity<Shelter>()
                .Property(e => e.ShelterAddress)
                .IsFixedLength();

            modelBuilder.Entity<Shelter>()
                .Property(e => e.ShelterWebsite)
                .IsFixedLength();

            modelBuilder.Entity<Shelter>()
                .HasMany(e => e.PetDogs)
                .WithRequired(e => e.Shelter)
                .WillCascadeOnDelete(false);
        }
    }
}
