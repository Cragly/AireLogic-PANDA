# Patient Appointment Network Data Application (PANDA)

## Introduction

This repo contains a solution for the AireLogic tech test [Patient Appointment Network Data Application](https://github.com/airelogic/tech-test-portal/tree/main/Patient-Appointment-Backend).

As my background is .NET development I have created an API using .NET API, EFCore and SQL Server hosted within docker containers. I have attempted to keep the development to around 3-4 hrs. Therefore this API provides does not provide all the functionality outlined in the specification. I have outlined my reasons below for my choices in architecture and functionality.

## Requirements

Once you have downloaded the repo you will need to ensure that you have the following installed on your machine:

- [Visual Studio 2022 v17.13.3](https://visualstudio.microsoft.com/vs/). It may work with earlier versions as docker support was added around v17.11
- [Latest version of .NET 9](https://dotnet.microsoft.com/en-us/download).
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## Running

1. Open the docker desktop app
2. Open the AireLogic.PANDA.sln file in Visual Studio and ensure the solution Launch Settings are set to 'Docker Compose'
   Depending on your docker configuration (run containers on project open) within Visual Studio you may already see that you have a new docker stack containing 2 containers. The first is for the API (airelogic.panda.api) and the second for the database (panda-sql-server-db).
3. Click the 'Docker Compose' play button in the Launch settings
4. Both API and Db containers should be running.
5. You can test the API is running by viewing the APIs OpenAPI document - https://localhost:5001/openapi/v1.json
6. You can test the Db by connecting to it using SQL Server Management Studio, Visual Studio Code or AzureDataStudio.

## Database

The API persists PANDA data to a SQL Server database. When the API is run for the first time I have seeded test data so you can interacting with the API straight away. I have used V4 UUIDs as primary keys (GUID). Not the best for performance but preferred for security and use in a mult-system environment. Performance can be overcome with a good indexing and caching startegy.

## Interact With API

There are two ways you can interact with the API, Postman and Scalar.

1. Included in the repo is a Postman Collection (panda.postman_collection.json) which you can import into Postman. Once you create a Patient the 'id' of the responce automatically gets updated so that you can continue to interact with the API without cutting and pasting GUIDs.
2. Scalar has been provided for 2 reasons. The first is that it documents the API and is based on the OpenAPI standard. The second is that it provides a mechanism for front end developers to familiarise themselves with the API whilst developing the front-end application.

To interact with the API using Scalar open a browser with the following Url - https://localhost:5001/scalar/v1.

## Architecture

The API has been designed with extensibility in mind. To prevent an over-architectured application I took the decision to keep the codebase restricted to a single API project within a solution. However, as the requirements state that the system is to grow I think it lends itself nicely to a clean architecture approach. With this in mind I have subdivided the application into known CA directories (Domain, Application, Infrastructure) with the remaining UI present in the root directory.

I have tried to ensure loose coupling between distinct areas of the application. For instance, although I have chosen to use SQL Server as my Db you could easily swap it out for another Db by creating a couple of new classes that implement Db specific functionality ie UUID, UTF-8 support etc as the repositories are decoupled from the service layer which uses them.

## Functionality

I have focused much of my time on developing a vertical slice of the application for Patients. I have also included the data structures for Appointments and Clinicians to show how I would tackle some of the design decisions in the wider application. You can still interact with Appointments and Clinicians but its not as feature rich as Patients. Hopefully I have demonstrated my approach enough in Patients, so that you can see how the Appointments and Clinician functionality would be implemented.

## Missing Functionality

My solution was to focus on the 'hard requirements', CRUD functionality for the core entities. I have prioritised data integrity, ensuring that the data entered into the system is valid and meets the business requirements. This can be seen in the use of validators in the services and the use of immutable records in the DTOs. Ensuring the correct data types that support UTF-8 for conforming to GDPR and that the API produces nicely formatted error messages to the client.

I believe by delivering the 'hard requirements' and building a strong robust foundation, it will be much simpler and quicker to add the additional pieces of functionality in future sprints.

Missed appointments (if time permitted) would have been included in the API, as I see it as a key piece of business logic. This could be implemented in several ways, either as a server scheduled task or probably my preferred solution, a non-blocking background task, running independently of the application thread.

There is a host of other functionality that I haven't included due to time constraints, such as API versioning, searching, pagination and maybe even making the API 100% RESTful, with the inclusion of Hypermedia, which may benefit the front end team.

## Testing

I have only created a single test class to demonstrate how I go about testing an application and writing unit tests. I am just testing the happy and sad paths of the patient validator using the Arrange, Act, Assert pattern. More comprehensive testing would involve testing the controllers and services using Moq to create Mocks and Stubs etc.
