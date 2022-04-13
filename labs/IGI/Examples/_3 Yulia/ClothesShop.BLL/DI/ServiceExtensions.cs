using ClothesShop.BLL.Services;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.BLL.DI
{
    public static class ServiceExtensions
    {
        public static void AddUnitOfWorkContext(this IServiceCollection services, string dbConnection)
        {
            services.AddSingleton<IUnitOfWork, ClothesShopDbUnitOfWork>(uow => new ClothesShopDbUnitOfWork(dbConnection));
        }
        public static void AddManufacturersService(this IServiceCollection services)
        {
            services.AddSingleton<ManufacturerService>();
        }
        public static void AddClothingItemTypesService(this IServiceCollection services)
        {
            services.AddSingleton<ClothingItemTypeService>();
        }
        public static void AddClothingItemsService(this IServiceCollection services)
        {
            services.AddSingleton<ClothingItemService>();
        }
    }
}
