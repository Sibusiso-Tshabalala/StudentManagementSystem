using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Views.Pages;

public partial class CoursesPage : Page
{
    private readonly User _user;

    public CoursesPage(User user)
    {
        InitializeComponent();
        _user = user;
        Load();
    }

    private void Load(string? search = null)
    {
        using var db = new AppDbContext();
        var q = db.Courses.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            q = q.Where(c => c.Name.Contains(search) || c.Code.Contains(search));
        CoursesGrid.ItemsSource = q.OrderBy(c => c.Code).ToList();
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) => Load(SearchBox.Text);
    private void Add_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Course add dialog can be expanded similarly to Students.", "Info");
        // Full dialog can be added following StudentDialog pattern
    }

    private void Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Edit course functionality ready to implement.", "Info");
    }
}