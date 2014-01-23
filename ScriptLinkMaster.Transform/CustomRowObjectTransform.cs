using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class CustomRowObjectTransform
    {
        public RowObject TransformToRowObject(CustomRowObject customRowObject)
        {
            var rowObject = new RowObject();
            rowObject.ParentRowId = customRowObject.ParentRowId;
            rowObject.RowId = customRowObject.RowId;
            rowObject.RowAction = customRowObject.RowAction == null ? null : customRowObject.RowAction.Value;
            rowObject.Fields = TransformCustomFields(customRowObject.Fields);
            return rowObject;
        }

        protected virtual List<FieldObject> TransformCustomFields(List<CustomFieldObject> list)
        {
            var fields = new List<FieldObject>();
            foreach (var customField in list)
            {
                fields.Add(TransformCustomField(customField));
            }
            return fields;
        }

        protected virtual FieldObject TransformCustomField(CustomFieldObject customField)
        {
            return new CustomFieldObjectTransform().TransformToFieldObject(customField);
        }
    }
}
