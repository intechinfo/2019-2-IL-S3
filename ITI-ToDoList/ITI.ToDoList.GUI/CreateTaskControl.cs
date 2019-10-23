using System;
using System.Windows.Forms;

namespace ITI.ToDoList.GUI
{
    public partial class CreateTaskControl : UserControl
    {
        public CreateTaskControl()
        {
            InitializeComponent();
        }

        void newButton_onClicked(object sender, EventArgs e)
        {
            TaskCreated(this, new TaskCreatedEventArgs(titleTextBox.Text, descriptionTextBox.Text));
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
        }

        public event EventHandler TaskCreated;
    }

    public class TaskCreatedEventArgs : EventArgs
    {
        string _title;
        string _description;

        public TaskCreatedEventArgs(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public string Title
        {
            get { return _title; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}
