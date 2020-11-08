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
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The OrderNumber is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("OrderNumber")]
        public string OrderNumber { get; set; }

    }
}
