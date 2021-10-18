# ping-pong
A ping-pong applicaiton to serve as a bootstrap code

This code serves as a starting point for a microservice application. It contains a MongoDb database, a C# backend, a C# BFF, and an Angular ui.


## Creating the code

### Create MongoDb database

We create the database with docker. As it is not really the application, only the database, we put it into the \env\database directory.

- create a directory named *env\database*
- create a file named *Dockerfile*
- search for the latest image on hub.docker.com, and edit Dockerfile

As we need the database for the development, we create a docker-compose-dev.yaml file, to be able to create a develompment environment with a running database.

- create *docker-compose-dev.yaml*
- create a *mongo-init.js* as well, to be able to create custom user/pass and collection

### Create MS
Now, we should create the microservice with the business logic. We do this based on the following tutorial from microsoft: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio

- in VS, create a new ASP.NET Core Web Application project with API template
  - Project name: *ms*
  - Location *\<location of the git repository>*
  - Solution name: *ping-pong*

- I prefer to move the newly created *ms* directory and the *ping-pong.sln* file into a *src* folder, but this is optional.

- Check the latest version of the mongodb driver on the [NuGet Gallery: MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/), and open the Package Manager Console window to install mongodb driver with the following command: *Install-Package MongoDB.Driver -Version {version}*

- create a new directory named *Models* to store database model
- implement *Ping.cs*, to store the *ping* database model
- add db config to appsettings.json
- implement *PingDatabaseSettings.cs* in the *Models* directory to represent database settings
- in the *Startup.cs*, bind the databasesetting with the config section
- in the *Startup.cs*, register the databasesetting interface with singleton lifetime in DI

- create a new directory named *Services* to store the mongodb service
- implement the *PingService.cs* for the mongo CRUD operations
  - implement a **get**, **get(string id)** and a **create** method for now, add the remaining methods later if needed
- in the startup.cs, register the service with singleton lifetime in DI

- implement *PingController.cs* in the *Contollers* directory
  - implement Get, Get(string id) and Create methods for now, add the remaining methods later if needed

- modify launchSettings.json, to be able to test the application
  - set launchUrl
  - set applicationUrl


### Create BFF



### Create UI





# Backlog:
Let's devops:
- create jenkins pipeline
- create metrics
- create logging
- deploy to kubernetes
- create init containers
- create readiness probes
- create liveness probes
- create monitoring (prometheus + grafana)
- create log server (elasticsearch + kibana)