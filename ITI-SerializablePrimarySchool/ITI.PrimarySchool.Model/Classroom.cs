using System.IO;

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
    }
}
