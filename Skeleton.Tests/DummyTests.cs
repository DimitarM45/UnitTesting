using NUnit.Framework;
using System;
using System.Reflection;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        private Dummy deadDummy;

        private Axe axe;

        [SetUp]

        public void Setup()
        {
            dummy = new Dummy(1, 1);

            deadDummy = new Dummy(0, 1);

            axe = new Axe(1, 1);
        }

        [Test]
        public void Test_DummyShouldLoseHealthWhenAttacked()
        {
            axe.Attack(dummy);

            Assert.AreEqual(0, dummy.Health, "Dummy should lose health when attacked.");
        }

        [Test]
        public void Test_DeadDummyShouldThrowAnExceptionWhenAttacked()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(deadDummy);
            }, "Dead dummy should throw an exception when attacked.");
        }

        [Test]
        public void Test_DeadDummyShouldGiveXP()
        {
            Assert.AreEqual(1, deadDummy.GiveExperience(), "Dead dummy shouldn't be able to give XP.");
        }

        [Test]
        public void Test_AliveDummyShouldNotGiveXP()
        {
            Assert.Throws<InvalidOperationException>( () =>
            {
                dummy.GiveExperience();

            }, "Living dummy should not give XP.");
        }
    }
}