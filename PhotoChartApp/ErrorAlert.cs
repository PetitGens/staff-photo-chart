using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoChartApp
{
    /// <summary>
    /// A basic alert window to display errors.
    /// </summary>
    internal class ErrorAlert : Dialog
    {
        /// <summary>
        /// Creates an alert with no text and default caption.
        /// Does not show it (you must call the Show method).
        /// </summary>
        public ErrorAlert() : base("", "Erreur") {}

        /// <summary>
        /// Creates an alert with the given parameters.
        /// Does not show it (you must call the Show method).
        /// </summary>
        /// <param name="message">the text displayed in the alert</param>
        /// <param name="title">the caption of the alert window</param>
        public ErrorAlert(string message, string title) : base(message, title){}

        public override MessageBoxResult Show()
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            return MessageBox.Show(Message, Title, button, icon);
        }
    }
}
