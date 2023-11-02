using EaterShell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShellTest
{
    [TestClass]
    public class ColorTest
    {
        [TestMethod]
        public void ColorIsWhite_InputEqualsRed_SetTextColorRed()
        {
            // Arrange
            TestOutputWriter output = new TestOutputWriter();
            ColorCommand colorCommand = new ColorCommand(output);
            CommandInvoker invoker = new CommandInvoker();

            // Act
            colorCommand.Parameters = new string[] { "Red" };
            colorCommand.Execute();

            // Assert       
            Assert.AreEqual(ConsoleColor.Red, output.ForegroundColor);
        }

        [TestMethod]
        public void BackroundColorIsBlack_InputEqualsGreen_SetBackroundColorGreen()
        {
            // Arrange
            TestOutputWriter output = new TestOutputWriter();
            ColorCommand colorCommand = new ColorCommand(output);
            CommandInvoker invoker = new CommandInvoker();

            // Act
            colorCommand.Parameters = new string[] {".", "Green" };
            colorCommand.Execute();

            // Assert       
            Assert.AreEqual(ConsoleColor.Green, output.BackgroundColor);
        }
    }
}
