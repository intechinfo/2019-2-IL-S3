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
        Classroom _assignment;

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
            get { return _assignment; }
        }

        public void AssignTo( Classroom c )
        {
            if( c != null && _context != c.School ) throw new ArgumentException( "The teacher and the classroom doesn't belong to the same school.", nameof( c ) );
            if( _assignment != null ) _assignment.OnAssignTo( null );

            _assignment = c;
            if( c != null ) c.OnAssignTo( this );
        }
    }
}
