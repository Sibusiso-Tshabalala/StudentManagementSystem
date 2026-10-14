using System.Windows;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views.Pages;

namespace StudentManagementSystem.Views;

public partial class MainWindow : Window
{
    private readonly User _currentUser;

    public MainWindow(User user)
    {
        InitializeComponent();
        _currentUser = user;
        UserInfoText.Text = $"{user.FullName}\n({user.Role})";

        if (user.Role != "Admin")
            UsersButton.Visibility = Visibility.Collapsed;

        NavigateToDashboard();
    }

    private void Nav_Dashboard(object sender, RoutedEventArgs e) => NavigateToDashboard();
    private void Nav_Students(object sender, RoutedEventArgs e) => MainFrame.Navigate(new StudentsPage(_currentUser));
    private void Nav_Courses(object sender, RoutedEventArgs e) => MainFrame.Navigate(new CoursesPage(_currentUser));
    private void Nav_Enrollments(object sender, RoutedEventArgs e) => MainFrame.Navigate(new EnrollmentsPage(_currentUser));
    private void Nav_Grades(object sender, RoutedEventArgs e) => MainFrame.Navigate(new GradesPage(_currentUser));
    private void Nav_Attendance(object sender, RoutedEventArgs e) => MainFrame.Navigate(new AttendancePage(_currentUser));
    private void Nav_Users(object sender, RoutedEventArgs e) => MainFrame.Navigate(new UsersPage(_currentUser));

    private void NavigateToDashboard() => MainFrame.Navigate(new DashboardPage(_currentUser));

    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        new LoginWindow().Show();
        Close();
    }
}