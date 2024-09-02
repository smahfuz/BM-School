using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_School.ViewModel
{
    public class ClassStudent
    {
        public int  ClassId {get; set;}
        public List<SelectListItem> Classes { get; set; }
    }
}
