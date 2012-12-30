using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace xcControlPoint.Auth
{
    public class CredentialsAndURL
    {
        // SharePoint forms UserName
        public static string USER_NAME = "User1";

        // SharePoint forms Password
        public static string USER_PASSWORD = "Pass@word1";

        // SharePoint path to authentication.asmx
        public static string AUTHENTICATION_SERVICE_URL = "http://ketansp2010:3434/_vti_bin/authentication.asmx";

        // SharePoint path to the Form Auth secured site
        public static string LIST_WEB_URL = "http://ketansp2010:3434/";
    }
}
