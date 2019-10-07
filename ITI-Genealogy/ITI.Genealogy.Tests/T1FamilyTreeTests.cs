using System;
using NUnit.Framework;

namespace ITI.Genealogy.Tests
{
    [TestFixture]
    public class T1FamilyTreeTests
    {
        [Test]
        public void t01_createAncestor_creates_a_person_correctly()
        {
            FamilyTree sut = new FamilyTree();

            Person person = sut.CreateAncestor( "Jean", "Dupuis", new DateTime( 1921, 10, 19 ), false );

            Assert.That( person.FirstName, Is.EqualTo( "Jean" ) );
            Assert.That( person.LastName, Is.EqualTo( "Dupuis" ) );
            Assert.That( person.BirthDate, Is.EqualTo( new DateTime( 1921, 10, 19 ) ) );
            Assert.That( person.IsFemale, Is.False );
            Assert.That( person.IsDead, Is.False );
        }

        [Test]
        public void t02_createAncestor_with_a_death_date_creates_a_dead_person()
        {
            FamilyTree sut = new FamilyTree();
            Person person = sut.CreateAncestor( "Jean", "Dupuis", new DateTime( 1921, 10, 19 ), false, new DateTime( 2000, 1, 25 ) );
            Assert.That( person.IsDead, Is.True );
        }

        [Test]
        public void t03_createAncestor_creates_an_ancestor()
        {
            FamilyTree sut = new FamilyTree();

            Person person = sut.CreateAncestor( "Annabelle", "Petit", new DateTime( 1911, 2, 20 ), true );

            Assert.That( person.Father, Is.Null );
            Assert.That( person.Mother, Is.Null );
        }

        [Test]
        public void t04_createAncestor_with_null_or_whitespace_firstName_or_lastName_throws_ArgumentException()
        {
            FamilyTree sut = new FamilyTree();

            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( null, "not null", new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( string.Empty, "not null", new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( "  ", "not null", new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( "not null", null, new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( "not null", string.Empty, new DateTime(), false ) );
            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( "not null", "   ", new DateTime(), false ) );
        }

        [Test]
        public void t05_breed_creates_child_correctly()
        {
            FamilyTree sut = new FamilyTree();
            Person louis = sut.CreateAncestor( "Louis", "Martin", new DateTime( 1936, 5, 14 ), false );
            Person jacqueline = sut.CreateAncestor( "Jacqueline", "Sanson", new DateTime( 1938, 11, 2 ), true );
            ChildOptions childOptions = new ChildOptions( "Helene", new DateTime( 1961, 3, 24 ), true );

            Person child = sut.Breed( louis, jacqueline, childOptions );

            Assert.That( child.Father, Is.SameAs( louis ) );
            Assert.That( child.Mother, Is.SameAs( jacqueline ) );
            Assert.That( child.FirstName, Is.EqualTo( "Helene" ) );
            Assert.That( child.LastName, Is.EqualTo( "Martin" ) );
            Assert.That( child.BirthDate, Is.EqualTo( new DateTime( 1961, 3, 24 ) ) );
            Assert.That( child.IsFemale, Is.True );
            Assert.That( child.IsDead, Is.False );
        }

        [Test]
        public void t06_breed_when_mother_is_first_parent_creates_child_correctly()
        {
            FamilyTree sut = new FamilyTree();
            Person louis = sut.CreateAncestor( "Louis", "Martin", new DateTime( 1936, 5, 14 ), false );
            Person jacqueline = sut.CreateAncestor( "Jacqueline", "Sanson", new DateTime( 1938, 11, 2 ), true );
            ChildOptions childOptions = new ChildOptions( "Helene", new DateTime( 1961, 3, 24 ), true );

            Person child = sut.Breed( jacqueline, louis, childOptions );

            Assert.That( child.Father, Is.SameAs( louis ) );
            Assert.That( child.Mother, Is.SameAs( jacqueline ) );
            Assert.That( child.FirstName, Is.EqualTo( "Helene" ) );
            Assert.That( child.LastName, Is.EqualTo( "Martin" ) );
            Assert.That( child.BirthDate, Is.EqualTo( new DateTime( 1961, 3, 24 ) ) );
            Assert.That( child.IsFemale, Is.True );
            Assert.That( child.IsDead, Is.False );
        }

        [Test]
        public void t07_breed_with_two_mothers_throws_ArgumentException()
        {
            FamilyTree sut = new FamilyTree();
            Person martine = sut.CreateAncestor( "Martine", "Martin", new DateTime( 1936, 5, 14 ), true );
            Person jacqueline = sut.CreateAncestor( "Jacqueline", "Sanson", new DateTime( 1938, 11, 2 ), true );
            ChildOptions childOptions = new ChildOptions( "Helene", new DateTime( 1961, 3, 24 ), true );

            Assert.Throws<ArgumentException>( () => sut.Breed( martine, jacqueline, childOptions ) );
        }

        [Test]
        public void t08_breed_with_two_fathers_throws_ArgumentException()
        {
            FamilyTree sut = new FamilyTree();
            Person jacques = sut.CreateAncestor( "Jacques", "Martin", new DateTime( 1936, 5, 14 ), false );
            Person louis = sut.CreateAncestor( "Louis", "Sanson", new DateTime( 1938, 11, 2 ), false );
            ChildOptions childOptions = new ChildOptions( "Helene", new DateTime( 1961, 3, 24 ), true );

            Assert.Throws<ArgumentException>( () => sut.Breed( jacques, louis, childOptions ) );
        }

        [Test]
        public void t09_breed_with_null_argument_throws_ArgumentNullException()
        {
            FamilyTree sut = new FamilyTree();
            Person father = sut.CreateAncestor( "father", "name", new DateTime( 1936, 5, 14 ), false );
            Person mother = sut.CreateAncestor( "mother", "other name", new DateTime( 1937, 6, 15 ), true );
            ChildOptions childOptions = new ChildOptions( "child", new DateTime( 1963, 7, 16 ), false );

            Assert.Throws<ArgumentNullException>( () => sut.Breed( null, mother, childOptions ) );
            Assert.Throws<ArgumentNullException>( () => sut.Breed( father, null, childOptions ) );
            Assert.Throws<ArgumentNullException>( () => sut.Breed( father, mother, null ) );
        }

        [Test]
        public void t10_breed_with_child_older_than_his_parents_throws_ArgumentException()
        {
            FamilyTree sut = new FamilyTree();
            Person father = sut.CreateAncestor( "father", "name", new DateTime( 1936, 5, 14 ), false );
            Person mother = sut.CreateAncestor( "mother", "other name", new DateTime( 1937, 6, 15 ), true );
            ChildOptions olderThanMother = new ChildOptions( "child", new DateTime( 1937, 5, 1 ), false );
            ChildOptions olderThanBothParents = new ChildOptions( "other child", new DateTime( 1935, 5, 1 ), false );

            Assert.Throws<ArgumentException>( () => sut.Breed( father, mother, olderThanMother ) );
            Assert.Throws<ArgumentException>( () => sut.Breed( mother, father, olderThanMother ) );
            Assert.Throws<ArgumentException>( () => sut.Breed( father, mother, olderThanBothParents ) );
            Assert.Throws<ArgumentException>( () => sut.Breed( mother, father, olderThanBothParents ) );
        }

        [Test]
        public void t11_breed_with_dead_father_throws_ArgumentException()
        {
            FamilyTree sut = new FamilyTree();
            Person father = sut.CreateAncestor( "father", "name", new DateTime( 1936, 5, 14 ), false, new DateTime( 1980, 10, 15 ) );
            Person mother = sut.CreateAncestor( "mother", "other name", new DateTime( 1937, 6, 15 ), true );
            ChildOptions bornToLateChild = new ChildOptions( "child", new DateTime( 1981, 5, 1 ), false );

            Assert.Throws<ArgumentException>( () => sut.Breed( father, mother, bornToLateChild ) );
            Assert.Throws<ArgumentException>( () => sut.Breed( mother, father, bornToLateChild ) );
        }

        [Test]
        public void t12_createAncestor_with_existing_person_throws_ArgumentException()
        {
            FamilyTree sut = CreateTestFamilyTree();

            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( "Isabelle", "Martin", new DateTime( 1950, 7, 15 ), true ) );
            Assert.Throws<ArgumentException>( () => sut.CreateAncestor( "Marianne", "Rousaud", new DateTime( 1938, 6, 14 ), true ) );
        }

        [Test]
        public void t13_breed_with_an_existing_person_throws_ArgumentException()
        {
            FamilyTree sut = CreateTestFamilyTree();
            sut.CreateAncestor( "Albert", "Martin", new DateTime( 1930, 1, 2 ), false );
            Person louis = sut[ "Louis", "Martin" ];
            Person jacqueline = sut[ "Jacqueline", "Sanson" ];
            ChildOptions albertOptions = new ChildOptions( "Albert", new DateTime( 1967, 5, 12 ), false );

            Assert.Throws<ArgumentException>( () => sut.Breed( louis, jacqueline, albertOptions ) );
            Assert.Throws<ArgumentException>( () => sut.Breed( jacqueline, louis, albertOptions ) );
        }

        [Test]
        public void t14_breed_with_dead_child_creates_a_dead_Person()
        {
            FamilyTree sut = new FamilyTree();
            Person louis = sut.CreateAncestor( "Louis", "Martin", new DateTime( 1936, 5, 14 ), false );
            Person jacqueline = sut.CreateAncestor( "Jacqueline", "Sanson", new DateTime( 1938, 11, 2 ), true );
            ChildOptions childOptions = new ChildOptions( "Helene", new DateTime( 1961, 3, 24 ), true, true );

            Person child = sut.Breed( louis, jacqueline, childOptions );

            Assert.That( child.IsDead, Is.True );
            Assert.That( child.DeathDate, Is.EqualTo( child.BirthDate ) );
        }

        [Test]
        public void t15_breed_with_child_dead_after_some_days_creates_a_dead_Person()
        {
            FamilyTree sut = new FamilyTree();
            Person louis = sut.CreateAncestor( "Louis", "Martin", new DateTime( 1936, 5, 14 ), false );
            Person jacqueline = sut.CreateAncestor( "Jacqueline", "Sanson", new DateTime( 1938, 11, 2 ), true );
            ChildOptions childOptions = new ChildOptions( "Helene", new DateTime( 1961, 3, 24 ), true, new DateTime( 1961, 4, 10 ) );

            Person child = sut.Breed( louis, jacqueline, childOptions );

            Assert.That( child.IsDead, Is.True );
            Assert.That( child.DeathDate, Is.EqualTo( new DateTime( 1961, 4, 10 ) ) );
        }

        [Test]
        public void t16_indexer_returns_the_right_Person()
        {
            FamilyTree sut = CreateTestFamilyTree();
            Person daniel = sut[ "Daniel", "Savi" ];
            Person marianne = sut[ "Marianne", "Rousaud" ];
            ChildOptions marcOptions = new ChildOptions( "Marc", new DateTime( 1986, 12, 20 ), false );
            Person marc = sut.Breed( daniel, marianne, marcOptions );

            Person result = sut[ "Marc", "Savi" ];

            Assert.That( result, Is.SameAs( marc ) );
        }

        [Test]
        public void t17_indexer_with_null_or_whitespace_argument_throws_ArgumentException()
        {
            FamilyTree sut = new FamilyTree();

            Assert.Throws<ArgumentException>( () => { Person p = sut[ null, "not null nor whitespace" ]; } );
            Assert.Throws<ArgumentException>( () => { Person p = sut[ string.Empty, "not null nor whitespace" ]; } );
            Assert.Throws<ArgumentException>( () => { Person p = sut[ " ", "not null nor whitespace" ]; } );
            Assert.Throws<ArgumentException>( () => { Person p = sut[ "not null nor whitespace", null ]; } );
            Assert.Throws<ArgumentException>( () => { Person p = sut[ "not null nor whitespace", string.Empty ]; } );
            Assert.Throws<ArgumentException>( () => { Person p = sut[ "not null nor whitespace", "   " ]; } );
        }

        [Test]
        public void t18_passAway_should_kill_the_Person()
        {
            FamilyTree sut = new FamilyTree();
            Person person = sut.CreateAncestor( "Jean", "Morin", new DateTime( 1922, 11, 14 ), false );

            sut.PassAway( person, new DateTime( 2005, 3, 2 ) );

            Assert.That( person.IsDead, Is.True );
        }

        [Test]
        public void t19_passAway_with_null_person_throws_ArgumentNullException()
        {
            FamilyTree sut = new FamilyTree();
            Assert.Throws<ArgumentNullException>( () => sut.PassAway( null, new DateTime( 2005, 3, 2 ) ) );
        }

        [Test]
        public void t20_passAway_before_birth_throws_InvalidOperationException()
        {
            FamilyTree sut = new FamilyTree();
            Person person = sut.CreateAncestor( "Jean", "Morin", new DateTime( 1922, 11, 14 ), false );

            Assert.Throws<InvalidOperationException>( () => sut.PassAway( person, new DateTime( 1922, 11, 13 ) ) );
        }

        [Test]
        public void t21_passAway_before_child_birth_throws_InvalidOperationException()
        {
            FamilyTree sut = CreateTestFamilyTree();
            Person louis = sut[ "Louis", "Martin" ];

            Assert.Throws<InvalidOperationException>( () => sut.PassAway( louis, new DateTime( 1965, 1, 1 ) ) );
        }

        [Test]
        public void t22_exist_with_existing_person_returns_true()
        {
            FamilyTree sut = CreateTestFamilyTree();
            bool exist = sut.Exist( "Isabelle", "Martin" );
            Assert.That( exist, Is.True );
        }

        [Test]
        public void t23_exist_with_not_existing_person_returns_false()
        {
            FamilyTree sut = CreateTestFamilyTree();
            bool exist = sut.Exist( "Claire", "Martin" );
            Assert.That( exist, Is.False );
        }

        private FamilyTree CreateTestFamilyTree()
        {
            FamilyTree familyTree = new FamilyTree();

            // Adds ancestors
            Person louis = familyTree.CreateAncestor( "Louis", "Martin", new DateTime( 1936, 5, 14 ), false );
            Person jacqueline = familyTree.CreateAncestor( "Jacqueline", "Sanson", new DateTime( 1938, 11, 2 ), true );
            Person daniel = familyTree.CreateAncestor( "Daniel", "Savi", new DateTime( 1951, 8, 4 ), false );
            Person marianne = familyTree.CreateAncestor( "Marianne", "Rousaud", new DateTime( 1960, 12, 13 ), true );

            // Adds childs
            ChildOptions renaudChildOptions = new ChildOptions( "Renaud", new DateTime( 1964, 4, 28 ), false );
            Person renaud = familyTree.Breed( louis, jacqueline, renaudChildOptions );
            ChildOptions isabelleChildOptions = new ChildOptions( "Isabelle", new DateTime( 1966, 5, 15 ), true );
            Person isabelle = familyTree.Breed( louis, jacqueline, isabelleChildOptions );
            ChildOptions christianeChildOptions = new ChildOptions( "Christiane", new DateTime( 1985, 9, 1 ), true );
            Person christiane = familyTree.Breed( daniel, marianne, christianeChildOptions );

            return familyTree;
        }
    }
}
