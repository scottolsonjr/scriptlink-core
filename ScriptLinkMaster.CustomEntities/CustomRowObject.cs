using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomRowObject
    {
        public List<CustomFieldObject> Fields { get; set; }
        public string ParentRowId { get; set; }
        public RowAction RowAction { get; set; }
        public string RowId { get; set; }
        public CustomRowObject()
        {
            this.Fields = new List<CustomFieldObject>();
        }
    }
}
