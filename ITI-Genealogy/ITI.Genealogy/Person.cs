using System;

namespace ITI.Genealogy
{
    public class Person
    {
        readonly string _firstName;
        readonly string _lastName;
        readonly DateTime _birthDate;
        readonly bool _isFemale;
        bool _isDead;
        readonly Person _father;
        readonly Person _mother;

        internal Person( string firstName, string lastName, DateTime birthDate, bool isFemale, DateTime deathDate )
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
            _isFemale = isFemale;
            _isDead = deathDate != DateTime.MinValue;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
        }

        public bool IsFemale
        {
            get { return _isFemale; }
        }

        public Person Father
        {
            get { return _father; }
        }

        public Person Mother
        {
            get { return _mother; }
        }

        public bool IsDead
        {
            get { return _isDead; }
        }

        public DateTime DeathDate
        {
            get { throw new NotImplementedException(); }
        }
    }
}
