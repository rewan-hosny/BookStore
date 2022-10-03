using System.Collections.Generic;

namespace Do_Again.viewModels
{
    public class EditBook: CreateBookNew
    {
        public int ID { get; set; } 
        public string Existing_photo { get; set; }
        public int TypeOfBookid { get; set; }
        public List<Do_Again.Models.TypeOfBook> categorys { get; set; }

    }
}
