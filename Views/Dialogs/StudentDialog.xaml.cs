using System.Windows;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Views.Dialogs;

public partial class StudentDialog : Window
{
    private readonly int? _studentId;

    public StudentDialog(int? studentId = null)
    {
        InitializeComponent();
        _studentId = studentId;
        if (_studentId.HasValue)
            LoadStudent();
        else
            TitleText.Text = "Add New Student";
    }

    private void LoadStudent()
    {
        using var db = new AppDbContext();
        var student = db.Students.Find(_studentId);
        if (student == null) return;

        TitleText.Text = "Edit Student";
        StudentNumberBox.Text = student.StudentNumber;
        FirstNameBox.Text = student.FirstName;
        LastNameBox.Text = student.LastName;
        EmailBox.Text = student.Email;
        PhoneBox.Text = student.Phone;
        DobPicker.SelectedDate = student.DateOfBirth;
        GenderBox.Text = student.Gender;
        AddressBox.Text = student.Address;
        StatusBox.Text = student.Status;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(StudentNumberBox.Text) ||
            string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
            string.IsNullOrWhiteSpace(LastNameBox.Text))
        {
            MessageBox.Show("Student Number, First Name and Last Name are required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        using var db = new AppDbContext();
        Student student;

        if (_studentId.HasValue)
        {
            student = db.Students.Find(_studentId)!;
        }
        else
        {
            student = new Student();
            db.Students.Add(student);
        }

        student.StudentNumber = StudentNumberBox.Text.Trim();
        student.FirstName = FirstNameBox.Text.Trim();
        student.LastName = LastNameBox.Text.Trim();
        student.Email = EmailBox.Text.Trim();
        student.Phone = PhoneBox.Text.Trim();
        student.DateOfBirth = DobPicker.SelectedDate ?? DateTime.Today.AddYears(-18);
        student.Gender = GenderBox.Text;
        student.Address = AddressBox.Text.Trim();
        student.Status = StatusBox.Text;

        try
        {
            db.SaveChanges();
            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}