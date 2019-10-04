using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.PrimarySchool
{
    public class Classroom
    {
        readonly School _context;
        readonly string _name;
        readonly Dictionary<string, Pupil> _pupils;

        internal Classroom(School context, string name)
        {
            _context = context;
            _name = name;
            _pupils = new Dictionary<string, Pupil>();
        }

        public string Name
        {
            get { return _name; }
            set { throw new NotImplementedException(); }
        }


        public Pupil AddPupil( string firstName, string lastName )
        {
            if( firstName == null || firstName.Length < 2 ) throw new ArgumentException( "The first name must be longer than 2 characters.", nameof( firstName ) );
            if( lastName == null || lastName.Length < 2 ) throw new ArgumentException( "The last name must be longer than 2 characters.", nameof( lastName ) );

            string name = string.Format( "{0}#{1}", firstName, lastName );
            if( _pupils.ContainsKey( name ) ) throw new ArgumentException( "A pupil with this first name and this last name already exists." );

            Pupil pupil = new Pupil( this, firstName, lastName );
            _pupils.Add( name, pupil );
            return pupil;
        }

        public Pupil FindPupil( string firstName, string lastName )
        {
            throw new NotImplementedException();
        }

        public School School { get { return _context; } }

        public Teacher Teacher
        {
            get { throw new NotImplementedException(); }
        }

    }
}
