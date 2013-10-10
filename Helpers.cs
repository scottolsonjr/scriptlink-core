using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptLinkCore.Objects;

namespace ScriptLinkCore
{
    public partial class ScriptLink
    {
        /// <summary>
        /// Used set required fields
        /// </summary>
        /// <param name="optionObject"></param>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public static OptionObject SetRequiredField(OptionObject optionObject, string fieldNumber)
        {
            OptionObject returnOptionObject = optionObject;
            Boolean updated = false;

            foreach (var form in returnOptionObject.Forms)
            {
                foreach (var currentField in form.CurrentRow.Fields)
                {
                    if (currentField.FieldNumber == fieldNumber)
                    {
                        currentField.Required = "1";
                        updated = true;
                    }
                }
            }

            if (updated == true)
            {
                foreach (var form in returnOptionObject.Forms)
                {
                    form.CurrentRow.RowAction = "EDIT";
                }
                return returnOptionObject;
            }
            else
            {
                return optionObject;
            }
        }
    }
}
