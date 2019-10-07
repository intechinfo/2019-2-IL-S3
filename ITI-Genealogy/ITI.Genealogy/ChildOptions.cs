using System;

namespace ITI.Genealogy
{
    public class ChildOptions
    {
        readonly string _firstName;
        readonly DateTime _birthDate;
        readonly bool _isFemale;

        public ChildOptions( string firstName, DateTime birthDate, bool isFemale )
        {
            _firstName = firstName;
            _birthDate = birthDate;
            _isFemale = isFemale;
        }

        public ChildOptions( string firstName, DateTime birthDate, bool isFemale, bool isDead )
        {
            throw new NotImplementedException();
        }

        public ChildOptions( string firstName, DateTime birthDate, bool isFemale, DateTime deathDate )
        {
            throw new NotImplementedException();
        }

        internal string FirstName
        {
            get { return _firstName; }
        }

        internal DateTime BirthDate
        {
            get { return _birthDate; }
        }

        internal bool IsFemale
        {
            get { return _isFemale; }
        }
    }
}
