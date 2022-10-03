using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_Again.Models
{

    [Table("TypeOfBook")]
    public class TypeOfBook
    {
        [Key]
        public int TypeofbookId { get; set; }
        public string Name_catogry { get; set; }    
       /* public string Classics { get; set; }
        public string Tragedy { get; set; }
        public string Sci_Fi { get; set; }
        public string Fantasy { get; set; }
        public string Action { get; set; }
        public string Adventure { get; set; }
        public string Crime_Mystery { get; set; }
        public string Humor { get; set; }
        public string Comics { get; set; }
        public string Biography_and_Autobiography { get; set; }
        public string Memoirs { get; set; }
        public string True_Stories { get; set; }
        public string Self_Help { get; set; }*/
       
    }
}
