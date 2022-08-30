// Keshan Padayachee
// 20121106
// PROG 6212
// Portfolio Of Evidence
// Task 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace StudyTime
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        // Private variables to hold the users details
        private string studentNumber;
        private string password;

        // Calling the Study Time Library classes
        StudyTimeLibrary.Validation validate = new StudyTimeLibrary.Validation();

        // Constructor
        public LogIn()
        {
            InitializeComponent();
            lblStatus.Visibility = Visibility.Hidden;
        }

        // Event to go back to the main window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Switching windows
            MainWindow showMainWindow = new MainWindow();
            this.Hide();
            showMainWindow.Show();
        }

        // Event to log the user in 
        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //Showing an error message if the student number is invalid
            this.studentNumber = txbStudentNumber.Text;
            this.password = pTxbPassword.Password;
            lblStatus.Content = "";

            // Task to validate the users details
            Task<string> tskValidate = new Task<string>(validateLogInDetails);
            tskValidate.Start();
            lblStatus.Content = "Validating details, Please be patient...";
            lblStatus.Visibility = Visibility.Visible;
            string errors = await tskValidate;
            if (errors.Equals(""))
            {
                // No errors - the user will be logged in
                if (StudyTimeLibrary.LoginWorker.logUserIn(this.studentNumber, this.password))
                {
                    // Checking to see if the user has semester details saved
                    if (StudyTimeLibrary.LoginWorker.checkSemesterDetails(StudyTimeLibrary.ListHandler.currentStudent.StudentId))
                    {
                        // Semester details exist - user shown the study manager
                        Thread thrdSetSemesterDetails = new Thread(() => StudyTimeLibrary.LoginWorker.getSemesterDetails(StudyTimeLibrary.ListHandler.currentStudent.StudentId));
                        thrdSetSemesterDetails.Start();

                        Portal showPortal = new Portal();
                        this.Hide();
                        showPortal.showStudyManager();
                        showPortal.Show();
                    }
                    else
                    {
                        // No semester details exist - user is shown the semester details
                        Portal showPortal = new Portal();
                        this.Hide();
                        showPortal.showSemesterDetails();
                        showPortal.Show();
                    }
                    
                }
                else
                {
                    lblStatus.Content = "We're having trouble signing you in. Please try again.";
                    return;
                }
            }
            else
            {
                MessageBox.Show(errors, "Error List: ", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Visibility = Visibility.Hidden;
                return;
            }



        }

        // Method to validate the users details
        private string validateLogInDetails()
        {
            // Validating student number to only contain numbers
            string errors = "";
            if ((StudyTimeLibrary.Validation.validateInteger(this.studentNumber) == false) ||
                (this.studentNumber.Length <= 0) ||
                (this.studentNumber.Length > 15))
            {
                errors += "- Invalid Student Number.\r";
            }

            // Validating password field contain data
            if (this.password.Length <= 0)
            {
                errors += "- Invalid Password.";
            }
            return errors;
        }

        // Event to terminate the application if the close button is clicked
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
