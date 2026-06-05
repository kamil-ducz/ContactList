# ContactList Local Setup
## Purpose
This project is a full-stack application that connects a .NET backend, an Angular frontend, and a SQL database. It demonstrates data mapping from C# code to a SQL database using Entity Framework, and connects these components with Angular services and a simple user interface. The application allows users to add, view, and edit contacts organized by categories.

## Steps
1. Download repository - master or development branch.
4. In backend folder open solution in your .NET IDE.
5. Use Package Manager Console and launch command 'update-database' to let Entity Framework create and populate database. Use Default project: ContactList.Infrastructure not Api.
6. Run backend solution with ContactList.Api selected as the startup project(should be so by default).
7. For this project npm package manager version 8.5.5 was used, Angular version 16. Make sure to have both npm and angular installed. In cmd/PowerSheell both 'npm' and 'ng' commands should work.
8. In frontend folder open terminal and launch command 'npm install' to install npm packages. Next launch command 'npm start' to start the frontend project.
9. Frontend is configured in launchSettings.json to work on port 4200 so to access the application go to URL: http://localhost:4200/
10. Happy testing
