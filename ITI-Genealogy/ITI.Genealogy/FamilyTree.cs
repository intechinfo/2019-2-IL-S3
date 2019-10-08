using System;
using System.Collections.Generic;

namespace ITI.Genealogy
{
    public class FamilyTree
    {
        readonly Dictionary<string, Person> _people;

        public FamilyTree()
        {
            _people = new Dictionary<string, Person>();
        }

        public Person this[string firstName, string lastName]
        {
            get
            {
                _people.TryGetValue( GetFullName( firstName, lastName ), out Person person );
                return person;
            }
        }

        public Person CreateAncestor( string firstName, string lastName, DateTime dateTime, bool isFemale )
        {
            return CreateAncestor( firstName, lastName, dateTime, isFemale, DateTime.MinValue );
        }

        public Person CreateAncestor( string firstName, string lastName, DateTime dateTime, bool isFemale, DateTime deathDate )
        {
            if( string.IsNullOrWhiteSpace( firstName ) ) throw new ArgumentException( "The first name must be not null nor whitespace.", nameof( firstName ) );
            if( string.IsNullOrWhiteSpace( lastName ) ) throw new ArgumentException( "The last name must be not null nor whitespace.", nameof( lastName ) );
            if( _people.ContainsKey( GetFullName( firstName, lastName ) ) ) throw new ArgumentException( "A person with this name already exists." );

            Person person = new Person( firstName, lastName, dateTime, isFemale, deathDate, null, null );
            string fullName = GetFullName( firstName, lastName );
            _people.Add( fullName, person );
            return person;
        }

        public Person Breed( Person firstParent, Person secondParent, ChildOptions childOptions )
        {
            if( firstParent == null ) throw new ArgumentNullException( nameof( firstParent ) );
            if( secondParent == null ) throw new ArgumentNullException( nameof( secondParent ) );
            if( childOptions == null ) throw new ArgumentNullException( nameof( childOptions ) );

            if( firstParent.IsFemale && secondParent.IsFemale ) throw new ArgumentException( "One parent must be the father." );
            if( !firstParent.IsFemale && !secondParent.IsFemale ) throw new ArgumentException( "One parent must be the mother." );
            if( childOptions.BirthDate < firstParent.BirthDate || childOptions.BirthDate < secondParent.BirthDate ) throw new ArgumentException( "The parents must be older than the child." );
            if( firstParent.IsDead && firstParent.DeathDate < childOptions.BirthDate ) throw new ArgumentException( "The first parent is already dead." );
            if( secondParent.IsDead && secondParent.DeathDate < childOptions.BirthDate ) throw new ArgumentException( "The second parent is already dead." );

            Person father = firstParent.IsFemale ? secondParent : firstParent;
            Person mother = firstParent.IsFemale ? firstParent : secondParent;
            Person person = new Person( childOptions.FirstName, father.LastName, childOptions.BirthDate, childOptions.IsFemale, DateTime.MinValue, father, mother );
            string fullName = GetFullName( person.FirstName, person.LastName );

            if( _people.ContainsKey( fullName ) ) throw new ArgumentException( "A person with this name already exists." );

            _people.Add( fullName, person );
            return person;
        }

        public void PassAway( Person person, DateTime dateTime )
        {
            throw new NotImplementedException();
        }

        public bool Exist( string firstName, string lastName )
        {
            throw new NotImplementedException();
        }

        string GetFullName( string firstName, string lastName )
        {
            return string.Format( "{0}@{1}", firstName, lastName );
        }
    }
}
