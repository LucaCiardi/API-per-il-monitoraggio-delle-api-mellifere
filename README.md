# API per il Monitoraggio delle Api Mellifere

This project is an API for monitoring beehives, developed as part of the Generation Italy .NET developer course. It provides endpoints for managing beehives, users, and monitoring various aspects of bee activity and hive conditions.

## Project Structure

```plaintext
API_per_il_monitoraggio_delle_api_mellifere/
├── Controllers/
│   ├── AlveariController.cs
│   ├── AuthController.cs
│   └── UsersController.cs
│
├── Models/
│   ├── Alveare.cs
│   ├── Misurazione.cs
│   ├── User.cs
│   └── LoginModel.cs
│
├── Data/
│   ├── ContestoApiario.cs
│   ├── Migrations/
│   └── Seeding/
│       └── DbInitializer.cs
│
├── Services/
│   ├── Monitoring/
│   │   ├── TemperatureMonitor.cs
│   │   ├── HumidityMonitor.cs
│   │   ├── BeeActivityMonitor.cs
│   │   └── HiveMonitoringSystem.cs
│   └── DTOs/
│       └── HiveStatus.cs
│
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

## Features

| Category | Capabilities |
|----------|-------------|
| Authentication | User login/registration, JWT tokens |
| Hive Management | CRUD operations for beehives |
| Monitoring | Temperature, humidity, bee activity tracking |
| Data | Automated seeding, migration support |

## Getting Started

1. Clone the repository
2. Ensure you have .NET 6.0 SDK installed
3. Update the connection string in `appsettings.json`
4. Run these commands:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

## API Endpoints

| Endpoint | Purpose |
|----------|---------|
| `/api/auth` | Authentication services |
| `/api/users` | User management |
| `/api/alveari` | Beehive operations |

## Technologies

| Category | Tools |
|----------|-------|
| Framework | ASP.NET Core 8.0.12 |
| ORM | Entity Framework Core 8.0.12 |
| Security | BCrypt.Net-Next 4.0.3, JWT Bearer 8.0.12 |
| Logging | Serilog.AspNetCore 8.0.3, Serilog.Sinks.File 6.0.0 |
| Documentation | Swashbuckle.AspNetCore 7.2.0 |
| Token Handling | System.IdentityModel.Tokens.Jwt 8.3.1 |

## Contributing

This project is an exercise and is not open for contributions. Feel free to fork it for learning purposes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Luca Ciardi**
- GitHub: [LucaCiardi](https://github.com/LucaCiardi)

## Acknowledgments

- Generation Italy for providing the .NET developer course
- All instructors and peers who provided support and feedback
