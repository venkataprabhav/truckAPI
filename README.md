# truckAPI (Updates: Frontend added for two endpoints) (Upcoming Updates: Implementing the use of Angular)
Simple API for Trucks coded using ASP.NET Core (.NET 6)
Use of MSSQL Database has been implemented into this API.
Unit Tests for testing endpoints have been implemented using the 'xUnit' framework.

## The API
This section contains information of what the API contains (endpoints and database) and their functions

### This API contains the following routes:

•	GET /Trucks  -  (Retrieves information of all trucks from the database)

![image](https://github.com/venkataprabhav/truckAPI/assets/123014399/d35286ab-e77d-4a46-b0c8-36b4817e50f9)


•	POST /Truck  -  (Adds a new truck to the database after providing necessary information)

![image](https://github.com/venkataprabhav/truckAPI/assets/123014399/9e10d612-e818-466d-81f7-949fb816b4b7)


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



![image](https://github.com/venkataprabhav/truckAPI/assets/123014399/9276cd4c-58f2-45a4-848c-0a2ac8003d9d)



## Unit Tests
This section provides an overview of the unit tests conducted for the Truck API controllers.

###	Unit Tests on /Truck - (POST)
Contains two Unit Tests. 
1. Unit Test that verifies that valid truck information is provided 
2. Unit Test that results in 'Bad Request' when truck information is not entered appropriately (null/empty).

### Unit Tests on /Trucks - (GET)
Contains a Unit Test that verifies all truck information is retrieved from the database and returned.

###	Unit Tests on /RemoveTruck/{id} - (DELETE)
1. Unit Test that retrieves information of trucks from database to verify deletion of truck information (used in 2nd Unit Test).
2. Unit Test that verifies deletion of truck information from database.
3. Unit test that results in a 'Not Found' when the Truck ID is not valid (null/incorrect ID)

###	Unit Tests on /EditTruck/{id} - (PATCH)
1. Unit Test that verifies that a truck's information has been successfully edited.
2. Unit Test that results in 'Bad Request' when truck information is not entered appropriately (null/empty).
3. Unit test that results in a 'Not Found' when the Truck ID is not valid (null/incorrect ID)

### Screenshot of Unit Tests
![image](https://github.com/venkataprabhav/truckAPI/assets/123014399/a743de0c-0af1-4a0c-8712-e83d8941c84c)



