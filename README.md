# Solution Stack

Blazor Server web app (`front_end_Stack`) plus REST API (`solution_stack_api`). Both use SQL Server LocalDB database **SolutionStackDb**. Migrations and seed data run automatically on startup.

## Reset the database (optional)

Use this for a clean slate (drops all users, orders, and Identity data). **Stop both apps first** so nothing is connected to the database.

```powershell
sqllocaldb start mssqllocaldb
sqlcmd -S "(localdb)\mssqllocaldb" -Q "IF DB_ID('SolutionStackDb') IS NOT NULL BEGIN ALTER DATABASE SolutionStackDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE SolutionStackDb; END"
```

## Running the Project

Solution → Configure Startup Projects → Multiple startup projects  
Set solution_stack_api and front_end_Stack to Start  
Run the project

## Default Admin Login

Email: admin@admin.com  
Password: 12345Az@
