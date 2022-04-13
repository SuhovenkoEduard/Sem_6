using ClothesShop.BLL.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.EntityServices
{
    public class ClothingItemTypeEntityService
    {
        public enum SortState
        {
            NameAsc,
            NameDesc
        }
        public IQueryable<ClothingItemTypeDTO> Filter(IQueryable<ClothingItemTypeDTO> clothingItemTypes, string selectedClothingItemTypeName)
        {
            if (!string.IsNullOrEmpty(selectedClothingItemTypeName))
            {
                clothingItemTypes = clothingItemTypes.Where(p => p.Name.Contains(selectedClothingItemTypeName));
            }
            return clothingItemTypes;
        }

        public IQueryable<ClothingItemTypeDTO> Sort(IQueryable<ClothingItemTypeDTO> clothingItemTypes, SortState sortState)
        {
            switch (sortState)
            {
                case SortState.NameAsc:
                    clothingItemTypes = clothingItemTypes.OrderBy(p => p.Name);
                    break;
                case SortState.NameDesc:
                    clothingItemTypes = clothingItemTypes.OrderByDescending(p => p.Name);
                    break;
            }
            return clothingItemTypes;
        }

        public IQueryable<ClothingItemTypeDTO> Paging(IQueryable<ClothingItemTypeDTO> clothingItemTypes, bool isFromFilter, int page, int pageSize)
        {
            if (isFromFilter)
            {
                page = 1;
            }
            return clothingItemTypes.Skip(((int)page - 1) * pageSize).Take(pageSize);
        }

        public void GetFilterCookiesForUserIfNull(IRequestCookieCollection cookies, string username, bool isFromFilterForm, ref string selectedName)
        {
            if (string.IsNullOrEmpty(selectedName))
            {
                if (!isFromFilterForm)
                {
                    cookies.TryGetValue(GetUsernameFromEmail(username) + "clothingItemTypeSelectedName", out selectedName);
                }
            }
        }

        public void GetSortPagingCookiesForUserIfNull(IRequestCookieCollection cookies, string username, bool isFromFilter, ref int? page, ref SortState? sortState)
        {
            if (!isFromFilter)
            {
                if (page == null)
                {
                    if (cookies.TryGetValue(GetUsernameFromEmail(username) + "clothingItemTypePage", out string pageStr))
                    {
                        page = int.Parse(pageStr);
                    }
                }
                if (sortState == null)
                {
                    if (cookies.TryGetValue(GetUsernameFromEmail(username) + "clothingItemTypeSortState", out string sortStateStr))
                    {
                        sortState = (SortState)Enum.Parse(typeof(SortState), sortStateStr);
                    }
                }
            }
        }

        public void SetDefaultValuesIfNull(ref string selectedName, ref int? page, ref SortState? sortState)
        {
            selectedName ??= "";
            page ??= 1;
            sortState ??= SortState.NameAsc;
        }

        public void SetCookies(IResponseCookies cookies, string username, string selectedName, int? page, SortState? sortState)
        {
            cookies.Append(GetUsernameFromEmail(username) + "clothingItemTypeSelectedName", selectedName);
            cookies.Append(GetUsernameFromEmail(username) + "clothingItemTypePage", page.ToString());
            cookies.Append(GetUsernameFromEmail(username) + "clothingItemTypeSortState", sortState.ToString());
        }

        public string GetUsernameFromEmail(string email)
        {
            return email.Split('@')[0];
        }
    }
}
