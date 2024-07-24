# MyTraceLib

MyTraceLib is a class library designed to support projects like MyTrace, MyTraceTrawler, and MyTraceFunctions. It provides essential services, data models, and database interaction functionalities.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Dependencies](#dependencies)
- [License](#license)

## Features

- **Database Context**: Provides an `DbContext` for interacting with SQL Server databases.
- **Services**: Contains various services for database operations, API interactions, and AI integrations.
- **Data Models**: Defines entity classes for products, brands, ingredients, and more.
- **AI Integration**: Uses OpenAI to fetch detailed ingredient breakdowns.

## Installation

1. **Include the library in your project file:**
    ```xml
    <ProjectReference Include="..\MyTraceLib\MyTraceLib.csproj" />
    ```

2. **Ensure your environment variables are set:**
    - `SQL_CONNECTION_STRING`
    - `AI_API_KEY`

## Dependencies

- .NET 8.0
- Betalgo.OpenAI 8.5.1
- Microsoft.EntityFrameworkCore 8.0.6
- Microsoft.EntityFrameworkCore.SqlServer 8.0.6
- Microsoft.EntityFrameworkCore.Tools 8.0.6
- Newtonsoft.Json 13.0.3
- System.CommandLine 2.0.0-beta4.22272.1
