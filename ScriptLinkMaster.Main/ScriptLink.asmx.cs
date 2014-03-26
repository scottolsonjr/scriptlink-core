using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Main
{
    /// <summary>
    /// Summary description for ScriptLink
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ScriptLink : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetVersion()
        {
            return "Version 1.0";
        }

        [WebMethod]
        public OptionObject RunScript(OptionObject OptionObject, string ScriptName)
        {
            var script = FactoryScriptName.GetScriptName(ScriptName);
            script.PerformAction();
            return OptionObject;
        }
    }
}
