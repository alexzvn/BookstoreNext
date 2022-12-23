using System;
using System.ComponentModel.DataAnnotations;

namespace BookstoreNext.Models
{
	public class BookModel
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the book's name")]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [StringLength(1000)]
        public string Description { get; set; } = "";

        [StringLength(255)]
        [Display(Name = "Image URL")]
        public string Image { get; set; } = "";

        [Required(ErrorMessage = "Enter the book's price")]
        public decimal Price { get; set; }

        public void CopyFrom(BookModel book)
        {
            Name = book.Name;
            Description = book.Description;
            Image = book.Image;
            Price = book.Price;
        }
    }
}

