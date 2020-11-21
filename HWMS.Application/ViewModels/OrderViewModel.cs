using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HWMS.Application.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderViewModel
    {
        // [Key]
        public Guid Id { get; set; }

        // [Required(ErrorMessage = "The OrderNumber is Required")]
        // [MinLength(2)]
        // [MaxLength(100)]
        // [DisplayName("OrderNumber")]
        public string OrderNumber { get; set; }


        // <summary>
        /// 省份
        /// </summary>
        // [Required(ErrorMessage = "The Province is Required")]
        // [DisplayName("Province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

    }
}
