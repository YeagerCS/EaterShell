using EaterShell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShellTest
{
    [TestClass]
    public class RenTest
    {
        [TestMethod]
        public void FileNameIsblud_InputEqualsBlusAsRelativePath_SetFileNameBlus()
        {
            // Arrange
            ShellWorkspace shellWorkspace = new ShellWorkspace();
            string inputPath = "eater\\blud";
            string newName = "blus";
            RenCommand renCommand = new RenCommand();
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());

            // Act
            renCommand.Parameters = new string[] { inputPath, newName };

            renCommand.Execute();
            FileSystemItem file = pathHandler.SearchFileSystemItem("eater\\blus");

            // Assert
            Assert.AreEqual(newName, file.Name);

        }

        [TestMethod]
        public void FileNameIskebab_InputEqualsbekabAsAbsolutePath_SetFileNameBekab()
        {
            // Arrange
            ShellWorkspace shellWorkspace = new ShellWorkspace();
            string inputPath = "C:\\eater\\blud\\kebab";
            string newName = "Bekab";
            RenCommand renCommand = new RenCommand();
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());

            // Act
            renCommand.Parameters = new string[] { inputPath, newName };
            renCommand.Execute();
            FileSystemItem file = pathHandler.SearchFileSystemItem("C:\\eater\\blud\\Bekab");

            // Assert
            Assert.AreEqual(newName, file.Name);
        }
    }
}
