-------------------- Task 4 -----------------------------

use Company_SD;
-- 1- a-The name and the gender of the dependence that's gender is Female and depending on Female Employee.
select D1.Dependent_name , D1.Sex
from Dependent D1
where D1.Sex = 'F'
union 
select  D.Dependent_name , D.Sex
from Dependent D
where D.Sex = 'M' 



--- 2.	For each project, list the project name and the total hours per week (for all employees) spent on that project

select P.Pname , sum(Hours*7)
from Project P , Works_for W
where P.Pnumber = W.Pno 
group by P.Pname ;

/*
select P.Pname , Hours
from Project P , Works_for W
where P.Pnumber = W.Pno 
*/


--- 3.	Display the data of the department which has the smallest employee ID over all employees' ID.
-- using subquery
select D.* 
from Employee E , Departments D
where (Dno = Dnum) and SSN = (select min(SSN) from Employee) 


-- 4.	For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
select D.Dname , max(E.Salary) as [Max Salary] , min(E.Salary)  as [Min Salary] , avg(isnull(E.Salary , 0))  as [Avg Salary]
from Departments D , Employee E
where D.Dnum = E.Dno
group by D.Dname
/*
select D.Dname , E.Salary
from Departments D , Employee E
where D.Dnum = E.Dno
*/


-- 5.	List the full name of all managers who have no dependents
-- using subquery
select Fname + ' ' + Lname  as [Full Name]  , SSN
from Employee E inner join Departments D
on E.SSN = D.MGRSSN  
where D.MGRSSN  not in (select ESSN from Dependent)



-- 6.	For each department-- if its average salary is less than the average salary of all employees
-- display its number, name and number of its employees.


select D.Dnum , D.Dname , count(E.SSN) as [Number Of Emp] ,avg(isnull(Salary , 0)) 
from Departments D , Employee E
where D.Dnum = E.Dno
group by D.Dnum , D.Dname 
having avg(isnull(Salary , 0)) < (select avg(isnull(Salary , 0)) from Employee )


-- 7.	Retrieve a list of employees names and the projects names they are working on 
-- ordered by department number and within each department, ordered alphabetically by last name, first name.
select Fname , Lname ,  Pname , Dno
from Employee E , Project P , Works_for W
where (E.SSN = W.ESSn) and (P.Pnumber = W.Pno)
order by E.Dno , Lname asc , Fname asc


-- 8.Try to get the max 2 salaries using subquery
select Top(2) Salary
from Employee E
--where Salary <= (select max(Salary) from Employee)
order by Salary desc



-- 9.	Get the full name of employees that is similar to any dependent name
select Fname + ' ' +  Lname as [FullName] 
from Employee E
where Fname + ' ' +  Lname in (select Dependent_name from Dependent )


--select Dependent_name from Dependent
--select Fname + ' ' +  Lname as [FullName]  from Employee E




-- 10.	Display the employee number and name if at least one of them have dependents (use exists keyword) 
select SSN , Fname + ' ' +  Lname as [FullName]
from Employee E
where EXISTS 
(select Dependent_name from Dependent where SSN = ESSN)



-- 11.	In the department table insert new department called "DEPT IT" , with id 100, 
-- employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'

insert into Departments (Dname , Dnum , MGRSSN  , [MGRStart Date]) values ('DEPT IT' ,100 , 112233 , '1-11-2006')


/* 12.	Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100),
and they give you(your SSN =102672) her position (Dept. 20 manager) 
a.	First try to update her record in the department table
b.	Update your record to be department 20 manager.
c.	Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)
*/


update Departments
	set MGRSSN = 968574 
where Dnum = 100

update Departments
	set MGRSSN = 102672
where Dnum = 20

update Employee
	set Superssn = 102672
where SSN = 102660




/*
13.	Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344) so try to delete his data from your database in case you know that you will be temporarily in his position.
Hint: (Check if Mr. Kamel has dependents, works as a department manager, supervises any employees or works in any projects and handle these cases).
*/

update Employee
	set Superssn = 102672
where (Superssn = 223344)

update Departments 
	set MGRSSN = 102672
where (MGRSSN = 223344)

update Works_for
	set ESSn = 102672
where (ESSn = 223344)



delete from Employee where (SSN = 223344) ;




--- 14.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%

update Employee 
	set Salary += Salary * 0.3
	from Works_for W , Project P
	where (W.ESSn = SSN) and (P.Pnumber = W.Pno) and (Pname = 'Al Rabwah');