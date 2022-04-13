using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.ViewModels.Manufacturer
{
    public class SortManufacturerViewModel
    {
        public EntityServices.ManufacturerEntityService.SortState NameSort { get; set; }
        public EntityServices.ManufacturerEntityService.SortState Current { get; set; }
        public SortManufacturerViewModel(ClothesShop.WEBUI.EntityServices.ManufacturerEntityService.SortState sortState)
        {
            NameSort = sortState == EntityServices.ManufacturerEntityService.SortState.NameAsc ? EntityServices.ManufacturerEntityService.SortState.NameDesc : EntityServices.ManufacturerEntityService.SortState.NameAsc;
            Current = sortState;
        }
    }
}
