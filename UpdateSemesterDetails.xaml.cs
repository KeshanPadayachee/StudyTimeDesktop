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
    /// Interaction logic for UpdateSemesterDetails.xaml
    /// </summary>
    public partial class UpdateSemesterDetails : Window
    {
        // Constructor
        public UpdateSemesterDetails()
        {
            InitializeComponent();
            dtStartDate.DisplayDate = DateTime.Now.Date;
            dtStartDate.DisplayDateStart = DateTime.Now.Date;
            dtStartDate.SelectedDate = DateTime.Now.Date;
        }

        // Event to change and save the semester details
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("All modules associated with the current semester will be deleted." +
                "\nDo you wish to continue.", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                if (StudyTimeLibrary.Validation.validateInteger(txbNumWeeks.Text) == false)
                {
                    MessageBox.Show("- Invalid Number of Weeks.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DateTime startDate = Convert.ToDateTime(dtStartDate.SelectedDate);
                int numWeeks = Convert.ToInt32(txbNumWeeks.Text);
                Thread thrdUpdate = new Thread(() => StudyTimeLibrary.SemesterWorker.updateSemesterDetails(startDate, numWeeks));
                thrdUpdate.Start();
                MessageBox.Show("Semester Details Updated successully");
                StudyTimeLibrary.SemesterWorker.setSemesterDetails();
                StudyTimeLibrary.SemesterWorker.deleteModules();
                StudyTimeLibrary.ModuleWorker.filterStudentModules();
                btnBack_Click(sender, e);
            }
            else
            {
                return;
            }



        }

        // Event to go back to the portal window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Portal showPortal = new Portal();
            showPortal.Show();
            showPortal.showStudyManager();
        }
    }
}
