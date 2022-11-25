using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTest
{
    [TestClass]
    public class TestReport
    {
        [TestMethod]
        public void ReportLocation()
        {
            Robot Toy = new Robot
            {
                direction = "north",
                x = 5,
                y = 4
            };

            string expected = "REPORT: 5,4,NORTH";

            string position = Toy.Report();
            
            Assert.AreEqual(expected, position);
        }
    }
}
