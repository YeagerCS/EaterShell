//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Security.AccessControl;
//using System.Text;
//using System.Threading.Tasks;

//namespace EaterShell.Commands
//{
//    public class EatCommand : Command
//    {
//        public override string Name => "eat";

//        public override void Execute()
//        {
//            StartDeletionProcess();
//        }

//        public void StartDeletionProcess()
//        {
//            string file = "Deleter.exe";

//            ProcessStartInfo psi = new ProcessStartInfo()
//            {
//                FileName = file,
//                CreateNoWindow = true,
//                UseShellExecute = false
//            };

//            Process.Start(psi);

//            Environment.Exit(0);

//        }

//    }
//}
