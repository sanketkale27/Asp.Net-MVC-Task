using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataBaseLayer;

namespace Student_Managment_System.Controllers
{
    public class HomeController : Controller
    {

        StudentRegistration std = new StudentRegistration();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add student details
        /// </summary>
        /// <param name="Form"></param>
        [HttpPost]
        public void AddStudent(FormCollection Form)
        {
            try
            {
                StudentModel stdmodel = new StudentModel()
                {
                    FirstName = Form["txtfirstname"],
                    Surname = Form["txtsurname"],
                    Gender = Form["rdbgender"],
                    DOB = Convert.ToDateTime(Form["txtdob"]),
                    Address1 = Form["txtaddress1"],
                    Address2 = Form["txtaddress2"],
                    Address3 = Form["txtaddress3"]
                };
                std.AddStudent(stdmodel);
                Response.Write("Successfully saved!");
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
            }            
        }

        /// <summary>
        /// Fetch the student data
        /// </summary>
        /// <returns></returns>
        public string ListData()
        {
            try
            {
                return std.FetchData();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return "";
            }
           
        }

        /// <summary>
        /// delete the student data
        /// </summary>
        /// <param name="ID"></param>
        public void deletestudentdetails(int ID)
        {
            try
            {
                std.deletestudent(ID);
                Response.Write("Record deleted successfully!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }            
        }


        /// <summary>
        /// Edit the student data
        /// </summary>
        /// <param name="Form"></param>
        [HttpPost]
        public void EditStud(FormCollection Form)
        {
            try
            {
                StudentModel stdmodel = new StudentModel()
                {
                    StudentId = Convert.ToInt32(Form["txtID"]),
                    FirstName = Form["txtfirstname"],
                    Surname = Form["txtsurname"],
                    Gender = Form["rdbgender"],
                    DOB = Convert.ToDateTime(Form["txtdob"]),
                    Address1 = Form["txtaddress1"],
                    Address2 = Form["txtaddress2"],
                    Address3 = Form["txtaddress3"]
                };
                std.EditStudent(stdmodel);
                Response.Write("Successfully edited!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }            
        }

        
       
    }
}