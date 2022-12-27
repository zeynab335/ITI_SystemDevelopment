use ITI

--1 Create a view that displays student full name, course name if the student has a grade more than 50. 
create view StudentDetails
as 
	select (St_Fname+ ' ' +St_Lname ) as fullname ,  Crs_Name , Grade
	from Student st , Course c , Stud_Course std_c
	where (std_c.Crs_Id = c.Crs_Id ) and (st.St_Id = std_c.St_Id) and (Grade > 50)
with check option

select * from StudentDetails


--2  Create an Encrypted view that displays manager names and the topics they teach. 
alter view displayMgrName
with ENCRYPTION
as 
	select  d.Dept_Name ,  Mgr.Ins_Name , Mgr.Ins_Id , Top_Name
	from   Instructor Mgr 
	inner join Department d 
	on (Mgr.Ins_Id = d.Dept_Manager )
	
	inner join Ins_Course ins_c
	on ins_c.Ins_Id = Mgr.Ins_Id
	
	inner join Course c
	on c.Crs_Id = ins_c.Crs_Id

	inner join Topic t
	on t.Top_Id = c.Top_Id

select * from displayMgrName


-- 3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 


create view displayInsDepartments
with ENCRYPTION
as 
	select  d.Dept_Name ,  Ins_Name 
	from   Instructor ins
	inner join Department d 
	on (ins.Dept_Id = d.Dept_Id ) and (d.Dept_Name in ('SD' , 'java'))

select * from displayInsDepartments


/*
	Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
	Note: Prevent the users to run the following query 
	Update V1 set st_address=’tanta’
	Where st_address=’alex’;
*/
-- with check option restricts how rows can be modified

create view displayStudentsInAnotherCountry
as 
	select * from Student s
	where s.St_Address in ('Alex' , 'Cairo')
	with check option

select * from displayStudentsInAnotherCountry

Update displayStudentsInAnotherCountry set st_address='tanta'
Where st_address='alex';  -- error




-- 5.	Create a view that will display the project name and the number of employees work on it. “Use SD database”
use SD
create view displayAllEmployeesInProject
as
	select ProjectName , count(e.EmpNo) as NumberOfEmp
	from Company.Project p , Works_on w , Hr.Employee e
	where (p.ProjectNo = w.ProjectNo) and (e.EmpNo = w.EmpNo)
	group by ProjectName


select * from displayAllEmployeesInProject



-- 6 Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?
use ITI
create clustered index idx1
on Department(Manager_hiredate)


-- 7.	Create index that allow u to enter unique ages in student table. What will happen? 
create unique index idx2
on Student(St_Age)


--8 Using Merge statement between the following two tables [User ID, Transaction Amount]
use Transactions
create table DailyTransction(
	id int identity primary key ,
	quantity int
)	

create table LastTransction(
	id int identity primary key ,
	quantity int
)	

merge  DailyTransction as DT
using LastTransction as LT
on DT.id = LT.id
when matched and (LT.quantity >  DT.quantity )
	then update 
	set DT.quantity = LT.quantity  

-- new transaction will insert
when not matched 
	then insert 
	values(LT.quantity);

select * from DailyTransction


