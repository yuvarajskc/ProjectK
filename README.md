# Full-Stack Todo Application

This project is a full-stack Todo application consisting of an Angular frontend and an ASP.NET Core backend API. The application is containerized using Docker and uses SQL Server for data storage.

## Project Structure

```
db-init/
    init.sql
docker-compose.yml
MyAngularApp/
    .angular/
    .editorconfig
    .gitignore
    angular.json
    Dockerfile
    nginx/
        default.conf
    package.json
    public/
        favicon.ico
    README.md
    src/
        app/
        index.html
        main.ts
        styles.css
    tsconfig.app.json
    tsconfig.json
    tsconfig.spec.json
MyApi/
    .gitignore
    appsettings.Development.json
    appsettings.json
    bin/
    Controllers/
        TodoItemsController.cs
    Dockerfile
    Models/
        TodoContext.cs
        TodoItem.cs
    MyApi.csproj
    MyApi.http
    MyApi.sln
    obj/
    Program.cs
    Properties/
```

## Prerequisites

- Docker
- Docker Compose
- Node.js
- .NET SDK

## Getting Started

### Running with Docker

1. **Build and run the containers:**

   ```sh
   docker-compose up --build
   ```

2. **Access the application:**

   - Angular frontend: `http://localhost:4200`
   - ASP.NET Core API: `http://localhost:5000`

### Running Locally

#### Backend (ASP.NET Core API)

1. **Navigate to the MyApi directory:**

   ```sh
   cd MyApi
   ```

2. **Restore dependencies and run the API:**

   ```sh
   dotnet restore
   dotnet run
   ```

3. **The API will be available at `http://localhost:5000`.**

#### Frontend (Angular)

1. **Navigate to the MyAngularApp directory:**

   ```sh
   cd MyAngularApp
   ```

2. **Install dependencies:**

   ```sh
   npm install
   ```

3. **Run the Angular development server:**

   ```sh
   npm start
   ```

4. **The Angular app will be available at `http://localhost:4200`.**

## Project Details

### Backend (ASP.NET Core API)

- **Framework:** .NET 8.0
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **API Endpoints:** Defined in TodoItemsController.cs
- **Database Context:** Defined in TodoContext.cs
- **Model:** Defined in TodoItem.cs

### Frontend (Angular)

- **Framework:** Angular 18.2.0
- **Main Component:** `AppComponent`
- **Service:** `TodoService` for interacting with the backend API
- **Routing:** Defined in app.routes.ts

### Database Initialization

The SQL Server database is initialized using the script in init.sql. This script creates the `TodoDb` database and the `TodoItems` table, and inserts initial data.

## Configuration

### Docker

- **Dockerfile (Angular):** Dockerfile
- **Dockerfile (API):** Dockerfile
- **Docker Compose:** docker-compose.yml

### Angular

- **Configuration:** angular.json
- **TypeScript Config:** tsconfig.json, tsconfig.app.json, tsconfig.spec.json

### ASP.NET Core

- **Configuration:** appsettings.json, appsettings.Development.json

## License

This project is licensed under the MIT License.
