using CourseWork.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Filters
{
    public class PrepareFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {               
                // ... 
            }
            catch(Exception e)
            {
                // ...
                // Вставить логирование
                // И возвращать сообщение ошибки
                context.Result = new JsonResult(new
                {
                    status = false,
                    msg = e.Message
                });
            }
            finally
            {
                base.OnActionExecuting(context);
            }
        }

       
    }
}
