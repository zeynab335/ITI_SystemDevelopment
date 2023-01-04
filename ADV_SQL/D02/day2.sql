-- 1.Create a scalar function 
-- that takes date and returns Month name of that date.


create function getNameOFMonth(@d date) 
returns nvarchar(50)
begin 
	return FORMAT(@d, 'MMMM')
end

select dbo.getNameOFMonth(GETDATE()) as 'month name'



---------------------------------------------

-- Create a multi-statements table-valued function that takes 2 integers and
-- returns the values between them.

create function getRangeNumbers(@x int , @y int ) 
returns @t table
		(
		 Range_num int 
		)
as
begin
	declare @counter int = @x
	while @counter != @y+1
		BEGIN
			insert into @t values(@counter)
			SET @counter = @counter + 1 ;

		END

return 
end

select * from getRangeNumbers(5,10)




-- Create inline function that takes Student No and
-- returns Department Name with Student full name.

use ITI 

create function getDepartment(@std_id int)
returns table
as 
return
(
	select s.st_fname, s.St_Lname , d.Dept_Name
	from student s , Department d
	where s.Dept_Id = d.Dept_Id and s.St_Id = @std_id 
)

select * from dbo.getDepartment(1)



--------------------------------------------------------

/*

	4.	Create a scalar function that takes Student ID and returns a message to user 
		a.	If first name and Last name are null then display 'First name & last name are null'
		b.	If First name is null then display 'first name is null'
		c.	If Last name is null then display 'last name is null'
		d.	Else display 'First name & last name are not null'

*/


create function getMessage(@std_id int)
	returns nvarchar(50)
	begin
		declare @fs_name varchar(50) 
		declare @l_name  varchar(50)

		
		select @fs_name = St_fname , @l_name = St_Lname from Student where St_Id = @std_id

		if (@fs_name is null) and (@l_name is null)
			return 'no user'
			
		else if (@fs_name is null)
			return 'first name is null'

		else if (@l_name is null)
			return 'last name is null'

	
		return 'First name & last name are not null'
			
	end


select dbo.getMessage(1)

----------------------------------------------------------

--5.Create inline function that takes integer 
-- which represents manager ID 
-- and displays department name, Manager Name and hiring date


alter function getDepartmentData(@mgr_id int)
returns table
as 
return
(
	select  d.Dept_Name ,  Mgr.Ins_Name , Manager_hiredate
	from   Instructor Mgr , Department d
	where d.Dept_Manager = @mgr_id and Mgr.Ins_Id = d.Dept_Manager  )

select * from dbo.getDepartmentData(1)


--------------------------------------------------------
/*
	6.	Create multi-statements table-valued function that takes a string
	If string='first name' returns student first name
	If string='last name' returns student last name 
	If string='full name' returns Full Name from student table 
	Note: Use “ISNULL” function
*/


alter function getNames(@string varchar(20)) 
returns @t table
		(
		 name varchar(20) 
		)
	as
	begin
		insert into @t
		select 
			case 
				when @string='first name' then isnull(St_Fname,' ')
				when @string='last name'  then isnull(St_Lname,' ')
				when @string='full name'  then concat(St_Fname , ' ' , St_Lname )
				--concat(isnull(St_Fname,' ') , ' ' ,isnull(St_Lname,' ')) 
			end
		from Student 

		return 
			 
	end

select * from getNames('full name')




---------------------------------------------------------

--7 Write a query that returns the Student No and
-- Student first name without the last char

select St_Id , SUBSTRING(St_Fname, 0 , LEN(St_Fname))

from Student 



----------------------------------------------------


-- 8.	Wirte query to delete all grades for the students Located in SD Department
--delete from Stud_Course
--if exists(select 1 from sys.tables where name='studen')
delete st 
from Stud_Course st
inner join student s
on st.St_Id = s.St_Id
inner join Department d
on d.Dept_Id = s.Dept_Id and d.Dept_Name = 'SD'
