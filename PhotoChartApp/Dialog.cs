using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoChartApp
{
    internal abstract class Dialog
    {
        private string message;
        private string title;

        /// <summary>
        /// The text displayed in the alert.
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// The caption of the alert window.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Creates an alert with the given parameters.
        /// Does not show it (you must call the Show method).
        /// </summary>
        /// <param name="message">the text displayed in the alert</param>
        /// <param name="title">the caption of the alert window</param>
        public Dialog(string message, string title)
        {
            this.message = message;
            this.title = title;
        }

        /// <summary>
        /// Shows the alert window with the current parameters.
        /// </summary>
        public abstract MessageBoxResult Show();
    }
}
