USE [MyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_student_lessthanfive_Course]    Script Date: 17-07-2021 22:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_student_lessthanfive_Course]
as
select std.FirstName,count(sc.[CourseCode])
from tblStudent std
join tblStudentCourse sc 
on std.StudentId = sc.StudentId
group by std.FirstName
having count(sc.[CourseCode]) < 5