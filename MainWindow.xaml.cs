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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudyTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event to show the login window
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn showLogIn = new LogIn();
            this.Hide();
            showLogIn.Show();
        }

        // Event to show the create account window
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount showCreateAccount = new CreateAccount();
            this.Hide();
            showCreateAccount.Show();
        }
    }
}
