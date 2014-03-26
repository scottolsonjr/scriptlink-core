using ScriptLinkMaster.Entities;
using ScriptLinkMaster.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScriptLinkMaster.Main
{
    public class TestClass : BaseScriptLink, IScriptName
    {
        public TestClass(): base(new OptionObject())
        {
        }

        public void PerformAction()
        {
            throw new NotImplementedException();
        }
    }
}