using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.PrimarySchool
{
    public class Pupil
    {
        readonly Classroom _context;
        readonly string _firstName;
        readonly string _lastName;

        internal Pupil(Classroom context, string firstName, string lastName)
        {
            _context = context;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public Classroom Classroom 
        { 
            get { return _context; } 
        }

    }
}
