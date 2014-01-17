using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class CustomFormObjectTransform
    {
        public FormObject TransformToFormObject(CustomFormObject customFormObject)
        {
            var formObject = new FormObject();
            formObject.FormId = customFormObject.FormId;
            return formObject;
        }
    }
}
