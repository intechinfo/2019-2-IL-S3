using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CollectionTests
{
    [TestFixture]
    public class SimpleTests
    {
        [Test]
        public void list_tests()
        {
            List<string> list = new List<string>();
            List<int> intList = new List<int>();
            List<DateTime> dateTimeList = new List<DateTime>();

            list.Add("Titi");
            list.Add("Toto");
            list.Add("Tata");

            intList.Add(5);
            intList.Add(2);

            Assert.That(list[0], Is.EqualTo("Titi"));
            Assert.That(list[1], Is.EqualTo("Toto"));
            Assert.That(list[2], Is.EqualTo("Tata"));

            Assert.That(intList[0], Is.EqualTo(5));
            Assert.That(intList[1], Is.EqualTo(2));

            list[1] = "Test";
            Assert.That(list[0], Is.EqualTo("Titi"));
            Assert.That(list[1], Is.EqualTo("Test"));
            Assert.That(list[2], Is.EqualTo("Tata"));

            Assert.That(list.Count, Is.EqualTo(3));
            list.Clear();
            Assert.That(list.Count, Is.EqualTo(0));

            list.Add("Titi");
            list.Add("Test");
            list.Add("Tata");

            list.Insert(1, "Toto");
            Assert.That(list.Count, Is.EqualTo(4));
            Assert.That(list[0], Is.EqualTo("Titi"));
            Assert.That(list[1], Is.EqualTo("Toto"));
            Assert.That(list[2], Is.EqualTo("Test"));
            Assert.That(list[3], Is.EqualTo("Tata"));

            list.RemoveAt(1);
            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list[0], Is.EqualTo("Titi"));
            Assert.That(list[1], Is.EqualTo("Test"));
            Assert.That(list[2], Is.EqualTo("Tata"));
        }

        [Test]
        public void dictionary_tests()
        {
            Dictionary<string, DateTime> birthDates = new Dictionary<string, DateTime>();
            birthDates.Add("Jean", new DateTime(1990, 6, 10));
            birthDates.Add("Sarah", new DateTime(1976, 4, 20));
            birthDates.Add("Albert", new DateTime(2005, 11, 28));

            Assert.That(birthDates.Count, Is.EqualTo(3));
            Assert.That(birthDates["Jean"], Is.EqualTo(new DateTime(1990, 6, 10)));
            Assert.That(birthDates["Sarah"], Is.EqualTo(new DateTime(1976, 4, 20)));
            Assert.That(birthDates["Albert"], Is.EqualTo(new DateTime(2005, 11, 28)));

            birthDates["Sarah"] = new DateTime(1976, 4, 21);
            Assert.That(birthDates.Count, Is.EqualTo(3));
            Assert.That(birthDates["Jean"], Is.EqualTo(new DateTime(1990, 6, 10)));
            Assert.That(birthDates["Sarah"], Is.EqualTo(new DateTime(1976, 4, 21)));
            Assert.That(birthDates["Albert"], Is.EqualTo(new DateTime(2005, 11, 28)));

            Assert.Throws<ArgumentException>(() => birthDates.Add("Albert", new DateTime(1985, 7, 2)));
            Assert.Throws<KeyNotFoundException>(() => { DateTime d = birthDates["Toto"]; });

            Assert.That(birthDates.ContainsKey("Test"), Is.False);

            DateTime date;
            bool found = birthDates.TryGetValue("Test", out date);
            Assert.That(found, Is.False);
            Assert.That(date, Is.EqualTo(DateTime.MinValue));

            found = birthDates.TryGetValue("Sarah", out date);
            Assert.That(found, Is.True);
            Assert.That(date, Is.EqualTo(new DateTime(1976, 4, 21)));

            birthDates["Toto"] = new DateTime(1964, 10, 1);
            Assert.That(birthDates.Count, Is.EqualTo(4));
            Assert.That(birthDates.ContainsKey("Toto"), Is.True);

            birthDates.Remove("Toto");
            Assert.That(birthDates.Count, Is.EqualTo(3));
            Assert.That(birthDates.ContainsKey("Toto"), Is.False);
            Assert.Throws<KeyNotFoundException>(() => { DateTime d = birthDates["Toto"]; });

            birthDates.Clear();
            Assert.That(birthDates.Count, Is.EqualTo(0));
        }

        [Test]
        public void enumerator()
        {
            List<int> integers = new List<int>();
            integers.Add(5);
            integers.Add(8);
            integers.Add(2);

            Dictionary<DateTime, int> birthDateCount = new Dictionary<DateTime, int>();
            birthDateCount[new DateTime(2019, 9, 30)] = 10;
            birthDateCount[new DateTime(2019, 10, 1)] = 3;

            string[] strings = new string[4];
            strings[0] = "test-0";
            strings[1] = "test-1";
            strings[2] = "test-2";
            strings[3] = "test-3";

            foreach(int value in integers)
            {
                Console.WriteLine(value);
            }

            foreach (string value in strings)
            {
                Console.WriteLine(value);
            }

            foreach(var value in birthDateCount)
            {
                Console.WriteLine(value);
            }

            foreach(var key in birthDateCount.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (var value in birthDateCount.Values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
