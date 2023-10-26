using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    internal class DirCommand : Command
    {

        public override string Name => "dir";

        public DirCommand() { }

        public static string FormatNumber(long number)
        {
            return number.ToString("#,##0");
        }

        public override void Execute()
        {
            string directory = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFileSystemEntries(directory);

            int fileCount = 0;
            int dirCount = 0;
            long totalFileSize = 0;
            DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(directory));

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                FileAttributes attributes = File.GetAttributes(file); 
                if ((attributes & FileAttributes.Hidden) == 0 && (attributes & FileAttributes.System) == 0)
                {
                    DateTime lastMod = fileInfo.LastWriteTime;
                    string fileSize = "";

                    Console.Write($"{lastMod:dd/MM/yyyy}\t");
                    Console.Write($"{lastMod:HH:mm}\t");

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        Console.Write($"[Dir]\t");
                        dirCount++;
                    } else
                    {
                        long fileSizeKb = fileInfo.Length;
                        totalFileSize += fileSizeKb;
                        fileSize = FormatNumber(fileSizeKb);
                        Console.Write($"\t");
                        Console.Write($"{fileSize}");
                        fileCount++;
                    }
                    Console.Write("\t");
                    Console.WriteLine($"{Path.GetFileName(file)}");

                }
            }

            Console.WriteLine($"\n\t\t{fileCount} File(s)\t{FormatNumber(totalFileSize)} bytes");
            Console.WriteLine($"\t\t{dirCount} Dir(s)\t{FormatNumber(driveInfo.TotalFreeSpace)} bytes free");

        }
    }
}
