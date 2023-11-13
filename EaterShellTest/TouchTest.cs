using EaterShell.Commands;
using EaterShell.FileSystem;
using EaterShell.Main;
using EaterShell.PathHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShellTest
{
    [TestClass]
    public class TouchTest
    {
        [TestMethod]
        public void FileeateatDoesNotExist_InputEqualseateat_CreateFileeateat()
        {
            // Arrange
            ShellWorkspace shellWorkspace = new ShellWorkspace();
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            TouchCommand touchCommand = new TouchCommand();
            string newFile = "eat.eat";

            // Act
            touchCommand.Parameters = new string[] { newFile, "" };
            touchCommand.Execute();

            // Assert
            FileSystemItem file = pathHandler.SearchFileSystemItem(PathDirectoryHandler.GetCurrentDirectory + "\\" + newFile);
            Assert.IsNotNull(file);
        }
    }
}
