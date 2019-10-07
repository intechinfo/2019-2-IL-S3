using System;
using NUnit.Framework;

namespace ITI.Genealogy.Tests
{
    [TestFixture]
    public class T2ChildOptionsTests
    {
        [Test]
        public void t1_constructor_with_null_or_whitespace_firstName_throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>( () => new ChildOptions( null, new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => new ChildOptions( string.Empty, new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => new ChildOptions( "  ", new DateTime(), false ) );
        }

        [Test]
        public void t2_constructor2_with_null_or_whitespace_firstName_throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>( () => new ChildOptions( null, new DateTime(), false, false ) );
            Assert.Throws<ArgumentException>( () => new ChildOptions( string.Empty, new DateTime(), false, false ) );
            Assert.Throws<ArgumentException>( () => new ChildOptions( "  ", new DateTime(), false, false ) );
        }

        [Test]
        public void t3_constructor3_with_null_or_whitespace_firstName_throws_ArgumentException()
        {
            DateTime birthDate = new DateTime(2000, 3, 7);
            DateTime deathDate = new DateTime(2001, 1, 25);
            Assert.Throws<ArgumentException>( () => new ChildOptions( null, birthDate, false, deathDate ) );
            Assert.Throws<ArgumentException>( () => new ChildOptions( string.Empty, birthDate, false, deathDate ) );
            Assert.Throws<ArgumentException>( () => new ChildOptions( "  ", birthDate, false, deathDate ) );
        }

        [Test]
        public void t4_constructor_with_death_before_birth_throws_ArgumentException()
        {
            DateTime birthDate = new DateTime( 2001, 1, 25 );
            DateTime deathDate = new DateTime( 2001, 1, 24 );

            Assert.Throws<ArgumentException>( () => new ChildOptions( "name", birthDate, false, deathDate ) );
        }
    }
}
