using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTest
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void ProcessPlaceCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5,5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 2,3,EAST");

            Assert.IsNotNull(testSetup.Simulation.robot);
        }

        [TestMethod]
        public void ProcessInvalidPlaceCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 6,3,EAST");

            string expected = "Place Location is outside the specific dimension or area.";
            Assert.AreSame(expected, testSetup.Simulation.CommandStatus);
        }

        [TestMethod]
        public void ProcessInvalidPlaceDirectionCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 4,4,EASTERN");

            string expected = "Place Direction is not valid direction: \n Valid directions are north, east, south and west.";
            Assert.AreSame(expected, testSetup.Simulation.CommandStatus);
        }

        [TestMethod]
        public void ProcessMoveCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 2,3,EAST");
            testSetup.ProcessCommand("MOVE");

            Robot expected = new Robot {x = 3, y = 3, direction = "east"};

            Assert.AreEqual(expected.x, testSetup.Simulation.robot.x);
        }

        [TestMethod]
        public void ProcessMoveWallCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 4,4,EAST");
            testSetup.ProcessCommand("MOVE");

            Robot expected = new Robot { x = 4, y = 4, direction = "east" };

            Assert.AreEqual(expected.x, testSetup.Simulation.robot.x);
        }

        [TestMethod]
        public void ProcessRightCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 2,3,EAST");
            testSetup.ProcessCommand("RIGHT");

            Robot expected = new Robot { x = 2, y = 3, direction = "south" };

            Assert.AreEqual(expected.direction, testSetup.Simulation.robot.direction);
        }

        [TestMethod]
        public void ProcessLeftCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 2,3,EAST");
            testSetup.ProcessCommand("LEFT");

            Robot expected = new Robot { x = 2, y = 3, direction = "north" };

            Assert.AreEqual(expected.direction, testSetup.Simulation.robot.direction);
        }

        [TestMethod]
        public void ProcessReportCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("PLACE 2,3,EAST");
            testSetup.ProcessCommand("REPORT");

            string expected = "REPORT: 2,3,EAST";

            Assert.AreEqual(expected, testSetup.Message);
        }

        [TestMethod]
        public void ProcessInvalidCommand()
        {
            Command testSetup = new Command();
            TableDimension table = new TableDimension(5, 5);
            testSetup.Simulation = new Simulator(table);
            testSetup.ProcessCommand("GIBBERISH");

            string expected = testSetup.ErrorInputs;

            Assert.AreEqual(expected, testSetup.Message);
        }
    }
}
