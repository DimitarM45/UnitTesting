using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;

        private Axe brokenAxe;

        private Dummy dummy;

        [SetUp]

        public void Setup()
        {
            axe = new Axe(10, 10);

            brokenAxe = new Axe(10, 0);

            dummy = new Dummy(10, 10);
        }

        [Test]
        public void Test_AxeShouldLoseDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability should decrease after an attack.");
        }

        [Test]
        public void Test_AttackingWithABrokenAxeShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                brokenAxe.Attack(dummy);
            }, "Attacking with a broken axe should throw an exception.");
        }
    }
}