using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views.Dialogs;

namespace StudentManagementSystem.Views.Pages;

public partial class StudentsPage : Page
{
    private readonly User _currentUser;

    public StudentsPage(User user)
    {
        InitializeComponent();
        _currentUser = user;
        LoadStudents();
    }

    private void LoadStudents(string? search = null)
    {
        using var db = new AppDbContext();
        var query = db.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(s => s.FirstName.ToLower().Contains(search) ||
                                     s.LastName.ToLower().Contains(search) ||
                                     s.StudentNumber.ToLower().Contains(search) ||
                                     s.Email.ToLower().Contains(search));
        }

        StudentsGrid.ItemsSource = query.OrderBy(s => s.LastName).ToList();
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        LoadStudents(SearchBox.Text);
    }

    private void Refresh_Click(object sender, RoutedEventArgs e) => LoadStudents();

    private void AddStudent_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new StudentDialog();
        if (dialog.ShowDialog() == true)
            LoadStudents();
    }

    private void StudentsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (StudentsGrid.SelectedItem is Student student)
        {
            var dialog = new StudentDialog(student.Id);
            if (dialog.ShowDialog() == true)
                LoadStudents();
        }
    }
}