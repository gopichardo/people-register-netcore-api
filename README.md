# People Register .NET Core API

This is a .NET Core API for registering and managing people.

## Application's specification
- **.NET Core 6.4.0** To develop the backend API.
- **Entity Framework Core** For database operations.
- **Docker** To containerize the application.
- **Clean Architecture** To use as architecture and create a robust and reliable application based on the domain.

## Project Structure
- **People.Api**: Contains the API project.
- **People.Application**: Contains application logic like use cases and validators.
- **People.Domain**: Contains domain models and interfaces.
- **People.Infrastructure**: Contains infrastructure-related code like database context, migrations, and repositories.

## Getting Started

### Prerequisites
- .NET Core SDK
- Docker (optional, for containerization)

### Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/gopichardo/people-register-netcore-api.git
    ```
2. Navigate to the project directory:
    ```sh
    cd people-register-netcore-api
    ```

### Running the Application
To run the application, use the following commands:

1. Restore the dependencies:
    ```sh
    dotnet restore
    ```
2. Build the project:
    ```sh
    dotnet build
    ```
3. Run the API:
    ```sh
    dotnet run --project People.Api
    ```

### Docker
To run the application using Docker, follow these steps:

1. Install Docker Desktop.
2. Navigate to project directory: 
   ```sh
   cd People.Infrastructure
   ```
3. Run Docker Compose command:
    ```sh
    docker-compose up -d
    ```
4. Apply Migrations (Create the Database):
    ```sh
    dotnet ef database update --project People.Infrastructure --startup-project People.Api
    ```


## Available Endpoints

### Create a Person
- **URL**: `/api/people`
- **Method**: `POST`
- **Parameters**:
  - `name` (string, required): The name of the person.
  - `phone` (string, required): The phone of the person.
  - `email` (string, required): The email of the person.
  - `company` ({ name: string, required }) The Company of the person.
- **HTTP Codes**:
  - `201 Created`: Successfully created a person.
  - `400 Bad Request`: Invalid input.
- **Curl Example**:
    ```sh
    curl -X POST "http://localhost:5000/api/people" -H "Content-Type: application/json" -d '{"name": "John Doe","phone": "5529725299","email": "john.doe@mail.com","company": {"name": "Wee"}'
    ```

### Get All People
- **URL**: `/api/people`
- **Method**: `GET`
- **Parameters**: None
- **HTTP Codes**:
  - `200 OK`: Successfully retrieved the list of people.
- **Curl Example**:
    ```sh
    curl -X GET "http://localhost:5000/api/people"
    ```

### Get a Person by ID
- **URL**: `/api/people/{id}`
- **Method**: `GET`
- **Parameters**:
  - `id` (uuid, required): The ID of the person.
- **HTTP Codes**:
  - `200 OK`: Successfully retrieved the person.
  - `404 Not Found`: Person not found.
- **Curl Example**:
    ```sh
    curl -X GET "http://localhost:5000/api/people/3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ```

## License
This project is licensed under the MIT License.

## Author
Mail: [gopichardoces@gmail.com](gopichardoces@gmail.com) | Linkedin: [gopichardoces](https://www.linkedin.com/in/gopichardoces/) | GitHub: [gopichardo](https://github.com/gopichardo)