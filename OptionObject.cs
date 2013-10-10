using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkCore.Objects
{
    // The OptionObject is defined by Netsmart Technologies, Inc. Do not modify.

    public class OptionObject
    {
        public string EntityID { get; set; }
        public double EpisodeNumber { get; set; }
        public double ErrorCode { get; set; }
        public string ErrorMesg { get; set; }
        public string Facility { get; set; }
        public List<FormObject> Forms { get; set; }
        public string OptionId { get; set; }
        public string OptionStaffId { get; set; }
        public string OptionUserId { get; set; }
        public string SystemCode { get; set; }

        public OptionObject()
        {
            this.Forms = new List<FormObject>();
        }
    }

    public class FormObject
    {
        public RowObject CurrentRow { get; set; }
        public string FormId { get; set; }
        public bool MultipleIteration { get; set; }
        public List<RowObject> OtherRows { get; set; }

        public FormObject()
        {
            this.OtherRows = new List<RowObject>();
        }
    }

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

    public class FieldObject
    {
        public string Enabled { get; set; }
        public string FieldNumber { get; set; }
        public string FieldValue { get; set; }
        public string Lock { get; set; }
        public string Required { get; set; }
    }

}
