using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Species { get; set; } //Faj

        [StringLength(100)]
        public string Title { get; set; } //Milyen evő?

        public int Age { get; set; }
        public int PetownerId { get; set; }
        public int PetFoodId { get; set; }

        [NotMapped]
        public Petowner Petowner { get; set; }
        [NotMapped]
        public PetFood PetFood { get; set; }



    }
}
