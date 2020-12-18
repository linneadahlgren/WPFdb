using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFdb
{
    public static class UniversalFunctions
    {
        public static void setUpWindow(Window windowToSetUp)
        {
            windowToSetUp.Top = 200;
            windowToSetUp.Left = 200;
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = windowToSetUp.Width;
            double windowHeight = windowToSetUp.Height;
            windowToSetUp.Left = (screenWidth / 2) - (windowWidth / 2);
            windowToSetUp.Top = (screenHeight / 2) - (windowHeight / 2);
        }
  /*      public static void setWindowPosition(Window window)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }
*/
    }
}
