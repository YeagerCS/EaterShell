using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
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
                TheDirectory rootDir = new("\\", DateTime.Now);

                eater.AddItem(sneak);
                blud.AddItem(kebab);
                eater.AddItem(blud);

                rootDir.AddItem(eater);



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
