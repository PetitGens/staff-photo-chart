using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoChartApp
{
    internal class ConfirmationDialog : Dialog
    {
        public ConfirmationDialog() : base("", "Confirmation") {}

        public ConfirmationDialog(string message, string title) : base(message, title) {}

        public override MessageBoxResult Show()
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Exclamation;
            return MessageBox.Show(Message, Title, button, icon);
        }
    }
}
