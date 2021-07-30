using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Newtonsoft.Json;

namespace DataBaseLayer
{
    public class StudentRegistration
    {
        public void AddStudent(StudentModel stdmodel)
        {
            using (var DB = new MyDBEntities4())
            {
                tblStudent std = new tblStudent()
                {
                    FirstName = stdmodel.FirstName,
                    Surname = stdmodel.Surname,
                    Gender = stdmodel.Gender,
                    DOB = stdmodel.DOB,
                    Address1 = stdmodel.Address1,
                    Address2 = stdmodel.Address2,
                    Address3 = stdmodel.Address3
                };
                DB.tblStudents.Add(std);
                DB.SaveChanges();
            }
        }


        public string FetchData()
        {
            using (var DB = new MyDBEntities4())
            {
                var data = DB.tblStudents.ToList();
                var Json = JsonConvert.SerializeObject(data);
                return Json;
            }
        }

        public void deletestudent(int ID)
        {
            using (var DB = new MyDBEntities4())
            {
                var data = DB.tblStudents.Find(ID);
                if (data != null)
                {
                    DB.tblStudents.Remove(data);
                    DB.SaveChanges();
                }             
            }
        }

        public void EditStudent(StudentModel stdmodel)
        {
            using (var DB = new MyDBEntities4())
            {
                tblStudent std = new tblStudent()
                {
                    StudentId = stdmodel.StudentId,
                    FirstName = stdmodel.FirstName,
                    Surname = stdmodel.Surname,
                    Gender = stdmodel.Gender,
                    DOB = stdmodel.DOB,
                    Address1 = stdmodel.Address1,
                    Address2 = stdmodel.Address2,
                    Address3 = stdmodel.Address3
                };
                DB.Entry(std).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
        }

      

    }
}
