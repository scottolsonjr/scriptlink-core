using ScriptLinkMaster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptLinkMaster.Scripts
{
    public abstract class BaseScriptLink
    {
        protected OptionObject OptionObject;
        public BaseScriptLink(OptionObject optionObject)
        {
            this.OptionObject = optionObject;
        }
    }
}
