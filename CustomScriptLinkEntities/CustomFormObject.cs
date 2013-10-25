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
            get { return (this.OtherRows.Count() > 1); }
        }

        public List<CustomRowObject> OtherRows { get; set; }

        public CustomFormObject()
        {
            this.OtherRows = new List<CustomRowObject>();
        }
    }
}
