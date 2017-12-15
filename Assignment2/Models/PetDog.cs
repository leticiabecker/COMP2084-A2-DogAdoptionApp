namespace DogAdoptionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PetDog")]
    public partial class PetDog
    {
        [Key]
        public int DogId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Dog's Name")]
        public string DogName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Breed")]
        public string DogBreed { get; set; }

        [Display(Name = "Age")]
        public int DogAge { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Gender")]
        public string DogGender { get; set; }

        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; }
    }
}
