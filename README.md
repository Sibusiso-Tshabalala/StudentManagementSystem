# EduCore – Student Management System

A modern desktop Student Management System built with **C#**, **WPF**, and **MySQL**.

Features a clean glass-style UI, role-based authentication, and core student management functionality.

## Features

- Secure login with role-based access (Admin, Registrar, Teacher)
- Dashboard with key statistics
- Student management (CRUD + search)
- Course management
- Structured modules for Enrollments, Grades, and Attendance
- Modern glassmorphism-inspired UI
- Entity Framework Core + MySQL
- Password hashing with BCrypt

## Screenshots

*(Add screenshots of the login, dashboard, and students page here after running the app)*

## Default Login

| Username | Password  |
|----------|-----------|
| admin    | admin123  |

## Tech Stack

- **Language**: C#
- **UI**: WPF
- **Database**: MySQL
- **ORM**: Entity Framework Core (Pomelo)
- **Authentication**: BCrypt

## Requirements

- Visual Studio 2022
- .NET 7 SDK
- MySQL Server

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR_USERNAME/StudentManagementSystem.git
   ```

2. Open `StudentManagementSystem.csproj` in Visual Studio.

3. Update the connection string in `Data/AppDbContext.cs`:
   ```csharp
   var connectionString = "Server=localhost;Database=StudentManagement;User=root;Password=YOUR_PASSWORD;";
   ```

4. Restore NuGet packages and build the solution.

5. Run the application.

## Project Structure

```
StudentManagementSystem/
├── Data/           # DbContext
├── Models/         # Entity classes
├── Views/          # Windows and pages
│   ├── Dialogs/    # Add/Edit dialogs
│   └── Pages/      # Main pages
└── App.xaml        # Application resources
```

## Author

**Sibusiso Tshabalala**  
Junior Software Developer  
[LinkedIn](https://www.linkedin.com/in/sibusiso-tshabalala-78a546279) • [GitHub](https://github.com/Sibusiso-Tshabalala)

---

Built as a portfolio project to demonstrate full-stack desktop development skills.
