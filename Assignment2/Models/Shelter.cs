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

        public int ShelterId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShelterName { get; set; }

        [Required]
        [StringLength(100)]
        public string ShelterAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string ShelterWebsite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetDog> PetDogs { get; set; }
    }
}
