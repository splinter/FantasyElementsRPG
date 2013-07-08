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

namespace FantasyElementsRPG.Client.Core.ExceptionFactory
{
    public static class ExceptionFactory
    {
        private static UserControl control;

       

        public static void HandleException(Exception e)
        { 
            
        }

        public static void SetExceptionUSerControl(UserControl ExceptionControl)
        { 
            control = ExceptionControl.Parent as UserControl;
        }

        public static void HandleFatalException(Exception e)
        {

            control.Opacity = 100;
            control.IsEnabled = false;

            //close the window
            System.Windows.Browser.HtmlPage.Window.Invoke("close");


        }
    }
}
