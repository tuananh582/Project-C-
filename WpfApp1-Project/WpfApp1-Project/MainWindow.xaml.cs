using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfApp1_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
    public partial class MainWindow : Window
    {
        private IMongoCollection<Employee> employeeCollection;
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private MongoClient client;
        public MainWindow()
        {
            InitializeComponent();
            listViewEmployees.ItemsSource = employees;
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "Employee";
            try
            {
                client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                employeeCollection = database.GetCollection<Employee>("Employees");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private async void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Add employee to MongoDB with auto-generated ObjectId
                Employee newEmployee = new Employee()
                {
                    Name = txtName.Text,
                    Age = int.Parse(txtAge.Text),
                    Salary = decimal.Parse(txtSalary.Text),
                    BonusSalary = decimal.Parse(txtBonus.Text),
                    Department = txtDepartment.Text,
                    City = txtCity.Text
                };

                await employeeCollection.InsertOneAsync(newEmployee);

                // Update ObservableCollection and clear input fields
                employees.Add(newEmployee);
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee to MongoDB: " + ex.Message);
            }

        }

        private async  void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve all employees from MongoDB
                var employeesFromDB = await employeeCollection.Find(new BsonDocument()).ToListAsync();

                employees.Clear();
                foreach (var emp in employeesFromDB)
                {
                    employees.Add(emp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employees from MongoDB: " + ex.Message);
            }
        }

        private async  void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (listViewEmployees.SelectedIndex != -1)
                {
                    Employee selectedEmployee = (Employee)listViewEmployees.SelectedItem;

                    // Delete selected employee from MongoDB
                    await employeeCollection.DeleteOneAsync(emp => emp.Id == selectedEmployee.Id);

                    employees.Remove(selectedEmployee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee from MongoDB: " + ex.Message);
            }
        }
        private void ClearInputFields()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
            txtBonus.Text = "";
            txtDepartment.Text = "";
            txtCity.Text = "";
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchName = txtSearchName.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                try
                {
                    var filter = Builders<Employee>.Filter.Where(emp => emp.Name.ToLower().Contains(searchName.ToLower()));
                    var filteredEmployees = await employeeCollection.Find(filter).ToListAsync();

                    if (filteredEmployees.Count > 0)
                    {
                        listViewEmployees.ItemsSource = filteredEmployees;
                    }
                    else
                    {
                        MessageBox.Show("No employees found in DataBase "); // Wrote by Tuan Anh
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching for employees: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a name to search.");
            }
        }

        private async void btnShowAllSalaries_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var projection = Builders<Employee>.Projection.Include(emp => emp.Name)
                                                              .Include(emp => emp.Salary)
                                                              .Include(emp => emp.BonusSalary);

                var allSalaries = await employeeCollection.Find(new BsonDocument())
                                                          .Project<Employee>(projection)
                                                          .ToListAsync();

                if (allSalaries.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Employee Salaries and Bonus:");

                    foreach (var emp in allSalaries)
                    {
                        sb.AppendLine($"Name: {emp.Name}, Salary: {emp.Salary}, Bonus: {emp.BonusSalary}");
                    }

                    MessageBox.Show(sb.ToString());
                }
                else
                {
                    MessageBox.Show("No employees found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving salaries: " + ex.Message);
            }
        }
    }
    public class Employee
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public decimal BonusSalary { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}
