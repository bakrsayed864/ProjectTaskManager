# Project Task Manager API

A simple RESTful API built with **ASP.NET Core (.NET 9)** for managing projects and their tasks. The project was developed as part of a backend technical assessment and focuses on clean architecture, maintainable code, and common backend development practices.

## Features

### Authentication
- User Registration
- User Login using JWT Authentication

### Projects
- Create Project
- Get All Projects
- Get Project By Id
- Update Project
- Delete Project

### Tasks
- Create Task
- Update Task Status
- Get Tasks By Project
- Delete Task

## Technologies

- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- SQL Server
- JWT Authentication
- Mapster
- Swagger

## Architecture

The project follows a layered architecture with clear separation of responsibilities.

- **Controllers** handle HTTP requests.
- **Services** contain the business logic.
- **Repositories** are responsible for data access.
- **Entity Framework Core** is used for database operations.
- **Mapster** is used for mapping between DTOs and entities.
- **DTOs** are used for request and response models.

## Implemented Practices

- Repository Pattern
- Service Layer
- Dependency Injection
- DTO Pattern
- Global Exception Handling
- Request Validation using Data Annotations
- JWT Authentication & Authorization
- Entity Framework Core Migrations
- Swagger Documentation

## Getting Started

1. Clone the repository

```bash
git clone https://github.com/bakrsayed864/ProjectTaskManager.git
```

2. Update the database connection string in `appsettings.json`.

3. Apply migrations

```bash
dotnet ef database update
```

4. Run the project

```bash
dotnet run
```

5. Open Swagger

```
https://localhost:{port}/swagger
```

## Project Structure

```
Controllers/
DTOs/
Entities/
Repositories/
Services/
Data/
Migrations/
Middleware/
```

## Notes

- Authentication is required for protected endpoints.
- Each authenticated user can manage their own projects and tasks.
- The project is designed to be simple, clean, and easy to extend.
