using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTest
{
    [TestClass]
    public class TestSimulator
    {
        [TestMethod]
        public void PlaceRobotOntoValidLocation()
        {
            TableDimension tableTop = new TableDimension(4, 4);
            Simulator instance = new Simulator(tableTop);
            instance.Place(0, 0, "NORTH");

            Robot expectedToy = new Robot
            {
                direction = "north",
                x = 0,
                y = 0
            };

            Assert.AreEqual(expectedToy.x, instance.robot.x);
            Assert.AreEqual(expectedToy.y, instance.robot.y);
            Assert.AreEqual(expectedToy.direction, instance.robot.direction);
        }

        [TestMethod]
        public void PlaceRobotOntoInvalidLocation()
        {
            TableDimension tableTop = new TableDimension(4, 4);
            Simulator instance = new Simulator(tableTop);
            instance.Place(5, 5, "NORTH");
            
            Assert.IsNull(instance.robot);
        }
    }
}
