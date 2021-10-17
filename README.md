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