using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class CustomFieldObjectTransform
    {
        public FieldObject TransformToFieldObject(CustomFieldObject customFieldObject)
        {
            var fieldObject = new FieldObject();
            fieldObject.FieldNumber = customFieldObject.FieldNumber;
            fieldObject.FieldValue = customFieldObject.FieldValue;
            fieldObject.Enabled = ((int)customFieldObject.EnabledStatus).ToString();
            fieldObject.Lock = ((int)customFieldObject.LockedStatus).ToString();
            fieldObject.Required = ((int)customFieldObject.RequiredStatus).ToString();
            return fieldObject;
        }
    }
}
