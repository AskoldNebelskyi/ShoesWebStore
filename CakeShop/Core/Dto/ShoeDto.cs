using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Core.Dto
{
    public class ShoeDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва шузів")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Короткий опис")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        //////////////Adding size//////////////
        /*[Required]
        [StringLength(255)]
        public int Size { get; set; }*/

        [Required]
        [Display(Name = "Опис")]
        [MaxLength(255)]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name = "Прайс")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Url зображення")]
        public string ImageUrl { get; set; }

        [Display(Name = "Вибір тижня? ")]
        public bool IsShoeOfTheWeek { get; set; }

        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }
    }
}
