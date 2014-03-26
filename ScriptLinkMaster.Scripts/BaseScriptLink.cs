using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;
using ScriptLinkMaster.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptLinkMaster.Scripts
{
    public abstract class BaseScriptLink
    {
        private OptionObject OptionObject;
        private OptionObjectTransform OptionObjectTransform;

        protected CustomOptionObject CustomOptionObject
        {
            get
            {
                return this.CustomOptionObject ?? this.OptionObjectTransform.TransformToCustomOptionObject(this.OptionObject);
            }
        }

        protected BaseScriptLink(OptionObject optionObject)
        {
            this.OptionObject = optionObject;
            this.OptionObjectTransform = new OptionObjectTransform();
        }

        protected void MakeFieldsRequired(List<FieldObject> fieldList)
        {
            MakeFieldsRequired(fieldList.Select(f => f.FieldNumber).ToList());
        }

        protected void MakeFieldsRequired(List<string> fieldNumberList)
        {
            this.CustomOptionObject.MakeFieldsRequired(fieldNumberList);
        }
    }
}
