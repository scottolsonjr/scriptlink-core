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
        public CustomOptionObject TransformToCustomObject(OptionObject optionObject)
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
            return CustomOptionObject;
        }
        private ErrorCode ConvertToEnum(double p)
        {
            if (Enum.IsDefined(typeof(ErrorCode), (int)p))
                return (ErrorCode)p;
            throw new ArgumentException("The error code is not valid");
        }
    }
}
