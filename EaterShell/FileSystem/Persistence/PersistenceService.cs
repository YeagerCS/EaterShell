using EaterShell.Commands;
using EaterShell.FileSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.FileSystem.Persistence
{
    public class PersistenceService
    {
        private const string FILEPATH = "EaterFS.json";


        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects //Adds Id's to the directories, so parent directories can be assigned by reference in the json
        };
        public static Drive Load()
        {
            if (File.Exists(FILEPATH))
            {
                string json = File.ReadAllText(FILEPATH);
                return JsonConvert.DeserializeObject<Drive>(json, serializerSettings);
            }
            else
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                DriveInfo winDrive = drives[0];
                //Encrypted Associative Technological Entity Retrieval File System
                TheDirectory sneak = new TheDirectory("sneak", DateTime.Now);
                TheDirectory blud = new TheDirectory("blud", DateTime.Now);
                TheDirectory kebab = new TheDirectory("kebab", DateTime.Now);
                TheDirectory eater = new TheDirectory("eater", DateTime.Now);
                TheFile esseExe = new TheFile("Esse.exe", "FRRRR????");
                esseExe.CreatedOn = DateTime.Now;
                esseExe.Size = new TouchCommand().GetFileSize(esseExe);
                TheDirectory rootDir = new("\\", DateTime.Now);
                rootDir.Size += esseExe.Size;

                eater.AddItem(sneak);
                blud.AddItem(kebab);
                eater.AddItem(blud);

                rootDir.AddItem(eater);
                rootDir.AddItem(esseExe);


                Drive drive = new Drive(rootDir, "C:", winDrive.VolumeLabel, "EATERFS", winDrive.DriveType.ToString());
                Save(drive);
                return drive;
            }

            return null;
        }




        public static void Save(Drive drive)
        {
            string json = JsonConvert.SerializeObject(drive, serializerSettings);
            File.WriteAllText(FILEPATH, json);
        }

    }

}
