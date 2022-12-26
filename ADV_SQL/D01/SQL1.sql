use SD;

/* Create Table Departmeny */
create table Department(
	DeptNo varchar(20) primary key,
	DeptName varchar(20),
	Location varchar(20),
);

/* Create a new user data type  */
Alter Table Department  
DROP column loc 

/* Create a rule for this Datatype 
:values in (NY,DS,KW)) and */

sp_addtype loc,'nchar(2)'  

create default loc_def1 as 'NY'

CREATE RULE r1_Dep
As
@value IN ('NY','DS','KW');

sp_bindrule r1_Dep , loc

sp_bindefault loc_def1 , loc

/*insert before binding rule */
insert into Department values
('d1' , 'Dep1','loction','kk'),
('d2' , 'Dep2','loction','PP');

/* Bind this rule to column name*/
sp_bindrule r1_Dep , 'Department.loc' 

/*insert data after binding */
insert into Department values
('d6' , 'Dep3','loction','kk')  /* make error */


/* Create Table Departmeny */
create table Employee(
	EmpNo int ,
	/*5-EmpFname, EmpLname not null*/
	EmpFname varchar(20) not null,
	EmpLname varchar(20) not null,
	DeptNo varchar(20),
	Salary money,

	/* PK constraint on EmpNo */
	constraint Emp_PK primary key (EmpNo),
	constraint Emp_FK foreign key (DeptNo) references Department(DeptNo),

	/*4-Unique constraint on Salary */
	constraint Emp_Salary unique (Salary),
);


/*6-Create a rule on Salary column 
	to ensure that it is less than 6000 */

create rule r2_salary 
As
@value < 6000;

sp_bindrule r2_salary , 'Employee.Salary'


/*1-Add  TelephoneNumber column to the employee table[programmatically]*/
alter table Employee add TelephoneNumber varchar(11)

/*2-drop this column[programmatically]*/
alter table Employee drop column TelephoneNumber

/*3-Bulid A diagram to show Relations between tables*/

/*********************************************************/

/*2.Create the following schema and transfer the following tables to it */
/* Company Schema */
/*Programmatically*/
create schema Company
alter schema  Company transfer Department

create schema HR
alter schema  HR transfer Employee


/*3.Write query to display the constraints for the Employee table.*/
sp_helpconstraint 'HR.Employee'


-- 4 
create synonym emp for HR.Employee
Select * from Employee	-- not working
Select * from HR.Employee
Select * from emp
Select * from HR.Emp      -- not working

--5 Increase the budget of the project where the manager number is 10102 by 10%.

update company.project set budget +=(budget*0.1) from hr.employee
where EmpNo in(select empno from Works_on where empno=10102 and Job='manger') 


update Company.Project
set budget = budget + 0.1*budget
from  Company.Project , Works_on 
where (Works_on.EmpNo = 10102) and (Works_on.ProjectNo = [Company].Project.ProjectNo)


-- 6.	Change the name of the department for which the 
-- employee named James works.The new department name is Sales.

update Company.Department
set Company.Department.DeptName = 'sales'
from  Company.Project , HR.Employee
where  [Company].Department.DeptNo =  HR.Employee.DeptNo
--and HR.Employee.

--7.Change the enter date for the projects for those employees
--who work in project p1 and belong to department ‘Sales’.
-- The new date is 12.12.2007.

update Works_on
set Enter_Date = '12.12.2007'
from  Company.Project , Works_on , HR.Employee 
where 
( Company.Project.ProjectName= 'p1') and 
(HR.Employee.EmpNo = Works_on.EmpNo  ) 
and 
HR.Employee.DeptNo = (select  Company.Department.DeptNo from Company.Department where Company.Department.DeptName = 'sales')


-- 8.	Delete the information in the works_on table
-- for all employees who work for the department located in KW.

delete from Works_on 
where EmpNo in (select EmpNo from HR.Employee e
inner join Company.Department d
on (d.DeptNo = e.DeptNo) and (d.loc = 'KW'))
