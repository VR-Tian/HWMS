using System;
using HWMS.DoMain.Core.Models;

namespace HWMS.Application.ViewModels
{
    public class NavigationMenuViewModel
    {
        public int id { get; set; }
        public int ParentMenuId { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int DisplayOrder { get; set; }
        public bool Visible { get; set; }
        public DateTime CreateTime { get; set; }
    }
}