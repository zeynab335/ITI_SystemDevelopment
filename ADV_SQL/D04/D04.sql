--1 1.	Create a stored procedure 
-- without parameters to show the number of students per department name.[use ITI DB]

use ITI
create proc st_showStd 
as
select count(s.St_Id) , Dept_Name 
from Student s, Department d
where s.Dept_Id = d.Dept_Id
group by Dept_Name

st_showStd

--2.Create a stored procedure that will check for the # of employees in the project p1
-- if they are more than 3 print message to the user 
-- “'The number of employees in the project p1 is 3 or more'”
-- if they are less display a message to the user “'The following employees work for the project p1'” 
--in addition to the first name and last name of each one. [Company DB]

use SD

alter proc st_showEmpNumber
as
	 declare @t table(fname varchar(20), lname varchar(20)) 
	 declare @count int = 1
	 select @count = (
		select Count(e.EmpNo) from  Hr.Employee e , Works_on w , Company.Project p
		where (p.ProjectNo = w.ProjectNo) and (e.EmpNo = w.EmpNo) and (p.ProjectName = 'p1') 
		)
	select
		case 
			when @count  > 3  then 'The number of employees in the project p1 is 3 or more'
			when @count  < 3 then  'The following employees work for the project p1 ' + EmpFname + ' ' + EmpLname
		end
		
	from  Hr.Employee e , Works_on w , Company.Project p
	where (p.ProjectNo = w.ProjectNo) and (e.EmpNo = w.EmpNo) and (p.ProjectName = 'p1')

	
st_showEmpNumber



-- 3.	Create a stored procedure that will be used in case there is an old employee has left the project and a new one become instead of him.
-- The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number) 
-- and it will be used to update works_on table. [Company DB]

alter Proc st_updateEmpData @oldEmp# int , @newEmp# int  , @project# varchar(20) 
as
	BEGIN try
			update Works_on
			set EmpNo = @newEmp# 
			where (EmpNo = @oldEmp#) and (ProjectNo = @project#)
	END try
	BEGIN catch
		select 'something error'
	End catch
    
st_updateEmpData 3,1,'p1'


-- 4 - add column budget in project table and insert any draft values in it then 
-- then Create an Audit table with the following structure 


create trigger tr_update_trials 
on Company.Project 
for update 
as 
	declare @pnum varchar(50) , @oldBudj int ,  @newBudj int 
	select @pnum = ProjectNo , @oldBudj = budget from deleted 
	select @newBudj = budget from inserted 

	insert into Audit
	values(@pnum, SUSER_NAME() , GETDATE() , @oldBudj , @newBudj)

update Company.Project
set Budget = 5000
where ProjectNo='p3'


--55.	Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
-- “Print a message for user to tell him that he can’t insert a new record in that table”

use ITI

create trigger tr_prevent_Delete
on Department
instead of insert
as
	select 'not allowed'

insert into Department values (15	, 'SD2'	, 'System Development'	, 'Cairo',	1	,'2000-01-01')


--6 Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
use SD
create trigger tr_prevent_Insert
on Hr.Employee
instead of insert
as
	if DATENAME(mm , GETDATE()) = 'March'
		select 'not allowed'
	else 
		insert into Employee select * from inserted

insert into HR.Employee values (20,'emp1','lname','d3',5000)


-- 7.	Create a trigger on student table after insert to add Row in Student Audit table 
-- (Server User Name , Date, Note) 
-- where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”

use ITI
alter trigger tr_insert_trials 
on Student 
after insert 
as 
	declare @st# int , @stName varchar(50) 
	select @st# = St_Id , @stName = St_Fname  from inserted 

	insert into St_Audit
	values( SUSER_NAME() , GETDATE() , @stName + ' Insert New Row with Key= ' + convert(varchar(20) , @st# )+ ' in table Student' )

insert into Student values(23	, 'daaa'	, 'Saleh2'   , 'Tanta',	30	, NULL	,NULL)

select * from St_Audit


-- Create a trigger on student table instead of delete 
-- to add Row in Student Audit table (Server User Name, Date, Note)
-- where note will be“ try to delete Row with Key=[Key Value]”
alter trigger tr_insert_trials_2
on Student 
instead of delete 
as 
	declare @st# int 
	select @st# = St_Id from deleted 

	insert into St_Audit
	values( SUSER_NAME() , GETDATE() , ' try to delete Row with with Key= ' + convert(varchar(20) , @st# ))

delete from Student
where St_Id = 6


select * from St_Audit


-- 9.	Display all the data from the Employee table (HumanResources Schema) 
-- As an XML document “Use XML Raw”. “Use Adventure works DB” 
-- A)	Elements
-- B)	Attributes

use SD
-- Elements
select * from HR.Employee	
for xml raw('Employee'),ELEMENTS,ROOT('Employees')

-- Attributes
select * from  HR.Employee	
for xml raw('Employee'),Root('Employees')


-- 10.	Display Each Department Name with its instructors. “Use ITI DB”
-- A)	Use XML Auto
-- B)	Use XML Path

use ITI
select dept.Dept_Name ,  ins.Ins_Name
from Department dept , Instructor ins
where dept.Dept_Id = ins.Dept_Id
for xml auto,elements,root('Instructors_Inside_Department')

-- XML Path
select dept.Dept_Name "@Dept_Name",
	(select ins.Ins_Name 
	from Instructor ins
	where dept.Dept_Id = ins.Dept_Id
	for xml path('Instructor'),TYPE,root('Instructors')
	)
from Department dept
for xml path('Department'),root('Instructors_Inside_Department')


-- 11.	Use the following variable to create a new table “customers” inside the company DB.
use ITI
declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'


--3)declare document handle
declare @hdocs int

--4)create memory tree
Exec sp_xml_preparedocument @hdocs output, @docs

--5)process document 'read tree from memory'
SELECT * FROM OPENXML (@hdocs, '//customer') 
WITH (FirstName varchar(20) '@FirstName' , ZipCode int '@Zipcode' ,
orderItem  varchar(20) 'order',
orderID int 'order/@ID' 
)

--5)remove memory tree
Exec sp_xml_removedocument @hdocs


