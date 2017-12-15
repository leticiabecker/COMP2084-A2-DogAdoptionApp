namespace DogAdoptionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shelter")]
    public partial class Shelter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shelter()
        {
            PetDogs = new HashSet<PetDog>();
        }

        [Display(Name = "Shelter Id")]
        public int ShelterId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Shelter's Name")]
        public string ShelterName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string ShelterAddress { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Website")]
        public string ShelterWebsite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetDog> PetDogs { get; set; }
    }
}
