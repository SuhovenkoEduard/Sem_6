using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.ViewModels.ClothingItem
{
    public class SortClothingItemViewModel
    {
        public EntityServices.ClothingItemEntityService.SortState NameSort { get; set; }
        public EntityServices.ClothingItemEntityService.SortState Current { get; set; }
        public SortClothingItemViewModel(EntityServices.ClothingItemEntityService.SortState sortState)
        {
            NameSort = sortState == EntityServices.ClothingItemEntityService.SortState.NameAsc ? EntityServices.ClothingItemEntityService.SortState.NameDesc : EntityServices.ClothingItemEntityService.SortState.NameAsc;
            Current = sortState;
        }
    }
}
