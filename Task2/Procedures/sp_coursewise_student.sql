USE [MyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_coursewise_student]    Script Date: 17-07-2021 22:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_coursewise_student]
as
select crs.CourseName, std.StudentID,std.FirstName,std.Surname 
from tblCourse crs join tblStudentCourse sc
on crs.CourseCode = sc.CourseCode
join tblStudent std 
on std.StudentId = sc.StudentId