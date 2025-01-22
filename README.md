```markdown
# API per il Monitoraggio delle Api Mellifere

This project is an API for monitoring beehives, developed as part of the Generation Italy .NET developer course. It provides endpoints for managing beehives, users, and monitoring various aspects of bee activity and hive conditions.

## Project Structure

```
API_per_il_monitoraggio_delle_api_mellifere/
│
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

- User authentication and authorization
- CRUD operations for beehives
- Monitoring of hive conditions (temperature, humidity, bee activity)
- Data seeding for initial setup

## Getting Started

1. Clone the repository
2. Ensure you have .NET 6.0 SDK installed
3. Update the connection string in `appsettings.json` to point to your database
4. Run the following commands in the project directory:
   ```
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

## API Endpoints

- `/api/auth` - Authentication
- `/api/users` - User management
- `/api/alveari` - Beehive management and monitoring

For detailed API documentation, run the project and navigate to the Swagger UI.

## Technologies Used

- ASP.NET Core 8.0.12
- Entity Framework Core 8.0.12
- BCrypt.Net-Next 4.0.3
- Microsoft.AspNetCore.Authentication.JwtBearer 8.0.12
- Serilog.AspNetCore 8.0.3
- Serilog.Sinks.File 6.0.0
- Swashbuckle.AspNetCore 7.2.0 (Swagger)
- System.IdentityModel.Tokens.Jwt 8.3.1

## Contributing

This project is an exercise and is not open for contributions. However, feel free to fork and use it for your own learning purposes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

Luca Ciardi - [LucaCiardi](https://github.com/LucaCiardi)

## Acknowledgments

- Generation Italy for providing the .NET developer course
- All instructors and peers who provided support and feedback
```
