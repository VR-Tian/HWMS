using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HWMS.Web.Filter
{
    public class CheckFileUploadAttribute : ActionFilterAttribute
    {

        public string[] PermittedFileExtensions { get; set; }
        /// <summary>
        /// 允许文件大小(MB为单位)
        /// </summary>
        public int PermittedFileSize { get; set; }
        public bool IsSaveFile { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requetContext = context.HttpContext.Request;
            if (PermittedFileExtensions == null || PermittedFileExtensions.Length == 0)
            {
                PermittedFileExtensions = new string[] { "jpeg,txt" };
            }
            foreach (var file in requetContext.Form.Files)
            {
                var temp = file.Length;
            }

            base.OnActionExecuting(context);
        }
    }
}
