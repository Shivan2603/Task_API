# Task Management API

This is the backend API for the Task Management Application, built using ASP.NET Core Web API. It provides endpoints to create, read, update, and delete tasks.

## Features

*   **RESTful API:** Exposes RESTful endpoints for managing tasks.
*   **SQLite Database:** Uses SQLite for data storage (you can easily switch to another provider if needed).
*   **Swagger UI:** Includes Swagger UI for interactive API documentation.
*   **CORS Enabled:** Configured to allow requests from your Angular frontend.

## Prerequisites

*   .NET 6 SDK (or later) 
*   SQLite (if you're using the default configuration)

## Getting Started

1.  **Clone the repository:**
*  Clone the code from the repository 

2.  **Restore dependencies:**

    ```bash
    dotnet restore
    ```

3.  **Run the application:**

    ```bash
    dotnet run
    ```

4.  **Access Swagger UI:**

    *   Open your web browser and navigate to `https://localhost:5000/swagger` (or the appropriate port if you've configured it differently).

## API Endpoints

*   **GET /api/tasks:** Retrieve a list of all tasks.
*   **GET /api/tasks/{id}**: Retrieve a specific task by ID.
*   **POST /api/tasks:** Create a new task.
*   **PUT /api/tasks/{id}**: Update an existing task.
*   **DELETE /api/tasks/{id}**: Delete   
 a task.

## Configuration

*   **Database:** The default configuration uses an SQLite database. You can modify the connection string in `appsettings.json` if you want to use a different database provider.
*   **CORS:** The API is configured to allow requests from `http://localhost:4200` (adjust this in `Program.cs` if your Angular app is running on a different port).
