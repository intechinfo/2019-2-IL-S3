using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ITI.PrimarySchool.Model
{
    public class School
    {
        readonly string _name;
        readonly Dictionary<string, Classroom> _classrooms;
        readonly Dictionary<string, Student> _students;

        public School(string name)
        {
            _name = name;
            _classrooms = new Dictionary<string, Classroom>();
            _students = new Dictionary<string, Student>();
        }

        public School(BinaryReader reader)
        {
            _classrooms = new Dictionary<string, Classroom>();
            _students = new Dictionary<string, Student>();

            _name = reader.ReadString();
            int classroomCount = reader.ReadInt32();
            for(int i = 0; i < classroomCount; i++)
            {
                Classroom c = new Classroom(this, reader);
                _classrooms.Add(c.Name, c);
            }

            int studentCount = reader.ReadInt32();
            for(int i = 0; i < studentCount; i++)
            {
                Student s = new Student(this, reader);
                _students.Add(s.LastName, s);
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(_name);
            writer.Write(_classrooms.Count);
            foreach (Classroom c in _classrooms.Values) c.Save(writer);

            writer.Write(_students.Count);
            foreach (Student s in _students.Values) s.Save(writer); 
        }

        public Classroom FindOrCreate(string name)
        {
            Classroom classroom;
            if (!_classrooms.TryGetValue(name, out classroom))
            {
                classroom = new Classroom(this, name);
                _classrooms.Add(name, classroom);
            }

            return classroom;
        }

        public Student CreateStudent(string firstName, string lastName)
        {
            Student student = new Student(this, firstName, lastName);
            _students.Add(lastName, student);
            return student;
        }

        public Student FindStudent(string lastName)
        {
            _students.TryGetValue(lastName, out Student student);
            return student;
        }

        public JToken Save()
        {
            return new JObject(
                new JProperty("name", _name),
                new JProperty("classrooms", _classrooms.Values.Select(c => c.Save())),
                new JProperty("students", _students.Values.Select(s => s.Save())));
        }
    }
}
