using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BusinessLayer;

namespace DataBaseLayer
{
    public class StdCourse
    {
    
        public string studentname()
        {
            using (var DB = new MyDBEntities4())
            {
                var data = DB.tblStudents.ToList();
                var Json = JsonConvert.SerializeObject(data);
                return Json;
            }
        }

      

        public string AddStudent(StudentCourseModel stdmodel)
        {
            using (var DB = new MyDBEntities4())
            {
                tblStudentCourse std = new tblStudentCourse()
                {
                    StudentId = stdmodel.StudentId,
                    CourseCode = stdmodel.CourseCode
                };

                var data = DB.tblStudentCourses.Any(x => x.StudentId == stdmodel.StudentId && x.CourseCode == stdmodel.CourseCode);

                var spacelimit = DB.tblCourseCounts.Where(x => x.CourseCode == stdmodel.CourseCode).Select(x=>x.MaxCourseCount).SingleOrDefault();

                var count = DB.tblStudentCourses.Count(t => t.CourseCode == stdmodel.CourseCode);

                var studentname = DB.tblStudents.Where(x => x.StudentId == stdmodel.StudentId).Select(x => x.FirstName).SingleOrDefault();
                var coursname = DB.tblCourses.Where(x => x.CourseCode == stdmodel.CourseCode).Select(x => x.CourseName).SingleOrDefault();

                if (data == true)
                {
                    
                    return  studentname + " already enrolled for the course " + coursname;
                }
                else if(spacelimit <= count )
                {
                    return coursname + " is not available. This course has only " + spacelimit + " seats";
                  
                }
                else
                {
                    DB.tblStudentCourses.Add(std);
                    DB.SaveChanges();
                    return "1";
                   
                }
            }
        }
    }
}
