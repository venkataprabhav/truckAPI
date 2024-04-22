# truckAPI
Simple API for Trucks coded using ASP.NET Core

Use of MSSQL Database has been implemented into this API.

### This API contains the following routes:

•	GET /Trucks  -  (Retrieves information of all trucks from the database)
•	POST /Truck  -  (Adds a new truck to the database after providing necessary information)
•	DELETE /RemoveTruck/{id}  -  (Deletes a Truck from the database through its ID)
•	PATCH /EditTruck/{id}  - (Edits a Truck's information through its ID and updated information)

### Below contains the columns and data types of Trucks in the table of the database: 

Field Name   -   Data Type 
ID           -   Guid 
Registration -   String 
GrossWeight  -   Numeric 
TareWeight   -   Numeric 
NettWeight   -   Numeric 
Haulier      -   String
