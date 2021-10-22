using ProgrammingProjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace ProgrammingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> CalculationResults = new ObservableCollection<string>();
        public ObservableCollection<string> Results
        {
            get { return CalculationResults; }
            set
            {
                CalculationResults = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoginSignupFunctions.mainWindow = this;
            tabLogin.IsEnabled = true;
            Logoutbtn.Visibility = Visibility.Hidden;
            Logoutbtn.IsEnabled = false;
            tabCalculator.IsEnabled = false;
            ListboxResults.ItemsSource = Results;
            



        }
        
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginSignupFunctions.Logout();
        }
        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            LoginSignupFunctions.Register(this);
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginSignupFunctions.LoginUser(this);
        }
        private void SignupLabelClick(object sender, RoutedEventArgs e)
        {
            tabSignup.IsSelected = true;
        }

        private void EqualbtnClick(object sender, RoutedEventArgs e) //Hesap makinesinin eşit butonu
        {
            decimal decResult = decimal.Zero;
            try
            {
                decResult = Methods.Evaluate(resultbox.Text);
            }
            catch (Exception E)
            {
                System.Windows.MessageBox.Show("You have entered an incorrect mathmetical equation. Here error message:\n " + E.Message);
                return;
            }

            Results.Insert(0, resultbox.Text + "\t=" + decResult.ToString("N5"));
            clearbtnclick(null, null);
            
        }
        private void deleteclick(object sender, RoutedEventArgs e) // geri tuşu butonu
        {
            if (resultbox.Text.Length > 0)
            {
                resultbox.Text = resultbox.Text.Substring(0, resultbox.Text.Length - 1);
            }
            FocusResultbox();
        }

        private void clearbtnclick(object sender, RoutedEventArgs e)
        {
            resultbox.Text = "";
            FocusResultbox();
        }
        private void FocusResultbox()
        {
            resultbox.Focus();
            resultbox.SelectionStart = resultbox.Text.Length;
        }
        private void CalculatorBtnClick(object sender, RoutedEventArgs e) //Hesap makinesini Tuşları
        {
            Button btn = (Button)sender;
            resultbox.Text += btn.Content.ToString();
            FocusResultbox();
        }
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter))
            {
                EqualbtnClick(null, null);
            }
            if ((e.Key == Key.D4 && Keyboard.IsKeyDown(Key.RightAlt)))
            {
                e.Handled = true;
            }
        }
        private void savebtn(object sender, RoutedEventArgs e) // Hesap Makinesini işlemlerini kaydetmek
        {
            

            using (StreamWriter streamWriter = new StreamWriter(Methods.CalculationHistoryFile, true))
            {
                foreach (string items in ListboxResults.Items)
                {
                    streamWriter.WriteLine(items + Environment.NewLine);
                }
            }
        }
        private void loadbtn(object sender, RoutedEventArgs e)
        {
            TextBlockLoad.Text = "";
           
            TextBlockLoad.Text = File.ReadAllText(Methods.CalculationHistoryFile);

        }
        


















        private void txtchangedUsername(object sender, EventArgs e) 
        {
            bool restrict = true;
            if (RegUsername.Text.StartsWith(" "))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("1"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("2"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("3"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("4"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("5"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("6"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("7"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("8"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("9"))
            {
                restrict = false;
            }
            if (RegUsername.Text.StartsWith("0"))
            {
                restrict = false;
            }      
            if (restrict == false)
            {
                RegUsername.Text = "";
            }
            
        }

       

        

        
    }
}
