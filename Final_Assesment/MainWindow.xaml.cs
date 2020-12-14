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

namespace Final_Assesment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        


        // Part time employees
        PartTimeEmployee PT1 = new PartTimeEmployee("Jane", "Jones", 12, 14);
        PartTimeEmployee PT2 = new PartTimeEmployee("John", "Smith", 11, 15);

        //Full time employees
        FullTimeEmployee FT1 = new FullTimeEmployee("Joe", "Murphy", 392);
        FullTimeEmployee FT2 = new FullTimeEmployee("Jess", "Walsh", 435);

        //Collection of Employees
        ObservableCollection<Employee> EmployeeCollection = new ObservableCollection<Employee>();
        //Collection of Part time Employees
        ObservableCollection<Employee> PTEmployeeCollection = new ObservableCollection<Employee>();
        //Collection of full time employees
        ObservableCollection<Employee> FTEmployeeCollection = new ObservableCollection<Employee>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                //adds employees to employee collection
                EmployeeCollection.Add(PT1);
                EmployeeCollection.Add(PT2);
                EmployeeCollection.Add(FT1);
                EmployeeCollection.Add(FT2);
                
                //sets the source for the listbox
                lbxNames.ItemsSource = EmployeeCollection;

                //adds employees to appropriate collections (part time or full time)
                for (int i = 0; i < EmployeeCollection.Count; i++)
                {
                    if (EmployeeCollection[i] is PartTimeEmployee)
                    {
                        PTEmployeeCollection.Add(EmployeeCollection[i]);
                    }
                    else if (EmployeeCollection[i] is FullTimeEmployee)
                    {
                    FTEmployeeCollection.Add(EmployeeCollection[i]);
                    }
                }
        }

        private void PTCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            lbxNames.ItemsSource = PTEmployeeCollection;

            if (FTCheckbox.IsChecked == true)
            {
                lbxNames.ItemsSource = EmployeeCollection;
            }

        }

        private void PTCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            lbxNames.ItemsSource = EmployeeCollection;

            if (FTCheckbox.IsChecked == true)
            {
                lbxNames.ItemsSource = FTEmployeeCollection;
            }
        }

        private void FTCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            lbxNames.ItemsSource = FTEmployeeCollection;

            if (PTCheckbox.IsChecked == true)
            {
                lbxNames.ItemsSource = EmployeeCollection;
            }
        }


        //sets what happens when FT checkbox is unchecked
        private void FTCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            lbxNames.ItemsSource = EmployeeCollection;
            

            if (PTCheckbox.IsChecked == true)
            {
                lbxNames.ItemsSource = PTEmployeeCollection;
            }
        }

        private void lbxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           /****************************************************NOTE****************************************************
            NOTE if statements appear long-winded as I could not make it work using only lbxNames.SelectedItem.GetType()
            ************************************************************************************************************/

            //if employee is full time, salary box is filled and ft radio button is checked
            if (lbxNames.SelectedItem.GetType().ToString() == "Final_Assesment.FullTimeEmployee")
            {
                //find what employee is selected
                FullTimeEmployee selectedEmployee = lbxNames.SelectedItem as FullTimeEmployee;
                
                // make sure it isnt null
                if (selectedEmployee != null)
                {
                    //populate text boxes & radio button
                    fNameTextBox.Text = selectedEmployee.FirstName;
                    surNameTextBox.Text = selectedEmployee.SurName;
                    ftRadioButton.IsChecked = true;
                    salaryTextBox.Text = selectedEmployee.Salary.ToString();
                    hoursWorkedTextBox.Text = "N/A";
                    hourlyRateTextBox.Text = "N/A";
                    decimal monthlypay = selectedEmployee.Salary * 4;
                    MonthlypayLabel.Content = monthlypay;
                    
                }
            }

            //if employee is part time, hours worked and hourly pay boxes are filled and pt radio button is checked
            else if (lbxNames.SelectedItem.GetType().ToString() == "Final_Assesment.PartTimeEmployee")
            {
                //find what employee is selected
                PartTimeEmployee selectedEmployee = lbxNames.SelectedItem as PartTimeEmployee;

                //make sure it isn't null
                if (selectedEmployee != null)
                {
                    //populate text boxes & radio button
                    fNameTextBox.Text = selectedEmployee.FirstName;
                    surNameTextBox.Text = selectedEmployee.SurName;
                    ptRadioButton.IsChecked = true;
                    salaryTextBox.Text = "N/A";
                    hoursWorkedTextBox.Text = selectedEmployee.HoursWorked.ToString();
                    hourlyRateTextBox.Text = selectedEmployee.HourlyRate.ToString();
                    decimal monthlypay = Convert.ToDecimal(selectedEmployee.HoursWorked) * selectedEmployee.HourlyRate * 4;
                    MonthlypayLabel.Content = monthlypay;
                }
                
            }
        }
    }
}
