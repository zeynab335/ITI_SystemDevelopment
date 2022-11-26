
use ITI;


-- 1.Retrieve number of students who have a value in their age. 
select count(St_Id) 
from Student
where St_Age is not null

-- 2.	Get all instructors Names without repetition
select distinct Ins_Name  
from Instructor

-- 3.	Display student with the following Format (use isNull function) 
-- Std_id , Student_full name , department name
select St_Id  as [Student ID ], (St_Fname + ' ' + isNull(St_Lname , '')) as [Student Full Name] , Dept_Name as [Department name]
from Student S  , Department D
where D.Dept_Id = S.Dept_Id



-- 4.	Display instructor Name and Department Name 
--      Note: display all the instructors if they are attached to a department or not

select isNull(Ins_Name , '') as [Instructor Name] , isNull(Dept_Name,'') as [Department name]
from Instructor Ins left join Department D
on D.Dept_Id = Ins.Dept_Id



-- 5.	Display student full name and the name of the course he is taking For only courses which have a grade
select CONCAT(St_Fname ,  ' ' , St_Lname ) as [FullName] , Crs_Name
from Student S , Course C , Stud_Course SC
where (C.Crs_Id =  SC.Crs_Id) and (S.St_Id = SC.St_Id ) and (SC.Grade is not null);



-- 6.	Display number of courses for each topic name
select count(Crs_Id) , T.Top_Name
from Course C, Topic T
where T.Top_Id = C.Top_Id
group by T.Top_Name 



-- 7.	Display max and min salary for instructors
select max(isNull(Salary , 0)) as [Max Salary], min(isNull(Salary , 0)) as [Min Salary]
from Instructor;


-- 8.	Display instructors who have salaries less than the average salary of all instructors.
select Ins_Name 
from Instructor
where Salary < (select AVG(isNull(Salary , 0)) from Instructor);


-- 9.Display the Department name that contains the instructor who receives the minimum salary.
select Dept_Name
from Department 
where Dept_Id  in (select Top(1) s.Dept_Id from Instructor s order by(Salary) asc) ;


-- 10.	 Select max two salaries in instructor table. 
select Top(2) isNull(Salary,0) as [Max Salary]
from Instructor
order by(Salary) desc; 


-- 11 Select instructor name and his salary but if there is no salary display instructor bonus keyword. �use coalesce Function�
select Ins_Name , coalesce(convert(char , Salary), 'instructor Bonus')
from Instructor


-- 12.	Select Average Salary for instructors 
select avg(isNull(Salary ,0))  as [Average Salary]
from Instructor


-- 13.	Select Student first name and the data of his supervisor 
select S.St_Fname , sup.* 
from Student S , Student Sup
where S.St_super = Sup.St_Id


-- 14.	Write a query to select the highest two salaries in Each Department for instructors who have salaries.
-- �using one of Ranking Functions�

select * from (
select Salary ,Dept_Id ,ROW_NUMBER() over(partition by(Dept_Id) order by(Salary) desc ) as Rw
from Instructor
) as newTable
where Rw <3



-- 15 Write a query to select a random  student from each department.  �using one of Ranking Functions�
select * from ( select St_Fname , Dept_Id , ROW_NUMBER() over(partition by(Dept_Id) order by(newId())) as Rw 
from Student) as newtable
where Rw=1


