# ContactManagement
Project by Chintan Purohit 

Hello User

This repository consists of 4 projects
1.ContactManagement -- Web API (http://localhost/ContactManagement)
2.ContactManagementWebAplication -- MVC web application (http://localhost/ContactsManager)
3.ContactManagement.Tests -- Test project
4.ContactModel -- POCO classes and repository

#Steps to setup project locally 
1. Launch Visual studio 2017/2015 in Administrator mode
2. Right click ContactManagement and go to properties -> Web -> Create Virtual directory
3. Right click ContactManagementWebApplication and go to properties -> Web -> Create Virtual directory

#Steps to setup database locally
1. Create a profile for user ContactDBUser in SQL server management studio
    a. Go to security folder of server
    b. In login select new
    c. Enter loginName and Password (Make sure connection string is updated with current Uname and Password)
    d. In ServerRoles -> select Public and SysAdmin
    e. In Status -> Select "Permission to conect -> Grant" and "Database login -> enabled"
2. Launch Nuget Package manager console to setup database locally
3. In console point to project "ContactModel" and "ContactManagement" is set up as startup project
4. Delete all migration history in Migration folder first since we are setting it up for first time
5. Type below commands in sequence
        Enable-migrations    --To enable creating migration files
        Add-migration <MigrationName> --Migration script is created
        Update-Database --Database will get created in server 
6. Go back to SSMS in Security->Login->ContactDBUser goto properties User Mapping tab -> select Valence
