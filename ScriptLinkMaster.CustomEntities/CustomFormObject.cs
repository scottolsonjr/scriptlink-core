using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomFormObject
    {
        public string FormId { get; set; }

        public bool MultipleIteration
        {
            get
            {
                return IsMultipleIteration();
            }
        }

        public List<CustomRowObject> Rows { get; set; }
        public CustomRowObject CurrentRow
        {
            get
            {
                return GetCurrentRow();
            }
        }
        public List<CustomRowObject> OtherRows
        {
            get
            {
                return GetOtherRows();
            }
        }
        protected virtual bool IsMultipleIteration()
        {
            return this.Rows.Any(r => r.RowType == RowType.Other);
        }
        protected virtual CustomRowObject GetCurrentRow()
        {
            return this.Rows.FirstOrDefault(r => r.RowType == RowType.Current);
        }
        protected virtual List<CustomRowObject> GetOtherRows()
        {
            return this.Rows.TakeWhile(r => r.RowType == RowType.Other).ToList();
        }
        public void RemoveEmptyRows()
        {
            Rows.RemoveAll(r => !r.Fields.Any());
        }
        public CustomFormObject()
        {
            this.Rows = new List<CustomRowObject>();
        }
    }
}
