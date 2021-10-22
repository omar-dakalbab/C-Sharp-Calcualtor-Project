using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using ProgrammingProjects;
using System.Security.Cryptography;

namespace ProgrammingProject
{
    public static class LoginSignupFunctions
    {
        public static string UsernameLabel = "";
        public static bool usernameloggedinBOOL = true;
        public static MainWindow mainWindow;
        public static Tuple<bool> Register(MainWindow MainWindow) //Bu Method Yeni hesap yapmak için yaptım
        {
            var Registeriftrue = LoginSignup.RegisterUser(MainWindow.RegUsername.Text.ToLower().Normalize(), MainWindow.RegPassword.Password.ToString(), MainWindow.RegRePassword.Password.ToString());
     
            if(Registeriftrue.BoolBool == false)
            {
                return new Tuple<bool>(Registeriftrue.BoolBool); 
            }
            if(Registeriftrue.BoolBool == true)
            {
                string RegisteredUsername = MainWindow.RegUsername.Text.ToLower().Normalize();
                Login(RegisteredUsername);
                File.AppendAllText(LoginSignup.UsersFileName, txtfileInsert(MainWindow.RegUsername.Text.ToLower(),MainWindow.RegPassword.Password.ToString()));    
            }
            
            return new Tuple<bool>(Registeriftrue.BoolBool);
        }
        public static string txtfileInsert(string REGusername,string REGpassword) // Method text dosyasına yazıldığı kullanıcı ve şifre 
        {
            return  REGusername + "=" + passwordHash(REGpassword) + Environment.NewLine;
        }
        public static void LoginUser(MainWindow MainWindow) // Oturum açmak için kullanılır
        {
            string LoginEnteredUsername = MainWindow.Logusername.Text.ToLower().Normalize();
            string LoginEnteredPassword = MainWindow.logPassword.Password.ToString().passwordHash();
            foreach (var vrPerline in File.ReadLines(LoginSignup.UsersFileName))
            {
                List<string> lstLineDetails = vrPerline.Split('=').ToList();
                if (lstLineDetails[0] == LoginEnteredUsername && LoginEnteredPassword == lstLineDetails[1])
                { 
                    Login(mainWindow.Logusername.Text.Normalize());
                    return;
                }             
            }
            MessageBox.Show("Wrong password or username"); // Değerler yanlış ise  Mesaj Kutu gösterilecek

        }
        public static void Login(string UserLoggedIn) // Login butonu basınca yapılacak olanlar
        {
            UsernameLabel = UserLoggedIn;
            usernameloggedinBOOL = true;
            mainWindow.tabSignup.IsEnabled = false;
            mainWindow.tabLogin.IsEnabled = false;
            mainWindow.tabCalculator.IsSelected = true;
            mainWindow.tabCalculator.IsEnabled = true;
            mainWindow.labelUsername.Content = "Logged User: " + UserLoggedIn;
            MessageBox.Show("You are logged in");
            mainWindow.Logoutbtn.Visibility = Visibility.Visible;
            mainWindow.Logoutbtn.IsEnabled = true;   
        }
        public static void Logout() // Logout butonu basınca yapılacak olanlar
        {

            UsernameLabel = "NA";
            usernameloggedinBOOL = false;
            mainWindow.tabSignup.IsEnabled = true;
            mainWindow.tabCalculator.IsSelected = false;
            mainWindow.tabLogin.IsSelected = true;
            mainWindow.tabLogin.IsEnabled = true;
            mainWindow.labelUsername.Content = UsernameLabel;         
            mainWindow.Logoutbtn.IsEnabled = false;
            mainWindow.Logoutbtn.Visibility = Visibility.Hidden;
            mainWindow.tabCalculator.IsEnabled = false;
            mainWindow.RegUsername.Text = "";
            mainWindow.Logusername.Text = "";
            mainWindow.RegPassword.Password = "";
            mainWindow.logPassword.Password = "";
            mainWindow.RegRePassword.Password = "";
        }
        public static string passwordHash(this string text) // Şifreyi 256hash'a  dönüştürmek
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
    
}
 