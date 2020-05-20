
using System.ComponentModel.DataAnnotations;

namespace GTL_Project.Models
{
    public class Book : IBook
    {
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "You must provide an ISBN!")]
        [Range(1000000, 9999999)]
        public int Isbn { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "You must provide an Author!")]
        public string Author { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "You must provide a title!")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You must write a short description!")]
        public string Description { get; set; }
        public bool In_Stock { get; set; }
        public bool Lendable { get; set; }

        [Display(Name = "Book edition")]
        [Required(ErrorMessage = "You must provide a book edition!")]
        public string Edition { get; set; }

        public string Cover_Type { get; set; }
    }
}