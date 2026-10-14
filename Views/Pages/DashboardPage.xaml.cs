using System.Windows.Controls;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Views.Pages;

public partial class DashboardPage : Page
{
    public DashboardPage(User user)
    {
        InitializeComponent();
        LoadStats();
    }

    private void LoadStats()
    {
        using var db = new AppDbContext();
        TotalStudents.Text = db.Students.Count().ToString();
        TotalCourses.Text = db.Courses.Count(c => c.IsActive).ToString();
        TotalEnrollments.Text = db.Enrollments.Count().ToString();
        TotalUsers.Text = db.Users.Count().ToString();

        // Simple recent activity placeholder
        RecentGrid.ItemsSource = new[]
        {
            new { Type = "System", Description = "Welcome to Student Management System", Date = DateTime.Now }
        };
    }
}