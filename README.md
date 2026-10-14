# Student Management System (Professional C# WPF Edition)

A modern, advanced desktop Student Management System built with **C#**, **WPF**, **Material Design**, and **Entity Framework Core + MySQL**.

## Features
- Secure login with role-based access (Admin, Registrar, Teacher)
- Dashboard with key statistics
- Full Student CRUD with search
- Course, Enrollment, Grades, and Attendance modules (structure ready for expansion)
- Professional Material Design UI
- Password hashing with BCrypt
- Automatic database creation and admin seed

## Default Login
- **Username:** `admin`
- **Password:** `admin123`

## Requirements
- Visual Studio 2022 (or later) with .NET 7 Desktop development workload
- MySQL Server (local or remote)
- .NET 7 SDK

## Setup Instructions

1. **Install MySQL** and create a database (or let the app create it):
   ```sql
   CREATE DATABASE StudentManagement;
   ```

2. **Update connection string** in `Data/AppDbContext.cs`:
   ```csharp
   var connectionString = "Server=localhost;Database=StudentManagement;User=root;Password=YOUR_PASSWORD;";
   ```

3. Open the solution/project in Visual Studio.

4. Restore NuGet packages (they will download automatically):
   - MaterialDesignThemes
   - Pomelo.EntityFrameworkCore.MySql
   - BCrypt.Net-Next
   - etc.

5. Build and run (`F5`).

6. Login with the default admin account.

## Project Structure
- `Models/` — Entity classes
- `Data/` — EF Core DbContext
- `Views/` — Windows and pages
- `Views/Dialogs/` — Add/Edit dialogs
- Modern MVVM-ready architecture

## Next Enhancements (Recommended)
- Complete Course / Enrollment / Grade / Attendance dialogs (follow StudentDialog pattern)
- Photo upload for students
- PDF report generation (use QuestPDF or iText)
- Charts on dashboard (LiveCharts is already referenced)
- Audit logging
- Export to Excel

This is a solid, professional portfolio project that demonstrates full-stack desktop development skills. Expand the remaining modules using the same patterns already implemented for Students.

Built for Sibusiso Tshabalala — Junior Software Developer.