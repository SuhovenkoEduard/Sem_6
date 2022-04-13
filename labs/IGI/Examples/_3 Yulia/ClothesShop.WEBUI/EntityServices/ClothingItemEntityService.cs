using ClothesShop.BLL.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.WEBUI.EntityServices
{
    public class ClothingItemEntityService
    {
        public enum SortState
        {
            NameAsc,
            NameDesc
        }
        public IQueryable<ClothingItemDTO> Filter(IQueryable<ClothingItemDTO> clothingItems, string selectedClothingItemName)
        {
            if (!string.IsNullOrEmpty(selectedClothingItemName))
            {
                clothingItems = clothingItems.Where(p => p.Name.Contains(selectedClothingItemName));
            }
            return clothingItems;
        }

        public IQueryable<ClothingItemDTO> Sort(IQueryable<ClothingItemDTO> clothingItems, SortState sortState)
        {
            switch (sortState)
            {
                case SortState.NameAsc:
                    clothingItems = clothingItems.OrderBy(p => p.Name);
                    break;
                case SortState.NameDesc:
                    clothingItems = clothingItems.OrderByDescending(p => p.Name);
                    break;
            }
            return clothingItems;
        }

        public IQueryable<ClothingItemDTO> Paging(IQueryable<ClothingItemDTO> clothingItems, bool isFromFilter, int page, int pageSize)
        {
            if (isFromFilter)
            {
                page = 1;
            }
            return clothingItems.Skip(((int)page - 1) * pageSize).Take(pageSize);
        }

        public void GetFilterCookiesForUserIfNull(IRequestCookieCollection cookies, string username, bool isFromFilterForm, ref string selectedName)
        {
            if (string.IsNullOrEmpty(selectedName))
            {
                if (!isFromFilterForm)
                {
                    cookies.TryGetValue(GetUsernameFromEmail(username) + "clothingItemSelectedName", out selectedName);
                }
            }
        }

        public void GetSortPagingCookiesForUserIfNull(IRequestCookieCollection cookies, string username, bool isFromFilter, ref int? page, ref SortState? sortState)
        {
            if (!isFromFilter)
            {
                if (page == null)
                {
                    if (cookies.TryGetValue(GetUsernameFromEmail(username) + "clothingItemPage", out string pageStr))
                    {
                        page = int.Parse(pageStr);
                    }
                }
                if (sortState == null)
                {
                    if (cookies.TryGetValue(GetUsernameFromEmail(username) + "clothingItemSortState", out string sortStateStr))
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
            cookies.Append(GetUsernameFromEmail(username) + "clothingItemSelectedName", selectedName);
            cookies.Append(GetUsernameFromEmail(username) + "clothingItemPage", page.ToString());
            cookies.Append(GetUsernameFromEmail(username) + "clothingItemSortState", sortState.ToString());
        }

        public string GetUsernameFromEmail(string email)
        {
            return email.Split('@')[0];
        }
    }
}
