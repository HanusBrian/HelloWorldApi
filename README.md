# HelloWorldApi

This is a simple api created with asp.net core.  It is a fun little console app that plugs into an api running on localhost.

# Running the project

To run, clone the repository to Visual Studio.  Once cloned, right click the solution and go to 
Properties => Common Properties => Startup Project
Select "Multiple startup projects' and under action select 'Start' for both 'HelloWorldApi' and 'HelloWorldClient'.

This will allow you to run both client and server from one instance of Visual Studio. 
