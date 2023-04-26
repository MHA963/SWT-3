using Microwave.Classes.Boundary;
using NUnit.Framework;
using System;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class ButtonTest
    {
        private Button uut;

        [SetUp]
        public void Setup()
        {
            uut = new Button();
        }
        [Test]
        public void Print_beep() // this test confirms that program works after .Press()
        {
            uut.Press();
            Console.Write("beep");
        }

        [Test]
        public void Press_NoSubscribers_NoThrow() // error caused by sound added to Button.cs
        {
            // We don't need an assert, as an exception would fail the test case
            uut.Press();
        }

        [Test]
        public void Press_1subscriber_IsNotified() // error caused by sound added to Button.cs
        {
            bool notified = false;

            uut.Pressed += (sender, args) => notified = true;
            uut.Press();
            Assert.That(notified, Is.EqualTo(true));
        }

    }
}