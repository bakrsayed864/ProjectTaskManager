# Project Task Manager API

A RESTful API built with **ASP.NET Core (.NET 9)** for managing projects and their tasks. The project was developed with a focus on writing clean, maintainable, and scalable code using **Clean Architecture** principles.

## Features

### Authentication

* User Registration
* User Login using JWT Authentication

### Projects

* Create Project
* Get All Projects
* Get Project By Id
* Update Project
* Delete Project

### Tasks

* Create Task
* Get Tasks By Project
* Update Task Status
* Delete Task

## Tech Stack

* ASP.NET Core Web API (.NET 9)
* Entity Framework Core
* SQL Server
* JWT Authentication
* Mapster
* Swagger 

## Architecture

The solution follows the **Clean Architecture** pattern and is organized into four independent layers:

```
Presentation
Application
Domain
Infrastructure
```

### Layer Responsibilities

* **Presentation**

  * Controllers
  * Dependency Injection
  * Swagger configuration

* **Application**

  * Services
  * DTOs
  * Business Logic
  * Mapping

* **Domain**

  * Entities
  * Enums
  * Repository Contracts

* **Infrastructure**

  * Entity Framework Core
  * DbContext
  * Repository Implementations
  * Authentication Configuration
  * Database Migrations

## Implemented Practices

* Clean Architecture
* Repository Pattern
* Service Layer
* Dependency Injection
* DTO Pattern
* Mapster for Object Mapping
* Global Exception Handling
* Request Validation using Data Annotations
* JWT Authentication & Authorization
* Entity Framework Core Migrations
* Swagger Documentation

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/bakrsayed864/ProjectTaskManager.git
```

### 2. Configure the database

Update the SQL Server connection string inside:

```
appsettings.json
```

### 3. Apply migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

### 5. Open Swagger

```
https://localhost:<port>/swagger
```

## Project Structure

```
ProjectTaskManager
│
├── Presentation
├── Application
├── Domain
└── Infrastructure
```

## Notes

* Authentication is required to access protected endpoints.
* Authenticated Users can manage projects and the tasks that belong to those projects.
* The project emphasizes clean code, separation of concerns, and maintainability over unnecessary complexity.
