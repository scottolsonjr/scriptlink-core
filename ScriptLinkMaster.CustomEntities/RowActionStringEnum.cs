using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptLinkMaster.CustomEntities
{
    public sealed class RowAction
    {
        public static readonly RowAction None = new RowAction("");
        public static readonly RowAction Add = new RowAction("ADD");
        public static readonly RowAction Edit = new RowAction("EDIT");
        public static readonly RowAction Delete = new RowAction("DELETE");

        private RowAction(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
    }
}
