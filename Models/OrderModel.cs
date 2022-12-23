using System;
using System.ComponentModel.DataAnnotations;

namespace BookstoreNext.Models
{
	public class OrderModel
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the customer's name")]
        [StringLength(100)]
        [Display(Name = "Customer name")]
        public string Name { get; set; } = "";

        [StringLength(1000)]
        [Display(Name = "Delivery address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = "";

        [StringLength(100)]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Enter the quantity")]
        [Range(1, 100)]
        public int Quantity { get; set; }

        public int BookId { get; set; }

        public BookModel? Book { get; set; }
    }
}

