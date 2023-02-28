use pubs;

create proc selectAllTitles 
as select * from titles



create proc selectAllPublishers 
as select * from publishers


create proc insertNewTitle @title_id varchar(40) , @title varchar(40) , @pub_id varchar(50) , @price money , @advance decimal , @royalty int , @ytd_sales int , @notes varchar(40)
as
	insert into titles
	values (@title_id
           ,@title
           ,null
           ,@pub_id
           ,@price
           ,@advance
           ,@royalty
           ,@ytd_sales
           ,@notes
           ,CURRENT_TIMESTAMP
		)


create proc UpdateTitle @title_id varchar(40) , @title varchar(40) , @pub_id varchar(50) , @price money , @advance decimal , @royalty int , @ytd_sales int , @notes varchar(40)
as
	update titles
	set 
        title = @title,
        pub_id = @pub_id,
         price = @price,
         advance =  @advance,
         royalty = @royalty,
          ytd_sales = @ytd_sales,
           notes = @notes
	where
	 title_id = @title_id;


create proc  DeleteTitle @title_id varchar(40)
as	
	Delete from titles
	where title_id = @title_id