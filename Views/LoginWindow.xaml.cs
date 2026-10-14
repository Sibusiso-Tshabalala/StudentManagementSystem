using System.Windows;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using BCrypt.Net;

namespace StudentManagementSystem.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        EnsureDatabase();
    }

    private void EnsureDatabase()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        // Seed admin user if none exists
        if (!db.Users.Any())
        {
            db.Users.Add(new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                FullName = "System Administrator",
                Email = "admin@school.edu",
                Role = "Admin"
            });
            db.SaveChanges();
        }
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        string username = UsernameBox.Text.Trim();
        string password = PasswordBox.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowError("Please enter username and password.");
            return;
        }

        using var db = new AppDbContext();
        var user = db.Users.FirstOrDefault(u => u.Username == username && u.IsActive);

        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            var main = new MainWindow(user);
            main.Show();
            Close();
        }
        else
        {
            ShowError("Invalid username or password.");
        }
    }

    private void ShowError(string message)
    {
        ErrorText.Text = message;
        ErrorText.Visibility = Visibility.Visible;
    }
}