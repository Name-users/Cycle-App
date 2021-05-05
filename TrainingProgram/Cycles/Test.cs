using System;
using System.Drawing;
using NUnit.Framework;


namespace TrainingProgram
{
    [TestFixture]
    public class Test
    {
        private ClosedLine four;
        private ClosedLine six;
        [SetUp]
        public void SetUp()
        {
            four = new ClosedLine(
                new[]
                {
                    new Point(0, 0),
                    new Point(10, 0),
                    new Point(10, 10),
                    new Point(0, 10)
                },
                Brushes.White,
                new Text()
            );
            six = new ClosedLine(
                new[]
                {
                    new Point(0, 5),
                    new Point(5, 0),
                    new Point(10, 0),
                    new Point(15, 5),
                    new Point(10, 10),
                    new Point(5, 10)
                },
                Brushes.White,
                new Text()
            );
        }
        
        [Test]
        public void TestFour()
        {
            
            Assert.AreEqual(new Point(5, 0), four.GetUp());
            Assert.AreEqual(new Point(5, 10), four.GetDown());
            Assert.AreEqual(new Point(0, 5), four.GetLeft());
            Assert.AreEqual(new Point(10, 5), four.GetRight());
        }
        
        [Test]
        public void TestSix()
        {
            Assert.AreEqual(new Point(7, 0), six.GetUp());
            Assert.AreEqual(new Point(7, 10), six.GetDown());
            Assert.AreEqual(new Point(0, 5), six.GetLeft());
            Assert.AreEqual(new Point(15, 5), six.GetRight());
        }

        [Test]
        public void TestConnectLines()
        {
            var test = new CycleWhile(1, 10);
            var r = test.СonnectLines(null, new []{four.GetUp(), four.GetDown()});
            Assert.IsTrue(r.Count > 0);
        }
    }
    
}