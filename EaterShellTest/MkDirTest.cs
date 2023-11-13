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
    public class MkDirTest
    {
        [TestMethod]
        public void DireatDoesNotExist_InputEqualseat_CreateDirectoryeat()
        {
            // Arrange
            ShellWorkspace shellWorkspace = new ShellWorkspace();
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            MkdirCommand mkdirCommand = new MkdirCommand();
            string newDir = "eat";

            // Act
            mkdirCommand.Parameters = new string[] { newDir };
            mkdirCommand.Execute();

            // Assert
            FileSystemItem file = pathHandler.SearchFileSystemItem(PathDirectoryHandler.GetCurrentDirectory + "\\eat");
            Assert.IsNotNull(file);
        }
    }
}
