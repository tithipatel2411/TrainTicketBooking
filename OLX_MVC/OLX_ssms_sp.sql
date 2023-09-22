create database OLX_DB

use OLX_DB




Create table Subcategory(          
    Id int IDENTITY(1,1) NOT NULL,          
    Product_id int NOT NULL,          
    SubcategoryName varchar(255) NOT NULL,  
    CategoryDescription varchar(30) NOT NULL,   
    price int NOT NULL,  
    Location varchar(220)  NULL,         
)  


insert into Subcategory values(1,'Mobile','sdfsfd',23,'ahm')
---select --index
alter procedure spGetAllSubcategory    
as        
Begin        
    select *        
    from Subcategory     
    order by Id   
End 

--insert--add
Create procedure spAddSubcategory          
(          
    @Product_id VARCHAR(50),           
    @SubcategoryName VARCHAR(50),          
    @CategoryDescription VARCHAR(30),          
    @price VARCHAR(20),  
    @Location VARCHAR(220)          
)          
as           
Begin           
    Insert into Subcategory (Product_id,SubcategoryName,CategoryDescription, price,Location)           
    Values (@Product_id,@SubcategoryName,@CategoryDescription, @price,@Location)           
End  

--edit
Create procedure spUpdateSubcategory            
(            
    @Id INTEGER ,          
    @Product_id VARCHAR(50),           
    @SubcategoryName VARCHAR(50),          
    @CategoryDescription VARCHAR(30),          
    @price VARCHAR(20),  
    @Location VARCHAR(220)             
)            
as            
begin				
   Update Subcategory             
   set Product_id=@Product_id,            
   SubcategoryName=@SubcategoryName,            
   CategoryDescription=@CategoryDescription,          
   price=@price,   
   Location=@Location            
   where Id=@Id            
End  


---delete
Create procedure spDeleteSubcategory              
(            
   @Id int            
)            
as             
begin            
   Delete from Subcategory where Id=@Id            
End
 


 select * from Subcategory