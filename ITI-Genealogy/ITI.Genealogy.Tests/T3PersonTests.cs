using System;
using NUnit.Framework;

namespace ITI.Genealogy.Tests
{
    [TestFixture]
    public class T3PersonTests
    {
        [Test]
        public void t1_deathDate_when_not_dead_throws_InvalidOperationException()
        {
            FamilyTree familyTree = new FamilyTree();
            Person sut = familyTree.CreateAncestor( "Marc", "Dupont", new DateTime( 2000, 5, 20 ), false );

            Assert.Throws<InvalidOperationException>( () => { DateTime deathDate = sut.DeathDate; } );
        }
    }
}
