# Ping-Pong
A ping-pong applicaiton to serve as a bootstrap code

This code serves as a starting point for a microservice application. It contains a MongoDb database, a C# backend, a C# BFF, and an Angular ui.


## Creating the code


### Create MongoDb database
We create the database with docker. As it is not really the application, only the database, we put it into the */env/database* directory.

- create a directory named *env/database*
- create a file named *Dockerfile*
- search for the latest image on hub.docker.com, and edit Dockerfile

As we need the database for the development, we create a *docker-compose-dev.yaml* file, to be able to create a develompment environment with a running database.

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
- add db config to *appsettings.json*
- implement *PingDatabaseSettings.cs* in the *Models* directory to represent database settings
- in the *Startup.cs*, bind the databasesetting with the config section
- in the *Startup.cs*, register the databasesetting interface with singleton lifetime in DI

- create a new directory named *Services* to store the mongodb service
- implement the *PingService.cs* for the mongo CRUD operations
  - implement a **get**, **get(string id)** and a **create** method for now, add the remaining methods later if needed
- in the startup.cs, register the service with singleton lifetime in DI

- implement *PingController.cs* in the *Contollers* directory
  - implement **Get**, **Get(string id)** and **Create** methods for now, add the remaining methods later if needed

- enable cors for the ui (https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0)
  - in *StartUp.cs*, allow all origins, headers and methods.

- modify *launchSettings.json*, to be able to test the application
  - set *launchUrl*
  - set *applicationUrl*

- create *docker-compose-backend.yaml* to be able to implement ui without running the ms in the IDE


### Create UI
In the svc directory, create a new angular project.

- create new ng project
  - **ng new ui**
  - no routing, and css

- add material design
  - **cd ui**
  - **ng add @angular/material**

- add a ping service
  - **ng g s services/ping**
  - implement the ping service
    - receives the *HttpClient* in the constructor
    - do not forget to add *HttpClient* to *app.module.ts* !
    - gets the backend url from the environment
      - add the environment url to the *environments.ts* and *environment.prod.ts*
      - the *getAll* method calls the endpoint

- add a ping component
  - **ng g c ping**
  - implement the ping component.ts
    - receives PingService in the constructor
    - calls the service's getAll method in the ngOnInit() function

  - implement the ping component.html
    - add an input field and a button (optional), to be able to send new message
    - import FormsModule and ReactiveFormsmodule in app.module.ts
    - implement the function for sendig the message
    - create a table and populate with ping data
    - add a little bit style with material design

- start using the new component instead of the default page
  - modify *app.component.html*
    - replace the placeholder with the selector of the new component, \<app-ping>

To be able to run the ui later in a kubernetes pod, we need to load the environment variables from file. To achive this, create an *environment.json* in the */assets/environments* directory, and load it at startup.

- create the *environment.json* in the *assets/environments* directory
- create an *environmentLoader* class, to load the json file
- call the *environmentLoader* from the* main.js*

- create *docker-compose.yaml*

Now, the application is ready, and now let's create the kubernetes yaml files. But first, we need to add our applicaiton's components to the dockerhub.


# Add our containers to dockerhub
- create an account at hub.docker.com
- 


# Backlog:
Let's devops:

- deploy to kubernetes
  - create yaml files, and test it on minikube
  - creaet azure kubernetes environment, and deploy the application
- create jenkins pipeline
  - implement automatic deployment to the kubernetes environment

- create init containers
- create readiness probes
- create liveness probes

- implement metrics
- implement logging
- create monitoring (prometheus + grafana)
- create log server (elasticsearch + kibana)