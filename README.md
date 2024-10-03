# TestTask

Insructions to run the project

1. Make sure, all the dependecies (NuGet Packages) are installed
2. Replace "LocalDb" connection string with yours in the foloqing files:
1) ./TestTask/appsetting.json
2) ./DataAccess/Data/TestTaskDbContext.cs in the commented region

3. Uncomment the region mentioned higher
4. Set "Data Access" as a startup project
5. Open Package Manager Console and run following commands:
1) add-migration "Migration Name"
2) update-database

5. Set "TestTask" as a startup project and run it on IIS Express
