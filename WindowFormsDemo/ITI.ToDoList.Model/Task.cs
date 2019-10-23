namespace ITI.ToDoList.Model
{
    public class Task
    {
        ToDoList _ctx;
        string _title; 
        string _description;

        internal Task(ToDoList ctx, string title, string description)
        {
            _ctx = ctx;
            _title = title;
            _description = description;
        }

        public ToDoList Context
        {
            get { return _ctx; }
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
