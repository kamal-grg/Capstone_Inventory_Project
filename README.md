# CustomerApp

**CapstoneInventoryApp** is a full-stack web application built using modern Microsoft technologies. It allows users to manage customer records through a clean and interactive user interface with full CRUD functionality.

##  Technology Stack

- **Frontend**: Blazor WebAssembly (WASM)
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Mapping**: AutoMapper
- **UI Framework**: Bootstrap 5
- **Notifications**: Custom Toast Component
- **Validation**: Server-side and Client-side
- **Logging**: Built-in ILogger
- **Design Patterns**: SOLID (planned), DTOs, Component-based UI

## Project Structure
CustomerApp/
│
├── CustomerApp.API # REST API with EF Core and AutoMapper
├── CustomerApp.Blazor # Blazor WASM frontend
├── CustomerApp.Shared # Shared DTOs and models


##  Features

- Responsive and interactive customer list with Add/Edit/Delete
- Modal-based forms with validation
- Toast notifications for success/error messages
- Loading spinner during async operations
- Centralized DTO and validation logic
- CORS-enabled for cross-origin API calls
- Ready for CI/CD deployment with GitHub Actions and Azure

This project demonstrates best practices in architecture, maintainability, and modern .NET development.
