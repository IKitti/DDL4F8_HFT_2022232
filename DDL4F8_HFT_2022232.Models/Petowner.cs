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
    public class Petowner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Sex { get; set; }

        public int Age { get; set; }

        public int Money { get; set; }

        public int OwnerID { get; set; }

        [NotMapped]
        public List<Pet> Pets { get; set; }
    }
}

