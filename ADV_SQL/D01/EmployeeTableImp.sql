use SD;

/* Create Table Departmeny */
create table Employee(
	EmpNo int ,
	EmpFname varchar(20),
	EmpLname varchar(20),
	DeptNo varchar(20),
	Salary money,

	/* PK constraint on EmpNo */
	constraint Emp_PK primary key (EmpNo),
	constraint Emp_FK foreign key (DeptNo) references De (DeptNo)

);
