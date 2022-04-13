using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.ViewModels.ClothingItemType
{
    public class SortClothingItemTypeViewModel
    {
        public EntityServices.ClothingItemTypeEntityService.SortState NameSort { get; set; }
        public EntityServices.ClothingItemTypeEntityService.SortState Current { get; set; }
        public SortClothingItemTypeViewModel(ClothesShop.WEBUI.EntityServices.ClothingItemTypeEntityService.SortState sortState)
        {
            NameSort = sortState == EntityServices.ClothingItemTypeEntityService.SortState.NameAsc ? EntityServices.ClothingItemTypeEntityService.SortState.NameDesc : EntityServices.ClothingItemTypeEntityService.SortState.NameAsc;
            Current = sortState;
        }
    }
}
