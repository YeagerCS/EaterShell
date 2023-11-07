﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    internal class DirCommand : Command
    {

        public override string Name => "dir";

        public DirCommand() { }

        public string FormatNumber(long number)
        {
            return number.ToString("#,##0");
        }

        public override void Execute()
        {
            Random random = new Random();
            TheDirectory directory = PathDirectoryHandler.GetTheDirectory();
            List<FileSystemItem> files = directory.FileSystemItems;

            int fileCount = 0;
            int dirCount = 0;
            long totalFileSize = 0;
            long totalDirSize = 0;

            foreach (FileSystemItem file in files)
            {
                DateTime lastMod = file.CreatedOn;
                string fileSize = "";

                Console.Write($"{lastMod:dd/MM/yyyy}\t");
                Console.Write($"{lastMod:HH:mm}\t");

                if (file is TheDirectory)
                {
                    Console.Write($"[Dir]\t");
                    totalDirSize += random.Next(10, 1024);
                    dirCount++;
                }
                else
                {
                    long n = random.Next(10, 1024);
                    Console.Write($"\t");
                    Console.Write($"{n}");
                    totalFileSize += n;
                    fileCount++;
                }
                Console.Write("\t");
                Console.WriteLine($"{file.Name}");

            }

            Console.WriteLine($"\n\t\t{fileCount} File(s)\t{FormatNumber(totalFileSize)} bytes");
            Console.WriteLine($"\t\t{dirCount} Dir(s)\t{FormatNumber(totalDirSize)} bytes");

        }
    }
}
