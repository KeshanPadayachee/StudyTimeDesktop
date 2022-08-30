// Keshan Padayachee
// 20121106
// PROG 6212
// Portfolio Of Evidence
// Task 2
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Threading;


namespace StudyTime
{
    /// <summary>
    /// Interaction logic for Portal.xaml
    /// </summary>
    public partial class Portal : Window
    {



        // Constructor
        public Portal()
        {
            InitializeComponent();
            // Dynamically designing the GUI
            grdNewSemester.Visibility = Visibility.Hidden;
            dtPickNewStartDate.DisplayDate = DateTime.Now.Date;
            dtPickNewStartDate.DisplayDateEnd = DateTime.Now.Date;
            dtPickNewStartDate.SelectedDate = DateTime.Now.Date;
            tabControl.Margin = new Thickness(0, 95, 0, 0);
            btnSubmitRecord.IsEnabled = false;
            populateModules();
            StudyTimeLibrary.StudyRecordWorker.retrieveStudyRecord();
            txtBlockStudyRecord.Text = showStudyRecord();
            btnSaveDetails.IsEnabled = false;
            populateField();
            if (StudyTimeLibrary.ListHandler.currentSemester != null)
            {
                lblWeekNumber.Content = "Week " + StudyTimeLibrary.ModuleWorker.calculateWeek() + " out of " +
                               StudyTimeLibrary.ListHandler.currentSemester.NumWeeks + " weeks. Todays date: " + DateTime.Now.Date.ToString().Substring(0, 10);

            }
            studyRecordWeeks();
        }

        // Method to terminate the application if the close button is clicked
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        /* -------------------------------------------------------------------------------------------*/
        /* START : Methods dealing with SEMESTER DETAILS */

        // Private variables - SEMESTER DETAILS
        private string numWeeks;
        private string startDate;

        // Event to add a new semester
        private void btnAddNewSemester_Click(object sender, RoutedEventArgs e)
        {
            // Assigning values to the private variables
            this.numWeeks = txbNewNumWeeks.Text;
            this.startDate = dtPickNewStartDate.SelectedDate.ToString();

            // Checking to see if values are valid and creating the semester record
            if (validateSemesterDetails().Equals(""))
            {
                StudyTimeLibrary.SemesterWorker.addNewSemesterDetail(Convert.ToDateTime(this.startDate), Convert.ToInt32(this.numWeeks));
                MessageBox.Show("Semester Details have been added successfully.");
                showStudyManager();
            }
            else
            {
                MessageBox.Show(validateSemesterDetails());
                return;
            }
        }

        // Method to validate the semester details
        public string validateSemesterDetails()
        {
            string errors = "";
            if (StudyTimeLibrary.Validation.validateInteger(this.numWeeks) == false)
            {
                errors += "- Invalid Number of Weeks.\r";
            }
            return errors;
        }

        // Method to show the semester details screen
        public void showSemesterDetails()
        {
            populateModules();
            grdSemester.Visibility = Visibility.Visible;
            grdNewSemester.Visibility = Visibility.Visible;
            grdNewSemester.Margin = new Thickness(30, 30, 30, 30);
            tabStudy.IsEnabled = false;
            tabModules.IsEnabled = false;
        }

        // Method to show the study manager screen
        public void showStudyManager()
        {
            if (StudyTimeLibrary.ListHandler.currentSemester != null)
            {
                lblWeekNumber.Content = "Week " + StudyTimeLibrary.ModuleWorker.calculateWeek() + " out of " +
                               StudyTimeLibrary.ListHandler.currentSemester.NumWeeks + " weeks. Todays date: " + DateTime.Now.Date.ToString().Substring(0, 10);

            }
            grdStudy.Visibility = Visibility.Visible;
            tabStudy.IsEnabled = true;
            tabModules.IsEnabled = true;
            tabSemester.IsEnabled = false;

        }

        /* END : Methods dealing with SEMESTER DETAILS */
        /* -------------------------------------------------------------------------------------------*/
        /* START : Methods dealing with ADDING MODULES */

        // Private vairables - ADDING MODULES
        private string moduleCode;
        private string moduleName;
        private string moduleCredits;
        private string classHours;

        // Event to add the Module record
        private void btnAddModule_Click(object sender, RoutedEventArgs e)
        {
            // Assigning the private variables values
            this.moduleCode = txbAddCode.Text;
            this.moduleName = txbAddName.Text;
            this.moduleCredits = txbAddCredits.Text;
            this.classHours = txbAddClassHours.Text;

            // Validating the inputs
            if (validateModuleDetails().Equals(""))
            {
                // Adding the record
                StudyTimeLibrary.ModuleWorker.addModule(this.moduleCode, this.moduleName, Convert.ToInt32(this.moduleCredits), Convert.ToDecimal(this.classHours));
                MessageBox.Show("Module has been added successfully.");
                clearAddModulesFields();
                populateModules();
            }
            else
            {
                MessageBox.Show(validateModuleDetails(), "Error List", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to validate the inputs
        private string validateModuleDetails()
        {
            string errors = "";
            if (this.moduleCode.Length <= 0 || this.moduleCode.Length >= 10)
            {
                errors += "- Invalid Module Code.\r";
            }
            if (this.moduleName.Length <= 0 || this.moduleName.Length >= 50)
            {
                errors += "- Invalid Module Name.\r";
            }
            if (StudyTimeLibrary.Validation.validateInteger(this.moduleCredits) == false)
            {
                errors += "- Invalid Module Credits.\r";
            }
            if (StudyTimeLibrary.Validation.validateDouble(this.moduleCredits) == false)
            {
                errors += "- Invalid Class Hours.\r";
            }
            return errors;
        }

        // Method to show the details of module added
        public void populateAddModuleOutput()
        {
            txtBlockDisplay.Text = "";
            txtBlockDisplay.Text = "MODULE CODE: " + txbAddCode.Text +
                "\rMODULE NAME: " + txbAddName.Text +
                "\rMODULE CREDITS: " + txbAddCredits.Text +
                "\rCLASS HOURS/WEEK: " + txbAddClassHours.Text;
        }


        private void txbAddCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            populateAddModuleOutput();
        }

        private void txbAddName_TextChanged(object sender, TextChangedEventArgs e)
        {
            populateAddModuleOutput();
        }

        private void txbAddCredits_TextChanged(object sender, TextChangedEventArgs e)
        {
            populateAddModuleOutput();
        }

        private void txbAddClassHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            populateAddModuleOutput();
        }

        // Method to clear the input fields
        private void clearAddModulesFields()
        {
            txbAddCode.Text = "";
            txbAddName.Text = "";
            txbAddCredits.Text = "";
            txbAddClassHours.Text = "";
        }

        /* END : Methods dealing with ADDING MODULES */
        /* -------------------------------------------------------------------------------------------*/
        /* START : Methods dealing with MANAGING MODULES */

        // Methods to populate the combobox with the users modules
        public void populateModules()
        {
            var tskFilter = Task.Run(() => StudyTimeLibrary.ModuleWorker.filterStudentModules());
            tskFilter.Wait();
            cmbSelectModule.Items.Clear();
            if (StudyTimeLibrary.ListHandler.lstModule.Count > 0)
            {
                foreach (StudyTimeLibrary.Models.Module populate in StudyTimeLibrary.ListHandler.lstModule)
                {
                    cmbSelectModule.Items.Add(populate.ModuleCode + "-" + populate.ModuleName);
                }
            }
        }

        // Method to load the details of the chosen module
        private async void cmbSelectModule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbSelectModule.SelectedIndex > -1)
            {
                btnSubmitRecord.IsEnabled = true;
                string selected = cmbSelectModule.SelectedItem.ToString();
                Task<string> tskLoadModule = new Task<string>(() => StudyTimeLibrary.ModuleWorker.showSelectedModule(selected));
                tskLoadModule.Start();
                string display = await tskLoadModule;
                txtBlockModuleDetails.Text = display;
            }

        }

        /* END : Methods dealing with MANAGING MODULES */
        /* -------------------------------------------------------------------------------------------*/
        /* START : Methods dealing with STUDY RECORDS */

        // Method to show all users study records
        public string showStudyRecord()
        {
            StudyTimeLibrary.StudyRecordWorker.retrieveStudyRecord();
            txtBlockStudyRecord.Text = "";
            string output = "";
            foreach (StudyTimeLibrary.Models.Module mod in StudyTimeLibrary.ListHandler.lstModule)
            {
                foreach (StudyTimeLibrary.Models.StudyRecord show in StudyTimeLibrary.ListHandler.lstStudyRecord)
                {
                    if (show.ModuleId.Equals(mod.ModuleId))
                    {
                        output += "MODULE CODE: " + mod.ModuleCode + "\rMODULE NAME: " + mod.ModuleName
                        + "\rHOURS STUDIED: " + show.HoursStudied + "\rDATE STUDIED: " + show.DateStudied.ToString().Substring(0, 10) + "\n";
                        //+"\rTOTAL HOURS REM.: "++"\n";
                    }
                }
            }
            return output;
        }

        // Populating for filter
        private void studyRecordWeeks()
        {
            cmbFilter.Items.Clear();
            if (StudyTimeLibrary.ListHandler.currentSemester != null)
            {
                for (int x = 1; x <= StudyTimeLibrary.ListHandler.currentSemester.NumWeeks; x++)
                {
                    cmbFilter.Items.Add(x);
                }
            }
        }

        // Submitting a new study record
        private async void btnSubmitRecord_Click(object sender, RoutedEventArgs e)
        {

            if (StudyTimeLibrary.Validation.validateDouble(txbHoursStudied.Text) == false)
            {
                MessageBox.Show("- Invalid Hours Studied.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                int modID = StudyTimeLibrary.StudyRecordWorker.getModuleID(cmbSelectModule.SelectedItem.ToString());
                StudyTimeLibrary.StudyRecordWorker.createStudyRecord(modID, DateTime.Now.ToString().Substring(0, 10), txbHoursStudied.Text);
                MessageBox.Show("Record added successfully. Keep up the hard work.");
                txtBlockStudyRecord.Text = "";
                txtBlockStudyRecord.Text = showStudyRecord();
                string selected = cmbSelectModule.SelectedItem.ToString();
                Task<string> tskLoadModule = new Task<string>(() => StudyTimeLibrary.ModuleWorker.showSelectedModule(selected));
                tskLoadModule.Start();
                string display = await tskLoadModule;
                txtBlockModuleDetails.Text = display;
                return;
            }
        }

        // Method to filter the study record
        private async void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int option = Convert.ToInt32(cmbFilter.SelectedItem.ToString());
            Task<string> tskFilter = new Task<string>(() => StudyTimeLibrary.StudyRecordWorker.filterStudyRecord(option));
            tskFilter.Start();
            txtBlockStudyRecordFiltered.Text = "Retrieving study record for week " + option;
            string output = await tskFilter;
            txtBlockStudyRecordFiltered.Text = output;
        }

        // Event to show the print window
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintStudyRecord showPrint = new PrintStudyRecord();
            this.Hide();
            showPrint.Show();
        }

        /* END : Methods dealing with STUDY RECORDS */
        /* -------------------------------------------------------------------------------------------*/
        /* START : Methods dealing with MANAGING PROFILE */

        // Event to edit the users personal details
        private void btnEditDetails_Click(object sender, RoutedEventArgs e)
        {
            btnEditDetails.IsEnabled = false;
            txbFirstName.Text = "";
            txbSurname.Text = "";
            txbEmailAddress.Text = "";
            txbCellNumber.Text = "";
            txbFirstName.IsEnabled = true;
            txbSurname.IsEnabled = true;
            txbEmailAddress.IsEnabled = true;
            txbCellNumber.IsEnabled = true;
            btnSaveDetails.IsEnabled = true;
        }

        // Private variables = MANAGING PROFILE
        private string firstName;
        private string surname;
        private string email;
        private string cell;

        // Event to save the changes to personal details
        private async void btnSaveDetails_Click(object sender, RoutedEventArgs e)
        {
            this.firstName = txbFirstName.Text;
            this.surname = txbSurname.Text;
            this.email = txbEmailAddress.Text;
            this.cell = txbCellNumber.Text;

            Task<string> tskValidate = new Task<string>(validateUpdateInputs);
            string errors;
            tskValidate.Start();
            btnSaveDetails.IsEnabled = false;
            lblStudentNumber.Content = "Updating. Please be patient.";
            errors = await tskValidate;
            lblStudentNumber.Content = StudyTimeLibrary.ListHandler.currentStudent.StudentNumber;
            if (errors.Equals(""))
            {
                Thread thrdUpdateDetails = new Thread(() => StudyTimeLibrary.ManageProfileWorker.updatePersonalDetails(
                                StudyTimeLibrary.ListHandler.currentStudent.StudentId, firstName, surname,
                                StudyTimeLibrary.ListHandler.currentStudent.StudentNumber, cell, email,
                                StudyTimeLibrary.ListHandler.currentStudent.PasswordHash,
                                StudyTimeLibrary.ListHandler.currentStudent.PasswordSalt));
                thrdUpdateDetails.Start();

                StudyTimeLibrary.ListHandler.currentStudent.FirstName = firstName;
                StudyTimeLibrary.ListHandler.currentStudent.Surname = surname;
                StudyTimeLibrary.ListHandler.currentStudent.EmailAddress = email;
                StudyTimeLibrary.ListHandler.currentStudent.CellNumber = cell;
                MessageBox.Show("Details updated successfully.");
                populateField();
                btnEditDetails.IsEnabled = true;
                return;
            }

            MessageBox.Show(errors, "Error List: ", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Method to validate the changes 
        public string validateUpdateInputs()
        {
            string errors = "";
            if (this.firstName.Length <= 0 || StudyTimeLibrary.Validation.validateString(this.firstName) == false)
            {
                errors += "- Invalid First Name.\r";
            }
            if (this.surname.Length <= 0 || StudyTimeLibrary.Validation.validateString(this.surname) == false)
            {
                errors += "- Invalid Surame.\r";
            }
            // Code Attribution : Validating email address
            // DelftStack
            // Validate Email Address in C#
            // Date Published : 19 March 2021
            // Date Accessed : 14 October 2021
            // URL : https://www.delftstack.com/howto/csharp/validate-email-in-csharp/
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                errors += "- Invalid Email Address.\r";
            }
            if (this.cell.Length <= 0 || this.cell.Length > 10 || StudyTimeLibrary.Validation.validateInteger(this.cell) == false)
            {
                errors += "- Invalid Cell Number.\r";
            }
            return errors;
        }

        // Method to display the changes
        public void populateField()
        {
            txbFirstName.IsEnabled = false;
            txbSurname.IsEnabled = false;
            txbEmailAddress.IsEnabled = false;
            txbCellNumber.IsEnabled = false;

            txbFirstName.Text = StudyTimeLibrary.ListHandler.currentStudent.FirstName;
            txbSurname.Text = StudyTimeLibrary.ListHandler.currentStudent.Surname;
            txbEmailAddress.Text = StudyTimeLibrary.ListHandler.currentStudent.EmailAddress;
            txbCellNumber.Text = StudyTimeLibrary.ListHandler.currentStudent.CellNumber;
            btnSaveDetails.IsEnabled = false;
            btnEditDetails.IsEnabled = true;

            lblStudentNumber.Content = StudyTimeLibrary.ListHandler.currentStudent.StudentNumber;
        }

        // Event to show the change password window
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword change = new ChangePassword();
            this.Hide();
            change.ShowDialog();
        }

        // Event to show the update semester details window
        private void btnUpdateSemDetails_Click(object sender, RoutedEventArgs e)
        {
            UpdateSemesterDetails show = new UpdateSemesterDetails();
            this.Hide();
            show.Show();
        }

        /* END : Methods dealing with MANAGING PROFILE
/* -------------------------------------------------------------------------------------------*/
    }
}
