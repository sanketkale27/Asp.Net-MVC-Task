using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Student_Managment_System.Models
{
    public class courename
    {
       
        public IEnumerable<SelectListItem> courselist { get; set; }
        public IEnumerable<SelectListItem> selectedcourse { get; set; }        
        public int[] CourseCode { get; set; } 
        public string errormsg { get; set; }
        public string coursename { get; set; }
        public string studentname { get; set; }
     
    }
}