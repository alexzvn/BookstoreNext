using System;
using System.ComponentModel.DataAnnotations;

namespace BookstoreNext.Models
{
    public class RequestOrderModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the quantity")]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}

