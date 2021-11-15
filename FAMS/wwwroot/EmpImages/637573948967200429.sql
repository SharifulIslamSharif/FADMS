alter PROC [dbo].[SP_GET_Notification]  
  (  @userName as nvarchar(120)  )  
  AS  
  BEGIN 
   DECLARE @UserRole AS NVARCHAR(120) 
	  DECLARE @AspNetId AS NVARCHAR(120) 
	  SELECT TOP 1 @UserRole=AR.Name,  @AspNetId=A.Id
	  FROM AspNetUsers A 
	  INNER JOIN AspNetUserRoles AUR ON A.Id=AUR.UserId 
	  INNER JOIN AspNetRoles AR ON AR.Id=AUR.RoleId WHERE A.UserName=@userName  
	  --PRINT @UserId
	  PRINT @UserRole
	   IF @UserRole='Admin'
	  BEGIN 
		  select top 1 s.firstname+' '+s.lastname as fullName from studentInfos s
		  INNER JOIN AspNetUsers A ON s.ApplicationUserId=A.Id   
		  WHERE isactive=1   
	  END   
	  else begin print 'not admin' end
  END
  GO



  SELECT * FROM AspNetRoles
  SELECT * FROM AspNetUsers where Id='c015c198-ae40-4d65-a2de-f05de5bb6cfb'
  select top 1 * from studentInfos order by Id desc

  exec SP_GET_Notification 'md juel rana'