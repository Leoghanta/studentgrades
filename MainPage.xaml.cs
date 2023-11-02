using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace studentgrades
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<student> students = new ObservableCollection<student>();


        public MainPage()
        {
            this.InitializeComponent();
            AddStudents();
        }

        /// <summary>
        /// Add a list of students as test data
        /// </summary>
        private void AddStudents()
        {
            students.Add(new student("Fred Jones", 72));
            students.Add(new student("Daphne Blake", 68));
            students.Add(new student("Velma Dinkley", 89));
            students.Add(new student("Shaggy Rogers", 55));
            students.Add(new student("Scoobert Doo", 59));
        }

        /// <summary>
        /// Display a message to the user.
        /// </summary>
        /// <param name="message">Message being sent</param>
        /// <param name="title">A nice title</param>
        private async void DisplayMessage(string message, string title)
        {
            MessageDialog msg = new MessageDialog(message, title);
            await msg.ShowAsync();
        }

        /// <summary>
        /// Event Handler when user clicks Add button
        /// </summary>
        /// <param name="sender">Button being clicked</param>
        /// <param name="e">Any parameters (there is none!)</param>
		private void Add_Click(object sender, RoutedEventArgs e)
		{
            // Nothing in the student name? Send them an error!
            if (string.IsNullOrEmpty(studentNameTextBox.Text))
            {
                DisplayMessage("Student name can not be empty!", "Error");
                return;
            }

            // Nothing in the marks? send them an error!
            if (string.IsNullOrEmpty (marksTextBox.Text))
            {
                DisplayMessage("Marks can not be empty!", "Error");
                
            }

            // New Student may throw an exception. int.Parse may also throw an exception
            // encase in try..catch clause
            try
            {
                //try and add the students.
                students.Add(new student(studentNameTextBox.Text, int.Parse(marksTextBox.Text)));
                studentNameTextBox.Text = string.Empty; // clear the text box
                marksTextBox.Text = string.Empty;       // clear the text box
            } 
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, "Error");
            }

		}
	}
}
