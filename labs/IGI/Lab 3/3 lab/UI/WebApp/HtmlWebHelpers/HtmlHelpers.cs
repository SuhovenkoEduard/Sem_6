using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.HtmlWebHelpers
{
    public static class HtmlHelpers
    {
        public static HtmlString GetUserName(this IHtmlHelper html, string name)
        {
            string result = $"<span> Пользователь с почтой: {name}</span>";
            return new HtmlString(result);
        }
    }
}