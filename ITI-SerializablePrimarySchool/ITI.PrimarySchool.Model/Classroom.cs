using System.IO;
using Newtonsoft.Json.Linq;

namespace ITI.PrimarySchool.Model
{
    public class Classroom
    {
        readonly School _ctx;
        readonly string _name;
        int _maxStudentCount;

        internal Classroom(School ctx, string name)
        {
            _ctx = ctx;
            _name = name;
            _maxStudentCount = 20;
        }

        internal Classroom(School ctx, BinaryReader reader)
        {
            _ctx = ctx;
            _name = reader.ReadString();
            _maxStudentCount = reader.ReadInt32();
        }

        internal Classroom(School ctx, JToken json)
        {
            _ctx = ctx;
            _name = json.Value<string>("name");
            _maxStudentCount = json.Value<int>("maxStudentCount");
        }

        public School School
        {
            get { return _ctx; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int MaxStudentCount
        {
            get { return _maxStudentCount; }
            set { _maxStudentCount = value; }
        }

        internal void Save(BinaryWriter writer)
        {
            writer.Write(_name);
            writer.Write(_maxStudentCount);
        }

        internal JToken Save()
        {
            return new JObject(
                new JProperty("name", _name),
                new JProperty("maxStudentCount", _maxStudentCount));
        }
    }
}
