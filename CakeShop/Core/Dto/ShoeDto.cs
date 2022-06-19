using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Core.Dto
{
    public class ShoeDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Shoe Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        //////////////Adding size//////////////
        /*[Required]
        [StringLength(255)]
        public int Size { get; set; }*/

        [Required]
        [Display(Name = "Long Description")]
        [MaxLength(255)]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Is Shoe Of the Week? ")]
        public bool IsShoeOfTheWeek { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
