using ProgrammingProject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace ProgrammingProjects
{
    public static class Methods
    {
        public static string CalculationHistoryFile = LoginSignupFunctions.UsernameLabel + ".txt";


        public static decimal Evaluate(String input)
        {
            NCalc.Expression e = new NCalc.Expression(input);
            var result = e.Evaluate();

            decimal h2 = Decimal.Parse(result.ToString(), System.Globalization.NumberStyles.Any);

            return Convert.ToDecimal(h2);
        }
        public static string composeUserfilePath(this string srUserName)
        {
            return srUserName + ".txt";
        }
       
    }
       
        
}
