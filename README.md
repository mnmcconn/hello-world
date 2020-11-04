# hello-world
This Visual Studio 2019 solution launches a console application and web api project simultaneously and writes "Hello World" to the console window.

There is a data project designed to support a future implementation of a SQL Server / Entity Framework Back End.   

For this sample project, an in-memory array of objects originating in a repository are retrieved rather than data from a SQL Server Database. 

A test project has been created to test two of the API methods.

Specifically, the solution consists of 4 projects.

1) HelloWorld Console Application

This program executes an async HTTP method calling the Get method in the HelloWorld.API (Web API project).
It will retrieve "Hello World!" from the settings file in the Hello.Data project and display that on the Console Window.

2) HelloWorld Data Project

This class library is the the interface to any data access for the solution.  It includes a repository pattern and an
entity used to retrieve data.  At this time, the data source is an in-memory array of HelloWorld entities populated for settings.

NOTE: This project is designed to support a future implementation of Entity Framework

3) HelloWorld Web API Project

This ASP.Net project contains multiple API method calls including Get and List.  Get takes an integer as a parameter and 
retrieves the respective item from the in-memory array.   List retrieves all items from the in-memory array.

4) HelloWorld Test Project

The test project tests the two methods in the API, Get and List.


