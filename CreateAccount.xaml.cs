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
using StudyTimeLibrary;
using System.Threading;

namespace StudyTime
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {

        // Private variables to hold the new users details
        private string firstName;
        private string surname;
        private string email;
        private string studentNumber;
        private string contactNumber;
        private string password1;
        private string password2;

        // Calling the Study Time Library classes
        private StudyTimeLibrary.Models.STUDYTIMEContext connection = new StudyTimeLibrary.Models.STUDYTIMEContext();
        private StudyTimeLibrary.Models.Student newStudent = new StudyTimeLibrary.Models.Student();
        private List<StudyTimeLibrary.Models.Student> lstStudent = new List<StudyTimeLibrary.Models.Student>();

        // Constructor
        public CreateAccount()
        {
            InitializeComponent();
            lblSubHeading.Content = "Let's create your account and get you started.";
           
        }

        // Event to go back to the main window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow showMainWindow = new MainWindow();
            this.Hide();
            showMainWindow.Show();
        }

        // Event to create the users account
        private async void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            // Populating the private variables with the users information
            this.firstName = txbFirstName.Text;
            this.surname = txbLastName.Text;
            this.email = txbEmailAddress.Text;
            this.studentNumber = txbStudentNumber.Text;
            this.contactNumber = txbContactNumber.Text;
            this.password1 = txbPassword.Text;
            this.password2 = txbConfirmPassword.Text;

            // Task to validate the users inputs
            Task<string> tskValidate = new Task<string>(validateInputs);
            tskValidate.Start();
            lblSubHeading.Content = "We are validating your details. Please be patient...";
            string errors = await tskValidate;

            // If errors occur, the user will be shown the errors
            if (errors.Length > 0)
            {
                lblSubHeading.Content = "Let's create your account and get you started.";
                MessageBox.Show(errors, "Error List:", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Creating the new users account
            lblSubHeading.Content = "Logging you in. Please be patient...";
            //Thread threadNewUser = new Thread(() => StudyTimeLibrary.CreateAccountWorker.createAccount(this.firstName, this.surname, this.email, this.studentNumber, this.contactNumber, this.password1));
            //threadNewUser.Start();
            var tskFilter = Task.Run(() => StudyTimeLibrary.CreateAccountWorker.createAccount(this.firstName, this.surname, this.email, this.studentNumber, this.contactNumber, this.password1));
            tskFilter.Wait();
            Portal showPortal = new Portal();
            this.Hide();
            showPortal.showSemesterDetails();
            showPortal.Show();
            // Showing the user the relevant screen to enter their semester details. No modules can be added without no semester details
            //if (StudyTimeLibrary.LoginWorker.checkSemesterDetails(StudyTimeLibrary.ListHandler.currentStudent.StudentId))
            //{
            //    Thread thrdSetSemesterDetails = new Thread(() => StudyTimeLibrary.LoginWorker.getSemesterDetails(StudyTimeLibrary.ListHandler.currentStudent.StudentId));
            //    thrdSetSemesterDetails.Start();

            //    Portal showPortal = new Portal();
            //    this.Hide();
            //    showPortal.showStudyManager();
            //    showPortal.Show();
            //}
            //else
            //{
            //    Portal showPortal = new Portal();
            //    this.Hide();
            //    showPortal.showSemesterDetails();
            //    showPortal.Show();
            //}
        }

        // Method to validate the users input
        private string validateInputs()
        {
            // Creating an instance of the Validation class in the class library
            string errors = "";

            // Validating the students first name
            if (StudyTimeLibrary.Validation.validateString(this.firstName) == false)
            {
                errors += "- Invalid First Name.\r";
            }

            // Validating the students last name
            if (StudyTimeLibrary.Validation.validateString(this.surname) == false)
            {
                errors += "- Invalid Surname.\r";
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

            // Validating the students student number
            if (StudyTimeLibrary.Validation.validateInteger(this.studentNumber) == false ||
                this.studentNumber.Length <= 0 ||
                this.studentNumber.Length > 15)
            {
                errors += "- Invalid Student Number.\r";
            }

            // Validating the students contact
            if (StudyTimeLibrary.Validation.validateInteger(this.contactNumber) == false ||
                this.contactNumber.Length <= 0 ||
                this.contactNumber.Length > 10)
            {
                errors += "- Invalid Contact Number.\r";
            }

            // Validating the students password
            if (this.password1 != this.password2)
            {
                errors += "- Passwords do not match.";
            }
            Thread.Sleep(2000);
            return errors;
        }

        // Method to terminate the application when the close button is clicked
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
