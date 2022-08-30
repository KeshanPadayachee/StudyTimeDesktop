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

namespace StudyTime
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        // Constructor
        public ChangePassword()
        {
            InitializeComponent();
        }

        // Method to validate the users input and returns a string holding error details
        private string validateInputs(string oldPassword, string newPassword, string confirmNew)
        {
            // Creating a variable to hold the error details
            string errors = "";

            // Getting the current hash for the password
            string oldHash = StudyTimeLibrary.ListHandler.currentStudent.PasswordHash;
            // Getting the password salt
            string salt = StudyTimeLibrary.ListHandler.currentStudent.PasswordSalt;

            // Checking if the old password is known
            if (StudyTimeLibrary.PasswordManagement.generateHash(oldPassword, salt).Equals(oldHash))
            {
                // Checking to see if the new password and confirmation match
                if (newPassword.Equals(confirmNew))
                {
                    errors = "";
                }
                else
                {
                    errors = "- The New Passwords do not match. Please try again.";
                }
            }
            else
            {
                errors = "- The existing password is incorrect. Please try again.";
            }
            return errors;
        }

        // Event to to submit the users new password
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            // Storing the users inputs in variables
            string oldPassword = txbOldPassword.Text;
            string newPassword = txbNewPassword.Text;
            string confirmNew = txbNewPassword.Text;

            // Calling the validation method
            string errors = validateInputs(oldPassword, newPassword, confirmNew);

            // Checking if there were any errors
            if (errors.Equals(""))
            {
                // No errors - the users details will be updated
                int id = StudyTimeLibrary.ListHandler.currentStudent.StudentId;
                string name = StudyTimeLibrary.ListHandler.currentStudent.FirstName;
                string surname = StudyTimeLibrary.ListHandler.currentStudent.Surname;
                string studNum = StudyTimeLibrary.ListHandler.currentStudent.StudentNumber;
                string cell = StudyTimeLibrary.ListHandler.currentStudent.CellNumber;
                string email = StudyTimeLibrary.ListHandler.currentStudent.EmailAddress;
                string salt = StudyTimeLibrary.ListHandler.currentStudent.PasswordSalt;
                string hash = StudyTimeLibrary.PasswordManagement.generateHash(txbNewPassword.Text, salt);
                StudyTimeLibrary.ManageProfileWorker.updatePersonalDetails(id, name, surname, studNum, cell,
                    email, hash, salt);
                MessageBox.Show("Your password has been changed successfully");
                Button_Click(sender, e);
            }
            else
            {
                // Errors - the user will be shown the errors
                MessageBox.Show(errors, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        // Event to go back to the portal window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Portal showPortal = new Portal();
            showPortal.Show();
        }


    }
}
