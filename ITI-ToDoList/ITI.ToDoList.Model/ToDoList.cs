using System.Collections.Generic;

namespace ITI.ToDoList.Model
{
    public class ToDoList
    {
        readonly List<Task> _tasks;

        public ToDoList()
        {
            _tasks = new List<Task>();
        }

        public Task CreateTask(string title, string description)
        {
            Task task = new Task(this, title, description);
            _tasks.Add(task);
            return task;
        }

        public IEnumerable<Task> AllTasks
        {
            get { return _tasks; }
        }
    }
}
