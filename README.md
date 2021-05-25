# LoanAgreementApp


The Loan Agreement API is an API used for Calculate Client loan intrest return for a particular amount passed in StartDate and End date   

## Table Of Content
1. [General Info] (#general-info)
2. [Technologies] (#technologies)
3. [Installation] (#installation)
4. [Collaboration] (#collaboration)
5. [API Flow] (#apiflow)

## General Info
***
The Loan Agreement API is an API used for Calculate Client loan intrest return for a particular amount Requested. This system consist of two separate projects: LoanAgreementAPI and VeriShareApplicationUI in MVC.
This project is currently in development stage.

## Technologies
***
A list of technologies used within the project:
* [Visual Studio 2019] (https://visualstudio.microsoft.com/downloads/)
* [.Net Core] (https://dotnet.microsoft.com/download/dotnet/3.1)
* [Sql Server Management Studio 18] (https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)



## Installation
***
You need to create a database, update the connection string then run the API.
***
1. git clone https://github.com/Sbu1/StudentsAPI.git using git or download the project direct https://github.com/Sbu1/StudentsAPI
2. Execute studentAttendanceDBscript in sql server which is in the project root folder.
3. Open the project using visual studio.
4. If you are using local sql server you don't need to update your connection string but if you using testing environment please change the server name in the connection string to point to your testing server.
6. If you need postman collection, you can find it in the root folder of the project




## API Flow
1.You need to create customers using the MVC Application

2. when you get all customers you need to request a loan for a customer 

3. result on reflecting from the inputs you provided will calculate from stored procedure and show data back.


7. User Local DB Database To run all the tables on the  project you have to add-migrations and update that database 

8. Create Customer
9. Create Agreementtype 