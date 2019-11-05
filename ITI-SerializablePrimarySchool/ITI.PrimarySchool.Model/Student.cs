using System.IO;
using Newtonsoft.Json.Linq;

namespace ITI.PrimarySchool.Model
{
    public class Student
    {
        readonly School _ctx;
        readonly string _firstName;
        readonly string _lastName;

        internal Student(School ctx, string firstName, string lastName)
        {
            _ctx = ctx;
            _firstName = firstName;
            _lastName = lastName;
        }

        internal Student(School ctx, BinaryReader reader)
        {
            _ctx = ctx;
            _lastName = reader.ReadString();
            _firstName = reader.ReadString();
        }

        public School School
        {
            get { return _ctx; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        internal void Save(BinaryWriter writer)
        {
            writer.Write(_lastName);
            writer.Write(_firstName);
        }

        internal JToken Save()
        {
            return new JObject(
                new JProperty("firstName", _firstName),
                new JProperty("lastName", _lastName));
        }
    }
}
