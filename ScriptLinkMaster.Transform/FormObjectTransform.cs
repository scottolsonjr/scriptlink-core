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
            var tempRows = MergeRows(formObject.CurrentRow, formObject.OtherRows);
            CustomFormObject.Rows = TransformRows(tempRows);
            return CustomFormObject;
        }

        protected virtual List<CustomRowObject> TransformRows(List<RowObject> tempRows)
        {
            var customRows = new List<CustomRowObject>();
            foreach (var row in tempRows)
            {
                customRows.Add(TransformRow(row));
            }
            return customRows;
        }

        protected virtual CustomRowObject TransformRow(RowObject row)
        {
            return new RowObjectTransform().TransformToCustomRowObject(row);
        }

        protected virtual List<RowObject> MergeRows(RowObject rowObject, List<RowObject> list)
        {
            var newRows = new List<RowObject>();
            if (rowObject == null)
                return newRows;
            newRows.Add(rowObject);
            newRows.AddRange(list);
            return newRows;
        }
    }
}
