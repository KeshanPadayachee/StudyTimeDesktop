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
    /// Interaction logic for PrintStudyRecord.xaml
    /// </summary>
    public partial class PrintStudyRecord : Window
    {

        // Constructor
        public PrintStudyRecord()
        {
            InitializeComponent();
            cmbFilter.Items.Clear();
            for (int x = 1; x <= StudyTimeLibrary.ListHandler.currentSemester.NumWeeks; x++)
            {
                cmbFilter.Items.Add(x);
            }
        }

        // Checking if all record are to be printed
        private void chkPrintAllRecords_Checked(object sender, RoutedEventArgs e)
        {
            if (chkPrintAllRecords.IsChecked == true)
            {
                hideFilterOptions();
            }
            else
            {
                showFilterOptions();
            }
        }

        // Hiding the filter components
        private void hideFilterOptions()
        {
            lblPrintOption.Visibility = Visibility.Hidden;
            cmbFilter.Visibility = Visibility.Hidden;
        }

        // Showing the filter components
        private void showFilterOptions()
        {
            lblPrintOption.Visibility = Visibility.Visible;
            cmbFilter.Visibility = Visibility.Visible;
        }

        // Method to print the study record
        public static void printStudyRecord(string record)
        {
            try
            {

                // Someblokeontheinternet.blogspot.com
                // Authors : N/A
                // http://someblokeontheinternet.blogspot.com/2009/11/printing-contents-of-text-box-or-just.html (Not a secure website)
                // 16 September 2021

                // Creating a print dialog object
                PrintDialog pd = new PrintDialog();

                if (pd.ShowDialog().GetValueOrDefault())
                {
                    string printStudyRecord = record;
                    // Creating a flow document object
                    FlowDocument flowDocument = new FlowDocument();
                    Paragraph outputPrint = new Paragraph();

                    outputPrint.Margin = new Thickness(15);
                    outputPrint.Inlines.Add(new Run(StudyTimeLibrary.ListHandler.currentStudent.FirstName + " " + StudyTimeLibrary.ListHandler.currentStudent.Surname + "'s Study Record ("+ StudyTimeLibrary.ListHandler.currentStudent.StudentNumber+")"));
                    outputPrint.Inlines.Add(new Run(printStudyRecord));
                    flowDocument.Blocks.Add(outputPrint);

                    DocumentPaginator page = ((IDocumentPaginatorSource)flowDocument).DocumentPaginator;

                    pd.PrintDocument(page, StudyTimeLibrary.ListHandler.currentStudent.FirstName + " " + StudyTimeLibrary.ListHandler.currentStudent.Surname + "'s Study Record (" + StudyTimeLibrary.ListHandler.currentStudent.StudentNumber + ")");
                }
            }
            catch
            {
                MessageBox.Show("An unexpected error occurred", "Monthly Budget Planner", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event to print the study record
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (chkPrintAllRecords.IsChecked == true)
            {
                string record = StudyTimeLibrary.StudyRecordWorker.printStudyRecord();
                printStudyRecord(record);
            }
            else
            {
                int chosen = Convert.ToInt32(cmbFilter.SelectedItem);
                string record = StudyTimeLibrary.StudyRecordWorker.filterStudyRecord(chosen);
                printStudyRecord(record);
            }
        }

        // Event to show the portal window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Portal showPortal = new Portal();
            showPortal.Show();
        }
    }
}
