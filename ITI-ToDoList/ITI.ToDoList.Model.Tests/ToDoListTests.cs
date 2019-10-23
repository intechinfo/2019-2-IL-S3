using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ITI.ToDoList.Model.Tests
{
    [TestFixture]
    public class ToDoListTests
    {
        [Test]
        public void create_some_tasks()
        {
            ToDoList sut = new ToDoList();
            Task t1 = sut.CreateTask("Title-1", "Description-1");
            Task t2 = sut.CreateTask("Title-2", "Description-2");

            IEnumerable<Task> tasks = sut.AllTasks;

            Assert.That(t1.Context, Is.SameAs(sut));
            Assert.That(t1.Title, Is.EqualTo("Title-1"));
            Assert.That(t1.Description, Is.EqualTo("Description-1"));

            Assert.That(t2.Context, Is.SameAs(sut));
            Assert.That(t2.Title, Is.EqualTo("Title-2"));
            Assert.That(t2.Description, Is.EqualTo("Description-2"));

            Assert.That(tasks.Count(), Is.EqualTo(2));
            Assert.That(tasks.Contains(t1), Is.True);
            Assert.That(tasks.Contains(t2), Is.True);
        }
    }
}
