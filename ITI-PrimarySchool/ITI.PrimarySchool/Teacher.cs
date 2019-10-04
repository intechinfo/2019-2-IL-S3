using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.PrimarySchool
{
    public class Teacher
    {
        readonly School _context;
        readonly string _name;

        internal Teacher(School context, string name)
        {
            _context = context;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public School School { get { return _context; } }
        
        public Classroom Assignment
        {
            get { throw new ArgumentException(); }
        }

        public void AssignTo( Classroom c )
        {
            throw new ArgumentException();
        }
    }
}
