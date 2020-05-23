using System.ComponentModel.DataAnnotations;

namespace Wyj.Blog.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}