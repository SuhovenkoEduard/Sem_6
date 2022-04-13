using ClothesShop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.ViewModels.ClothingItemType
{
    public class IndexClothingItemTypeViewModel
    {
        public IEnumerable<ClothingItemTypeDTO> ClothingItemTypes { get; set; }
        public FilterClothingItemTypeViewModel FilterClothingItemTypeViewModel { get; set; }
        public SortClothingItemTypeViewModel SortClothingItemTypeViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
