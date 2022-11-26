use Company_SD;

-- 1. Display the Department id, name and id and the name of its manager
select Dnum , Dname ,MGRSSN ,Fname 
from Departments D inner join Employee E
on D.MGRSSN = E.SSN


-- 2.Display the name of the departments and the name of the projects under its control.
select Dname , Pname , P.Dnum 
from Departments D inner join Project P
on D.Dnum = P.Dnum


-- 3.Display the full data about all the dependence associated with the name of the employee they depend on him/her.
select D.* , (E.Fname + ' ' + E.Lname) as EmployeeName
from Dependent D , Employee E
where E.SSN = D.ESSN

-- 4.Display the Id, name and location of the projects in Cairo or Alex city.
select Pnumber , Pname , Plocation
from Project  
where City in ('Cairo', 'Alex');


-- 5.	Display the Projects full data of the projects with a name starts with "a" letter.
select * from Project where Pname like 'A%'


-- 6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
select (Fname + ' ' + Lname) as Name , Salary
from Employee 
where Dno = 30 and  (Salary between 1000 and 2000)


-- 7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
select (Fname + ' ' + Lname) as Name
from Employee , Works_for W , Project P
where (SSN = ESSn) and (W.Pno = P.Pnumber) and (Dno = 10 ) and (Pname = 'AL Rabwah' ) and (Hours <= 10)


--8.	Find the names of the employees who directly supervised with Kamel Mohamed.
select (E.Fname + ' ' + E.Lname) as Name , Sup.Fname
from Employee E , Employee Sup
where (E.Superssn = Sup.SSN) and (Sup.Fname = 'Kamel' ) and (Sup.Lname = 'Mohamed' ) 


-- 9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.

select Fname , Pname
from Employee , Works_for , Project
where (SSN = ESSn) and (Pno = Pnumber ) 
order by Pname

-- 10.	For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
select Lname , Pnumber  , Dname , Address , Bdate
from Departments D Inner join Project P on (D.Dnum = P.Dnum) and (City = 'Cairo Ciry')
Inner join Employee on (SSN = D.MGRSSN)  


-- 11.	Display All Data of the managers
select distinct E.* 
from Employee E , Departments D
where E.SSN = D.MGRSSN


--12.Display All Employees data and the data of their dependents even if they have no dependents
select E.* , D.*
from Employee E left outer join Dependent D
on E.SSN = D.ESSN;


-- 13.	Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000
insert into Employee (Dno , SSN ,Superssn, Salary , Fname) values(30 , 102672 , 112233 , 3000 , 'Zeinab');


--14.	Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
insert into Employee (Dno , SSN) values(30 , 102660)
--update Employee  set Fname = 'My Friend'   where SSN = 102660



-- 15 Upgrade your salary by 20 % of its last value.
update Employee 
set Salary = Salary + Salary * 0.2
where SSN = 102672;