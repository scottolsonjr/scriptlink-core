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
            return optionObject;
        }
    }
}
