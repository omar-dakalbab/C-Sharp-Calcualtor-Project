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
using System.IO;
using System.Globalization;
using System.Security.Cryptography;
using ProgrammingProjects;

namespace ProgrammingProject
{
    public static class LoginSignup
    {
        public static int UsernameMinimumLength = 4;
          // Kullanıcı adı için en az karakter sayısı
        public static int PasswordMinimumLength = 6;
         // Şifre için en az karakter sayısı
        public static string AllowedLettersForUsernameSR = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_1234567890";
         // İzin verilen karakterler
        public static string UsersFileName = "usersdb.txt";
        // Kullanıcı adıların dosyası
        public static List<char> AllowedLettersForUsername = new List<char>();
        public class bools
        {
            public  bool BoolBool = true;
        }

        public static bools RegisterUser(string REGusername, string REGpassword, string REGconfirmpassword) // Kullanıcı adı ve şifre Methodları
        {    
            bools boolResult = new bools();
            if(REGusername.Length < UsernameMinimumLength)
            {
                boolResult.BoolBool = false;
                MessageBox.Show($"The minimum length for username is {UsernameMinimumLength} characters");
            }
            if(REGpassword.Length < PasswordMinimumLength)
            {
                boolResult.BoolBool = false;
                MessageBox.Show($"The minimum length for password is {PasswordMinimumLength} characrters");
            }
            if(REGpassword != REGconfirmpassword)
            {
                boolResult.BoolBool = false;
                MessageBox.Show("Please check your passwords");
            }
            bool PasswordContainsDigit = false;
            bool PasswordContainsLetter = false;
            bool PasswordContainsUpperCase = false;
            bool PasswordContainsLowerCase = false;
           
            foreach (char PasswordPerChar in REGpassword.ToCharArray())
            {
                if (char.IsDigit(PasswordPerChar))
                    PasswordContainsDigit = true;
                if (char.IsLetter(PasswordPerChar))
                    PasswordContainsLetter = true;
                if (char.IsUpper(PasswordPerChar))
                    PasswordContainsUpperCase = true;
                if (char.IsLower(PasswordPerChar))
                    PasswordContainsLowerCase = true;
            }
            if(!PasswordContainsDigit && boolResult.BoolBool == true)
            {
                boolResult.BoolBool = false;
                MessageBox.Show("Please enter a Numeric Character");
            }
            if (!PasswordContainsLetter &&boolResult.BoolBool== true)
            {
               boolResult.BoolBool= false;
                MessageBox.Show("Please enter a Letter Character");
            }
            if (!PasswordContainsLowerCase &&boolResult.BoolBool== true)
            {
               boolResult.BoolBool= false;
                MessageBox.Show("Please enter a LowerCase Character");
            }
            if (!PasswordContainsUpperCase &&boolResult.BoolBool== true)
            {
               boolResult.BoolBool= false;
                MessageBox.Show("Please enter a Uppercase Character");
            }
            foreach (var InputChar in REGusername)
            {
                if (AllowedLettersForUsername.Contains(InputChar) == false)
                {
                   boolResult.BoolBool = false;
                   MessageBox.Show($"Your username can not contain character {InputChar}");
                   break;
                }
            }
            if (File.Exists(UsersFileName))
            {
                foreach(var vrperChar in File.ReadLines(UsersFileName))
                {
                    if (string.IsNullOrEmpty(vrperChar))
                        continue;
                    List<string> stringSplitchar = vrperChar.Split('=').ToList();
                    string regUser = stringSplitchar[0];
                    if(regUser.Normalize() == REGusername.Normalize())
                    {
                        boolResult.BoolBool = false;
                        MessageBox.Show(REGusername + " is not available, try again with another username");
                        break;
                    }
                }             
            }
            return boolResult;
        }
        static LoginSignup() // izin verilen karakterleri dönüştürmek
        {
            foreach(var USERNAMEchar in AllowedLettersForUsernameSR.ToCharArray())
            {
                AllowedLettersForUsername.Add(USERNAMEchar);
            }
            foreach (var USERNAMEchar in AllowedLettersForUsernameSR.ToLower(new System.Globalization.CultureInfo("en-US")))
            {
                AllowedLettersForUsername.Add(USERNAMEchar);
            }
            foreach (var USERNAMEchar in AllowedLettersForUsernameSR.ToUpper(new System.Globalization.CultureInfo("en-US")))
            {
                AllowedLettersForUsername.Add(USERNAMEchar);
            }
            AllowedLettersForUsername = AllowedLettersForUsername.Distinct().ToList();
        }
        public static string Normalize(string username)
        {
            return username.ToUpper(new CultureInfo("en-US")).RemoveDiacritics().ToLower(new CultureInfo("en-US")).Trim();
        }
        static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }






    }
}



	

