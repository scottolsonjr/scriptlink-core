using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomFieldObject
    {
        public string FieldNumber { get; set; }
        public string FieldValue { get; set; }
        public LockedStatus LockedStatus { get; set; }
        public RequiredStatus RequiredStatus { get; set; }
        public EnabledStatus EnabledStatus { get; set; }
        public FieldState FieldState { get; set; }
        public CustomFieldObject()
        {
            FieldState = FieldState.Unchanged;
            LockedStatus = LockedStatus.Unlocked;
            RequiredStatus = RequiredStatus.Unrequired;
            EnabledStatus = EnabledStatus.Enabled;
        }
    }
    public enum LockedStatus
    {
        Unlocked = 0,
        Locked = 1
    }
    public enum RequiredStatus
    {
        Unrequired = 0,
        Required = 1
    }
    public enum EnabledStatus
    {
        Disabled = 0,
        Enabled = 1
    }
    public enum FieldState
    {
        Unchanged = 0,
        Modified = 1
    }
}
