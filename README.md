# TestTask

Insructions to run the project

1. Make sure, all the dependecies (NuGet Packages) are installed
2. Replace "LocalDb" connection string with yours in the foloqing files:
a) ./TestTask/appsetting.json
b) ./DataAccess/Data/TestTaskDbContext.cs in the commented region

3. Uncomment the region mentioned higher
4. Set "Data Access" as a startup project
5. Open Package Manager Console and run following commands:
a) add-migration "Migration Name"
b) update-database

5. Set "TestTask" as a startup project and run it on IIS Express
