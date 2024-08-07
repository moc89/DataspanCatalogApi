# Catalog API

This project is a Catalog API built with ASP.NET Core. 
It provides endpoints to manage authors and books, including creating, retrieving, and deleting records. 
The project uses an in-memory database for data storage.
Solution architecture developed for the larger scale application as a base application.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any other IDE that supports .NET development

### Installation

1. Clone the repository:
    git clone https://github.com/moc89/DataspanCatalogApi.git
    cd catalog-api
2. Restore the dependencies:
   dotnet restore
   3. Build the project:
dotnet build

### Usage

1. Run the application:
   dotnet run

2. The API will be available at `https://localhost:8080` (or `http://localhost:8080` for non-HTTPS).

3. Open your browser and navigate to `https://localhost:8080/swagger/index.html` to view the Swagger UI and explore the API endpoints.

## API Endpoints

### Authors

- **Create Author**
    - **POST** `/Author`
    - Request Body: `{
                        "name": "string",
                        "surname": "string",
                        "birthYear": 0
                      }`

- **Get Author by ID**
    - **GET** `/Author/{id}`

- **Get All Authors**
    - **GET** `/Author`

- **Delete Author**
    - **DELETE** `/Author/{id}`

### Books

- **Create Book**
    - **POST** `/book`
    - Request Body: `{ "title": "Book Title", "bookAuthors": [{ "authorId": 1 }] }`

- **Get Book by ID**
    - **GET** `/book/{id}`

- **Get All Books**
    - **GET** `/book`

- **Delete Book**
    - **DELETE** `/book/{id}`

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
