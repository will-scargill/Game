using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;

namespace Game.Phases.subPhases
{
    class subPhaseLoadUnload
    {
        public static void Parse(string command)
        {
            Console.Clear();
            if (GM.loadUnload == "load")
                MM.LoadModule(command);
            else if (GM.loadUnload == "unload")
                MM.UnloadModule(command);
            GM.subPhase = "Modules";
        }
    }
}
