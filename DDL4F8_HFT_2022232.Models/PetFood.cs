﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Buffers;
using System.Text.Json.Serialization;

namespace DDL4F8_HFT_2022232.Models
{
    public class PetFood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string PetRecommendation { get; set; }

        [StringLength(100)]
        public string CasualFood { get; set; } //Zöldség-gyümölcs

        [StringLength(100)]
        public string BestFood { get; set; }

        public int BestFoodCost { get; set; }

        public int PetFoodId { get; set; }

        [JsonIgnore]
        public virtual List<Pet> Pets { get; set; }
        [JsonIgnore]
        public virtual Petowner FoodShop { get; set; }




    }
}
