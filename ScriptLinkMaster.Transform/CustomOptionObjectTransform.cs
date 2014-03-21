using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class CustomOptionObjectTransform
    {
        public OptionObject TransformToOptionObject(CustomOptionObject customOptionObject)
        {
            var optionObject = new OptionObject();
            optionObject.EntityID = customOptionObject.EntityID;
            optionObject.EpisodeNumber = customOptionObject.EpisodeNumber;
            optionObject.ErrorCode = (double)customOptionObject.ErrorCode;
            optionObject.ErrorMesg = customOptionObject.ErrorMesg;
            optionObject.Facility = customOptionObject.Facility;
            optionObject.OptionId = customOptionObject.OptionId;
            optionObject.OptionStaffId = customOptionObject.OptionStaffId;
            optionObject.OptionUserId = customOptionObject.OptionUserId;
            optionObject.SystemCode = customOptionObject.SystemCode;
            optionObject.Forms = customOptionObject.Forms.Any() ? TransformCustomForms(customOptionObject.Forms) : new List<FormObject>();
            return optionObject;
        }

        protected virtual List<FormObject> TransformCustomForms(List<CustomFormObject> list)
        {
            var forms = new List<FormObject>();
            foreach (var customForm in list)
            {
                forms.Add(TransformCustomForm(customForm));
            }
            return forms;
        }

        protected virtual FormObject TransformCustomForm(CustomFormObject customForm)
        {
            return new CustomFormObjectTransform().TransformToFormObject(customForm);
        }
    }
}
