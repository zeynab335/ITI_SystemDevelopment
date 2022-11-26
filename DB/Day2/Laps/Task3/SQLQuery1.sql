use Company_SD;


/*select * from Employee */
select * from Employee;

/*Num 2 */
select Fname , Lname, Salary, Dno
from Employee;

/*Num 3 */
select Pname , Plocation, Dnum 
from Project;

/*Num 4*/
select Fname +' ' + Lname as FULLNAME  , (Salary*12*0.1) as [ANNUAL COMM] 
from Employee;

/*Num 5*/
select SSN , Fname
from Employee
where Salary > 1000;

/*Num 6*/
select SSN , Fname
from Employee
where (Salary * 12) > 10000;



/*Num 7*/
select Fname , Salary
from Employee
where Sex = 'F';


/*Num 8 */
select Dnum , Dname
from Departments
where MGRSSN = 968574;


/*Num 9 */
select Pnumber , Pname , Plocation
from Project
where Dnum = 10;

