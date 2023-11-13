using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EaterShell.FileSystem;

namespace EaterShell.PathHandling
{
    public class PathDirectoryHandler
    {
        private static string currentDirectory;
        private static TheDirectory _currentDirectory;
        private static Drive selectedDrive;
        private static TheDirectory tempDirectory;


        public static TheDirectory GetTempDirectory()
        {
            return tempDirectory;
        }

        public static void SetTempDirectory(TheDirectory directory)
        {
            tempDirectory = directory;
        }

        public static void SelectDrive(Drive drive)
        {
            selectedDrive = drive;
            _currentDirectory = drive.RootDirectory;
        }

        public static Drive GetSelectedDrive()
        {
            return selectedDrive;
        }

        public static void SetTheDirectory(TheDirectory dir)
        {
            _currentDirectory = dir;
        }

        public static TheDirectory GetTheDirectory()
        {
            return _currentDirectory;
        }

        public static void SetCurrentDirectory(string path)
        {
            currentDirectory = path;
        }

        public static string GetCurrentDirectory()
        {
            return currentDirectory;
        }

        public static string GetFullPath(string basePath, string relativePath)
        {
            if (Path.IsPathRooted(relativePath))
            {
                return relativePath;
            }

            string fullPath = Path.Combine(basePath, relativePath);

            fullPath = Path.GetFullPath(fullPath);

            return fullPath;
        }


    }
}
