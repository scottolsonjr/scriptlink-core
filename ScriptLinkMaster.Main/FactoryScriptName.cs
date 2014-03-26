using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScriptLinkMaster.Main
{
    public class FactoryScriptName
    {
        public static IScriptName GetScriptName(string ScriptName)
        {
            IScriptName tempScriptName = null;
            switch (ScriptName)
            {
                case "Required":
                    tempScriptName = new RequiredClass();
                    break;
                case "Enabled":
                    tempScriptName = new EnabledClass();
                    break;
                default:
                    break;
            }
            return tempScriptName;
        }
    }
}