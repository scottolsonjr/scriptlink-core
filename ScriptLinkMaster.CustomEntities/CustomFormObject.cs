using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomFormObject : IEquatable<CustomFormObject>
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

        public bool Equals(CustomFormObject other)
        {
            if (other == null)
                return false;
            return this.FormId == other.FormId &&
                this.MultipleIteration == other.MultipleIteration &&
                this.CurrentRow.Equals(other.CurrentRow) &&
                AreRowsEqual(this.OtherRows, other.OtherRows);
        }
        private bool AreRowsEqual(List<CustomRowObject> list1, List<CustomRowObject> list2)
        {
            if (!AreBothNull(list1, list2) && AreBothEmpty(list1, list2))
                return true;
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreBothEmpty(List<CustomRowObject> list1, List<CustomRowObject> list2)
        {
            return (!list1.Any() && !list2.Any());
        }

        private bool AreBothNull(List<CustomRowObject> list1, List<CustomRowObject> list2)
        {
            return (list1 == null && list2 == null);
        }
        public override bool Equals(object obj)
        {
            CustomFormObject customFormObject = obj as CustomFormObject;
            if (customFormObject == null)
                return false;
            return this.Equals(customFormObject);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + FormId.GetHashCode();
            hash = hash * 23 + MultipleIteration.GetHashCode();
            hash = hash * 23 + CurrentRow.GetHashCode();
            foreach (var otherRow in this.OtherRows)
            {
                hash = hash * 23 + otherRow.GetHashCode();
            }
            return hash;
        }
    }
}
