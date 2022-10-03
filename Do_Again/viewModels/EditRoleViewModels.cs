using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Do_Again.viewModels
{
    public class EditRoleViewModels
    {

        public EditRoleViewModels()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
