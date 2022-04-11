using System.ComponentModel.DataAnnotations;

namespace Vineforce.TusharBhagat.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}