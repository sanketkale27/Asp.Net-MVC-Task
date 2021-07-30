using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataBaseLayer;

namespace Student_Managment_System.Controllers
{
    public class CourseController : Controller
    {
        CourseDetails crs = new CourseDetails();
        // GET: Course
        public ActionResult courseIndex()
        {
            return View();
        }

        /// <summary>
        /// Add Course details
        /// </summary>
        /// <param name="Form"></param>        
        [HttpPost]
        public void AddCourse(FormCollection Form)
        {
            try
            {
                CourseModel crsmodel = new CourseModel()
                {
                    CourseCode = Convert.ToInt32(Form["txtcoursecode"]),
                    CourseName = Form["txtcoursename"],
                    TeacherName = Form["txtteachername"],
                    StartDate = Convert.ToDateTime(Form["txtstartdate"]),
                    EndDate = Convert.ToDateTime(Form["txtenddate"])                    
                };
                CourseCountModel crscntmodel = new CourseCountModel()
                {
                    CourseCode = Convert.ToInt32(Form["txtcoursecode"]),
                    MaxCourseCount = Convert.ToInt32(Form["txtenrol"])
                };
                crs.Addcourse(crsmodel, crscntmodel);
                Response.Write("Successfully saved!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }          
        }

        /// <summary>
        /// Fetch list data
        /// </summary>
        /// <returns></returns>
        public string ListData()
        {
            try
            {
                return crs.FetchCourseDetails();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return "";
            }           
        }

        /// <summary>
        /// Delete the course data
        /// </summary>
        /// <param name="ID"></param>
        public void deletecoursedetails(int ID)
        {
            try
            {
                crs.deletecourse(ID);
                Response.Write("Record deleted successfully!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());                
            }
          
        }

        /// <summary>
        /// Edit Course details
        /// </summary>
        /// <param name="Form"></param>
        [HttpPost]
        public void Editcrs(FormCollection Form)
        {
            try
            {
                CourseModel crsmodel = new CourseModel()
                {
                    CourseCode = Convert.ToInt32(Form["txtID"]),
                    CourseName = Form["txtcoursename"],
                    TeacherName = Form["txtteachername"],
                    StartDate = Convert.ToDateTime(Form["txtstartdate"]),
                    EndDate = Convert.ToDateTime(Form["txtenddate"])
                };
                CourseCountModel objcrs = new CourseCountModel
                {
                     CourseCode = Convert.ToInt32(Form["txtID"]),
                     MaxCourseCount = Convert.ToInt32(Form["txtenrol"])
                };
                crs.EditCourse(crsmodel, objcrs);
                Response.Write("Successfully edited!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
          
        }
    }
}