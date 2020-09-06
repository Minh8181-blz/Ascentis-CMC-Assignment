# Ascentis - CMC Assignment

This is the repository of electric register assignment project. The following platforms/frameworks are used in the project:
  - .NET Core 3.1
  - ASP.NET Core 3.1
  - .NET Console Application 3.1
  - SQL Server
  - Entity Framework core 3.1
  - XUnit

## Deployment instructions

  The following instructions guide you through the steps to run the applications on local machine
>Prerequisites: make sure .NET Core 3.1 is installed on your manchine and an SQL Server instance is available

### Step 1: Create database & import schema
  - Connect to your SQL Server instance
  - Create a database named **device_manager**
  - Execute the **db.sql** script file at the root folder of repository on the instance
### Step 2.1: Run web application
  - Open the solution with Visual Studio 2019
  - Publish the ***DeviceManager.Presentation.Web*** project as FolderProfile
  - Navigate to the target folder, open command window and submit command 
    >dotnet DeviceManager.Presentation.Web.dll
  - Or navigate to the target folder and execute **DeviceManager.Presentation.Web.exe**
  - Access url https://localhost:5001/ from your browser
### Step 2.2: Run console application
  - Open the solution with Visual Studio 2019
  - Publish the ***DeviceManager.Presentation.ConsoleApp*** project as FolderProfile
  - Navigate to the target folder and execute **DeviceManager.Presentation.ConsoleApp.exe**
