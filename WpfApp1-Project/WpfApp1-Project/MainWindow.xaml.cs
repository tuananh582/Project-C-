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

namespace WpfApp1_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            listViewEmployees.ItemsSource = employees;
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            employees.Add(new Employee()
            {
                Id = txtId.Text,
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text),
                Salary = decimal.Parse(txtSalary.Text),
                BonusSalary = decimal.Parse(txtBonus.Text),
                Department = txtDepartment.Text,
                City = txtCity.Text
            });

            // Clear input fields after adding an employee
            ClearInputFields();
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            listViewEmployees.ItemsSource = null;
            listViewEmployees.ItemsSource = employees;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listViewEmployees.SelectedIndex != -1)
            {
                employees.RemoveAt(listViewEmployees.SelectedIndex);
            }
        }
        private void ClearInputFields()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
            txtBonus.Text = "";
            txtDepartment.Text = "";
            txtCity.Text = "";
        }
    }
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public decimal BonusSalary { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}
