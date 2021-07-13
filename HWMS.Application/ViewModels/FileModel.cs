using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HWMS.Application.ViewModels
{
    public class FileModel<T> where T : class
    {
        public string FirstTitle { get; set; }
        public string SecondTitle_Left { get; set; }
        public string SecondTitle_Right { get; set; }

        public List<T> Details { get; set; }
    }

    public class TextModel
    {
        [FileCloumnDisplayName("长度")]
        [DisplayName("长度")]
        public int Leng1 { get; set; }
        //[FileCloumnDisplayName("高度")]
        [DisplayName("高度")]
        public int Leng2 { get; set; }
        //[FileCloumnDisplayName("深度")]
        [DisplayName("深度")]
        public int Leng3 { get; set; }
        //[FileCloumnDisplayName("厚度")]
        [DisplayName("厚度")]
        public int Leng4 { get; set; }
        //[FileCloumnDisplayName("宽度")]
        [DisplayName("宽度")]
        public int Leng5 { get; set; }
        //[FileCloumnDisplayName("尺度")]
        [DisplayName("尺度")]
        public int Leng6 { get; set; }
        [DisplayName("时间")]
        public DateTime ETime { get; set; }
    }

    public class FileCloumnDisplayNameAttribute : Attribute
    {
        public FileCloumnDisplayNameAttribute(string keyvalue)
        {
            SetKeyValue = keyvalue;
        }
        public string SetKeyValue { get; set; }
        public FileCloumnDisplayNameAttribute(Dictionary<string, string> keyValuePairs)
        {
            this.KeyValue = keyValuePairs;
        }

        public Dictionary<string,string> KeyValue { get; set; }
    }
}
