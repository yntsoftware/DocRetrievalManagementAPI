DocumentManagementApi



Project Overview



DocumentManagementApi is an ASP.NET Core Web API built with .NET 8.

This project is designed to manage documents with basic CRUD operations, simple searching, data validation, soft delete, and audit logging.

The purpose of this project is to demonstrate clean API design, proper validation, correct HTTP status codes, and clear documentation.



====================================================

Technology Stack

===================================================

.NET 8

ASP.NET Core Web API

Entity Framework Core

SQLite

Swagger (OpenAPI)

Visual Studio 2022



===================================================

Database/Migration

===================================================

Database: SQLite

ORM: Entity Framework Core

Approach: Code First with Migrations



Database Migration

To create and update the database, open Package Manager Console in Visual Studio 2022 and run:



Add-Migration InitialCreateTable

Update-Database



This will automatically create the database and required tables.



===================================================

Required NuGet Packages

===================================================

The following packages are installed via NuGet Package Manager (Solution) in Visual Studio 2022:

* Microsoft.AspNetCore.Identity.EntityFrameworkCore Version="8.0.0"
* Microsoft.EntityFrameworkCore.Sqlite Version="8.0.0"
* Microsoft.EntityFrameworkCore.Tools Version="8.0.0"



==================================================

How to Run the Project

=================================================

1. Open the solution in Visual Studio 2022
2. Restore NuGet packages (automatic)
3. Run database migration (see section above)
4. Click Run (▶) or press F5

The API will run using HTTPS.



=================================================

Swagger API Documentation

=================================================

Swagger is enabled for API documentation and testing.



https://localhost:7024/swagger/index.html





================================================

API Endpoints

================================================

Get All Documents => GET /documents

Filter by category: => GET /documents?category=Legal



Response Example

&nbsp; {

&nbsp;       "id": 5,

&nbsp;       "title": "Sample Document 5",

&nbsp;       "category": "Legal",

&nbsp;       "uploadedAt": "2026-01-06T23:53:21.3722395",

&nbsp;       "uploadedBy": "Supervisor",

&nbsp;       "isActive": true

&nbsp;   },



-------------------------------------------------

Get Document by ID : GET /documents/{id}

Response Example

{

&nbsp;   "id": 15,

&nbsp;   "title": "Sample Document 15",

&nbsp;   "category": "Medical",

&nbsp;   "uploadedAt": "2026-01-06T23:57:08.3191887",

&nbsp;   "uploadedBy": "Supervisor",

&nbsp;   "isActive": true

}

--------------------------------------------------



Create Document: POST /documents

Request Example

{

"title": "Sample Document 15",

"category": "Medical"

}



Response Example (201 Created)

{

    "id": 15,

    "title": "Sample Document 15",

    "category": "Medical",

    "uploadedAt": "2026-01-06T23:57:08.3191887",

    "uploadedBy": "Supervisor",

    "isActive": true

}

\*\*\*An audit log with action Insert will be created automatically.

----------------------------------------------------------------

Update Document: PUT /documents/{id}

Request Example

{

"title": "Updated test",

"category": "Medical"

}



Response Example (200 Ok)

Updated Successful! : Id: 20



\*\*\*An audit log with action Update will be created automatically.



----------------------------------------------------------------

Delete Document (Soft Delete) : DELETE /documents/{id}



This operation does not remove the record from the database.

It updates the field IsActive to false.



Response Example (200 Ok)

Deleted Successful! : Id: 20



\*\*\*An audit log with action Delete will be created automatically.



================================================================

Validation Rules

===============================================================



Validation is applied during Create and Update operations:



Title => Required , Maximum length: 150 characters

Category => Required



If validation fails, the API returns 400 Bad Request.



==============================================================

Audit Logging

==============================================================



Audit information is stored in a separate audit table.



Audit Fields

* Id (Int64)	=>  Audit record ID
* UserId (string) =>	User who performed the action
* Action (string) =>	Insert, Update, Delete
* TableName (string) => Name of affected table
* EntityId (Int64) =>	ID of affected record
* Timestamp (DateTime)	Date and time of the action



Audit logs are recorded for: Create, Update, Delete



==============================================================

Authentication

==============================================================



No authentication is implemented

A mock user is used for audit logging



User: Supervisor

Defined in DocumentsController



===============================================================

The API returns appropriate HTTP status codes:

==============================================================

200 OK => Request completed successfully

201 Created => created successfully

400 Bad Request => Validation error

404 Not Found => Data not found









