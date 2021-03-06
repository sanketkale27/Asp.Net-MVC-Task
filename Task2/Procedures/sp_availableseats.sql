USE [MyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_availableseats]    Script Date: 17-07-2021 22:11:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_availableseats]
as
select sc.CourseCode, cc.[MaxCourseCount] - Count(sc.[CourseCode]) as Available_seats, cc.[MaxCourseCount] as Total_Seats
from [dbo].[tblStudentCourse] sc
join [dbo].[tblCourseCount] cc
on sc.CourseCode = cc.CourseCode
group by sc.CourseCode,cc.[MaxCourseCount]