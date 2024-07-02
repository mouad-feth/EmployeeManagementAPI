# Employee Management API

## Overview

The Employee Management API is a web service built using ASP.NET Core, designed to handle CRUD (Create, Read, Update, Delete) operations for managing employee data. It leverages the CQRS (Command Query Responsibility Segregation) pattern to separate data modification operations from data retrieval operations, ensuring a clear and maintainable codebase.

## Key Features

- **Create Employee**: Add new employee records.
- **Read Employee**: Retrieve employee details by ID or get a list of all employees.
- **Update Employee**: Modify existing employee information.
- **Delete Employee**: Remove employee records from the database.

## Technologies Used

- **ASP.NET Core**: Framework for building the API.
- **SQLite**: Database engine for storing employee data.
- **MediatR**: Library for implementing the CQRS pattern.
- **Angular**: Frontend framework for user interface.

## CQRS Pattern

- **Commands**: Handle operations that modify data (create, update, delete).
- **Queries**: Handle operations that retrieve data without modifying it.

## Database Configuration

The API uses SQLite as its database engine, with the connection string named `DefaultConnection` pointing to `Data Source=employee_management.db`.


