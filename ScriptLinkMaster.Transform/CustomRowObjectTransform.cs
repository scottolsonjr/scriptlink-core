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
            rowObject.RowAction = customRowObject.RowAction.Value;
            return rowObject;
        }
    }
}
