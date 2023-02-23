USE [pubs]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTitleName]    Script Date: 2/22/2023 2:28:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[UpdatePropertiesInTitle]  @Property varchar(50) , @PropertyValue varchar(80) , @title_id varchar(6) 
as 
	execute ('update titles set ' + @Property + ' = ' + '''' + @PropertyValue + '''' +'where title_id = ' + '''' + @title_id  + '''')

	


	create or alter proc [dbo].[DeleteTitle]   @title_id varchar(6) 
as 
	begin
		execute ('Delete  from titles where title_id = ' + '''' + @title_id  + '''')
	end
	DeleteTitle 'TC7777'




	
alter proc insertNewTitle    @title_id varchar(6) , @title varchar(50)  ,@pub_id char(4) , @price money ,
@advance money , @royalty int, @ytd_sales int, @notes varchar(200)
as 

	insert into titles values (@title_id , @title ,null, @pub_id ,  @price , @advance , @royalty , @ytd_sales ,@notes , CURRENT_TIMESTAMP )  
	
	insertNewTitle '20' , 'title5' ,null ,  2000 , 2000 , 20 , 200 ,'jdjdjdj' 
