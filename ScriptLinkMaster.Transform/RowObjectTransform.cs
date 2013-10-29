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
        private static readonly string MULTIPLE_ITERATION_ROW_IDENTIFIER = "||";
        public CustomRowObject TransformToCustomRowObject(RowObject rowObject)
        {
            var CustomRowObject = new CustomRowObject();
            CustomRowObject.ParentRowId = rowObject.ParentRowId;
            CustomRowObject.RowAction = ConvertToRowAction(rowObject.RowAction);
            CustomRowObject.RowId = rowObject.RowId;
            CustomRowObject.RowType = GetRowType(rowObject);
            return CustomRowObject;
        }
        protected virtual RowType GetRowType(RowObject rowObject)
        {
            return IsMultipleIteration(rowObject) ? RowType.Other : RowType.Current;
        }
        protected virtual bool IsMultipleIteration(RowObject rowObject)
        {
            if (rowObject.ParentRowId.IndexOf(MULTIPLE_ITERATION_ROW_IDENTIFIER) > 0)
                return true;
            return false;
        }
        protected virtual RowAction ConvertToRowAction(string rowAction)
        {
            switch (rowAction)
            {
                case "ADD":
                    return RowAction.Add;
                case "DELETE":
                    return RowAction.Delete;
                case "EDIT":
                    return RowAction.Edit;
                case "":
                    return RowAction.None;
                default:
                    throw new ArgumentException("The Row Action is not valid.");
            }
        }
    }
}
