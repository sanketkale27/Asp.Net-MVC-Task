using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataBaseLayer;
using Student_Managment_System.Models;
using System.Text;

namespace Student_Managment_System.Controllers
{
    public class StudentCourseController : Controller
    {
        string errormsg { get; set; }
        StdCourse std = new StdCourse();
      

        /// <summary>
        /// display the list of data and view
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public ActionResult Studentcourse(string error = "")
        {
            try
            {
                List<SelectListItem> list = new List<SelectListItem>();
                courename viewModel = new courename();
                list = listdata();
                viewModel.courselist = list;
                viewModel.errormsg = error;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return View();
            }           
        }

        /// <summary>
        /// on submit of data
        /// </summary>
        /// <param name="Form"></param>
        /// <param name="selectedcourse"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Studentcourse(FormCollection Form, IEnumerable<int> selectedcourse)
        {
            try
            {
                string result =string.Empty;
                IEnumerable<int> d = selectedcourse;
                courename viewModel = new courename();
                if (d.Count() >5)
                {
                    errormsg = "You can not enroll more than 5 course.";
                }
                else
                {
                    foreach (var item in d)
                    {
                        StudentCourseModel stdmodel = new StudentCourseModel()
                        {
                            StudentId = Convert.ToInt32(Form["txtStudentname"]),
                            CourseCode = item

                        };
                        result = std.AddStudent(stdmodel);

                    }

                    if (result == "1")
                    {
                        errormsg = "Course added successfully";
                        
                    }
                    else
                    {
                        errormsg = result;

                    }                    
                }
                List<SelectListItem> list = new List<SelectListItem>();
                list = listdata();
                viewModel.courselist = list;
                viewModel.errormsg = errormsg;           
                return View(viewModel);
            

            }
            catch (Exception ex)
            {              
                return View(ex.Message.ToString());
            }
        }


        /// <summary>
        /// populate student list
        /// </summary>
        /// <returns></returns>
        public string populatestudent()
        {
            try
            {
                return std.studentname();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return "";
            }   
        }

        /// <summary>
        /// bind list of data
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> listdata()
        {
            MyDBEntities4 mb = new MyDBEntities4();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (tblCourse e in mb.tblCourses)
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = e.CourseName,
                    Value = e.CourseCode.ToString(),
                    Selected = false
                };
                list.Add(item);
            }           

            return list;
        }       
       


    }
}