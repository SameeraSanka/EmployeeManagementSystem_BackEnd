
# Employee Management System - Backend

## Overview
The **Backend** for the Employee Management System is built using **.NET 8** and utilizes **SQL Server** for the database.

## Technologies Used
- **Framework**: .NET 8
- **Database**: SQL Server

## Requirements
- **.NET 8 SDK**
- **SQL Server**

## Setup Instructions

### 1. Clone the Repository
Clone the repository and navigate to the backend folder:
```bash
git clone <repository-url>
cd <repository-folder>/Backend
```

### 2. Create the Database
- Open SQL Server Management Studio (SSMS) or another database tool.
- Create a new database for the project, e.g., `EmployeeManagementDB`.

### 3. Update the Connection String
- Locate the `appsettings.json` file in the backend folder.
- Update the `ConnectionStrings` section with your database details. Example:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-database-server>;Database=EmployeeManagementDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
  ```

### 4. Run the Backend
- Open the backend project in Visual Studio or your preferred IDE.
- Build and run the project using https to start the API server. It will typically run on `https://localhost:7045`.

## Accessing the Backend
The API endpoints will be available at [https://localhost:7045/api/Employee](https://localhost:7045/api/Employee).
