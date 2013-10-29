using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Transform
{
    public class FieldObjectTransform
    {
        public CustomFieldObject TransformToCustomFieldObject(FieldObject fieldObject)
        {
            var customFieldObject = new CustomFieldObject();
            customFieldObject.FieldNumber = fieldObject.FieldNumber;
            customFieldObject.FieldValue = fieldObject.FieldValue;
            customFieldObject.EnabledStatus = ConvertToEnabledStatusEnum(fieldObject.Enabled);
            customFieldObject.LockedStatus = ConvertToLockedStatusEnum(fieldObject.Lock);
            customFieldObject.RequiredStatus = ConvertToRequiredStatusEnum(fieldObject.Required);
            return customFieldObject;
        }

        protected virtual RequiredStatus ConvertToRequiredStatusEnum(string p)
        {
            var EnumValue = GetNumericValue(p);
            if (IsRequiredStatusValid(EnumValue))
                return (RequiredStatus)EnumValue;
            throw new ArgumentException(GetInvalidEnumErrorMessage("RequiredStatus", p));
        }

        protected virtual bool IsRequiredStatusValid(int EnumValue)
        {
            return Enum.IsDefined(typeof(RequiredStatus), EnumValue);
        }

        protected virtual LockedStatus ConvertToLockedStatusEnum(string p)
        {
            var EnumValue = GetNumericValue(p);
            if (IsLockedStatusValid(EnumValue))
                return (LockedStatus)EnumValue;
            throw new ArgumentException(GetInvalidEnumErrorMessage("LockedStatus", p));
        }

        protected virtual bool IsLockedStatusValid(int EnumValue)
        {
            return Enum.IsDefined(typeof(LockedStatus), EnumValue);
        }

        protected virtual EnabledStatus ConvertToEnabledStatusEnum(string p)
        {
            var EnumValue = GetNumericValue(p);
            if (IsEnabledStatusValid(EnumValue))
                return (EnabledStatus)EnumValue;
            throw new ArgumentException(GetInvalidEnumErrorMessage("EnabledStatus", p));
        }
        protected virtual bool IsEnabledStatusValid(int EnumValue)
        {
            return Enum.IsDefined(typeof(EnabledStatus), EnumValue);
        }

        private string GetInvalidEnumErrorMessage(string myEnum, string value)
        {
            return String.Format("{0} is not a valid value for {1} enum type.", value, myEnum);
        }
        private int GetNumericValue(string p)
        {
            int number;
            bool result = Int32.TryParse(p, out number);
            if (result)
                return number;
            throw new ArgumentException(String.Format("Unabled to part {0} into an int. {0} is not a valid value.", p));
        }
    }
}
