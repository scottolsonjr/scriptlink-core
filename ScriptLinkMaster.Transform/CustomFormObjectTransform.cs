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
            formObject.CurrentRow = customFormObject.CurrentRow == null ? null : TransformCustomRow(customFormObject.CurrentRow);
            formObject.OtherRows = customFormObject.OtherRows.Any() ? TransformCustomRows(customFormObject.OtherRows) : new List<RowObject>();
            return formObject;
        }
        protected virtual List<RowObject> TransformCustomRows(List<CustomRowObject> list)
        {
            var rows = new List<RowObject>();
            foreach (var customRow in list)
            {
                rows.Add(TransformCustomRow(customRow));
            }
            return rows;
        }

        protected virtual RowObject TransformCustomRow(CustomRowObject customRow)
        {
            return new CustomRowObjectTransform().TransformToRowObject(customRow);
        }
    }
}
