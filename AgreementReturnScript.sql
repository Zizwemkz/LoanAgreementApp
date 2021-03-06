USE [LOANAgreementDB]
GO

/****** Object:  StoredProcedure [dbo].[AgreementInterestReturn]    Script Date: 2021/05/25 08:01:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[AgreementInterestReturn] 

@AgreementTypeID int,
@Amount int,
@StartDate Nvarchar(30) ,
@EndDate Nvarchar(30) ,
@RepoRate decimal (16,2),
--@CustomerId int,

@return_status int output,
@Calculation decimal (16,2) output,
@return_message Nvarchar(50) output,
@return_Agreementtype Nvarchar(10) output

--select datediff(m, @StartDate,dateadd(d,1,@EndDate))
--select datediff(m, @StartDate,dateadd(d,1,@EndDate))
--select datediff(d, @StartDate,@EndDate)/365,@interestAgreementTypeID,@RepoRate

AS

BEGIN
     if (@AgreementTypeID = 1 )
	  IF (((select datediff(D, @StartDate,@EndDate)/365) >= 1))
	   BEGIN
	          set  @Calculation = @Amount * ((((@RepoRate * 2.2) + 0.05)) / 100) * datediff(D, @StartDate,@EndDate)/365
	          set @return_status = 1
			  set @Amount  =  @Amount
			  set @return_Agreementtype = '1'
	          set @return_message = 'Transection Completed Successful'
	    END
  
   ELSE
	      BEGIN
	         set @return_status  = 0
			 set @return_Agreementtype = '1'
	         set @return_message = 'Transection Did not exacute successfuly please check the date range selected if it > Year'
	     END
END



    BEGIN
      IF (@AgreementTypeID = 2 or @AgreementTypeID = 7 )
	  IF(((select datediff(D, @StartDate,@EndDate)/365) >= 1))
		BEGIN 
	     	set  @Calculation =  @Amount * ((((@RepoRate * 2.2) + 0.10)) / 100) * datediff(D, @StartDate,@EndDate)/365
            set @return_status = 1
			set @Amount  =  @Amount
			set @return_Agreementtype = '2,7'
            set @return_message = 'Transection Completed Successful'
         END
   ELSE
	   BEGIN
	         set @return_status  = 0
			 set @return_Agreementtype = '2,7'
	         set @return_message = 'Transection Did not exacute successfuly please check the date range selected if it > Year'
	    END
   END

   BEGIN
     IF (@AgreementTypeID = 3 or  @AgreementTypeID = 4 or  @AgreementTypeID = 5)
	   IF (((select datediff(D, @StartDate,@EndDate)/365) >= 1))
	   BEGIN
	          set  @Calculation = @Amount * ((((@RepoRate * 2.2) + 0.20)) / 100) * datediff(D, @StartDate,@EndDate)/365
	          set @return_status = 1
			  set @Amount  =  @Amount
			  set @return_Agreementtype = '3,4,5'
	          set @return_message = 'Transection Completed Successful'
	    END
  
   ELSE
	      BEGIN
	         set @return_status  = 0
			 set @return_Agreementtype = '3,4,5'
	         set @return_message = 'Transection Did not exacute successfuly please check the date range selected if it > Year'
	     END
END

BEGIN
		IF (@AgreementTypeID = 6)
			IF ((select datediff(m, @StartDate,@EndDate) )> 1 )
        BEGIN 	
	     set @Calculation = @Amount * 0.05 * (datediff(m, @StartDate,dateadd(d,1,@EndDate)))
	     set @return_status = 1
		  set @Amount  =  @Amount
		 set @return_Agreementtype = '6'
	     set @return_message = 'Transection Completed Successful'
      END

	 ELSE
	       BEGIN
	         set @return_status  = 0
			 set @return_Agreementtype = '6'
	         set @return_message = 'Transection Did not exacute successfuly please check the date range selected if it > MOnth'
	        END
END

BEGIN
       IF (@AgreementTypeID = 8)
	   IF((select datediff(m, @StartDate,@EndDate) )> 1 )
          BEGIN 
                 set  @Calculation =  @Amount * 0.02 * (datediff(m, @StartDate,dateadd(d,1,@EndDate)))
                 set @return_status = 1
				 set @return_Agreementtype = '8'
	             set @return_message = 'Transection Completed Successful'
          END
     
	 ELSE
	   BEGIN
	         set @return_status  = 0
			  set @return_Agreementtype = '8'
	         set @return_message = 'Transection Did not exacute successfuly please check the date range selected if it > MONTH'
	    END
END

			    
  select @Calculation As 'Calculation',
            @return_status As 'return_status',
			@Amount As 'Amount',
             @return_message As 'return_message',
			 @return_Agreementtype As'return_Agreementtype'


			 

GO

