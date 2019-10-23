using System;
using System.Windows.Forms;

namespace ITI.ToDoList.GUI
{
    public partial class MainForm : Form
    {
        readonly Model.ToDoList _model;

        public MainForm()
        {
            _model = new Model.ToDoList();
            InitializeComponent();
        }

        void onTaskCreated(object sender, EventArgs e)
        {
            TaskCreatedEventArgs taskCreatedEventArgs = e as TaskCreatedEventArgs;
            if (taskCreatedEventArgs == null) return;

            _model.CreateTask(taskCreatedEventArgs.Title, taskCreatedEventArgs.Description);
        }
    }
}
