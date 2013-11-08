using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomRowObject : IEquatable<CustomRowObject>
    {
        public List<CustomFieldObject> Fields { get; set; }
        public string ParentRowId { get; set; }
        public RowAction RowAction { get; set; }
        public string RowId { get; set; }
        public RowType RowType { get; set; }
        public CustomRowObject()
        {
            this.Fields = new List<CustomFieldObject>();
        }
        public void RemoveUnchangedFields()
        {
            Fields.RemoveAll(f => f.FieldState == FieldState.Unchanged);
        }

        public bool Equals(CustomRowObject other)
        {
            if (other == null)
                return false;
            return this.ParentRowId == other.ParentRowId &&
                this.RowAction == other.RowAction &&
                this.RowId == other.RowId &&
                this.RowType == other.RowType &&
                this.Fields == this.Fields;

        }
        public override bool Equals(object obj)
        {
            CustomRowObject customRowObject = obj as CustomRowObject;
            if (customRowObject == null)
                return false;
            return this.Equals(customRowObject);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + ParentRowId.GetHashCode();
            hash = hash * 23 + RowAction.GetHashCode();
            hash = hash * 23 + RowId.GetHashCode();
            hash = hash * 23 + RowType.GetHashCode();
            hash = hash * 23 + Fields.GetHashCode();
            return hash;
        }
    }
    public enum RowType
    {
        Current = 0,
        Other = 1
    }
}
