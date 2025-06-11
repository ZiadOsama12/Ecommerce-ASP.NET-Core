# Ecommerce-ASP.NET-Core

A backend Ecommerce System built using C#, ASP.NET Core, and SQL Server, following Onion Architecture principles. It includes features such as authentication, role-based access control, product management, advanced filtering, pagination, and global exception handling.

---

## 🛠️ Tech Stack

- **C#**
- **ASP.NET Core 8**
- **JWT**
- **SQL Server** (Database)
- **AutoMapper** (for DTO mapping)
- **Serilog** (Logging)
- **FluentValidation**

## 📦 Features

- ✅ JWT-based user authentication and authorization
- ✅ Role-based access control for protected endpoints
- ✅ CRUD operations for products, users, and orders
- ✅ Pagination, filtering, and sorting
- ✅ DTO validation using FluentValidation
- ✅ Global exception handling with standardized error responses
- ✅ Structured logging using Serilog
- ✅ Request shaping and query support
- ✅ Onion Architecture with clear separation of concerns

## 📁 Project Structure
```plaintext
📁 Ecommerce-ASP.NET-Core
│
├── Ecommerce.sln                # Solution file
│
├── 📁 Core                      # Core layer (Domain, Services, Validation)
│   ├── 📁 Api.Domain            # Domain models, interfaces, exceptions
│   │   ├── 📁 Entities
│   │   ├── 📁 Exceptions
│   │   ├── 📁 ConfigurationModels
│   │   ├── 📁 Repositories       # Interfaces only
│   │   └── 📁 Responses
│   ├── 📁 Api.Services.Contracts  # Service interfaces
│   ├── 📁 Api.Service           # Business logic / service implementations
│   ├── 📁 Mapping               # AutoMapper profiles
│   └── 📁 Validation            # FluentValidation validators
│
├── 📁 Infrastructure            # Technical details (EF Core, Controllers)
│   ├── 📁 Persistence           # EF Core DbContext, Migrations, Repos
│   │   ├── 📁 Configurations
│   │   ├── 📁 Migrations
│   │   └── 📁 Repositories       # Implementations
│   └── 📁 Presentation          # ASP.NET Core Controllers
│       ├── 📁 Controllers
│       └── AssemblyReference.cs
│
├── 📁 Ecommerce                 # Startup layer / main API project
│   ├── 📁 ContextFactory        # For migrations and design-time support
│   ├── 📁 Extensions            # Service registration, middleware
│   ├── 📁 logs                  # Serilog log outputs
│   ├── appsettings.json        # Configuration
│   ├── GlobalExceptionHandling.cs  # Central error middleware
│   └── Program.cs              # Entry point
│
├── 📁 Shared                   # Shared objects (used across layers)
│   ├── 📁 DTOs                 # Data Transfer Objects
│   └── 📁 RequestFeatures      # Filtering, sorting, pagination

```
## 📦 Getting Started

### Prerequisites

* Visual Studio 2022 or later
* .NET 8 SDK
* MS SQL Server
* Postman (for testing API)

### Installation

1. **Clone the Repository:**

   ```bash
    https://github.com/ZiadOsama12/Ecommerce-ASP.NET-Core.git
    cd Ecommerce-ASP.NET-Core
   
2. **Configure the Database:**
   
   * Ensure SQL Server is running.
   * Update the connection string in appsettings.json:
   ```json
   {
       "ConnectionStrings": {
          "DefaultConnection": "Server=your_server;Database=EcommerceDB;Trusted_Connection=True;TrustServerCertificate=True;"
      }
   }
   ```
3. Apply Migrations and Run:
   ```bash
     dotnet ef database update
     dotnet run --project Ecommerce
   ```
4. Test the API:
    Use Swagger UI or Postman to test endpoints.
####  🔐 4.1. Register a New User

   ```bash
   POST /api/auth/register
   Content-Type: application/json
  {
    "firstName":"Ziad",
    "lastName": "Osama",
    "userName":"ziad3",
    "password":"osama3",
    "email":"ziad123456@gmail.com",
    "phonenumber":"464-456",
    "roles":[
        "Administrator"
    ]
  }
  ```
####  🔑 4.2. Login to Get a JWT Token
  ```bash
    POST /api/auth/login
    Content-Type: application/json
    {
    "username": "ziad1",
    "password":"osama1"
    }
```
  Sample Response:
  ```json
    {
      "access_token": "eyJhbGciOiJIUzI1N.....",
      "refresh_token": "eyJhbGciOiJI..............",
    }
  ```
####  🔓 4.3. Access Protected Endpoints

```bash
  GET /api/orders
  Authorization: Bearer <your_token_here>
  Content-Type: application/json
```

## 🤝 Contributions
Pull requests are welcome. For major changes, open an issue first to discuss what you would like to change.

## 📌 Future Improvements
* Add unit and integration tests

* Email notifications

* Admin dashboard

* Frontend integration (e.g., Angular or React)

## 💬 Contact

For any questions or suggestions, feel free to reach out:

* **Email:** ziadosama9595@gmail.com
* **GitHub:** [Ziad Osama](https://github.com/ZiadOsama12)
