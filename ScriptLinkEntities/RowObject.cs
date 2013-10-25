using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.Entities
{
    public class RowObject
    {
        public List<FieldObject> Fields { get; set; }
        public string ParentRowId { get; set; }
        public string RowAction { get; set; }
        public string RowId { get; set; }
        public RowObject()
        {
            this.Fields = new List<FieldObject>();
        }
    }
}