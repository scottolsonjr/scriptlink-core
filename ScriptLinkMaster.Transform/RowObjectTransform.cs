using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class RowObjectTransform
    {
        public CustomRowObject TransformToCustomRowObject(RowObject rowObject)
        {
            var CustomRowObject = new CustomRowObject();
            CustomRowObject.ParentRowId = rowObject.ParentRowId;
            CustomRowObject.RowAction = rowObject.RowAction;
            CustomRowObject.RowId = rowObject.RowId;
            return CustomRowObject;
        }
    }
}
