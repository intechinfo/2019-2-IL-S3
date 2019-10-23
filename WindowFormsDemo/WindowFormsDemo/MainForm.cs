using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITI.ToDoList.Model;

namespace WindowFormsDemo
{
    public partial class MainForm : Form
    {
        readonly ToDoList _model;

        public MainForm()
        {
            _model = new ToDoList();
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
