use ITI
create table AddNewRows (FName varchar(20) , LName varchar(20) , st_id int primary key )

declare @counter int = 3000
while (@counter < 6000)
	begin 
		insert into AddNewRows values('Jane' , ' Smith'  , @counter)
		set @counter += 1 
	end
