using System;

namespace ITI.Genealogy
{
    public class FamilyTree
    {
        public Person this[string firstName, string lastName]
        {
            get { throw new NotImplementedException(); }
        }

        public Person CreateAncestor( string firstName, string lastName, DateTime dateTime, bool isFemale )
        {
            return CreateAncestor( firstName, lastName, dateTime, isFemale, DateTime.MinValue );
        }

        public Person CreateAncestor( string firstName, string lastName, DateTime dateTime, bool isFemale, DateTime deathDate )
        {
            if( string.IsNullOrWhiteSpace( firstName ) ) throw new ArgumentException( "The first name must be not null nor whitespace.", nameof( firstName ) );
            if( string.IsNullOrWhiteSpace( lastName ) ) throw new ArgumentException( "The last name must be not null nor whitespace.", nameof( lastName ) );

            return new Person( firstName, lastName, dateTime, isFemale, deathDate, null, null );
        }

        public Person Breed( Person firstParent, Person secondParent, ChildOptions childOptions )
        {
            return new Person( childOptions.FirstName, firstParent.LastName, childOptions.BirthDate, childOptions.IsFemale, DateTime.MinValue, firstParent, secondParent );
        }

        public void PassAway( Person person, DateTime dateTime )
        {
            throw new NotImplementedException();
        }

        public bool Exist( string firstName, string lastName )
        {
            throw new NotImplementedException();
        }
    }
}
