using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FirstProjectXamarin.Models
{
   public class Constants
    {
        public static bool IsDev = true;

        public static Color BackgroundColor = Color.Blue;
        public static Color MainTextColor = Color.White;

        public static int LoginIconHeight = 120;


        //-----Login---------------
        public static string LoginUrl = "https://test.com/api/Auth/Login";
        public static string NoInternetText = "No Internet, Please reconnect.";
  
    }
}
