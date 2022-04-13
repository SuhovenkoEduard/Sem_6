using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClothesShop.BLL.DTO
{
    public class ClothingItemDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(30, 70, ErrorMessage = "Size should be in range from 30 to 70")]
        public int Size { get; set; }
        [DisplayName("Male")]
        public bool IsMale { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price should be positive")]
        public int Price { get; set; }

        [DisplayName("Type")]
        public int ClothingItemTypeId { get; set; }

        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }
    }
}
