using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class TheDirectory : FileSystemItem
    {
        

        public List<FileSystemItem> FileSystemItems { get; set; }

        public TheDirectory(List<FileSystemItem> fileSystemItems, string name, DateTime createdOn, TheDirectory dir) 
        {
            FileSystemItems = fileSystemItems;
            Name = name;
            CreatedOn = createdOn;
            ParentDirectory= dir;
        }

        public void AddItem(FileSystemItem item)
        {
            item.ParentDirectory = this;
            FileSystemItems.Add(item);
        }
        public TheDirectory Clone()
        {
            return (TheDirectory)this.MemberwiseClone();
        }

        public TheDirectory() { }

        public TheDirectory(string name, DateTime createdOn)
        {
            FileSystemItems = new List<FileSystemItem>();
            Name = name;
            CreatedOn = createdOn;
        }

        public TheDirectory(string name, DateTime createdOn, TheDirectory parentDir)
        {
            FileSystemItems = new List<FileSystemItem>();
            Name = name;
            CreatedOn = createdOn;
            ParentDirectory = parentDir;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
