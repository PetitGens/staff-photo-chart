using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoChartApp
{
    internal class ErrorAlert
    {
        private string message; 
        private string title;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public ErrorAlert()
        {
            message = "";
            title = "Erreur";
        }

        public ErrorAlert(string message, string title) {
            this.message = message;
            this.title = title;
        }

        public void Show()
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(message, title, button, icon);
        }
    }
}
