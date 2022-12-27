use SD

-- 1)	Create view named   “v_clerk” that will display employee#,project#, 
-- the date of hiring of all the jobs of the type 'Clerk'.

create view v_clerk
as 
	select ProjectName , e.EmpNo , Job
	from Company.Project p , Works_on w , Hr.Employee e
	where (p.ProjectNo = w.ProjectNo) and (e.EmpNo = w.EmpNo) and (Job = 'Clerk')

select * from v_clerk
	

--- 2)	 Create view named  “v_without_budget” that will display all the projects data without budget
-- budget in project table
create view v_without_budget
as 
	select ProjectName , Budget
	from Company.Project p 
	where (p.Budget is null) 

select * from v_without_budget


-- 3)	Create view named  “v_count “ that will display the project name and the # of jobs in it
create view v_count
as 
	select ProjectName , COUNT(w.Job) as #
	from Company.Project p , Works_on w 
	where (p.ProjectNo = w.ProjectNo) 
	group by ProjectName 

select * from v_count


--4 Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
-- use the previously created view  “v_clerk”

create view v_project_p2
as 
	select EmpNo as 'emp#', ProjectName as 'project#'
	from v_clerk
	where ProjectName = 'p2'

select * from v_project_p2


-- 5)	modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 


alter view v_project_p2
as 
	select *
	from v_clerk
	where ProjectName in  ('p1','p2')

select * from v_project_p2


-- 6)	Delete the views  “v_ clerk” and “v_count”
drop view v_clerk
drop view v_count


-- 7)	Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
create view e_count
as 
	select EmpNo as 'emp#' , EmpLname , DeptName
	from Company.Department d , HR.Employee e
	where (d.DeptNo = e.DeptNo)  and (DeptName = 'd2')


select * from e_count


-- 8)	Display the employee  lastname that contains letter “J” 
-- Use the previous view created in Q#7

create view v_check_empname
as 
	select EmpLname 
	from e_count
	where EmpLname like '%j%'

select * from v_check_empname


-- 9)	Create view named “v_dept” that will display the department# and department name.
create view v_dept
as 
	select DeptNo as 'department#' , DeptName
	from Company.Department 


select * from v_dept


--10)using the previous view try enter new department data 
-- where dept# is ’d4’ and dept name is ‘Development’

insert into v_dept 
values ('d4' , 'Development');


-- 11)	Create view name “v_2006_check” that will display 
-- employee# 
-- the project# where he works
-- the date of joining the project 
-- which must be from the first of January and the last of December 2006.
create view v_2006_check
as 
	select p.ProjectNo , e.EmpNo  , Enter_Date
	from Company.Project p , Works_on w , HR.Employee e
	where (p.ProjectNo = w.ProjectNo) and (e.EmpNo = w.EmpNo) 
	and (year(Enter_Date) = 2006 )
	

select * from v_2006_check

