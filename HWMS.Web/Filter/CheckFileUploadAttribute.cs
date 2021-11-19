using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HWMS.API.Filter
{
    public class CheckFileUploadAttribute : ActionFilterAttribute
    {

        public string[] PermittedFileExtensions { get; set; }
        /// <summary>
        /// 允许文件大小(MB为单位)
        /// </summary>
        public int PermittedFileSize { get; set; }
        public bool IsSaveFile { get; set; }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var file in context.HttpContext.Request.Form.Files)
            {
                if (PermittedFileExtensions != null && PermittedFileExtensions.Length != 0)
                {
                    var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !PermittedFileExtensions.Contains(ext))
                    {
                        context.Result = new JsonResult("未通过后缀检测");
                    }
                }
                if (PermittedFileSize != 0)
                {
                    if (file.Length > PermittedFileSize * 1024 * 1024)
                    {
                        context.Result = new JsonResult("未通过大小检测");
                    }
                }
                if (IsSaveFile)
                {
                    string saveFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploadfiles", context.Controller.ToString(), Guid.NewGuid().ToString());
                    byte[] buffer = new byte[file.Length];
                    if (!Directory.Exists(saveFilePath))
                    {
                        Directory.CreateDirectory(saveFilePath);
                        saveFilePath = Path.Combine(saveFilePath, Path.GetRandomFileName());
                    }
                    using (var writer = File.Create(saveFilePath))
                    {
                        file.CopyToAsync(writer);
                    }
                }
            }
            return base.OnActionExecutionAsync(context, next);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
