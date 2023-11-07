using EaterShell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShellTest
{
    [TestClass]
    public class DelTest
    {
        [TestMethod]
        public void FilenameIsEsseExe_InputEqualsEsseExeAsRelativePath_DeleteEsseExe()
        {
            ShellWorkspace shellWorkspace = new ShellWorkspace();
            string inputPath = "Esse.exe";
            DelCommand delCommand = new DelCommand();
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            TheFile theFile1 = pathHandler.SearchFileSystemItem(inputPath) as TheFile;
            if(theFile1 == null)
            {
                Assert.Fail();
            }


            delCommand.Parameters = new string[] {inputPath};
            delCommand.Execute();
            TheFile theFile = pathHandler.SearchFileSystemItem(inputPath) as TheFile;

            Assert.IsNull(theFile);
        }

        [TestMethod]
        public void FilenameIsEatTxt_InputEqualsEatTxtAsAbsolutePath_DeleteEatTxt()
        {
            ShellWorkspace shellWorkspace = new ShellWorkspace();
            string inputPath = "C:\\eater\\eat.txt";
            DelCommand delCommand = new DelCommand();
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            TheFile theFile1 = pathHandler.SearchFileSystemItem(inputPath) as TheFile;

            //If the file doesn't exist to begin with, the test Fails
            if (theFile1 == null)
            {
                Assert.Fail();
            }


            delCommand.Parameters = new string[] { inputPath };
            delCommand.Execute();
            //After deletion the file is searched again
            TheFile theFile = pathHandler.SearchFileSystemItem(inputPath) as TheFile;

            Assert.IsNull(theFile);
        }
    }
}
