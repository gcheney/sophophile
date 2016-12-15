using System.ComponentModel.DataAnnotations;
using Thoughtwave.Models;

namespace Thoughtwave.ViewModels.ThoughtViewModels
{
    public class ThoughtViewModel
    {
        [Required(ErrorMessage = "Please include a title for your thought")]
        [StringLengthAttribute(50, 
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", 
            MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please include your thought content")]
        [Display(Name = "Your Thought")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please choose a category for your thought")]
        public Category Category { get; set; }

        [Display(Name = "Disable Comments?")]
        public bool DisableComments { get; set; }
    }
}