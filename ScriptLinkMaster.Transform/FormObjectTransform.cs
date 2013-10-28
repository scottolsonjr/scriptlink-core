using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class FormObjectTransform
    {
        public CustomFormObject TransformToCustomFormObject(FormObject formObject)
        {
            var CustomFormObject = new CustomFormObject();
            CustomFormObject.FormId = formObject.FormId;
            CustomFormObject.Rows = new List<CustomRowObject>();
            if (formObject.MultipleIteration)
                CustomFormObject.Rows.Add(new CustomRowObject { RowType = RowType.Other });
            if (formObject.CurrentRow != null)
                CustomFormObject.Rows.Add(new CustomRowObject { RowType = RowType.Current });
            return CustomFormObject;
        }
    }
}
