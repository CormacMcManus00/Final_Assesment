using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
             THIS IS A FIRST DRAFT FOR LISTBOX SELECTIONS
             ************************************************************************************************************/

            //if employee is full time, salary box is filled and ft radio button is checked
            /*if (lbxNames.SelectedItem.GetType().ToString() == "Final_Assesment.FullTimeEmployee")*/
            if (lbxNames.SelectedItem != null && lbxNames.SelectedItem is FullTimeEmployee)
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
            else if (lbxNames.SelectedItem != null && lbxNames.SelectedItem is PartTimeEmployee)
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

            else if (lbxNames.SelectedItem is null)
            {
                fNameTextBox.Text = ("ERROR - Selected Item has value of NULL");
            }

        }

    private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            fNameTextBox.Text = "";
            surNameTextBox.Text = "";
            ptRadioButton.IsChecked = false;
            ftRadioButton.IsChecked = false;
            salaryTextBox.Text = "";
            hoursWorkedTextBox.Text = "";
            hourlyRateTextBox.Text = "";
            MonthlypayLabel.Content = "N/A";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {



            // User can add up to 5 Full time employees
            if (ftRadioButton.IsChecked == true)
            {
                int ftCaseSwitch = 1;
                

                switch (ftCaseSwitch)
                {
                    case 1:
                        FullTimeEmployee CustomFTEmployee1 = new FullTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(salaryTextBox.Text));
                        EmployeeCollection.Add(CustomFTEmployee1);
                        FTEmployeeCollection.Add(CustomFTEmployee1);
                        ftCaseSwitch++;
                        break;
                    case 2:
                        FullTimeEmployee CustomFTEmployee2 = new FullTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(salaryTextBox.Text));
                        EmployeeCollection.Add(CustomFTEmployee2);
                        FTEmployeeCollection.Add(CustomFTEmployee2);
                        ftCaseSwitch++;
                        break;
                    case 3:
                        FullTimeEmployee CustomFTEmployee3 = new FullTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(salaryTextBox.Text));
                        EmployeeCollection.Add(CustomFTEmployee3);
                        FTEmployeeCollection.Add(CustomFTEmployee3);
                        ftCaseSwitch++;
                        break;
                    case 4:
                        FullTimeEmployee CustomFTEmployee4 = new FullTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(salaryTextBox.Text));
                        EmployeeCollection.Add(CustomFTEmployee4);
                        FTEmployeeCollection.Add(CustomFTEmployee4);
                        ftCaseSwitch++;
                        break;
                    case 5:
                        FullTimeEmployee CustomFTEmployee5 = new FullTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(salaryTextBox.Text));
                        EmployeeCollection.Add(CustomFTEmployee5);
                        FTEmployeeCollection.Add(CustomFTEmployee5);
                        ftCaseSwitch++;
                        break;
                    default:
                        fNameTextBox.Text = ("STORAGE FULL - NO MORE FULL TIME EMPLOYEES");
                        break;
                }
            }
            //User can add up to 5 Part Time employees
            else if (ptRadioButton.IsChecked == true)
            {
                int ptCaseSwitch = 1;
                switch (ptCaseSwitch)
                {
                    case 1:
                        PartTimeEmployee CustomPTEmployee1 = new PartTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(hourlyRateTextBox.Text), double.Parse(hoursWorkedTextBox.Text));
                        EmployeeCollection.Add(CustomPTEmployee1);
                        PTEmployeeCollection.Add(CustomPTEmployee1);
                        ptCaseSwitch++;
                        break;
                    case 2:
                        PartTimeEmployee CustomPTEmployee2 = new PartTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(hourlyRateTextBox.Text), double.Parse(hoursWorkedTextBox.Text));
                        EmployeeCollection.Add(CustomPTEmployee2);
                        PTEmployeeCollection.Add(CustomPTEmployee2);
                        ptCaseSwitch++;
                        break;
                    case 3:
                        PartTimeEmployee CustomPTEmployee3 = new PartTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(hourlyRateTextBox.Text), double.Parse(hoursWorkedTextBox.Text));
                        EmployeeCollection.Add(CustomPTEmployee3);
                        PTEmployeeCollection.Add(CustomPTEmployee3);
                        ptCaseSwitch++;
                        break;
                    case 4:
                        PartTimeEmployee CustomPTEmployee4 = new PartTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(hourlyRateTextBox.Text), double.Parse(hoursWorkedTextBox.Text));
                        EmployeeCollection.Add(CustomPTEmployee4);
                        PTEmployeeCollection.Add(CustomPTEmployee4);
                        ptCaseSwitch++;
                        break;
                    case 5:
                        PartTimeEmployee CustomPTEmployee5 = new PartTimeEmployee(fNameTextBox.Text, surNameTextBox.Text, Convert.ToDecimal(hourlyRateTextBox.Text), double.Parse(hoursWorkedTextBox.Text));
                        EmployeeCollection.Add(CustomPTEmployee5);
                        PTEmployeeCollection.Add(CustomPTEmployee5);
                        ptCaseSwitch++;
                        break;
                    default:
                        fNameTextBox.Text = ("STORAGE FULL - NO MORE PART TIME EMPLOYEES");
                        break;
                }
            }
        }


        //Removes details of employee from employee list & part / full time employee list
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lbxNames.SelectedItem is FullTimeEmployee)
            {
                FTEmployeeCollection.Remove(lbxNames.SelectedItem as FullTimeEmployee);
            }
            else if (lbxNames.SelectedItem is PartTimeEmployee)
            {
                PTEmployeeCollection.Remove(lbxNames.SelectedItem as PartTimeEmployee);
            }
            EmployeeCollection.Remove(lbxNames.SelectedItem as Employee);
        }



        //updates selected list employee with details input in text fields
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lbxNames.SelectedItem is FullTimeEmployee)
            {
                FullTimeEmployee selectedEmployee = lbxNames.SelectedItem as FullTimeEmployee;
                selectedEmployee.FirstName = fNameTextBox.Text;
                selectedEmployee.SurName = surNameTextBox.Text;
                selectedEmployee.Salary = Convert.ToDecimal(salaryTextBox.Text);
            }
            else if (lbxNames.SelectedItem is PartTimeEmployee)
            {
                PartTimeEmployee selectedEmployee = lbxNames.SelectedItem as PartTimeEmployee;
                selectedEmployee.FirstName = fNameTextBox.Text;
                selectedEmployee.SurName = surNameTextBox.Text;
                selectedEmployee.HoursWorked = double.Parse(hoursWorkedTextBox.Text);
                selectedEmployee.HourlyRate = Convert.ToDecimal(hourlyRateTextBox.Text);
                
            }
            if (lbxNames.SelectedItem is null)
            {
                
            }
        }
    }
}
