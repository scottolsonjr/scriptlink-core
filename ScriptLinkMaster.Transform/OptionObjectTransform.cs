using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class OptionObjectTransform
    {
        public CustomOptionObject TransformToCustomOptionObject(OptionObject optionObject)
        {
            var CustomOptionObject = new CustomOptionObject();
            CustomOptionObject.EntityID = optionObject.EntityID;
            CustomOptionObject.EpisodeNumber = optionObject.EpisodeNumber;
            CustomOptionObject.ErrorCode = ConvertToEnum(optionObject.ErrorCode);
            CustomOptionObject.ErrorMesg = optionObject.ErrorMesg;
            CustomOptionObject.Facility = optionObject.Facility;
            CustomOptionObject.OptionId = optionObject.OptionId;
            CustomOptionObject.OptionStaffId = optionObject.OptionStaffId;
            CustomOptionObject.OptionUserId = optionObject.OptionUserId;
            CustomOptionObject.SystemCode = optionObject.SystemCode;
            CustomOptionObject.Forms = TransformForms(optionObject.Forms);
            return CustomOptionObject;
        }

        protected virtual List<CustomFormObject> TransformForms(List<FormObject> list)
        {
            var customForms = new List<CustomFormObject>();
            foreach (var form in list)
            {
                customForms.Add(TransformForm(form));
            }
            return customForms;
        }

        protected virtual CustomFormObject TransformForm(FormObject form)
        {
            return new FormObjectTransform().TransformToCustomFormObject(form);
        }
        protected virtual ErrorCode ConvertToEnum(double ErrorCode)
        {
            if (IsErrorCodeValid((int)ErrorCode))
                return (ErrorCode)ErrorCode;
            throw new ArgumentException("The Error Code is not valid.");
        }
        protected virtual bool IsErrorCodeValid(int ErrorCode)
        {
            return Enum.IsDefined(typeof(ErrorCode), (int)ErrorCode);
        }
    }
}
