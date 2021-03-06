USE [MyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_showstudewisedata]    Script Date: 17-07-2021 22:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_showstudewisedata]
as
select distinct std.StudentID,std.FirstName,
  STUFF((SELECT distinct ', ' + crs.CourseName 
         from tblStudentCourse sc join tblCourse crs on crs.CourseCode = sc.CourseCode
         where sc.StudentId = std.[StudentId]
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,2,'') CourseName
from tblstudent std join tblStudentCourse sc
on sc.StudentId = std.[StudentId]