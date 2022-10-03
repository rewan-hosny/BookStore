using System.ComponentModel.DataAnnotations;

namespace Do_Again.viewModels
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
  
    }
}
