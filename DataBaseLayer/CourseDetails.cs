using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Newtonsoft.Json;

namespace DataBaseLayer
{
    public class CourseDetails
    {
        public void Addcourse(CourseModel crsmodel,CourseCountModel objcrs)
        {
            using (var DB = new MyDBEntities4())
            {
                tblCourse crs = new tblCourse()
                {
                    CourseCode = crsmodel.CourseCode,
                    CourseName = crsmodel.CourseName,
                    TeacherName = crsmodel.TeacherName,
                    StartDate = crsmodel.StartDate,
                    EndDate = crsmodel.EndDate                    
                };
                DB.tblCourses.Add(crs);
                tblCourseCount crscount = new tblCourseCount()
                {
                    CourseCode = objcrs.CourseCode,
                    MaxCourseCount = objcrs.MaxCourseCount
                };
                DB.tblCourseCounts.Add(crscount);
                DB.SaveChanges();
            }
        }

        public string FetchCourseDetails()
        {
            using (var DB = new MyDBEntities4())
            {
                var data = DB.tblCourses.Join(DB.tblCourseCounts, crs => crs.CourseCode, crscnt => crscnt.CourseCode, (crs, crscnt) => new
                {
                    crs.CourseCode,
                    crs.CourseName,
                    crs.TeacherName,
                    crs.StartDate,
                    crs.EndDate,
                    crscnt.MaxCourseCount
                });
                var Json = JsonConvert.SerializeObject(data);
                return Json;
            }
        }

        public void deletecourse(int ID)
        {
            using (var DB = new MyDBEntities4())
            {
                var data = DB.tblCourses.Find(ID);
                if (data != null)
                {
                    DB.tblCourses.Remove(data);
                    DB.SaveChanges();
                }
            }
        }

        public void EditCourse(CourseModel crsmodel,CourseCountModel crsobj)
        {
            using (var DB = new MyDBEntities4())
            {
                tblCourse std = new tblCourse()
                {
                    CourseCode = crsmodel.CourseCode,
                    CourseName = crsmodel.CourseName,
                    TeacherName = crsmodel.TeacherName,
                    StartDate = crsmodel.StartDate,
                    EndDate = crsmodel.EndDate
                };
                DB.Entry(std).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                tblCourseCount obj = new tblCourseCount()
                {
                    CourseCode = crsobj.CourseCode,
                    MaxCourseCount = crsobj.MaxCourseCount
                };

                var author = DB.tblCourseCounts.First(X => X.CourseCode == crsobj.CourseCode);
                author.MaxCourseCount = crsobj.MaxCourseCount;
                DB.SaveChanges();
            }
        }

    }
}
