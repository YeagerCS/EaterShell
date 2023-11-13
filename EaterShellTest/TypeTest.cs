using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EaterShell.PathHandling;
using EaterShell.FileSystem;
using EaterShell.Commands;
using EaterShell.OutputWriters;
using EaterShell.FileSystem.Persistence;
using EaterShell.Main;

namespace EaterShellTest
{
    [TestClass]
    public class TypeCommandTest    
    {
        [TestMethod]
        public void TypeCommand_AddsFileToDirectory()
        {
            // Arrange
            TestOutputWriter output = new TestOutputWriter();
            TypeCommand typeCommand = new TypeCommand(output);
            ShellWorkspace shellWorkspace= new ShellWorkspace();

            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            string fileName = @"c:\eater\blud\TestText.txt";
            string fileContent = "This is the Content of the File";
            pathHandler.SearchFileSystemItem(fileName);

            TheDirectory selectedDir = PathDirectoryHandler.GetTempDirectory();

            TheFile file = new();
            string[] parts = fileName.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            string filename = parts[parts.Length - 1];
            file.Name = filename;
            file.Content = fileContent;

            selectedDir.AddItem(file);

            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());

            // Assuming you have a suitable directory and drive setup, specify the path.
            string filePath = @"C:\eater\blud\TestText.txt";
            

            // Act
            
             
            typeCommand.Parameters = new string[] { filePath };
            typeCommand.Execute();


            // Assert
            
            Assert.AreEqual(fileContent, output.OutputBuffer);
        }
    }
}
