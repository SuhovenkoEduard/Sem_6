using ClothesShop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.ViewModels.Manufacturer
{
    public class IndexManufacturerViewModel
    {
        public IEnumerable<ManufacturerDTO> Manufacturers { get; set; }
        public FilterManufacturerViewModel FilterManufacturerViewModel { get; set; }
        public SortManufacturerViewModel SortManufacturerViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
